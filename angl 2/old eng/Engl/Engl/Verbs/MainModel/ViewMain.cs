using Engl.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Speech.Synthesis;

namespace Engl.MainModel
{
    class ViewMain
    {
        MethodsForModel Method;
        MainWindow Main;
        int[] threount = new int[]{ 0, 0, 0 };
        List<System.Windows.Controls.RadioButton> Rad ;
        List<System.Windows.Controls.Label> Label;
        List<System.Windows.Controls.Label> star;
        Engl.DataBase.Word w = null;
        List<DataBase.Word> quest = null;
        SpeechSynthesizer synth = new SpeechSynthesizer();
        

        public ViewMain(MainWindow MainWin)
        {

            synth.SetOutputToDefaultAudioDevice();

            Main = MainWin;
            Main.StartMain += Main_Start;
            Main.StopMain += Main_StopMain;
            Main.NextMain += Main_NextMain;
            Main.RButtom += Main_RButtom;
            Main.clearProfil += Main_clearProfil;
            Main.Verbs += Main_Verbs;
            Main.sliderUse += Main_sliderUse;
           // Main.slider.Value = 100;
        }

        private void Main_sliderUse(object sender, EventArgs e)
        {
            
                
                synth.Volume = Main.voiceDP.Voice;

            
           
           
           
        }

        private void Main_Verbs(object sender, EventArgs e)
        {
            Main.verbs = new Verbs.VerbsLern();
            Main.verbs.ShowDialog();
            
        }

        private void Main_clearProfil(object sender, EventArgs e)
        {
            System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Все слова будут онулираваны! Вы ходите обновить оценки", "ClearStars", System.Windows.MessageBoxButton.YesNo);
            if(result == System.Windows.MessageBoxResult.Yes)
            {
                DataBase.DataBaseWithMethod.ClearAllCount();
            }
           

        }
        private void Main_RButtom(object sender, EventArgs e)
        {
            synth.SpeakAsyncCancelAll();
            if ( Main.voiceDP.Voice!=0)
            {

                if (w.NumberPart == 7)
                {
                    synth.SpeakAsync("to " + w.EN);
                }
                else
                {
                    synth.SpeakAsync(w.EN);
                }
            }
           
           


            Word dd2 = new Word();
            for (int i = 0; i <RadioButList().Count; i++)
            {
           
                if (RadioButList().ElementAt(i).IsChecked == true)
                {
                    
                    bool TF = quest.ElementAt(i) == w;
                    if(TF)
                    {
                        threount[0]++;
                        Main.TruOrFals.Foreground = Brushes.White;
                      //  Method.Blink(Main.TruOrFals, Brushes.White);
                        RadioButList().ElementAt(i).Foreground = Brushes.Green;



                    }
                    else
                    {
                        threount[1]++;
                        Main.TruOrFals.Foreground = Brushes.Red;
                        dd2 = quest.ElementAt(i);
                        RadioButList().ElementAt(i).Foreground = Brushes.DarkRed;
                        for (int j = 0; j < RadioButList().Count; j++)
                        {
                            if (quest.ElementAt(j) == w)
                            {
                                RadioButList().ElementAt(j).Foreground = Brushes.DarkGreen;
                            }
                        }

                    }

                

                    Main.TruOrFals.Content = Method.TrueOrFalse(TF);

                   Method.MethodReadCount(TF, w, dd2);
                   
                }
         
            }
            

            foreach (var r in RadioButList())
            {
              
                r.IsEnabled = false;
            }

            Main.LvL.Content = ForSerial.Lvl + ForSerial.sravnenieOstatka;
            Main.Progres.Value = Engl.Kateroris.DependencyPropertySub.LvlProgres;

            methodSTARS();

          
            // System.Console.WriteLine(synth.Voice.Name.ElementAt(i).ToString());
            //   synth.SelectVoice( synth.Voice.Name.ElementAt(i).ToString());
            // Speak a string.

        }

        private void Main_NextMain(object sender, EventArgs e)
        {
           

           threount[2]++;
            foreach(var r in RadioButList())
            {
                r.IsChecked = false;
                r.IsEnabled = true;
                r.Foreground = Brushes.Black;

            }
            
            Main.TruOrFals.Content = null;
         // int  rNewR = new Random().Next(0, 5);
           // Engl.DataBase.Word w = new DataBase.Word();
           //----------------------------------------------------------
            w = Method.RandomQuesion();
         

         quest = Method.MethorOtherFiveRandom(w);
          ModelMain mm = Method.GetStringObject(w,quest) as ModelMain;
            Main.l1.Content = mm.L1;
            Main.l2.Content = mm.L2;
            Main.word.Content = mm.GetWord;
            Main.synonym.Content = mm.GetSynonym;
            for (int i = 0; i < RadioButList(). Count; i++)
            {
                RadioButList().ElementAt(i).Content = mm.GetWordsQuest.ElementAt(i);
            }
            Main.LvL.Content = ForSerial.Lvl + ForSerial.sravnenieOstatka;
            Main.Progres.Value = Engl.Kateroris.DependencyPropertySub.LvlProgres;
            #region stars
            methodSTARS();
            #endregion
        }

