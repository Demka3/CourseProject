using System.Windows;

namespace CourseProject1.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EncryptWindow.xaml
    /// </summary>
    public partial class EncryptWindow : Window
    {
        internal bool isReady = false;
        public EncryptWindow()
        {
            InitializeComponent();
            label.Content = $"Введите сообщение для шифровки (текущий ключ - {MainWindow.key}):";
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(messageTextBox.Text))
            {
                MessageBox.Show("Вы ничего не ввели :(");
                return;
            }
            this.isReady = true;
            this.Close();
        }

        private void messageTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key==System.Windows.Input.Key.Enter)
            {
                messageTextBox.Text += "\n";
                messageTextBox.CaretIndex = messageTextBox.Text.Length;
            }
        }
    }
}
