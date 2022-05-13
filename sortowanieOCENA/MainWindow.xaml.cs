using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace sortowanieOCENA
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.FileName = @"Documenten";

            tekst tekstInfo = new tekst();
            string[] tekstArray;

            DataTable dt = new DataTable();
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Subject", typeof(string));

            using(StreamReader sr=new StreamReader(ofd.FileName))
            {
                while(!sr.EndOfStream)
                {
                    tekstArray = sr.ReadLine().Split(";");

                    tekstInfo.LastName = tekstArray[0];
                    tekstInfo.FirstName = tekstArray[1];
                    tekstInfo.Subject = tekstArray[2];

                    dt.Rows.Add(tekstArray);



                }
                DataView dv = new DataView(dt);
                dtGridView.ItemsSource = dv;
            }
        }
    }
}
