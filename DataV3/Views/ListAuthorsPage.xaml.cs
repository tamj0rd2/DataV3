namespace DataV3.Views
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    using DataV3.Models;
    using DataV3.Services;
    using DataV3.ViewModels;

    /// <summary>
    /// Interaction logic for ListAuthorsPage.xaml
    /// </summary>
    public partial class ListAuthorsPage
    {
        private readonly ListAuthorsViewModel viewModel;

        public ListAuthorsPage()
        {
            this.InitializeComponent();
            this.viewModel = new ListAuthorsViewModel();
            this.DataContext = this.viewModel;
        }

        private void BtnAddAuthor(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new AddAuthorPage());
        }

        private void BtnEditAuthor(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new EditAuthorPage(this.viewModel.SelectedAuthor));
        }

        private void BtnDeleteAuthor(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.SelectedAuthor == null)
            {
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the author {this.viewModel.SelectedAuthor.FirstName}?",
                "Author Management",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                DbManager.Instance.DeleteAuthor(this.viewModel.SelectedAuthor);
                this.UpdateAuthors();
                MessageBox.Show("Author deleted");
            }
            else
            {
                MessageBox.Show("No changes have been made");
            }
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.GoBack();
        }

        private void BtnFilterAuthorsOn(object sender, RoutedEventArgs e)
        {
            this.BirthdayFilterDateChanged(null, null);
        }

        private void BtnFilterAuthorsOff(object sender, RoutedEventArgs e)
        {
            this.UpdateAuthors();
        }

        private void BirthdayFilterDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.viewModel.IsBirthdayFilterApplied)
            {
                var date = this.viewModel.BirthdayFilterDate;
                var filteredAuthors = DbManager.Instance.GetAuthorsBornAfterDate(date);
                this.UpdateAuthors(filteredAuthors);
            }
        }

        private void BtnDeleteAuthorsWithNoBooks(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                $"Are you sure you want to delete all authors with no books?",
                "Author Management",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                DbManager.Instance.SpDeleteAuthorsWithoutBooks();
                this.UpdateAuthors();
                MessageBox.Show("Authors deleted");
            }
            else
            {
                MessageBox.Show("No changes have been made");
            }
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            this.UpdateAuthors();
        }

        private void UpdateAuthors(IEnumerable<Author> authors = null)
        {
            this.viewModel.Authors = authors ?? DbManager.Instance.GetAuthors();
        }
    }
}
