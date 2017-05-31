using System.Windows.Controls;

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for ClientsView
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
        }

        private void AddClientClick(object sender, System.Windows.RoutedEventArgs e)
        {
            AddClient ac = new AddClient();
            ac.ShowDialog();
        }
    }
}
