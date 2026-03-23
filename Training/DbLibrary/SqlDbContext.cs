namespace DbLibrary;

public class SqlDbContext : DbContext
{
    
    public DbSet<RegisteredUser> RegisteredUsers { get; set; }

    public DbSet<TrainingCourse> TrainingCourses{ get; set; }
    public DbSet<CourseQestion> CourseQestions{ get; set; }
    public DbSet<Answer> Answers { get; set; }


    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    //public SqlDbContext()
    //{
    //    //Database.EnsureCreated();
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    string connection = "Data Source = WIN10PC; Initial Catalog =MedicalCRM ; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //    //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    //    optionsBuilder.UseSqlServer(connection);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Employee>().Navigation(e => e.Position).AutoInclude();
        //modelBuilder.Entity<MedicalService>().Navigation(e => e.MedicalServiceType).AutoInclude();
    }
}