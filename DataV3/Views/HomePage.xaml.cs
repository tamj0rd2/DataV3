namespace DataV3.Views
{
    using System.Linq;
    using System.Windows;

    using DataV3.Services;
    using DataV3.ViewModels;

    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage
    {
        private readonly HomePageViewModel viewModel;

        public HomePage()
        {
            this.InitializeComponent();
            this.viewModel = new HomePageViewModel();
            this.viewModel.SelectedConnection = this.viewModel.ConnectionOptions.First();
            this.DataContext = this.viewModel;
        }

        private void OnManageAuthorsClick(object sender, RoutedEventArgs e)
        {
            DbManager.Instance.ConnectionType = this.viewModel.SelectedConnection.ConnectionType;
            this.NavigationService?.Navigate(new ListAuthorsPage());
        }
    }
}
