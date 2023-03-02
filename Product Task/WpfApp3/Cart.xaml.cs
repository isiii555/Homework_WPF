using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window,INotifyPropertyChanged
    {
        public ObservableCollection<Product> Cart { get; set; } = new();

        private double price = 0;
        public double Price
        {
            get { return price; }
            set { price = value;
                OnPropertyChanged();
            }
        }

        public Window2()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cart.Clear();
            Price = 0;
            MessageBox.Show("Thanks for shopping", "Application", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
