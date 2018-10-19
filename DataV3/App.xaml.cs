namespace DataV3
{
    using System;
    using System.Linq;

    using DataV3.Models;
    using DataV3.Services;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var author = new Author { BirthDate = DateTime.Today, FirstName = "Tingle", LastName = "Francis" };

            using (var context = new MySqlContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }
    }
}
