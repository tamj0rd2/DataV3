namespace DataV3.ViewModels
{
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
    }
}
