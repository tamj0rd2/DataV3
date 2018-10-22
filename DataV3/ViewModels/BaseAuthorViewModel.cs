namespace DataV3.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseAuthorViewModel : ObservableViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public virtual bool IsValid()
        {
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
