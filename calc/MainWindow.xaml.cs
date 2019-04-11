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

namespace calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double delimoe = 0;
        double delitel = 0;
        double chastnoe = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TBdelimoe.Text = TBdelimoe.Text.Replace(".", ",");
            TBdelitel.Text = TBdelitel.Text.Replace(".", ",");
            try
            {
                delimoe = Convert.ToDouble(TBdelimoe.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат данных", "Error", MessageBoxButton.OK);
            }
            try
            {
                delitel = Convert.ToDouble(TBdelitel.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат данных", "Error", MessageBoxButton.OK);
            }
            
             
            chastnoe = delimoe / delitel;

            // это будет что-то тип вывода результата
           // for (int i = 0; i < 100; i++)
            //{
                TBResult.Text = Convert.ToString(chastnoe); 
        //    }
        }
    }
}
