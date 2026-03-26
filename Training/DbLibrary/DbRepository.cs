using DbLibrary.Helpers;
using Entities.Interfaces;
using System.Linq.Expressions;

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
                    return (false, null) ;// throw new Exception("Сервер БД не доступен.");

                var result = db.Set<MyUser>().Count();//проверяем что есть таблица в БД. Считаем, что если есть таблица, то есть и другие таблицы.
                if (result >= 0)
                    return (true,null);
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
                // todo заменить на вызов метода
                var rezult= await db.Database.CanConnectAsync(); //Провеяем доступен ли сервер MSSQL

                if (rezult)
                {
                    var users = UserSeeder.GetSampleUsers();
                    await db.MyUsers.AddRangeAsync(users);

                    var trainingCourse = TrainingCourseJapaneseSeeder.GetSampleCourses(users);
                    await db.TrainingCourses.AddRangeAsync(trainingCourse);

                    var questions = CommonCourseQuestionSeeder.GetQuestions(trainingCourse);
                    await db.CourseQestions.AddRangeAsync(questions);

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
                var deletedEntity= db.Remove(find);
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

            var rezult= orderBy is not null
                ? await orderBy(query).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();

            return (rezult, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
        
    }


    public async Task<(IEnumerable<TrainingCourse> data, Exception? ex)> GetAllMyTrainingCourse(MyUser myUser)
    {
        return await GetEntitiesAsync<TrainingCourse>();
    }
}

