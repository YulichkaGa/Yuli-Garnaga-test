using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Xml;
using Yuli_Garnaga_test.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Yuli_Garnaga_test.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options):base(options)
        {

        }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Types> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Type>();

            base.OnModelCreating(modelBuilder);
        }
    }
}