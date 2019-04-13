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
        /// <summary>
        /// ///////////////////////////////////////////////ДелениеДелениеДеление//////////////////////////////////////////////////////////////////
        /// </summary>
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TBdelimoe.Text = TBdelimoe.Text.Replace(".", ",");
            TBdelitel.Text = TBdelitel.Text.Replace(".", ",");
            try
            {
                prm.delim = Convert.ToDouble(TBdelimoe.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат данных", "Error", MessageBoxButton.OK);
            }
            try
            {
                prm.delit = Convert.ToDouble(TBdelitel.Text);
            }
            catch
            {
                MessageBox.Show("Неверный формат данных", "Error", MessageBoxButton.OK);
            }


            CounterDelitel(prm.delit);
            CounterDelimoe(prm.delim);

            int pDelim = CounterDelimoe(prm.delim);
            int pDelit = CounterDelitel(prm.delit);
            
            // отсечение запятой
            if (pDelim > pDelit)
            {
                prm.delimoe = Convert.ToInt32(prm.delim * Math.Pow(10, pDelim));
                prm.delitel = Convert.ToInt32(prm.delit * Math.Pow(10, pDelim));
                TBdelitel.Text = Convert.ToString(prm.delitel);
                TBdelimoe.Text = Convert.ToString(prm.delimoe);
            }
            else
            {
                prm.delimoe = Convert.ToInt32(prm.delim * Math.Pow(10, pDelit));
                prm.delitel = Convert.ToInt32(prm.delit * Math.Pow(10, pDelit));
                TBdelitel.Text = Convert.ToString(prm.delitel);
                TBdelimoe.Text = Convert.ToString(prm.delimoe);
            }


            label1.Content = Convert.ToString(prm.delimoe);
            label2.Content = Convert.ToString(prm.delitel);

            //длина делимого и делителя
            prm.delimoeln = Convert.ToInt16(Convert.ToString(prm.delimoe).Length);
            prm.delitelln = Convert.ToInt16(Convert.ToString(prm.delitel).Length);


            // ostatok(prm.delimoe, prm.delitel, prm.chastnoe);
            ost(prm.delimoe, prm.delitel);
            
            res.Content = Convert.ToString(prm.celoe + "."+ prm.ostatok );

            

        }
        public static int ost(int delimoe, int delitel)
        {
            prm.ostatok = "";
           // prm.celoe = prm.delimoe / prm.delitel;

            prm.ostat = prm.delimoe;
            prm.result = prm.celoe;
            Console.WriteLine("celoe " + prm.celoe);
          //расчёт остатка
            for (int i = 0; i<15; i++)
            {
                prm.ostat = prm.ostat - (prm.result * prm.delitel);
               // Console.WriteLine("ostat ");
                //Console.WriteLine(prm.ostat);
                if (prm.ostat < prm.delitel)
                {
                    prm.ostat = Convert.ToInt32(Convert.ToString(prm.ostat) + "0");
                }
                prm.result = prm.ostat / prm.delitel;
               // Console.WriteLine("result ");
               // Console.WriteLine(prm.result);
                prm.ostatok = prm.ostatok + Convert.ToString(prm.result);
                //Console.WriteLine("ostatok ");
               // Console.WriteLine(prm.ostatok);
            }
                return prm.ostat;
        }
        
      
        // кол-во символов после запятой в делимом
        public static int CounterDelimoe(double delimoe)
        {
            return delimoe.ToString().Substring(delimoe.ToString().IndexOf(",") + 1).Length;
        }
        // в делителе
        public static int CounterDelitel(double delitel)
        {
            return delitel.ToString().Substring(delitel.ToString().IndexOf(",") + 1).Length;
        }





        ////////////////////////////////////////////////////////////////////////////////////////////////////ДелениеДелениеДеление/////////////////////////
        ///
        //Умножение


       
        private void Umnj_Click(object sender, RoutedEventArgs e)
        {
            mn1.Text = mn1.Text.Replace(".", ",");
            mn2.Text = mn2.Text.Replace(".", ",");
                prm.mnj1 = Convert.ToDouble(mn1.Text);
                prm.mnj2 = Convert.ToDouble(mn2.Text);
            string s = umnozh(prm.mnj1, prm.mnj2);
            resmn.Content= s;
        }
       
        private static string umnozh(double mnj1, double mnj2)
        {
            string add = "";
            string result = "";
            foreach (char c in mnj1.ToString().Reverse())
            {
                result += char.GetNumericValue(c) * mnj2 + add + "\r\n" + "+" + "\r\n";
                add += "0";
            }
            result += "__________\r\n";
            result += mnj1 * mnj2;
            return result;
        }
        /////////////Умножение///////////////////////////////////////////////////////////////////////////
    }

}
