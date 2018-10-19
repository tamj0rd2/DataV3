namespace DataV3.Services
{
    using System.Data.Entity;

    using DataV3.Models;

    using MySql.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlContext : InventoryContext
    {
        public MySqlContext()
            : base("name=InventoryMySql")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
