namespace DataV3.ViewModels
{
    using System;

    public class AddAuthorViewModel : BaseAuthorViewModel
    {
        public bool IsValid
        {
            get
            {
                // TODO: use the correct way to validate view models like we do in MVC ;|
                if (string.IsNullOrWhiteSpace(this.FirstName))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(this.LastName))
                {
                    return false;
                }

                if (this.Birthday == DateTime.MinValue)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
