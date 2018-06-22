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
using System.Threading;
using Microsoft.Win32;
using System.Text;

namespace Engl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Filter f1;
        Addwin add;
        Engl.MainModel.ViewMain VievMain;
     public    Engl.Verbs.VerbsLern verbs;

        Engl.MainModel.MethodsForModel main = new MainModel.MethodsForModel();
        public MainWindow()
        {
            InitializeComponent();
            VievMain = new Engl.MainModel.ViewMain(this);
           


        }
        public event EventHandler StartMain = null;
        public event EventHandler NextMain = null;
        public event EventHandler StopMain = null;
        public event EventHandler RButtom = null;
        public event EventHandler sliderUse = null;
        // menu
        public event EventHandler clearProfil = null;
        public event EventHandler Verbs = null;



      




        private void add_word(object sender, RoutedEventArgs e)
        {

            
                add = new Addwin();
           
            
            add.ShowDialog();

            Kateroris.DependencyPropertySub.WindAdd = null;
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f1 = new Filter();
                f1.ShowDialog();
            }
            catch(Exception ee)
            {
                
            }
         


        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            StopMain.Invoke(sender, e);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
          

            StartMain.Invoke(sender, e);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NextMain.Invoke(sender, e);
        }

   
        private void r_Checked(object sender, RoutedEventArgs e)
        {
            RButtom.Invoke(sender, e);
        }

        //private void LBRB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            
        //    MessageBox.Show(e.ToString());
        //}

        private void profileclear_Click(object sender, RoutedEventArgs e)
        {
            clearProfil.Invoke(sender, e);
        }

        private void MenuItem_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Verbs_Click(object sender, RoutedEventArgs e)
        {
            Verbs.Invoke(sender, e);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)

        {
            try
            {
                sliderUse.Invoke(sender, e);
            }
            catch { }
           
        }
    }
}
