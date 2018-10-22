namespace DataV3.ViewModels
{
    using System;

    using DataV3.Models;

    public class EditAuthorViewModel : BaseAuthorViewModel
    {
        public readonly Author Author;

        public EditAuthorViewModel(Author author)
        {
            this.Author = author;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
            this.Birthday = author.BirthDate;
        }

        public bool IsValid
        {
            get
            {
                // TODO: use the correct way to validate view models like we do in MVC ;|
                // TODO: and reduce all this duplicated code from AddAuthorPage/ViewModel
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
