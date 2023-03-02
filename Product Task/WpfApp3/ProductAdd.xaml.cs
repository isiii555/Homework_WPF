using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public ObservableCollection<Product> temp = new();

        public ObservableCollection<Product> products= new();
        public Product product { get; set; } = new();
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (product_name.Text != string.Empty && product_picture.Text != string.Empty)
            {
                temp.Add(product);
                products.Add(product);
                product = new Product();
                MessageBox.Show("Product succesfully added", "Application", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all sections", "Application", MessageBoxButton.OK, MessageBoxImage.Error);
                product = new Product();
            }
        }
    }
}
