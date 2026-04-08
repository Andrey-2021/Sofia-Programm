using DbLibrary.Helpers;
using Entities.Enums;
using Entities.Interfaces;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace DbLibrary;

public class DbRepository
{
    private readonly IDbContextFactory<SqlDbContext> contextFactory;

    public DbRepository(IDbContextFactory<SqlDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    /// <summary>
    /// Проверка доступности БД
    /// </summary>
    /// <returns></returns>
    public async Task<(bool checkResult, Exception? ex)> DbAvailableAsync()
    {
        try
        {
            using (var db = contextFactory.CreateDbContext())
            {
                var dbAvailableResult = await db.Database.CanConnectAsync(); //Провеяем доступен ли сервер MSSQL

                if (!dbAvailableResult)
                    return (false, null);// throw new Exception("Сервер БД не доступен.");

                var result = db.Set<MyUser>().Count();//проверяем что есть таблица в БД. Считаем, что если есть таблица, то есть и другие таблицы.
                if (result >= 0)
                    return (true, null);
                return (false, null);
            }
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    /// <summary>
	/// Создать новую БД
	/// </summary>
	public async Task<(bool operationResult, Exception? ex)> CreateNewDbAsync()
    {
        try
        {
            //using var db = contextFactory.CreateDbContext();
            //await db.CreateClearDbAsync();
            //await InitDb(db);
            //return (true, null);

            //using (var db = new SqlDbContext())
            using (var db = contextFactory.CreateDbContext())
            {
                await db.Database.EnsureDeletedAsync();
                var rezult = await db.Database.EnsureCreatedAsync();

                if (!rezult)
                    return (false, null);
                return (true, null);
            }
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    /// <summary>
    /// Загрузить начальные данные в БД
    /// </summary>
    public async Task<(bool operationResult, Exception? ex)> SaveInitDataInDbAsync()
    {
        try
        {
            using (var db = contextFactory.CreateDbContext())
            {
                var rezult = await db.Database.CanConnectAsync(); //Провеяем доступен ли сервер MSSQL
                if (rezult)
                {
                    await MainInit.InitDb(db);
                    await db.SaveChangesAsync();
                }
            }
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }


    public async Task<(IEnumerable<TEntity> data, Exception? ex)> GetEntitiesAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicate = null,
                                                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                                                            TrackingType trackingType = TrackingType.NoTracking)
        where TEntity : class
    {
        try
        {
            //using var db = contextFactory.CreateDbContext();
            using (var db = contextFactory.CreateDbContext())
            {
                var query = db.Set<TEntity>().AsQueryable(); //.AsSplitQuery();
                query = TrackingPart(trackingType, query);
                query = Common_Predicat_OrderBy_Include(query, predicate, orderBy, include);
                var result = await query.ToListAsync();
                return (result, null);
            }
        }
        catch (Exception ex)
        {
            return (new List<TEntity>(), ex);
        }
    }

    public async Task<OperationResponce<IEnumerable<TEntity>?>> GetEntities<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicate = null,
                                                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                                                            TrackingType trackingType = TrackingType.NoTracking)
        where TEntity : class
    {
        try
        {
            //using var db = contextFactory.CreateDbContext();
            using (var db = contextFactory.CreateDbContext())
            {
                var query = db.Set<TEntity>().AsQueryable(); //.AsSplitQuery();
                query = TrackingPart(trackingType, query);
                query = Common_Predicat_OrderBy_Include(query, predicate, orderBy, include);
                var result = await query.ToListAsync();
                return OperationResponce<IEnumerable<TEntity>?>.SetSuccessfullOperation(result);
            }
        }
        catch (Exception ex)
        {
            return OperationResponce<IEnumerable<TEntity>?>.SetExceptionOperation("Оибка при чтении данных", ex);

        }
    }


    protected IQueryable<T> TrackingPart<T>(TrackingType trackingType, IQueryable<T> entities)
        where T : class
    {
        var query = trackingType switch
        {
            TrackingType.NoTracking => entities.AsNoTracking(),
            TrackingType.NoTrackingWithIdentityResolution => entities.AsNoTrackingWithIdentityResolution(),
            TrackingType.Tracking => entities,
            _ => throw new ArgumentOutOfRangeException(nameof(trackingType), trackingType, null)
        };
        return query;
    }

    private IQueryable<T> Common_Predicat_OrderBy_Include<T>(IQueryable<T> query,
                                                                System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null,
                                                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        where T : class
    {
        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            query = orderBy(query);
        return query;
    }

    /// <summary>
	/// Обновить сущность в БД
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public async Task<Exception?> UpdateEntityAsync<TEntity>(TEntity entity)
    where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();
            var result = db.Update<TEntity>(entity);
            var n = await db.SaveChangesAsync();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }


    public async Task<OperationResponce<TEntity>> UpdateEntity<TEntity>(TEntity entity)
    where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();
            var result = db.Update<TEntity>(entity);
            var n = await db.SaveChangesAsync();

            return OperationResponce<TEntity>.SetSuccessfullOperation(result.Entity, "Объект обновлён (сохранён) в БД");
        }
        catch (Exception ex)
        {
            return OperationResponce<TEntity>.SetExceptionOperation("Ошибка при обновлении (сохранении) объекта в БД", ex);
        }
    }



    /// <summary>
	/// Удалить сущность в БД
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public async Task<(TEntity entity, Exception? ex)> DelEntityAsync<TEntity>(TEntity entity)
    where TEntity : class, IHaveId
    {
        try
        {
            using var db = contextFactory.CreateDbContext();
            var find = await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (find != null)
            {
                var deletedEntity = db.Remove(find);
                await db.SaveChangesAsync();
                return (deletedEntity.Entity, null);
            }
            return (entity, null);
        }
        catch (Exception ex)
        {
            return (entity, ex);
        }
    }

    public async Task<(TEntity? entity, Exception? ex)> GetFirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null,
                                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                                TrackingType trackingType = TrackingType.NoTracking)
        where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();

            var _dbSet = db.Set<TEntity>();

            var query = trackingType switch
            {
                TrackingType.NoTracking => _dbSet.AsNoTracking(),
                TrackingType.NoTrackingWithIdentityResolution => _dbSet.AsNoTrackingWithIdentityResolution(),
                TrackingType.Tracking => _dbSet,
                _ => throw new ArgumentOutOfRangeException(nameof(trackingType), trackingType, null)
            };

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            var rezult = orderBy is not null
                ? await orderBy(query).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();

            return (rezult, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }

    }


