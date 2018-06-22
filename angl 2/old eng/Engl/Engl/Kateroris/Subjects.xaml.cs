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

namespace Engl.Kateroris
{
    /// <summary>
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : Window
    {
        SubViewModal subM;
        public Subjects()
        {
            InitializeComponent();
            subM = new SubViewModal(this);

        }
        public event EventHandler pickItems;
        public event EventHandler Addclick;
        public event EventHandler Editclick;
        public event EventHandler ButonOk;
        public event EventHandler DelTem;
       

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pickItems.Invoke(sender, e);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Addclick.Invoke(sender, e);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Editclick.Invoke(sender, e);

                }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            ButonOk.Invoke(sender, e);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            DelTem.Invoke(sender, e);
        }
    }
}
