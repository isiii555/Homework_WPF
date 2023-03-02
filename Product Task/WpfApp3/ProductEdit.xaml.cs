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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        public Product prodtemp { get; set; } = new();

        public Product prod { get; set; } = new();

        public ProductEdit(Product p)
        {
            prod = new Product()
            {
                productName = p.productName,
                productPicture = p.productPicture,
                productPrice = p.productPrice
            };
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(name_txt.Text != string.Empty && pic_txt.Text != string.Empty && Double.TryParse(price_txt.Text,out double _))
                {
                    prodtemp.productName = prod.productName;
                    prodtemp.productPrice = prod.productPrice;
                    prodtemp.productPicture = prod.productPicture;
                    MessageBox.Show("Success!", "Application", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please fill all sections", "Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    prod.productName = prodtemp.productName;
                    prod.productPrice = prodtemp.productPrice;
                    prod.productPicture = prodtemp.productPicture;
                }
            }
        }
    }
}
