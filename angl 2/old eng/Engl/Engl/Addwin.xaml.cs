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
using System.Data.Entity;
using Engl.DataBase;
using System.Data;
using Engl.Operation;
using Engl.Kateroris;

namespace Engl
{
    /// <summary>
    /// Interaction logic for Addwin.xaml
    /// </summary>
    /// 
   
    public partial class Addwin : Window
    {
        ViewModelAdd VMA;
        int count = 0;
        public Addwin()
        {
            InitializeComponent();
            VMA = new ViewModelAdd(this);
            DependencyPropertySub.WindAdd = this;
            
            
          
        }
        public event EventHandler MOUSE;
        public event EventHandler addclick;
        public event EventHandler Delete;
        public event EventHandler update;
        public event EventHandler SelectPart;
        public event EventHandler clear;
        public event EventHandler Ok1;
        public event EventHandler ChekFilytr;
        public event EventHandler Key;
        private void data_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MOUSE.Invoke(sender, e);
         
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            addclick.Invoke(sender, e);
        }

        private void UpDate_Click(object sender, RoutedEventArgs e)
        {
            update.Invoke(sender, e);
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
           
            Delete.Invoke(sender, e);
        }

    
        private void PartOfSpeechCOM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (count > 0)
            {
                SelectPart.Invoke(sender, e);
                Key.Invoke(sender, e);
            }
            else
            {
                count++;
            }



        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear.Invoke(sender, e);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Ok1.Invoke(sender, e);
        }

        private void FindOfFiltr_Checked(object sender, RoutedEventArgs e)
        {
            ChekFilytr.Invoke(sender,e);
        }

        private void En_KeyDown(object sender, KeyEventArgs e)
        {
            Key.Invoke(sender,e);
        }

        private void PodPunk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (count > 1)
            {
                Key.Invoke(sender, e);
            }
            else
            {
                count++;
            }
           
        }

        private void data_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            MOUSE.Invoke(sender, e);
        }
    }
}
