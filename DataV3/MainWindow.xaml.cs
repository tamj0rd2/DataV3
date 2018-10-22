namespace DataV3
{
    using System.Windows;

    using DataV3.Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.MainFrame.Navigate(new HomePage());
        }
    }
}
