using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaClient.MediaServiceReference;


namespace MediaClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AxWMPLib.AxWindowsMediaPlayer axWmp;
        public MainWindow()
        {
            InitializeComponent();

            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Create the ActiveX control.
            axWmp = new AxWMPLib.AxWindowsMediaPlayer();

            // Assign the ActiveX control as the host control's child.
            host.Child = axWmp;

            // Add the interop host control to the Grid
            // control's collection of child controls.
            this.grid1.Children.Add(host);
        }

        private void tableDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            MediaServiceClient client = new MediaServiceClient();
            grid.ItemsSource = client.GetTable();
        }

        private void tableDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            MyTable path = grid.SelectedItem as MyTable;
            if (path != null)
                axWmp.URL = path.Path;  
        }
    }
}
