using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Product : INotifyPropertyChanged
    {
        private string productName1;
        private string productPicture1;
        private double productPrice1 = 0;

        public string productName { get => productName1; set
            {
                productName1 = value;
                PropertyChanging();
            }
        }
        public string productPicture { get => productPicture1; set
            {
                productPicture1 = value;
                PropertyChanging();
            }
        }
        public double productPrice
        { get => productPrice1; set
            {
                productPrice1 = value;
                PropertyChanging();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void PropertyChanging([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
