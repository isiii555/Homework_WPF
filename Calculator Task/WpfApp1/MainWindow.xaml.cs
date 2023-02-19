using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> process = new();
        string number = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void History_show()
        {
            History_lbl.Content = string.Empty;
            for (int i = 0; i < process.Count; i++)
            {
                History_lbl.Content += process[i];
            }
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b) {
                if (float.TryParse(b.Content.ToString(), out float c))
                {
                    
                    number += b.Content.ToString();
                    Answer_lbl.Content = number;
                    if(process.Count > 0)
                    {
                        if (History_lbl.Content.ToString() == "0")
                            History_lbl.Content = string.Empty;
                        History_show();
                    }
                    else
                        History_lbl.Content = number;
                }
                else
                {
                    if (b.Content.ToString() == "CE")
                    {
                        Answer_lbl.Content = "0";
                        number = string.Empty;
                    }
                    else if (b.Content.ToString() == "C")
                    {
                        process.Clear();
                        number = string.Empty;
                        Answer_lbl.Content = "0";
                        History_lbl.Content = "0";
                    }
                    else if(b.Content.ToString() == "%")
                    {
                        if(process.Count == 0)
                        {
                            process.Clear();
                            number = string.Empty;
                            Answer_lbl.Content = "0";
                            History_lbl.Content = "0";
                        }
                        else if(number == string.Empty)
                        {
                            float temp;
                            temp = Convert.ToSingle(process[0]) * Convert.ToSingle(process[2]) / 100;
                            process[2] = temp.ToString();
                            Answer_lbl.Content = temp.ToString();
                            History_show();
                        }
                        else
                        {
                            float temp;
                            temp = Convert.ToSingle(process[0]) * Convert.ToSingle(number) / 100;
                            process.Add(temp.ToString());
                            Answer_lbl.Content = temp.ToString();
                            number = string.Empty;
                            History_show();
                        }
                    }
                    else if(b.Content.ToString() == "√")
                    {
                        if (process.Count == 0)
                        {
                            process.Clear();
                            number = Math.Sqrt(Convert.ToDouble(number)).ToString();
                            Answer_lbl.Content = number;
                            History_lbl.Content = number;
                        }
                        else if (number == string.Empty)
                        {
                            if (process.Count == 3)
                            {
                                process[2] = Math.Sqrt(Convert.ToDouble(process[2])).ToString();
                                Answer_lbl.Content = process[2];
                            }
                            else if(process.Count == 2)
                            {
                                process[0] = Math.Sqrt(Convert.ToDouble(process[0])).ToString();
                                Answer_lbl.Content = process[0];
                            }
                            History_show();
                        }
                        else
                        {
                            number = Math.Sqrt(Convert.ToDouble(number)).ToString();
                            process.Add(number);
                            Answer_lbl.Content = number;
                            number = string.Empty;
                            History_show();
                        }
                    }
                    else if(b.Content.ToString() == "x²")
                    {
                        if (process.Count == 0)
                        {
                            process.Clear();
                            number = Math.Pow(Convert.ToSingle(number), 2).ToString();
                            Answer_lbl.Content = number;
                            History_lbl.Content = number;
                        }
                        else if(number == string.Empty) {
                            if (process.Count == 3)
                            {
                                process[2] = Math.Pow(Convert.ToSingle(process[2]),2).ToString();
                                Answer_lbl.Content = process[2];
                            }
                            else if (process.Count == 2)
                            {
                                process[0] = Math.Pow(Convert.ToSingle(process[0]),2).ToString();
                                Answer_lbl.Content = process[0];
                            }
                            History_show();
                        }
                        else
                        {
                            number = Math.Pow(Convert.ToSingle(number),2).ToString();
                            process.Add(number);
                            Answer_lbl.Content = number;
                            number = string.Empty;
                            History_show();
                        }
                    }
                    else if(b.Content.ToString() == "1/x")
                    {
                        try
                        {
                            if (process.Count == 0)
                            {
                                if (number != "0")
                                {
                                    process.Clear();
                                    number = (1 / Convert.ToSingle(number)).ToString();
                                    Answer_lbl.Content = number;
                                    History_lbl.Content = number;
                                }
                                else 
                                     throw new DivideByZeroException();
                            }
                            else if (number == string.Empty)
                            {
                                if (process.Count == 3)
                                {
                                    if (process[2] != "0")
                                    {
                                        process[2] = (1 / Convert.ToSingle(process[2])).ToString();
                                        Answer_lbl.Content = process[2];
                                    }
                                    else
                                        throw new DivideByZeroException();

                                }
                                else if (process.Count == 2)
                                {
                                    if (process[0] != "0")
                                    {
                                        process[0] = (1 / Convert.ToSingle(process[0])).ToString();
                                        Answer_lbl.Content = process[0];
                                    }
                                    else
                                        throw new DivideByZeroException();
                                }
                                History_show();
                            }
                            else
                            {
                                if (number != "0")
                                {
                                    number = (1 / Convert.ToSingle(number)).ToString();
                                    process.Add(number);
                                    Answer_lbl.Content = number;
                                    number = string.Empty;
                                    History_show();
                                }
                                else
                                    throw new DivideByZeroException();
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Cannot divide by zero");
                            number = string.Empty;
                        }
                    }
                    else if(b.Name == "remove_btn")
                    {
                        if (number != string.Empty)
                        {
                            string temp = Answer_lbl.Content.ToString();
                            temp  = temp.Remove(temp.Length- 1);
                            Answer_lbl.Content = temp;
                            number = temp;
                            History_show();
                        }
                    }
                    else if(b.Content.ToString() == "±")
                    {
                        if(process.Count == 0)
                        {
                            if (number == string.Empty)
                            {
                                number = "0";
                            }
                            number = (-1 * Convert.ToSingle(number)).ToString();
                            Answer_lbl.Content = number;
                            History_lbl.Content = number;
                        }
                        else if (number != string.Empty)
                        {
                            number = (Convert.ToSingle(number) * -1).ToString();
                            process.Add(number);
                            Answer_lbl.Content = number;
                            number = string.Empty;
                        }
                        else
                        {
                            number = (Convert.ToSingle(process[0]) * -1).ToString();
                            Answer_lbl.Content = number;
                            number = string.Empty;
                        }
                    }
                    else if(b.Content.ToString() == ".")
                    {
                        if (!Answer_lbl.Content.ToString().Contains(".") && !number.Contains("."))
                        {
                            Answer_lbl.Content += ".";
                            number += ".";
                        }
                        else
                            MessageBox.Show("This number is already float number");
                    }
                    else
                    {
                        if (number != string.Empty)
                        {
                            process.Add(number);
                            number = string.Empty;
                        }
                        if (process.Count == 1)
                        {
                            process.Add(b.Content.ToString()!);
                        }
                        else if (process.Count == 3)
                        {
                            if (float.TryParse(process[0], out float number1) && float.TryParse(process[2], out float number2))
                            {
                                if (process[1] == "+")
                                {
                                    process.Clear();
                                    process.Add((number1 + number2).ToString());
                                    process.Add(b.Content.ToString());
                                }
                                else if (process[1] == "-")
                                {
                                    process.Clear();
                                    process.Add((number1 - number2).ToString());
                                    process.Add(b.Content.ToString());
                                }
                                else if (process[1] == "X")
                                {
                                    process.Clear();
                                    process.Add((number1 * number2).ToString());
                                    process.Add(b.Content.ToString());
                                }
                                else if (process[1] == "/")
                                {
                                    if (number2 == 0)
                                    {
                                        MessageBox.Show("Cannot divide by zero!");
                                    }
                                    else
                                    {
                                        process.Clear();
                                        process.Add((number1 / number2).ToString());
                                        process.Add(b.Content.ToString());
                                    }
                                }
                                else if (process[1] == "=")
                                {
                                    string temp = process[2];
                                    process.Clear();
                                    process.Add(temp);
                                    process.Add(b.Content.ToString());
                                }
                            }
                            else
                                MessageBox.Show("ERROR");
                        }
                        else
                            process[1] = b.Content.ToString();
                        Answer_lbl.Content = process[0];
                        History_show();
                    }
                }
            }
        }
    }
}
