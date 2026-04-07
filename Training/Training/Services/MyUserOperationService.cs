using Entities.Enums;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Reflection.Metadata.Ecma335;

namespace Training.Services;

/// <summary>
/// Сервис, обеспечивает работу с данными посетителей сайта
/// </summary>
public class MyUserOperationService
{
    private ProtectedLocalStorage ProtectedBrowserStorage { get; set; }
    private IServiceProvider ServiceProvider { get; set; } = default!;

    private DbRepository Repository { get; set; }

    public MyUserOperationService(IServiceProvider serviceProvider, ProtectedLocalStorage protectedBrowserStorage, DbRepository repository)
    {
        ServiceProvider = serviceProvider;
        ProtectedBrowserStorage = protectedBrowserStorage;
        Repository = repository;
    }

    /// <summary>
    /// Логин и пароль по умолчанию
    /// </summary>
    private const string adminEmail = "admin";
    private const string adminPassword = "1234";

    /// <summary>
    /// Количество часов активности входа посетителя сайта
    /// </summary>
    public const int UserLoginActiveHours = 12;

    /// <summary>
    /// Название ключа, хранящегося у пользователя
    /// </summary>
    private const string userKeyName = "_userGUID";

    /// <summary>
	/// Посетитель нашего сайта
	/// </summary>
	public MyUser? MyUser
    {
        get => myUser;
        private set
        {
            myUser = value;
            NotifyUserChanged(MyUser);
        }
    }
    public MyUser? myUser;

    /// <summary>
    /// Пользователь изменился
    /// </summary>
    public event Action<MyUser?>? StateChanged;

    /// <summary>
    /// Это зарегистрированный пользователь
    /// </summary>
    public bool IsRegisteredUser => CheckIsRegisteredUser(MyUser);

    /// <summary>
    /// Провенрка что это зарегистрированный пользователь
    /// </summary>
    /// <param name="user"></param>
    /// <returns>true- пользовате зарегистрирован</returns>
    private bool CheckIsRegisteredUser(MyUser? user)
    {
        return user != null && !string.IsNullOrEmpty(user.Login) && !string.IsNullOrEmpty(user.Password);
    }

    /// <summary>
    /// Это администратор по умолчанию
    /// </summary>
    /// <returns></returns>
    public bool IAmDefaultAdmin(MyUser myUser)
    {
        if (myUser != null && myUser.Login == adminEmail && myUser.Password == adminPassword && myUser.Role == RoleEnum.admin)
            return true;
        return false;
    }

    /// <summary>
    /// Оповестить всех подписчиков на событие, что пользователь изменился
    /// </summary>
    /// <param name="user"></param>
    private void NotifyUserChanged(MyUser? user)
    {
        StateChanged?.Invoke(user);
    }


    public async Task<Exception?> InitUserAsync()
    {
        //запросить Guid вошедшего на сайт посетителя в его браузере
        var userGuidKey = await GetUserGuidFromBrowserAsync();
        if (userGuidKey.ex != null)
        {
            MyUser = null;
            return userGuidKey.ex;
        }

        //Guid нет в браузере
        if (userGuidKey.guid == null)
        {
            var result = await CreateNewUserAsync();
            MyUser = result.myUser;
            return result.ex;
        }

        //Guid есть в браузере
        //тогда ищем пользователя с таким Guid в БД
        //var findUserResult = await _usersService.FindUserWithGuidInDbAsync(userGuidKey.guid!); //ReadRepository.FindUserWithGuidInDbAsync(userGuidKey.guid!);
        var dbAvailable = await Repository.DbAvailableAsync();
        if (dbAvailable.ex != null)
        {
            MyUser = null;
            return dbAvailable.ex;
        }
        if (dbAvailable.checkResult == false)
        {
            var result = await CreateNewUserAsync();
            MyUser = result.myUser;
            return result.ex;
        }

        var findUserResult = await Repository.GetFirstOrDefaultAsync<MyUser>(predicate: x => x.UserGuid == userGuidKey.guid);
        if (findUserResult.ex != null) // Если ошибка
        {
            MyUser = null;
            return findUserResult.ex;
        }

        if (findUserResult.entity == null) // Нет данных в БД - Нет пользователя с таким ключом в БД
        {
            var result = await CreateNewUserAsync();
            MyUser = result.myUser;
            return result.ex;
        }

        //Это зарегистрированный пользователь?
        if (CheckIsRegisteredUser(findUserResult.entity))
        {
            //Время Guid закончилось?
            if (findUserResult.entity.ExpiredAt < DateTime.Now)
            {
                var result = await LogoutAsync(findUserResult.entity);
                return result;
            }
            //прибавить часы
            findUserResult.entity.ExpiredAt = DateTime.Now.AddHours(UserLoginActiveHours);
        }

        //var saveEntityOperationResponce = await _usersService.Update(findUserResult.Data);
        var saveEntityOperationResponce = await Repository.UpdateEntityAsync<MyUser>(findUserResult.entity);

        if (saveEntityOperationResponce != null)
            return saveEntityOperationResponce;

        //MyUser = saveEntityOperationResponce.Data!.Value.entity;
        MyUser = findUserResult.entity;
        return null;
    }

