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
    /// Логика взаимодействия для AskEncodingTypeWindow.xaml
    /// </summary>
    public partial class AskEncodingTypeWindow : Window
    {
        public AskEncodingTypeWindow()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {            
            this.DialogResult = true;
        }
    }
}
