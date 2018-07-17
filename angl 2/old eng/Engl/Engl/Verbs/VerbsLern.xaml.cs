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

namespace Engl.Verbs
{
    /// <summary>
    /// Interaction logic for VerbsLern.xaml
    /// </summary>
    public partial class VerbsLern : Window
    {
        ViewModelVerbs vmv;
        public VerbsLern()
        {
            vmv = new ViewModelVerbs(this);
            InitializeComponent();
        }
        public event EventHandler v1check;
        public event EventHandler Selec;
        public event EventHandler clickin;
        
        public event EventHandler Vol;
        public event EventHandler SpeedSpech;


        #region cheked uncheced
        private void V1rV2rV3_Checked(object sender, RoutedEventArgs e)
        {
            v1check.Invoke(sender, e);
        }
        private void V1rV2rV3_Unchecked(object sender, RoutedEventArgs e)
        {
            v1check.Invoke(sender, e);
        }


        #endregion

     
        private void dataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Selec.Invoke(sender, e);
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Selec.Invoke(sender, e);
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            clickin.Invoke(sender, e);
        }

        private void sliderVerb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Vol.Invoke(sender, e);
            }
            catch { }
            
        }

        private void sliderVerbSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                SpeedSpech.Invoke(sender, e);
            }
            catch { }
        }
    }
}
