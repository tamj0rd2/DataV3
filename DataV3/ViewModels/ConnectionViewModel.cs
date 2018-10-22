namespace DataV3.ViewModels
{
    using DataV3.Enums;

    public class ConnectionViewModel
    {
        public ConnectionViewModel(ConnectionType connectionType)
        {
            this.ConnectionType = connectionType;
        }

        public ConnectionType ConnectionType { get; }

        public string Text => this.ConnectionType.ToString();
    }
}
