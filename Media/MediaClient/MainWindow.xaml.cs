using System;
using System.Collections.Generic;
using System.Linq;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MediaClient.MediaDbDataSet mediaDbDataSet = ((MediaClient.MediaDbDataSet)(this.FindResource("mediaDbDataSet")));
            // Load data into the table Table. You can modify this code as needed.
            MediaClient.MediaDbDataSetTableAdapters.TableTableAdapter mediaDbDataSetTableTableAdapter = new MediaClient.MediaDbDataSetTableAdapters.TableTableAdapter();
            mediaDbDataSetTableTableAdapter.Fill(mediaDbDataSet.Table);
            System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tableViewSource.View.MoveCurrentToFirst();
        }
        private void tableDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            System.Data.DataRowView row = grid.SelectedItem as System.Data.DataRowView;
            if (row != null)
                axWmp.URL = row[4].ToString();
            
        }
    }
}
