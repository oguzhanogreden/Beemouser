using System;
using System.IO;
using SQLite;

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
            optionsBuilder.UseSqlite($"Filename={GetDbPath()}");
        }

        private string GetDbPath()
        {
            // todo: replace with app folder
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string dbPath = Path.Combine(documents, "ClickDatabase.db3");

            return dbPath;
        }
    }
}
