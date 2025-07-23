using System;
using System.Windows;

namespace calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Close button
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Clear button
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetInputs(out double first, out double second))
            {
                double result = first + second;
                txt3.Text = result.ToString();
                historyList.Items.Add($"{first} + {second} = {result}");
            }
        }

        private void multipbtn_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetInputs(out double first, out double second))
            {
                double result = first * second;
                txt3.Text = result.ToString();
                historyList.Items.Add($"{first} × {second} = {result}");
            }
        }

        private void dividebtn_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetInputs(out double first, out double second))
            {
                if (second == 0)
                {
                    MessageBox.Show("Cannot divide by zero.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt3.Text = string.Empty;
                }
                else
                {
                    double result = first / second;
                    txt3.Text = result.ToString();
                    historyList.Items.Add($"{first} ÷ {second} = {result}");
                }
            }
        }

        private void percentbtn_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetInputs(out double first, out double second))
            {
                if (second == 0)
                {
                    MessageBox.Show("Cannot divide by zero.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt3.Text = string.Empty;
                }
                else
                {
                    double result = (first / second) * 100;
                    txt3.Text = result.ToString("F2") + "%";
                    historyList.Items.Add($"{first} % {second} = {result:F2}%");
                }
            }
        }

        private double memoryValue = 0;

        private void mplusbtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txt3.Text.Replace("%", ""), out double val))
            {
                memoryValue += val;
                MessageBox.Show($"Added to memory: {val}", "Memory", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No valid result to add to memory.", "Memory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void mminusbtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txt3.Text.Replace("%", ""), out double val))
            {
                memoryValue -= val;
                MessageBox.Show($"Subtracted from memory: {val}", "Memory", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No valid result to subtract from memory.", "Memory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void mrbtn_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = memoryValue.ToString();
        }

        private void mcbtn_Click(object sender, RoutedEventArgs e)
        {
            memoryValue = 0;
            MessageBox.Show("Memory cleared.", "Memory", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool TryGetInputs(out double first, out double second)
        {
            first = 0;
            second = 0;
            if (!double.TryParse(txt1.Text, out first))
            {
                MessageBox.Show("Please enter a valid first number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt3.Text = string.Empty;
                return false;
            }
            if (!double.TryParse(txt2.Text, out second))
            {
                MessageBox.Show("Please enter a valid second number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt3.Text = string.Empty;
                return false;
            }
            return true;
        }
    }
}