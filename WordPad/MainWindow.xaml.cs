using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WordPad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string currentPath = Environment.CurrentDirectory;
            currently_path.Content = "Path:" + currentPath;
        }
        string filePath = "Documents.txt";
        bool CheckAuto = false;
        private void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBox1.Text);
            MessageBox.Show("All Text Copied Sucssesfully", "Information");
        }

        private void FontFamilyBoldClick(object sender, RoutedEventArgs e)
        {
            if (TextBox1.FontWeight == FontWeights.Bold)
            {
                TextBox1.FontWeight = FontWeights.Normal;
            }
            else
            {
                TextBox1.FontWeight = FontWeights.Bold;
            }
        }

        private void FontFamilyItalicClick(object sender, RoutedEventArgs e)
        {
            if (TextBox1.FontStyle == FontStyles.Italic)
            {
                TextBox1.FontStyle = FontStyles.Normal;
            }
            else
            {
                TextBox1.FontStyle = FontStyles.Italic;
            }
        }

        private void SelectCombobox(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ComboBox1.SelectedIndex == 0)
                {
                    if (TextBox1.Text.Count() != 0)
                    {
                        TextBox1.FontSize = 10;
                    }
                }
                else if (ComboBox1.SelectedIndex == 1)
                {
                    TextBox1.FontSize = 12;
                }
                else if (ComboBox1.SelectedIndex == 2)
                {
                    TextBox1.FontSize = 14;
                }
                else if (ComboBox1.SelectedIndex == 3)
                {
                    TextBox1.FontSize = 16;
                }
                else if (ComboBox1.SelectedIndex == 4)
                {
                    TextBox1.FontSize = 18;
                }
                else if (ComboBox1.SelectedIndex == 5)
                {
                    TextBox1.FontSize = 20;
                }
                else if (ComboBox1.SelectedIndex == 6)
                {
                    TextBox1.FontSize = 22;
                }
                else if (ComboBox1.SelectedIndex == 7)
                {
                    TextBox1.FontSize = 24;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            string text = TextBox1.Text;
            WriteTextToFile(filePath, text);
        }


        private void WriteTextToFile(string filePath, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing Error");
            }
        }

        private void AutosaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CheckAuto == false)
            {
                AutoButton.Content = "+";
                AutoButton.Foreground = new SolidColorBrush(Colors.White);
                AutoButton.Width = 30;
                AutoButton.Height = 30;
                CheckAuto = true;
            }
            else
            {
                AutoButton.Content = " ";
                CheckAuto = false;
            }
        }

        private void CustomButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = false;
            saveFileDialog.ShowDialog();
        }

        private void PasteButtonClick(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                TextBox1.Text += clipboardText;
            }
            else
            {
                MessageBox.Show("Clipboard doesn't contain text data!", "Error");
            }
        }

        private void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            if (File.Exists(FileTextBox.Text + ".txt"))
            {
                filePath = FileTextBox.Text + ".txt";
                string fileContent = File.ReadAllText(filePath);
                TextBox1.Text = fileContent;
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(FileTextBox.Text + ".txt"))
                    {
                        writer.WriteLine(TextBox1.Text);
                    }

                    MessageBox.Show("File Created Succesfuly!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Certain Time Error!");
                }
                filePath = FileTextBox.Text + ".txt";

            }
        }

        private void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            if (CheckAuto == true)
            {
                string text = TextBox1.Text;

                WriteTextToFile(filePath, text);
            }
        }
    }
}

