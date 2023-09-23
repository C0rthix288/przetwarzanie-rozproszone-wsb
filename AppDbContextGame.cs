using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject
{
    public class AppDbContextGame:DbContext
    {

        public AppDbContextGame(DbContextOptions<AppDbContextGame> options) : base(options) { }

        public DbSet<NumberModel> Numbers { get; set; }

    }
}
