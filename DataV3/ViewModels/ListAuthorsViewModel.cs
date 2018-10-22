namespace DataV3.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataV3.Enums;
    using DataV3.Models;
    using DataV3.Services;

    public class ListAuthorsViewModel : ObservableViewModel
    {
        private IEnumerable<Author> authors;

        public ListAuthorsViewModel()
        {
            this.authors = new List<Author>();
            this.BirthdayFilterDate = DateTime.MinValue;
        }

        public IEnumerable<Author> Authors
        {
            get
            {
                return this.authors.OrderBy(a => a.FirstName).ThenBy(a => a.LastName).ToList();
            }

            set
            {
                this.authors = value;
                this.OnPropertyChanged();
            }
        }

        public Author SelectedAuthor { get; set; }

        public DateTime BirthdayFilterDate { get; set; }

        public bool IsBirthdayFilterApplied { get; set; }

        public bool StoredProceduresEnabled => DbManager.Instance.ConnectionType == ConnectionType.Sql;
    }
}
