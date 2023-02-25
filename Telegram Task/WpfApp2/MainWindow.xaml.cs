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
using Bogus;
using Emoji;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> contacts { get; set; } = new();

        public MainWindow()
        {
            this.Background = new SolidColorBrush(Colors.LightSkyBlue);
            InitializeComponent();
            contacts = new Faker<Person>().RuleFor(p => p.Avatar, f => f.Person.Avatar).RuleFor(p => p.FullName, f => f.Person.FullName).RuleFor(p => p.date , f => f.Date.Recent()).Generate(3);
            DataContext = this;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Conversation con = new()
                {
                    User = false,
                    Content = txt_box.Text.ToString(),
                    time = DateTime.Now
                };
                (List_view.SelectedItem as Person)?.ConversationList.Add(con);
                if (txt_box.Text.ToString().ToLower().StartsWith("salam aleyhim") || txt_box.Text.ToString().ToLower().EndsWith("salam aleyhim"))
                {
                    Conversation temp = new();
                    temp.User = true;
                    temp.Content = "Aleyhim salam";
                    temp.time = DateTime.Now;
                    (List_view.SelectedItem as Person)?.ConversationList.Add(temp);
                }
                else
                {
                    Conversation temp = new();
                    temp.User = true;
                    temp.Content = "nagaysan yeti";
                    temp.time = DateTime.Now;
                    (List_view.SelectedItem as Person)?.ConversationList.Add(temp);
                }
                //txt_box.Text = "Write a message";
                txt_box.Text = string.Empty;
                //txt_box.Foreground = new SolidColorBrush(Colors.Gray);
                List_view_MouseDoubleClick(List_view, null);
            }
        }

        private void List_view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grid1.IsEnabled = true;
            if (sender is ListView l)
            {
                
                Stackpnl.Children.Clear();
                var p = l.SelectedItem as Person;
                label_name.Content = p.FullName;
                for (int i = 0; i < p.ConversationList.Count; i++)
                {
                    StackPanel panel = new();
                    panel.MaxWidth = 600;
                    panel.Margin = new Thickness(5);

                    TextBlock text = new TextBlock();
                    text.TextWrapping = TextWrapping.Wrap;
                    text.Text = p.ConversationList[i].Content;
                    text.MaxWidth = 600;
                    text.FontSize = 22;
                    text.Margin = new Thickness(5);
                    panel.Children.Add(text);

                    TextBlock time = new();
                    time.Text = p.ConversationList[i].time.ToShortTimeString();
                    time.FontSize = 10;
                    time.FontStyle = FontStyles.Italic;
                    time.FontWeight= FontWeights.Bold;
                    time.HorizontalAlignment = HorizontalAlignment.Right;
                    time.Margin = new Thickness(5);

                    panel.Children.Add(time);
                    if (p.ConversationList[i].User == true)
                    {
                        panel.HorizontalAlignment = HorizontalAlignment.Left;
                        panel.Background = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        panel.HorizontalAlignment = HorizontalAlignment.Right;
                        panel.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                    }
                    Stackpnl.Children.Add(panel);
                }
            }
        }

        private void txt_box_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txt_box.Text == "Write a message")
            {
                txt_box.Text = string.Empty;
                txt_box.Foreground = new SolidColorBrush(Colors.Black);
                txt_box.FontStyle = FontStyles.Normal;
            }
        }

        private void txt_box_MouseLeave(object sender, MouseEventArgs e)
        {
            if(txt_box.Text == string.Empty)
            {
                txt_box.Foreground = new SolidColorBrush(Colors.Gray);
                txt_box.Text = "Write a message";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window win = new Window();

        }

        private void emoji_Picked(object sender, Emoji.Wpf.EmojiPickedEventArgs e)
        {
            var emo = emoji.Selection;
            if (txt_box.Text == "Write a message")
            {
                txt_box.Clear();
                txt_box.Foreground = new SolidColorBrush(Colors.Black);
                txt_box.Text += emo;
            }
            else
                txt_box.Text += emo;

        }
    }
}
