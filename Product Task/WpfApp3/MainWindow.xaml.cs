using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfApp3;

namespace WpfApp3
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> database = new()
        {
            new Product()
            {
                productName = "Cola",
                productPicture = "https://www.bakenroll.az/en/image/coca-cola.jpg",
                productPrice = 2
            },
            new Product()
            {
                productName = "Fanta",
                productPicture = "https://www.bakenroll.az/en/image/fanta.jpg",
                productPrice = 3
            },
            new Product()
            {
                productName = "Sprite",
                productPicture = "https://www.bakenroll.az/en/image/sprite-1.jpg",
                productPrice = 4
            },
        };
        public ObservableCollection<Product> products { get; set; } = new();

        public ObservableCollection<Product> Cart { get; set; } = new();

        public MainWindow()
        {
            for (int i = 0; i < database.Count; i++)
            {
                products.Add(database[i]);
            }
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if (b.DataContext is Product p)
                {
                    Cart.Add(p);
                    MessageBox.Show("Product added to cart", "Application", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 window = new();
            window.Price = 0;
            window.Cart = this.Cart;
            for (int i = 0; i < window.Cart.Count; i++)
            {
                window.Price += window.Cart[i].productPrice;
            }
            window.Show();
        }

        private void TextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (search_box.Text == "Search")
            {
                search_box.Text = string.Empty;
            }
        }

        private void TextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (search_box.Text == string.Empty)
            {
                search_box.Text = "Search";
            }
        }

        private void search_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search_box.Text != "Search" && search_box.Text != string.Empty)
            {
                var list = new ObservableCollection<Product>();
                for (int i = 0; i < database.Count; i++)
                {
                    if (database[i].productName.ToUpper().StartsWith(search_box.Text.ToUpper()))
                    {
                        list.Add(database[i]);
                    }
                }
                if (list.Count > 0)
                {
                    products.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        products.Add(list[i]);
                    }
                }
                else
                {
                    products.Clear();
                }
            }
            else if (search_box.Text == string.Empty)
            {
                products.Clear();
                for (int i = 0; i < database.Count; i++)
                {
                    products.Add(database[i]);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 window = new();
            window.temp = database;
            window.products = products;
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (sender is Button l) {
                if(l.DataContext is Product p)
                {
                    ProductEdit window = new ProductEdit(p);
                    window.prodtemp = p;
                    window.Show();
                }
            }
        }
    }
}
