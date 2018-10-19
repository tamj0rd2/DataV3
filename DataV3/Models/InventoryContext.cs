namespace DataV3.Models
{
    public abstract partial class InventoryContext
    {
        protected InventoryContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}
