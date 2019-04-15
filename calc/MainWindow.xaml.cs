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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// ///////////////////////////////////////////////ДелениеДелениеДеление//////////////////////////////////////////////////////////////////
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

            //  label1.Content = Convert.ToString(prm.delimoe);
            //  label2.Content = Convert.ToString(prm.delitel);

            //длина делимого и делителя
            prm.delimoeln = Convert.ToInt16(Convert.ToString(prm.delimoe).Length);
            prm.delitelln = Convert.ToInt16(Convert.ToString(prm.delitel).Length);

            ost(prm.delimoe, prm.delitel);
            divres.Content = Convert.ToString(prm.znak + prm.celoe + "." + prm.ostatok);
        }
        public static int ost(int delimoe, int delitel)
        {
            prm.ostatok = "";
            prm.znak = "";
            if (prm.delitel < 0 ^ prm.delimoe < 0)
            {
                prm.znak = "-";
            }
            prm.delitel = Math.Abs(prm.delitel);
            prm.delimoe = Math.Abs(prm.delimoe);

            prm.celoe = prm.delimoe / prm.delitel;
            prm.ostat = prm.delimoe;
            prm.result = prm.celoe;
            Console.WriteLine("celoe " + prm.celoe);
            //расчёт остатка
            for (int i = 0; i < 15; i++)
            {
                prm.ostat = prm.ostat - (prm.result * prm.delitel);
                if (prm.ostat == 0)
                {
                    break;
                }

                //resdel.Content =
                Console.WriteLine("ostat " + prm.ostat);               // ("ostat " + prm.ostat);
                if (prm.ostat < prm.delitel)
                {
                    prm.ostat = Convert.ToInt32(Convert.ToString(prm.ostat) + "0");
                }
                prm.result = prm.ostat / prm.delitel;
                //resdel.Content = ("result " + prm.result);
                Console.WriteLine("result " + prm.result);
                prm.ostatok = prm.ostatok + Convert.ToString(prm.result);
                Console.WriteLine("ostatok " + prm.ostatok);

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
        //Умножение
        private void Umnj_Click(object sender, RoutedEventArgs e)
        {
            mn1.Text = mn1.Text.Replace(".", ",");
            mn2.Text = mn2.Text.Replace(".", ",");
            prm.mnj1 = Convert.ToDouble(mn1.Text);
            prm.mnj2 = Convert.ToDouble(mn2.Text);
            string res = umnozh(prm.mnj1, prm.mnj2);
            resmn.Content = res;
        }

        private static string umnozh(double mnj1, double mnj2)
        {
            string add = "";
            string result = "";
            // double res = 0;
            foreach (char c in mnj1.ToString().Reverse())
            {
                result += char.GetNumericValue(c) * mnj2 + add + "\r\n" + "+" + "\r\n";
                //res += char.GetNumericValue(c) * mnj2;
                //Console.WriteLine(res);
                add += "0";
            }
            result += "__________\r\n";

            result += mnj1 * mnj2;
            return result;
        }
        /////////////Умножение///////////////////////////////////////////////////////////////////////////

        //// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-//////////////////
        ///-----
         // колво знаков после запятой в уменьшаемом
       //  в вычитаемом
        public static int Countervic(string vichetaemoe)
        {
            string[] zap = vichetaemoe.Split(',');
            if (zap.Length < 2)
            {
                return 0;
            }
            else 
            // return prm.vichetaemoe.ToString().Substring(prm.vichetaemoe.ToString().IndexOf(",") + 1).Length;
            return vichetaemoe.Split(',')[1].Length;            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            umensh.Text = umensh.Text.Replace(".", ",");
            vich.Text = vich.Text.Replace(".", ",");
            try
            {
                prm.umenshaemoe = umensh.Text;
            }
            catch
            {
                MessageBox.Show("Неверный формат данных", "Error", MessageBoxButton.OK);
            }
            try
            {
                prm.vichetaemoe =vich.Text;
            }
            catch
            {
                MessageBox.Show("Неверный формат данных", "Error", MessageBoxButton.OK);
            }

            int shumensh = Countervic(prm.umenshaemoe);
            int shvich = Countervic(prm.vichetaemoe);

            prm.bolsh = (shumensh > shvich) ? shumensh : shvich;
            

            dlumns.Content = shumensh;
            dlvct.Content = shvich;
            prm.vichet = Convert.ToString(prm.vichetaemoe);
            prm.umenshm = Convert.ToString(prm.umenshaemoe);
            
            if (shumensh > shvich)
            {
                int k = shumensh - shvich;
                for (int i = 0; i < k; i++)
                {
                    prm.vichet = prm.vichet + "0";
                    vich.Text = prm.vichet;
                }
            }
            else
            {
                int k = shvich - shumensh;
                for (int i = 0; i < k; i++)
                {
                    prm.umenshm = prm.umenshm + "0";
                    umensh.Text = prm.umenshm;
                }
            }

            string celumendl = Convert.ToString(Math.Truncate(Convert.ToDouble(prm.umenshaemoe)));
            string celvichdl = Convert.ToString(Math.Truncate(Convert.ToDouble(prm.vichetaemoe)));
            umdl.Content = celumendl.Length;
            vcdl.Content = celvichdl.Length;

            if (celumendl.Length > celvichdl.Length)
            {
                int k = celumendl.Length - celvichdl.Length;
                for (int i = 0; i < k; i++)
                {
                    prm.vichet = prm.vichet.Insert(0, "0");
                    vich.Text = prm.vichet;
                }
            }
            else
            {
                int k = celvichdl.Length - celumendl.Length;
                for (int i = 0; i < k; i++)
                {
                    prm.umenshm = prm.umenshm.Insert(0, "0");
                    umensh.Text = prm.umenshm;
                    
                }
            }

            if (cbpm.SelectedIndex == 0)
            {
                slozh();
            }
            if (cbpm.SelectedIndex == 1)
            {
                viche();
            }
            Console.WriteLine("prm.res " + prm.res);
            
            vicres.Content = slozh();
        }
        
        /// //////сложение сложение сложение
        
        public static string slozh()
        { int k = 0;
            prm.res = "";
            int j = prm.umenshm.Length;
            int per = 0;
            
            Console.WriteLine(prm.umenshm);
            Console.WriteLine(prm.vichet);
            prm.umenshm = prm.umenshm.Replace(",", "");
            prm.vichet = prm.vichet.Replace(",", "");
            for (int i = prm.umenshm.Length; i > 0 ; i--)
            {
                
                char um = prm.umenshm[prm.umenshm.Length-1 - k];
                Console.WriteLine("um "+um);
                char vic = prm.vichet[prm.vichet.Length-1 - k];
                Console.WriteLine("vic "+vic);
                int um1 = Convert.ToInt32(Convert.ToString(um));
                Console.WriteLine("um1 "+um1);
                int vc1 = Convert.ToInt32(Convert.ToString(vic));
                Console.WriteLine("vc1 "+vc1);
                prm.res = Convert.ToString((um1 + vc1 +per)%10) + prm.res;
                
                per = Convert.ToInt32((um1 + vc1 + per)/10);
                Console.WriteLine("per " + per);
                
               
                Console.WriteLine("res "+prm.res);
                k++;
                Console.WriteLine("k "+k);
            }
            if (per != 0)
            {
                prm.res = Convert.ToString(per) + prm.res;
            }

            prm.res = prm.res.Insert(prm.res.Length - prm.bolsh , ",");

            return prm.res ;
        }

/// ////////////// вычитание вычитание вычитание//////


        public static string viche()
        {
            int k = 0;
            prm.res = "";
            int j = prm.umenshm.Length;
            int per = 0;

            Console.WriteLine(prm.umenshm);
            Console.WriteLine(prm.vichet);
            prm.umenshm = prm.umenshm.Replace(",", "");
            prm.vichet = prm.vichet.Replace(",", "");
            for (int i = prm.umenshm.Length; i > 0; i--)
            {

                char um = prm.umenshm[prm.umenshm.Length - 1 - k];
                Console.WriteLine("um " + um);
                char vic = prm.vichet[prm.vichet.Length - 1 - k];
                Console.WriteLine("vic " + vic);
                int um1 = Convert.ToInt32(Convert.ToString(um));
                Console.WriteLine("um1 " + um1);
                int vc1 = Convert.ToInt32(Convert.ToString(vic));
                Console.WriteLine("vc1 " + vc1);
                prm.res = Convert.ToString((um1 - vc1 + per) % 10) + prm.res;

                per = Convert.ToInt32((um1 - vc1 + per) / 10);
                Console.WriteLine("per " + per);


                Console.WriteLine("res " + prm.res);
                k++;
                Console.WriteLine("k " + k);
            }
            if (per != 0)
            {
                prm.res = Convert.ToString(per) + prm.res;
            }

            prm.res = prm.res.Insert(prm.res.Length - prm.bolsh, ",");

            return prm.res;
        }
    }

}
