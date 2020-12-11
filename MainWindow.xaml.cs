using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using CourseProject1.DialogWindows;
using System;

namespace CourseProject1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static string key = "скорпион";
        public MainWindow()
        {
            InitializeComponent();
        }

        // Выбор текстового файла, расшифровка и вывод результата
        private void fileOpenButton_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();
                    AskEncodingTypeWindow askEncodingTypeWindow = new AskEncodingTypeWindow();
                    if (askEncodingTypeWindow.ShowDialog()==true)
                    {
                        SelectEncodingType selectEncodingType = new SelectEncodingType();
                        if (selectEncodingType.ShowDialog()==true)
                        {
                            fileContent = GetStringFromFile(fileStream, selectEncodingType.encodingTypesComboBox.Text);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            Encoding type = EncodingType.GetEncodingType(openFileDialog.FileName);
                            if (type == Encoding.UTF8)
                            {
                                using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                            }
                            else if (type == Encoding.Default)
                            {
                                using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                            }
                            else if (type == Encoding.Unicode)
                            {
                                using (StreamReader reader = new StreamReader(fileStream, Encoding.Unicode))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                            }
                            else if (type == Encoding.BigEndianUnicode)
                            {
                                using (StreamReader reader = new StreamReader(fileStream, Encoding.BigEndianUnicode))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не удалось определить кодировку файла :(");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Не удалось определить кодировку файла :(");
                        }
                    }      
                }
            }
            encryptDecryptLabel.Content = "Расшифровано:";
            encryptDecryptLabel.Visibility = Visibility.Visible;
            textScrollViewer.Visibility = Visibility.Visible;
            decryptedTextBlock.Text = EncryptionAlgorithm.GetDecryptedString(fileContent, key);
        }

        // Смена ключа
        private void enterKeyButton_Click(object sender, RoutedEventArgs e)
        {
            EnterKeyWindow enterKeyWindow = new EnterKeyWindow();
            if (enterKeyWindow.ShowDialog() == true)
            {
                key = enterKeyWindow.newKeyTextBox.Text.ToLower();
            }
            else
            {
                return;
            }
        }

        // Показ ключа
        private void showKeyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(key);
        }

        // Сохранение информации на экране (как расшифрованной, так и зашифрованной) в файл
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        // Ввод пользователем строки с последующей шифровкой и записью в файл
        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptWindow encryptWindow = new EncryptWindow();
            
            if (encryptWindow.ShowDialog()==true)
            {
                encryptDecryptLabel.Content = "Зашифровано:";
                encryptDecryptLabel.Visibility = Visibility.Visible;
                textScrollViewer.Visibility = Visibility.Visible;
                decryptedTextBlock.Text = EncryptionAlgorithm.GetEncryptedString(encryptWindow.messageTextBox.Text, key);
                SaveFile();
            }
            else
            {
                return;
            }
        }

        // Запись в файл с выбранным именеи в выбранную директорию
        private void SaveFile()
        {
            if (string.IsNullOrEmpty(decryptedTextBlock.Text))
            {
                MessageBox.Show("Нечего сохранять :(");
                return;
            }
            string fileName = "";
            EnterFileNameWindow enterFileNameWindow = new EnterFileNameWindow();
            if (enterFileNameWindow.ShowDialog() == true)
            {
                fileName = enterFileNameWindow.pathToFileTextBox.Text;
            }
            else
            {
                return;
            }
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (string.IsNullOrEmpty(folderBrowser.SelectedPath))
            {
                return;
            }
            using (FileStream fs = File.Create(folderBrowser.SelectedPath + "\\" + fileName + ".txt"))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(decryptedTextBlock.Text);
                }
            }
            MessageBox.Show("Сохранено!");
        }
        private static string GetStringFromFile(Stream fileStream, string encodingType)
        {
            switch (encodingType)
            {
                case "ANSI":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding(1251)))
                    {
                        return reader.ReadToEnd();
                    }
                case "UTF8":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                case "UTF7":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF7))
                    {
                        return reader.ReadToEnd();
                    }
                case "UTF32":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF32))
                    {
                        return reader.ReadToEnd();
                    }
                case "ASCII":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.ASCII))
                    {
                        return reader.ReadToEnd();
                    }
                case "Unicode":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                case "Big Endian Unicode":
                    using (StreamReader reader = new StreamReader(fileStream, Encoding.BigEndianUnicode))
                    {
                        return reader.ReadToEnd();
                    }
            }
            return "Абра Кадабра!";
        }
    }
}
