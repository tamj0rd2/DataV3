namespace DataV3.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DataV3.Enums;
    using DataV3.Mappers;
    using DataV3.Models;
    using DataV3.ViewModels;

    // A service I wrote which utilizes Entity Framework to abstract away all the complex SQL things
    public class DbManager
    {
        private static readonly Lazy<DbManager> LazyDbManager = new Lazy<DbManager>(() => new DbManager());

        public static DbManager Instance => LazyDbManager.Value;

        public ConnectionType ConnectionType { get; set; }

        // Creates and Author and stores it in the database
        public void AddAuthor(AddAuthorViewModel viewModel)
        {
            var author = AuthorMapper.Map(viewModel);

            using (var context = this.CreateContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        // Reads the Authors table and returns all the authors as objects
        public IEnumerable<Author> GetAuthors()
        {
            using (var context = this.CreateContext())
            {
                return context.Authors.Include(x => x.Books).ToList();
            }
        }

        // Updates the Author that the user has selected and saves the changes in the DB
        public void EditAuthor(EditAuthorViewModel viewModel)
        {
            using (var context = this.CreateContext())
            {
                context.Authors.Attach(viewModel.Author);
                viewModel.Author.FirstName = viewModel.FirstName;
                viewModel.Author.LastName = viewModel.LastName;
                viewModel.Author.BirthDate = viewModel.Birthday;
                context.SaveChanges();
            }
        }

        // Removes the Author from the database
        public void DeleteAuthor(Author author)
        {
            using (var context = this.CreateContext())
            {
                context.Authors.Attach(author);
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }

        // Calls a stored procedure to delete all Authors with no existing books
        public void SpDeleteAuthorsWithoutBooks()
        {
            using (var context = this.CreateContext())
            {
                context.sp_Delete_Authors_Without_Books();
                context.SaveChanges();
            }
        }

        // A query that returns all Authors born after a certain date
        public IEnumerable<Author> GetAuthorsBornAfterDate(DateTime date)
        {
            using (var context = this.CreateContext())
            {
                var authors = context.Authors.Include(x => x.Books);

                var query = from author in authors
                            where author.BirthDate >= date
                            select author;

                return query.ToList();
            }
        }

        private InventoryContext CreateContext()
        {
            switch (this.ConnectionType)
            {
                case ConnectionType.Sql:
                    return new SqlContext();
                case ConnectionType.Sqlite:
                    return new SqliteContext();
                case ConnectionType.Postgres:
                    return new PostgresContext();
                default:
                    throw new ArgumentOutOfRangeException(nameof(this.ConnectionType), this.ConnectionType, null);
            }
        }
    }
}
