namespace DataV3.Services
{
    using System.Data.Entity;

    using DataV3.Models;

    using SQLite.CodeFirst;

    public class SqliteContext : InventoryContext
    {
        public SqliteContext() : base("name=InventorySqlite")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SqliteContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}
