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
using System.Windows.Shapes;

namespace CourseProject1.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для EnterFileNameWindow.xaml
    /// </summary>
    public partial class EnterFileNameWindow : Window
    {
        public EnterFileNameWindow()
        {
            InitializeComponent();
        }

        private void readyButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pathToFileTextBox.Text))
            {
                MessageBox.Show("Вы ничего не ввели :(");
                return;
            }
            this.DialogResult = true;
        }
    }
}
