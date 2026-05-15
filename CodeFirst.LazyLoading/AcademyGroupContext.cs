using Microsoft.EntityFrameworkCore;

namespace CodeFirst.LazyLoading
{
    public class AcademyGroupContext : DbContext
    {
        public AcademyGroupContext()
        {
            if (Database.EnsureCreated())
            {
                AcademyGroup group1 = new AcademyGroup { Name = "СПР112" };
                AcademyGroup group2 = new AcademyGroup { Name = "ПВ111" };
                AcademyGroup group3 = new AcademyGroup { Name = "ПР211" };
                AcademyGroups?.Add(group1);
                AcademyGroups?.Add(group2);
                AcademyGroups?.Add(group3);
                Students?.Add(new Student { FirstName = "Богдан", LastName = "Іваненко", Age = 20, GPA = 10.5, AcademyGroup = group1 });
                Students?.Add(new Student { FirstName = "Анна", LastName = "Шевченко", Age = 23, GPA = 11.5, AcademyGroup = group2 });
                Students?.Add(new Student { FirstName = "Петро", LastName = "Петренко", Age = 25, GPA = 12, AcademyGroup = group3 });
                Students?.Add(new Student { FirstName = "Олена", LastName = "Артем'єва", Age = 42, GPA = 11.5, AcademyGroup = group1 });
                Students?.Add(new Student { FirstName = "Олена", LastName = "Алєксєєва", Age = 47, GPA = 12, AcademyGroup = group2 });
                Students?.Add(new Student { FirstName = "Вікторія", LastName = "Бабенко", Age = 29, GPA = 10, AcademyGroup = group3 });

                SaveChanges();
            }
        }

        public DbSet<AcademyGroup> AcademyGroups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // метод UseLazyLoadingProxies() робить доступним ліниве завантаження.
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=AcademyGroupDB;Integrated Security=SSPI;TrustServerCertificate=true");
        }
    }
}