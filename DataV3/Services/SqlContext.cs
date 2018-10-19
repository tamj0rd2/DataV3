namespace DataV3.Services
{
    using DataV3.Models;

    public class SqlContext : InventoryContext
    {
        public SqlContext() : base("name=InventorySql")
        {
        }
    }
}
