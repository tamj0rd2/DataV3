namespace DataV3.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using DataV3.Enums;

    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            var connectionTypes = new List<ConnectionType> { ConnectionType.Sql, ConnectionType.Sqlite, ConnectionType.Postgres };
            this.ConnectionOptions = connectionTypes.Select(ct => new ConnectionViewModel(ct));
            this.SelectedIndex = 0;
        }

        public IEnumerable<ConnectionViewModel> ConnectionOptions { get; }

        public ConnectionViewModel SelectedConnection { get; set; }

        public int SelectedIndex { get; set; }
    }
}