    public async Task<OperationResponce<TEntity?>> GetFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>>? predicate = null,
                                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                                TrackingType trackingType = TrackingType.NoTracking)
        where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();

            var _dbSet = db.Set<TEntity>();

            var query = trackingType switch
            {
                TrackingType.NoTracking => _dbSet.AsNoTracking(),
                TrackingType.NoTrackingWithIdentityResolution => _dbSet.AsNoTrackingWithIdentityResolution(),
                TrackingType.Tracking => _dbSet,
                _ => throw new ArgumentOutOfRangeException(nameof(trackingType), trackingType, null)
            };

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            var result = orderBy is not null
                ? await orderBy(query).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();

            return OperationResponce<TEntity?>.SetSuccessfullOperation(result, "Объект прочитан из БД");
        }
        catch (Exception ex)
        {
            return OperationResponce<TEntity?>.SetExceptionOperation("Ошибка при чтении данных из БД", ex);
        }

    }


    public async Task<(IEnumerable<TrainingCourse>? data, Exception? ex)> GetAllMyTrainingCourse(MyUser myUser)
    {
        if (myUser == null)
            return (null, null);

        if (myUser.Role == RoleEnum.admin) //Если это администратор,
            return await GetEntitiesAsync<TrainingCourse>(include: x => x.Include(c => c.MyUser)); // Читаем все курсы
        else
            return await GetEntitiesAsync<TrainingCourse>(predicate: x => x.MyUserId == myUser.Id, //Читаем только свои курсы
                                                            include: x => x.Include(c => c.MyUser));

    }

    /// <summary>
    /// Получить все свои курсы
    /// </summary>
    /// <param name="myUser">Зарегистрированный пользователь</param>
    /// <returns>Список своих курсов</returns>
    public async Task<OperationResponce<IEnumerable<TrainingCourse>>> GetAllMyTrainingCourseAsync(MyUser myUser)
    {
        Func<IQueryable<TrainingCourse>, IIncludableQueryable<TrainingCourse, object>>? includeData = (x) => x.Include(ct => ct.MyUser);

        if (myUser.Role == RoleEnum.admin) //Если это администратор,
            return await GetEntities<TrainingCourse>(include: includeData); // Читаем все курсы
        else
            return await GetEntities<TrainingCourse>(include: includeData,
                                                    predicate: x => x.MyUserId == myUser.Id); //Читаем только свои курсы
    }


    /// <summary>
    /// Чужие курсы, на которые я выбрал
    /// </summary>
    /// <param name="myUser">Пользователь</param>
    /// <returns></returns>
    public async Task<OperationResponce<IEnumerable<SelectedOtherPeopleCourse>?>> GetOtherPeoplesCoursesThatIChosenAsync(MyUser myUser)
    {
        // Список курсов на которые я уже подписан
        var mySelectedOtherPeopleCourseResponce = await GetEntities<SelectedOtherPeopleCourse>(predicate: x => x.MyUserId == myUser.Id,
            include: x=>x.Include(sopc=>sopc.TrainingCourse)
                            .ThenInclude(tc=>tc.MyUser)
                            .Include(sopc => sopc.TrainingCourse.CourseQestions));
        return mySelectedOtherPeopleCourseResponce;
    }


    /// <summary>
    /// Получить курсы других заристрированных пользователей, которые открыты для всех
    /// </summary>
    /// <param name="myUser"></param>
    /// <returns></returns>
    public async Task<OperationResponce<(IEnumerable<SelectedOtherPeopleCourse>? mySelectedOtherPeopleCourse, List<TrainingCourse>? allOtherPeopleCourse)>> GetOtherPeoplesCoursesAsync(MyUser myUser)
    {
        // Список курсов на которые я уже подписан
        var mySelectedOtherPeopleCourseResponce = await GetEntities<SelectedOtherPeopleCourse>(predicate: x => x.MyUserId == myUser.Id);
        if (!mySelectedOtherPeopleCourseResponce.IsSuccessfullOperation) //Если ошибка чтения
            return OperationResponce<(IEnumerable<SelectedOtherPeopleCourse>? mySelectedCourses, List<TrainingCourse>? allOtherPeopleCourse)>.SetExceptionOperation("Ошибка чтения данных", mySelectedOtherPeopleCourseResponce.Exception);

        // Список всех чужих курсов
        OperationResponce <IEnumerable<TrainingCourse>> allOtherPeopleCourseResponce;
        Func<IQueryable<TrainingCourse>, IIncludableQueryable<TrainingCourse, object>>? includeData = (x) => x.Include(ct => ct.MyUser);
        if (myUser.Role == RoleEnum.admin) //Если это администратор,
        {
            allOtherPeopleCourseResponce = await GetEntities<TrainingCourse>(include: includeData,
                                                                    predicate: x => x.MyUserId != myUser.Id && x.IsVisableForAll == true); // Читаем все открытые курсы


        }
        else
        {
            allOtherPeopleCourseResponce = await GetEntities<TrainingCourse>(include: includeData,
                                                    predicate: x => x.MyUserId != myUser.Id && x.IsVisableForAll == true); //Читаем чужие курсы лоступные для всех
        }

        if(!allOtherPeopleCourseResponce.IsSuccessfullOperation) //Если ошибка чтения
            return OperationResponce<(IEnumerable<SelectedOtherPeopleCourse>? mySelectedCourses, List<TrainingCourse>? allOtherPeopleCourse)>.SetExceptionOperation("Ошибка чтения данных", allOtherPeopleCourseResponce.Exception);
        
        // Возвращаем результат
        return OperationResponce<(IEnumerable<SelectedOtherPeopleCourse>? mySelectedCourses, List<TrainingCourse>? allOtherPeopleCourse)>
            .SetSuccessfullOperation((mySelectedOtherPeopleCourseResponce.Data, allOtherPeopleCourseResponce.Data.ToList()), null);
    }







    public async Task<(IEnumerable<CompletedTest>? data, Exception? ex)> GetAllMyCompletedTest(MyUser myUser)
    {
        if (myUser == null)
            return (null, null);

        Func<IQueryable<CompletedTest>, IIncludableQueryable<CompletedTest, object>>? includeData = (x) => x.Include(ct => ct.MyUser).
                                                                                                        Include(ct => ct.TrainingCourse.MyUser);


        if (myUser.Role == RoleEnum.admin) //Если это администратор,
            return await GetEntitiesAsync<CompletedTest>(include: includeData); // Читаем все 
        else
            return await GetEntitiesAsync<CompletedTest>(predicate: x => x.MyUserId == myUser.Id, //Читаем только свои 
                                                            include: includeData);

    }


    public async Task<OperationResponce<TrainingCourse>> GetCourse(int? id)
    {
        return await GetFirstOrDefault<TrainingCourse>
            (predicate: x => x.Id == id,
            include: x => x.Include(tc => tc.CourseQestions)
                            .ThenInclude(cq => cq.WrongRussianWordAnswers));


    }
}

