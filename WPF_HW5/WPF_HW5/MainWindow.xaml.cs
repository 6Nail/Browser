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

namespace WPF_HW5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TabItem TabItem { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControlLoaded(object sender, RoutedEventArgs e)
        {
            tabControl = (sender as TabControl);
        }

        private void searchByUrlButtonClick(object sender, RoutedEventArgs e)
        {
            WebBrowser browser = new WebBrowser();
            browser.Navigate($"https://{searchByUrl.Text}");

            TabItem = new TabItem
            {
                Height = 20,
                Width = 100,
                Header = searchByUrl.Text,
                Content = (browser as WebBrowser)
            };

            TabItem.MouseDoubleClick += tabItemMouseDoubleClick;

            tabControl.Items.Add(TabItem);

            TabItem.IsSelected = true;

            searchByUrl.Clear();
        }

        private void tabItemMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tabControl.Items.Remove(tabControl.SelectedItem);
        }
    }
}
