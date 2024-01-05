using Microsoft.EntityFrameworkCore;

namespace AdriansApp.Models

{
    public class MyDbContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDB");
        }

    }
}
