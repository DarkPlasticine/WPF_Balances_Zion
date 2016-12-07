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
using Microsoft.Win32;
using System.IO;

namespace WPF_Balances_Zion
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Balances> _listB = new List<Balances>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.DefaultExt = ".txt";
            opnDlg.Filter = "(.txt)|*.txt";

            string file ="";

            if (opnDlg.ShowDialog() == true)
            {
                file = opnDlg.FileName;
            }

            using (StreamReader sr = new StreamReader(file, Encoding.Default))
            {
                _listB.Clear();
                string _tmp = "";
                
                while ((_tmp = sr.ReadLine()) != null) 
                {
                    Balances bal = new Balances();
                    string sep = "\t";
                    String[] sb;
                    sb = _tmp.Split(sep.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    bal.Name = sb[0];
                    bal.Count = Convert.ToInt32(sb[1].Split('.')[0]);
                    bal.Current = 0;
                    // _listB.Add(new Balances {Name=sb[0], Count=Convert.ToInt32(sb[1]), Current=0 });
                    _listB.Add(bal);
                }
                
            }

            lstvDB.ItemsSource = _listB;
            
        }

        public class Balances
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public int Current { get; set; }
        }
    }
}