    /// <summary>
    /// Запрос Guid (уникальный ключ посетителя сайта) у браузера
    /// </summary>
    /// <returns></returns>
    private async Task<(string? guid, Exception? ex)> GetUserGuidFromBrowserAsync()
    {
        try
        {
            var userGuidKey = await ProtectedBrowserStorage.GetAsync<string>(userKeyName);
            if (userGuidKey.Success)
                return (userGuidKey.Value, null);
            throw new Exception("Ошибка чтения ключа");
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }

    /// <summary>
    /// Создать нового посетителя
    /// </summary>
    /// <returns></returns>
    private async Task<(MyUser? myUser, Exception? ex)> CreateNewUserAsync()
    {
        var userGuidKey = await CreateNewUserGuidForBrowserAsync();
        if (userGuidKey.ex != null)
            return (null, userGuidKey.ex);

        var myUser = new MyUser(userGuidKey.guid, UserLoginActiveHours);
        return (myUser, null);
    }

    private async Task<(string? guid, Exception? ex)> CreateNewUserGuidForBrowserAsync()
    {
        try
        {
            var userGuidKey = Guid.NewGuid().ToString();
            await ProtectedBrowserStorage.SetAsync(userKeyName, userGuidKey);
            return (userGuidKey, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }


    private async Task<(string? guid, Exception? ex)> SaveUserGuidToBrowserAsync(string userGuidKey)
    {
        try
        {
            await ProtectedBrowserStorage.SetAsync(userKeyName, userGuidKey);
            return (userGuidKey, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }

    /// <summary>
    /// Выход пользователя
    /// </summary>
    /// <returns></returns>
    public async Task<Exception?> LogoutAsync(MyUser? user = null)
    {
        //if (user != null)
        //{
        //	var ex = await LogoutMyUserAsync(user);
        //}
        //else
        //{
        //	var ex = await LogoutMyUserAsync(MyUser);
        //	if (ex != null)
        //	{
        //		MyUser = null;
        //		return ex;
        //	}
        //}

        var ex = await LogoutMyUserAsync(MyUser);
        MyUser = null;

        if (ex != null)
        {
            //MyUser = null;
            return ex;
        }

        //await MyLocalstorage.RemoveAsync(userKeyName);
        return null;

        //var result = await CreateNewUserAsync();
        //MyUser = result.myUser;
        //return result.ex;
    }

    /// <summary>
    /// операция "Выход"
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private async Task<Exception?> LogoutMyUserAsync(MyUser? user)
    {
        if (user == null) return new NullReferenceException("Нет пользователя");
        if (IAmDefaultAdmin(user)) return null;

        user.ClearForLogout();
        //var saveEntityOperationResponce = await ReadRepository.UpdateAsync(user);
        //if (!saveEntityOperationResponce.IsSuccessfullOperation)
        //    return saveEntityOperationResponce.Exception;


        //переделал , но не проверил
        //var saveEntityOperationResponce = await _usersService.Update(user);
        var repository = ServiceProvider.GetRequiredService<DbRepository>();
        var saveEntityOperationResponce = await repository.UpdateEntityAsync<MyUser>(user);


        if (saveEntityOperationResponce != null)
            return saveEntityOperationResponce;
        return null;
    }

    /// <summary>
    /// Вход пользователя
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns></returns>
    public async Task<(bool? isLogin, string? messageForUser, Exception? ex)> LoginAsync(UserLoginModel loginModel)
    {
        var createAdmin = await CreateDefaultAdminAsync(loginModel, MyUser?.UserGuid);
        if (createAdmin.ex != null)
            return (false, "Ошибка при проверке на администратора по умолчанию", createAdmin.ex);

        if (createAdmin.myUser != null)
        {
            MyUser = createAdmin.myUser;
            return (true, null, null);
        }

        //var findUserWithSameEmailResult2 = await ReadRepository.GetFirstOrDefaultAsync(x => x.Login!.ToUpper() == loginModel.Login!.ToUpper());
        //var findUserWithSameEmailResult = await ReadRepository.FindEntityAsync(x => x.Login.ToUpper() == loginModel.Login!.ToUpper());
        //      if (!findUserWithSameEmailResult.IsSuccessfullOperation)
        //          return (false, "Ошибка при проверке данных", findUserWithSameEmailResult.Exception);

        //переделал , но не проверил
        var findUserWithSameEmailResult = await Repository.GetFirstOrDefaultAsync<MyUser>(x => x.Login!.ToUpper() == loginModel.Login!.ToUpper());
        if (findUserWithSameEmailResult.ex != null)
            return (false, "Ошибка при проверке данных", findUserWithSameEmailResult.ex);


        //В БД нет такого e-mail
        if (findUserWithSameEmailResult.entity == null)
            return (false, "Нет пользователя с таким логином. Проверьте логин или зарегистрируйтесь.", null);

        var finedUser = findUserWithSameEmailResult.entity;

        //пароль верный?
        if (finedUser.Password != loginModel.Password)
        {    //нет, неверный
             //Увеличить счётчик попыток ввода пароля в БД
            finedUser.PasswordInputCount++;

            //var saveEntityOperationResponce = await ReadRepository.UpdateAsync(finedUser);
            // todo переделал, но не проверил
            var saveEntityOperationResponce = await Repository.UpdateEntityAsync(finedUser);

            //количество попыток > 5
            if (finedUser.PasswordInputCount > LengthConstants.maxPasswordInputCount)
                return (false, "Вы исчерпали количество попыток ввода пароля. Повторите вход завтра или обратитесь к администратору сайта", null);

            if (saveEntityOperationResponce != null)
                return (false, "Ошибка при проверке данных", saveEntityOperationResponce);
            return (false, "Неправильно ввели пароль.", null);
        }

        //количество попыток > 5
        if (finedUser.PasswordInputCount > LengthConstants.maxPasswordInputCount)
            return (false, "Вы исчерпали количество попыток ввода пароля. Повторите вход завтра или обратитесь к администратору сайта", null);

        var result = await SaveLoginUserAsync(finedUser, MyUser, UserLoginActiveHours);
        if (result.ex != null)
            return (false, "Ошибка при проверке данных. Обновите страницу или попробуйте зайти попозже", findUserWithSameEmailResult.ex);

        MyUser = result.loginedUser;
        var saveGuidResult = await SaveUserGuidToBrowserAsync(MyUser!.UserGuid!);
        if (saveGuidResult.ex != null)
            return (false, "Ошибка при проверке данных. Обновите страницу или попробуйте зайти попозже", saveGuidResult.ex);

        return (true, null, null);
    }

    public async Task<(MyUser? loginedUser, Exception? ex)> SaveLoginUserAsync(MyUser loginingUser, MyUser? currentUser, int userLoginActiveHours)
    {
        var finedUser = await Repository.GetFirstOrDefaultAsync<MyUser>(x => x.Id == loginingUser.Id, trackingType: TrackingType.Tracking);
        if (finedUser.entity == null)
            return (null, new Exception("Пользователь не найден. Возможно он уже кем-то удалён или изменён"));

        if (finedUser.entity.UserGuid == null || finedUser.entity.ExpiredAt < DateTime.Now)
        {
            if (currentUser != null && !string.IsNullOrEmpty(currentUser.UserGuid))
                finedUser.entity.UserGuid = currentUser.UserGuid;
            else
                finedUser.entity.UserGuid = Guid.NewGuid().ToString();
        }

        finedUser.entity.LastOperationDate = DateTime.Now;
        finedUser.entity.PasswordInputCount = 0;
        finedUser.entity.ExpiredAt = DateTime.Now.AddHours(userLoginActiveHours);

        var ex = await Repository.UpdateEntityAsync<MyUser>(finedUser.entity);
        return (finedUser.entity, null);

    }

    /// <summary>
    /// Создать администратора. В случаи когда БД ещё не существует
    /// </summary>
    /// <returns></returns>
    private async Task<(MyUser? myUser, Exception? ex)> CreateDefaultAdminAsync(UserLoginModel loginModel, string? guid)
    {

        if (loginModel.Login == adminEmail && loginModel.Password == adminPassword)
        {
            // var dbAvailableResult = await ReadRepository.DbAvailableAsync();
            //переделал, но не проверил
            var dbAvailableResult = await Repository.DbAvailableAsync();

            //Если ошибка 
            if (dbAvailableResult.ex != null)
                return (null, dbAvailableResult.ex);

            //Если БД доступна, тогда НЕ создаём админа по умолчанию
            if (dbAvailableResult.ex == null && dbAvailableResult.checkResult == true)
                return (null, null);

            MyUser admin = new MyUser(guid, 1);//достаточно 1го часа для временного администратора
            if (string.IsNullOrEmpty(guid))
            {
                var result = await GetUserGuidFromBrowserAsync();
                if (result.ex != null || string.IsNullOrEmpty(result.guid))
                    admin.UserGuid = Guid.NewGuid().ToString();
                else
                    admin.UserGuid = result.guid;
            }

            //admin.Fio = adminFio;
            admin.Login = loginModel.Login;
            admin.Password = loginModel.Password;
            admin.Role = RoleEnum.admin;
            //admin.ExpiredAt = DateTime.Now.AddDays(1);
            return (admin, null);
        }

        return (null, null);
    }


}
