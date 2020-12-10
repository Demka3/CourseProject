using System.Windows;

namespace CourseProject1.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EnterKeyWindow.xaml
    /// </summary>
    public partial class EnterKeyWindow : Window
    {
        public EnterKeyWindow()
        {
            InitializeComponent();
        }

        private void readyButton_Click(object sender, RoutedEventArgs e)
        {
            bool isKeyValid = true;
            if (string.IsNullOrEmpty(newKeyTextBox.Text))
            {
                MessageBox.Show("Вы ничего не ввели :(");
                return;
            }
            foreach (var item in newKeyTextBox.Text)
            {
                if (!EncryptionAlgorithm.rusAlphabet.Contains(char.ToLower(item)))
                {
                    isKeyValid = false;
                }
            }
            if (isKeyValid)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите руские буквы без пробелов!");
                return;
            }
        }
    }
}
