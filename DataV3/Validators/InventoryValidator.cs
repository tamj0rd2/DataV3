namespace DataV3.Validators
{
    using System;
    using System.Data.SqlTypes;

    using DataV3.ViewModels;

    public static class InventoryValidator
    {
        public static bool IsValid(BaseAuthorViewModel author)
        {
            if (string.IsNullOrWhiteSpace(author.FirstName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(author.LastName))
            {
                return false;
            }

            if (author.Birthday <= SqlDateTime.MinValue)
            {
                return false;
            }

            return true;
        }
    }
}
