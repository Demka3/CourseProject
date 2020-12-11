using System.Windows;

namespace CourseProject1.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EncryptWindow.xaml
    /// </summary>
    public partial class EncryptWindow : Window
    {        
        public EncryptWindow()
        {
            InitializeComponent();
            label.Content = $"Введите сообщение для шифровки (текущий ключ - {MainWindow.key}):";
        }

        private void readyButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(messageTextBox.Text))
            {
                MessageBox.Show("Вы ничего не ввели :(");
                return;
            }
            this.DialogResult = true;            
        }
    }
}
