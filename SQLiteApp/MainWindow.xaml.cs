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

namespace SQLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
            
        }

        private void btn_add_data_Click(object sender, RoutedEventArgs e)
        {   
            if (txt_first_name.Text == "")
            {
                MessageBox.Show("please input your name","ERROR");
            }
            else
            {
                DataAccess.AddData(txt_first_name.Text);
                txt_first_name.Clear();
            }
        }

        private void btn_show_db_Click(object sender, RoutedEventArgs e)
        {
            string show = "";
            foreach(string first_name in DataAccess.GetData())
            {
                show = show + first_name+"\n";
            }
            MessageBox.Show(show);
        }
    }
}
