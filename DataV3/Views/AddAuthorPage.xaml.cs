namespace DataV3.Views
{
    using System.Windows;

    using DataV3.Services;
    using DataV3.ViewModels;

    /// <summary>
    /// Interaction logic for AddAuthorPage.xaml
    /// </summary>
    public partial class AddAuthorPage
    {
        private readonly AddAuthorViewModel viewModel;

        public AddAuthorPage()
        {
            this.InitializeComponent();
            this.viewModel = new AddAuthorViewModel();
            this.DataContext = this.viewModel;
        }

        private void BtnAdd(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.IsValid)
            {
                DbManager.Instance.AddAuthor(this.viewModel);
                MessageBox.Show("Author added!");
                this.NavigationService?.GoBack();
            }
            else
            {
                MessageBox.Show("Couldn't add the user. Make sure you've typed in all details!");
            }
        }

        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.GoBack();
        }
    }
}
