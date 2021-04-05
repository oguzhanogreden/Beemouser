using System;
using System.IO;

using Microsoft.EntityFrameworkCore;

using Beemouser.Domain.Models;

namespace Beemouser.DbContexts
{
    public class ClickContext : DbContext
    {
        public DbSet<Click> Clicks { get; set; }

        public ClickContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(GetDbPath());
            optionsBuilder.UseSqlite($"Filename={GetDbPath()}");
        }

        private string GetDbPath()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string dbPath = Path.Combine(documents, "ClickDatabase.db3");

            return dbPath;
        }
    }
}
