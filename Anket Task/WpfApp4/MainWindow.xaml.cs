using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public ObservableCollection<Person> Persons
        {
            get { return (ObservableCollection<Person>)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        
        // Using a DependencyProperty as the backing store for Persons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersonsProperty =
            DependencyProperty.Register("Persons", typeof(ObservableCollection<Person>), typeof(MainWindow));

        public MainWindow()
        {
            Persons = new ObservableCollection<Person>();
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.Content.ToString() == "Elave et")
                {
                    if (name_txt.Text != string.Empty && surname_txt.Text != string.Empty && email_txt.Text != string.Empty && tel_txt.Text != string.Empty && birtday_date.Text != string.Empty)
                    {
                        Persons.Add(new Person()
                        {
                            Name = name_txt.Text,
                            Surname = surname_txt.Text,
                            Email = email_txt.Text,
                            Number = tel_txt.Text,
                            Date = birtday_date.Text
                        });
                    }
                    else
                    {
                        MessageBox.Show("Please fill all sections", "Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if(b.Content.ToString() == "Deyishdir") {
                    if (members_list.SelectedItem is Person p)
                    {
                        p.Name = name_txt.Text;
                        p.Surname = surname_txt.Text;
                        p.Number = tel_txt.Text;
                        p.Email = email_txt.Text;
                        p.Date = birtday_date.Text;
                        b.Content = "Elave et";
                        name_txt.Text = string.Empty;
                        surname_txt.Text = string.Empty;
                        tel_txt.Text = string.Empty;
                        email_txt.Text = string.Empty;
                        birtday_date.Text = string.Empty;

                    }
                }
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(sender is ListBox l)
            {
                if(l.SelectedItem is Person person)
                {
                    name_txt.Text = person.Name;
                    surname_txt.Text=person.Surname;
                    email_txt.Text=person.Email;
                    tel_txt.Text = person.Number;
                    birtday_date.Text = person.Date;
                    add_btn.Content = "Deyishdir";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var json = File.ReadAllText(filename_txt.Text + ".json");
                Persons = JsonSerializer.Deserialize<ObservableCollection<Person>>(json);
                filename_txt.Text = string.Empty;
                MessageBox.Show("Loaded", "Application", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(FileNotFoundException d) {
                MessageBox.Show("File not found", "Application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (members_list.ItemsSource is ObservableCollection<Person> list)
            {
                if (list.Count > 0)
                {
                    if (filename_txt.Text != string.Empty && filename_txt.Text != "Enter file name " && !filename_txt.Text.Contains('"'))
                    {
                        var json = JsonSerializer.Serialize(Persons);
                        File.WriteAllText($"{filename_txt.Text}.json", json);
                        MessageBox.Show("Saved", "Application", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Please enter file name correctly", "Application", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Your list is empty", "Application", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void filename_txt_MouseEnter(object sender, MouseEventArgs e)
        {
            if(filename_txt.Text == "Enter file name(ex:newfile)")
            {
                filename_txt.Text = string.Empty;
                filename_txt.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void filename_txt_MouseLeave(object sender, MouseEventArgs e)
        {
            if (filename_txt.Text == string.Empty)
            {
                filename_txt.Foreground = new SolidColorBrush(Colors.Gray);
                filename_txt.Text = "Enter file name(ex:newfile)";
            }
        }
    }
}
