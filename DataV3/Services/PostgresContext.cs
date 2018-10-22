namespace DataV3.Services
{
    using System.Data.Entity;

    using DataV3.Models;

    public class PostgresContext : InventoryContext
    {
        public PostgresContext() : base("name=InventoryPostgres")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }
    }
}
