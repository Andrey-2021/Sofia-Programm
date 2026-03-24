using Entities;
using Entities.Enums;
namespace InitDb;

public static class UserSeeder
{
    /// <summary>
    /// Возвращает список с заранее определёнными данными
    /// </summary>
    public static List<MyUser> GetSampleUsers()
    {
        List<Manager> managers = ManagerSeeder.GetSampleManagers();

        var users = new List<MyUser>();
        users.Add(new MyUser("admin","1234", RoleEnum.admin, managers[0]));
        users.Add(new MyUser("admin2", "admin123", RoleEnum.manager, managers[1]));
        users.Add(new MyUser("manager", "1234", RoleEnum.manager, managers[2]));
        users.Add(new MyUser("alice", "alice2024", RoleEnum.manager, managers[3]));
        users.Add(new MyUser("bob", "bob1234", RoleEnum.manager, managers[4]));
        users.Add(new MyUser("charlie", "charlie567", RoleEnum.manager, managers[5]));
        users.Add(new MyUser("diana", "diana789", RoleEnum.manager, managers[6]));
        users.Add(new MyUser("eve", "eve000", RoleEnum.manager, managers[7]));
        users.Add(new MyUser("frank", "frank111", RoleEnum.manager, managers[8]));
        users.Add(new MyUser("grace", "grace222", RoleEnum.manager, managers[9]));
        users.Add(new MyUser("henry", "henry333", RoleEnum.manager, managers[10]));
        users.Add(new MyUser("iris", "iris444", RoleEnum.manager, managers[11]));
        users.Add(new MyUser("jack", "jack555", RoleEnum.manager, managers[12]));
        users.Add(new MyUser("karen", "karen666", RoleEnum.manager, managers[13]));
        users.Add(new MyUser("leo", "leo777", RoleEnum.manager, managers[14]));
        users.Add(new MyUser("maya", "maya888", RoleEnum.manager, managers[15]));
        users.Add(new MyUser("nick", "nick999", RoleEnum.manager, managers[16]));
        users.Add(new MyUser("olivia", "olivia000", RoleEnum.manager, managers[17]));
        users.Add(new MyUser("paul", "paul111", RoleEnum.manager, managers[18]));
        users.Add(new MyUser("quincy", "quincy222", RoleEnum.manager, managers[19]));
        return users;
    }
}



public static class ManagerSeeder
{
    /// <summary>
    /// Возвращает список из 20 сотрудников с заранее определёнными данными.
    /// </summary>
    public static List<Manager> GetSampleManagers()
    {
        var Managers = new List<Manager>();

        // Добавляем 20 сотрудников, передавая данные непосредственно в конструктор.
        // ManagerId не задаётся.
        Managers.Add(new Manager(
            lastName: "Иванов",
            firstName: "Пётр",
            middleName: "Сергеевич",
            phoneNumber: "+7 (123) 111-22-33",
            email: "ivanov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Петрова",
            firstName: "Мария",
            middleName: "Ивановна",
            phoneNumber: "+7 (123) 222-33-44",
            email: "petrova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Сидоров",
            firstName: "Алексей",
            middleName: "Викторович",
            phoneNumber: "+7 (123) 333-44-55",
            email: "sidorov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Кузнецова",
            firstName: "Елена",
            middleName: "Владимировна",
            phoneNumber: "+7 (123) 444-55-66",
            email: "kuznetsova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Смирнов",
            firstName: "Дмитрий",
            middleName: "Николаевич",
            phoneNumber: "+7 (123) 555-66-77",
            email: "smirnov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Михайлова",
            firstName: "Анна",
            middleName: "Олеговна",
            phoneNumber: "+7 (123) 666-77-88",
            email: "mikhailova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Фёдоров",
            firstName: "Андрей",
            middleName: "Павлович",
            phoneNumber: "+7 (123) 777-88-99",
            email: "fedorov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Морозова",
            firstName: "Ольга",
            middleName: "Игоревна",
            phoneNumber: "+7 (123) 888-99-00",
            email: "morozova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Волков",
            firstName: "Иван",
            middleName: "Алексеевич",
            phoneNumber: "+7 (123) 999-00-11",
            email: "volkov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Соколова",
            firstName: "Татьяна",
            middleName: "Дмитриевна",
            phoneNumber: "+7 (123) 000-11-22",
            email: "sokolova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Лебедев",
            firstName: "Максим",
            middleName: "Сергеевич",
            phoneNumber: "+7 (124) 111-22-33",
            email: "lebedev@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Козлова",
            firstName: "Наталья",
            middleName: "Викторовна",
            phoneNumber: "+7 (124) 222-33-44",
            email: "kozlova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Новиков",
            firstName: "Александр",
            middleName: "Иванович",
            phoneNumber: "+7 (124) 333-44-55",
            email: "novikov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Зайцева",
            firstName: "Ирина",
            middleName: "Петровна",
            phoneNumber: "+7 (124) 444-55-66",
            email: "zaytseva@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Павлов",
            firstName: "Михаил",
            middleName: "Геннадьевич",
            phoneNumber: "+7 (124) 555-66-77",
            email: "pavlov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Борисова",
            firstName: "Екатерина",
            middleName: "Анатольевна",
            phoneNumber: "+7 (124) 666-77-88",
            email: "borisova@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Соловьёв",
            firstName: "Владимир",
            middleName: "Андреевич",
            phoneNumber: "+7 (124) 777-88-99",
            email: "soloviev@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Васильева",
            firstName: "Светлана",
            middleName: "Максимовна",
            phoneNumber: "+7 (124) 888-99-00",
            email: "vasilieva@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Попов",
            firstName: "Артём",
            middleName: "Валерьевич",
            phoneNumber: "+7 (124) 999-00-11",
            email: "popov@clinic.ru"
        ));

        Managers.Add(new Manager(
            lastName: "Алексеева",
            firstName: "Дарья",
            middleName: "Сергеевна",
            phoneNumber: "+7 (124) 000-11-22",
            email: "alekseeva@clinic.ru"
        ));

        return Managers;
    }
}
