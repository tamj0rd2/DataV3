namespace DataV3.Views
{
    using System.Windows;

    using DataV3.Models;
    using DataV3.Services;
    using DataV3.ViewModels;

    /// <summary>
    /// Interaction logic for EditAuthorPage.xaml
    /// </summary>
    public partial class EditAuthorPage
    {
        private readonly EditAuthorViewModel viewModel;

        public EditAuthorPage(Author author)
        {
            this.InitializeComponent();
            this.viewModel = new EditAuthorViewModel(author);
            this.DataContext = this.viewModel;
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.IsValid)
            {
                DbManager.Instance.EditAuthor(this.viewModel);
                MessageBox.Show("Changes saved :)");
                this.NavigationService?.GoBack();
            }
            else
            {
                MessageBox.Show("Couldn't edit the user. Make sure you've typed in all details!");
            }
        }

        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.GoBack();
        }
    }
}
