namespace DataV3.Mappers
{
    using DataV3.Models;
    using DataV3.ViewModels;

    public static class AuthorMapper
    {
        // Maps the user provided details to an Author object
        public static Author Map(AddAuthorViewModel viewModel)
        {
            return new Author
            {
                BirthDate = viewModel.Birthday,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };
        }
    }
}
