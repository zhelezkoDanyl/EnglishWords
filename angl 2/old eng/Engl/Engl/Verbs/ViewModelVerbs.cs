using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
namespace Engl.Verbs
{
    class ViewModelVerbs
    {
        int s = 0;
        VerbsLern Verblist;
        ModelVerbs MV;
        List<System.Windows.Controls.CheckBox> CheckVerb;
        List<System.Windows.Controls.CheckBox> ChecRima;
        private List<System.Windows.Controls.CheckBox> GetRimaCheck
        {
            get
            {
                if (ChecRima == null)
                {
                    ChecRima = checkBoxRima();
                    return ChecRima;
                }
                return ChecRima;
            }
        }
        private List<System.Windows.Controls.CheckBox> GetVerbCheck
        {
            get { if(CheckVerb == null)
                {
                    CheckVerb = checkBoxVerb();
                    return CheckVerb;
                }
                return CheckVerb;
            }
        }
        SpeechSynthesizer synth = new SpeechSynthesizer();
        public ViewModelVerbs(VerbsLern VL)
        {
            MV = new ModelVerbs();
            Verblist = VL;
            Verblist.v1check += Verblist_v1check;
            Verblist.Selec += Verblist_Selec;
            Verblist.clickin += Verblist_clickin;
            Verblist.Vol += Verblist_Vol;
            Verblist.SpeedSpech += Verblist_SpeedSpech;
        }

        private void Verblist_SpeedSpech(object sender, EventArgs e)
        {
            synth.Rate = Verblist.Mycontrol.SpeedVoice-10;
        }

        private void Verblist_Vol(object sender, EventArgs e)
        {
            synth.Volume = Verblist.Mycontrol.Voice;
          
        }

        private void Verblist_clickin(object sender, EventArgs e)
        {
            Verblist.Close();
        }

        private void Verblist_Selec(object sender, EventArgs e)
        {
            synth.SpeakAsyncCancelAll();
           
            Engl.DataBase.VerbsWord row = Verblist.dataGrid.SelectedItem as Engl.DataBase.VerbsWord;
            Verblist.RuWord.Text = row.Ru;
            Verblist.Form1.Text = row.EnForms1;
            Verblist.form2.Text = row.VerbForms2;
            Verblist.form3.Text = row.VerbForms3;

            
            synth.SpeakAsync(row.EnForms1 + "," + row.VerbForms2 + "," + row.VerbForms3);
        }
           
         

        private void Verblist_v1check(object sender, EventArgs e)
        {
            try
            {
                Verblist.dataGrid.ItemsSource = MV.Fyltr(GetVerbCheck, GetRimaCheck);
                Verblist.CountLabel.Content = MV.Fyltr(GetVerbCheck, GetRimaCheck).Count.ToString();
            }
            catch(Exception ex)
            {
              //  System.Windows.MessageBox.Show(ex.ToString());
            }
           
            
        }

        private List<System.Windows.Controls.CheckBox> checkBoxVerb()
        {
            List<System.Windows.Controls.CheckBox> listCheck = new List<System.Windows.Controls.CheckBox>();
            foreach (var r in Verblist.DP.Items)
            {
                if(r is System.Windows.Controls.CheckBox)
                {
                    listCheck.Add(r as System.Windows.Controls.CheckBox);
                }
            }
            return listCheck;
        }
        private List<System.Windows.Controls.CheckBox> checkBoxRima()
        {
            List<System.Windows.Controls.CheckBox> listCheck = new List<System.Windows.Controls.CheckBox>();
            foreach (var r in Verblist.rima.Items)
            {
                if (r is System.Windows.Controls.CheckBox)
                {
                    listCheck.Add(r as System.Windows.Controls.CheckBox);
                }
            }
            return listCheck;
        }
    }
}