        private void Main_StopMain(object sender, EventArgs e)
        {
            Main.LvL.Content = null;
            Main.Next.IsEnabled = false;
            Main.Stop.IsEnabled = false;
          Main.Start.IsEnabled = true;
            Main.m.Opacity = 1;
            Method = null;
            foreach (var r in RadioButList())
            {
                r.IsChecked = false;
                r.IsEnabled = false;
                r.Content = null;
            }
            foreach (var l in LabelList())
            {

                l.Content = null;
            }
            foreach (var s in Stars())
            {
                s.Opacity = 0;
                s.Content = null;
            }
            var builder = new StringBuilder();

            builder.Append("из " + threount[2] + " слов \n").Append("правильно = " + threount[0] + "\n").Append(" неправильно  = " + threount[1] +"\n ").Append(" оставлиные без ответа - " + (threount[2] - threount[0] - threount[1]));
            System.Windows.MessageBox.Show( builder.ToString() );
            for (int i = 0; i < 3; i++)
            {
                threount[i] = 0;
            }
            Main.word.Content = "Продолжим?";
        }

        private void Main_Start(object sender, EventArgs e)
        {

            Main.word.Content = "Please Wait";
            
            Method = new MethodsForModel();
            int pf = Method.ProverkaCounWordsForFilyter();
            if (pf ==0)
            {
                System.Windows.MessageBox.Show("По вашему фильтру выбрано 0 слов");
                Main.word.Content = "Выберете другой фильтр ! ";
            }
            else
            {
                System.Windows.MessageBox.Show("По вашему фильтру выбрано "+pf+ " слов");

                Main.Next.IsEnabled = true;
                Main.Stop.IsEnabled = true;

                Main_NextMain(sender, e);
               Main.Start.IsEnabled = false;
                Main.m.Opacity = 0.5;
             //   Main.m.IsEnabled = false;
                foreach (var R in RadioButList())
                {
                    R.IsEnabled = true;
                }
            }
           

        }


    //-----------------------------------------------------------------------
        private List<System.Windows.Controls.RadioButton> RadioButList()
        {
            if (Rad == null)
            {
                Rad = new List<System.Windows.Controls.RadioButton>();
                //foreach (var rb in Main.LBRB.Items)
                //{
                //    Rad.Add(rb as System.Windows.Controls.RadioButton);
                //}
                Rad.Add(Main.r1);
                Rad.Add(Main.r2);
                Rad.Add(Main.r3);
                Rad.Add(Main.r4);
                Rad.Add(Main.r5);
                Rad.Add(Main.r6);


            }
            return Rad;
        }

        private List<System.Windows.Controls.Label> LabelList()
        {
            if (Label == null)
            {
                Label = new List<System.Windows.Controls.Label>();
                Label.Add(Main.word);
                Label.Add(Main.l1);
                Label.Add(Main.l2);
                Label.Add(Main.TruOrFals);
                Label.Add(Main.synonym);
            }
            return Label;
        }
        private List<System.Windows.Controls.Label> Stars()
        {
             if (star == null)
            {
                star = new List<System.Windows.Controls.Label>();
                star.Add(Main.C1);
                star.Add(Main.C2);
                star.Add(Main.C3);
                star.Add(Main.C4);
                star.Add(Main.C5);
                star.Add(Main.C6);
                star.Add(Main.C7);
                star.Add(Main.C8);
                star.Add(Main.C9);
            }
            return star;
        }
        private void methodSTARS()
        {
            if (w.Count == 0)
            {
                foreach (var s in Stars())
                {
                    s.Opacity = 0.3;
                    s.Content = null;
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (w.Count > i)
                    {
                        int c = i + 1;
                        Stars().ElementAt(i).Opacity = 1;

                        Stars().ElementAt(i).Content = " " + c;
                    }
                    else
                    {
                        Stars().ElementAt(i).Opacity = 0.3;
                        Stars().ElementAt(i).Content = null;
                    }
                }
            }
        }
    }
}