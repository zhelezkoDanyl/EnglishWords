using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using Engl.Operation;
using Engl.DataBase;


//using System.Windows;

namespace Engl.ENUMS
{


  public class SvyazyFilter 
       
   {
  
 // объявляем переменные
       AzzA svyazy = new AzzA();
       List<string> EnumTop;
       List<string> RuAlf;
       List<string>EnAlf;
       Filter f;

      //serialize region
       XmlSerializer serializer = new XmlSerializer(typeof(SEareliz));
       List<CheckBox> ChBx = new List<CheckBox>();
       List<ComboBox> CombBx = new List<ComboBox>();
       SEareliz ser;
       SEareliz s2;
 
       // COnstructor
       public SvyazyFilter(Filter fi)
       {


           f = fi;
           f.RandommyEvent += f_RandommyEvent;
           f.RandommyEventuUnChek += f_RandommyEventuUnChek;
           f.SelectLang += f_SelectLang;
           f.DefaultEvent += f_DefaultEvent;
           //part speech
           // unchek
           f.nounUnchecEvent += f_nounUnchecEvent;
           f.adjectiveUnchecEvent += f_adjectiveUnchecEvent;
           f.adverbUnchecEvent += f_adverbUnchecEvent;
           f.pronounUnchecEvent += f_pronounUnchecEvent;
           f.prepositionUnchecEvent += f_prepositionUnchecEvent;
           f.conjunctionUnchecEvent += f_conjunctionUnchecEvent;
           f.verbUnchecEvent += f_verbUnchecEvent;
           f.numerUnchecEvent += f_numerUnchecEvent;
           f.OkSave += f_OkSave;
           //checed
           f.ChecnounEv +=f_ChecnounEv;
           f.ChecadjectiEv +=f_ChecadjectiEv;
           f.ChecadverbEv +=f_ChecadverbEv;
           f.ChecpronounEv +=f_ChecpronounEv;
           f.ChecpreposiEv +=f_ChecpreposiEv;
           f.ChecconjuncEv +=f_ChecconjuncEv;
           f.ChecverbUncEv += f_ChecverbUncEv;
           f.ChecnumerUnEv += f_ChecnumerUnEv;
            f.ADDWord += F_ADDWord;
            f.DelWord += F_DelWord;
            f.ClearAll += F_ClearAll;
            f.chekeMY += F_chekeMY;
           ser = new SEareliz();
       }

        private void F_chekeMY(object sender, EventArgs e)
        {
            if(f.MYselfList.IsChecked==true)
            {
                MethodDefaultTrue();
                for (int i = 0; i < 8; i++)
                {
                    ChBx.ElementAt(i).IsEnabled = false;
                }
                for (int i = 0; i < 9; i++)
                {
                    CombBx.ElementAt(i).IsEnabled = false;
                }
                


            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    ChBx.ElementAt(i).IsEnabled = true;
                }
                for (int i = 0; i < 9; i++)
                {
                    CombBx.ElementAt(i).IsEnabled = true;
                }

            }
        }

        private void F_ClearAll(object sender, EventArgs e)
        {
            try
            {
                System.Windows.MessageBoxResult YN = System.Windows.MessageBox.Show("Вы хотите удалить весь список MyList ", "DeleteMyList", System.Windows.MessageBoxButton.YesNo);
                if (YN == System.Windows.MessageBoxResult.Yes)
                {
                    List<Word> ff = new List<Word>();
                    ViewModel.N.RemoveRange(0, ViewModel.N.Count);
                    ff = ViewModel.DataMySelfList.ToList();
                    f.dataMy.ItemsSource = ff;
                    f.dataGridAll.ItemsSource = ViewModel.DataAllCreateMyself;
                    f.Count.Content = f.dataGridAll.Items.Count;
                    f.count2.Content = f.dataMy.Items.Count;
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Вы не выбрали слово которрое нужно убрать");
            }
        }

        private void F_DelWord(object sender, EventArgs e)
        {
            try
            {
                if (f.dataMy.SelectedItem != null)
                {
                    List<Word> ff = new List<Word>();
                    if(f.dataMy.SelectedItems!=null)
                    {
                        
                        foreach(var m in f.dataMy.SelectedItems)
                        {
                            ViewModel.N.Remove(m as Word);
                        }
                    }
                    else
                    {
                        // не обьязательно посколь селект айтем будет тру !!
                        ViewModel.N.Remove(f.dataMy.SelectedItem as Word);
                    }
                    
                    ff = ViewModel.DataMySelfList.ToList();
                    f.dataMy.ItemsSource = ff;
                    f.dataGridAll.ItemsSource = ViewModel.DataAllCreateMyself;
                    f.Count.Content = f.dataGridAll.Items.Count;
                    f.count2.Content = f.dataMy.Items.Count;
                }
                else
                {
                    System.Windows.MessageBox.Show("Вы не выбрали слово из правого списка, которое хотите убрать! ");
                }
               
              
            }
            catch
            {
                System.Windows.MessageBox.Show("Вы не выбрали слово которрое нужно убрать");
            }
            
        }

        private void F_ADDWord(object sender, EventArgs e)
        {
            try
            {
                if (f.dataGridAll.SelectedItem != null)
                {
                    if (f.dataGridAll.SelectedItems != null)
                    {
                     
                      
                        foreach (var m in f.dataGridAll.SelectedItems)
                        {
                            ViewModel.N.Add(m as Word);
                        }
                    }
                    else
                    {
                        //'это не обьязательно делать
                        ViewModel.N.Add(f.dataGridAll.SelectedItem as Word);
                    }
                    List<Word> ff = new List<Word>();
                 
                    ff = ViewModel.DataMySelfList.ToList();
                    f.dataMy.ItemsSource = ff;
                    f.dataGridAll.ItemsSource = ViewModel.DataAllCreateMyself;
                    f.Count.Content = f.dataGridAll.Items.Count;
                    f.count2.Content = f.dataMy.Items.Count;
                }
                else
                {
                    System.Windows.MessageBox.Show("Вы не выбрали слово из первого списка которое нужно поместить в собственный словарь");
                }
            }
            catch(Exception ee)
            {
                
                System.Windows.MessageBox.Show("Вы не выбрали слово из первого списка которое нужно поместить в собственный словарь");
            }
          
        }






        //reliz event
        #region EVENT
        //check & unchek random

        void f_OkSave(object sender, EventArgs e)
       {
           serial();
           f.Close();
       }
       void f_RandommyEventuUnChek(object sender, EventArgs e)
       {
       
           f.AZorZA.IsEnabled = true;
           if (f.EnRu.SelectedItem.ToString() == Engl.ENUMS.Lang.All.ToString())
           {
               f.AZ.IsEnabled = true;
               f.AR.IsEnabled = true;
           }
           else if(f.EnRu.SelectedItem.ToString() == Engl.ENUMS.Lang.En.ToString())
           {
               f.AZ.IsEnabled = true;
               f.AR.IsEnabled = false;
           }
           else if(f.EnRu.SelectedItem.ToString() == Engl.ENUMS.Lang.Ru.ToString())
           {
               f.AZ.IsEnabled = false;
               f.AR.IsEnabled = true;

           }
           else
           {
               //этот метод не должен произойти так как язык по умолчанию ALL
              // MessageBox.Show("Не выбран язык");
           }
       }

       void f_RandommyEvent(object sender, EventArgs e)
       {
           f.AZorZA.IsEnabled = false;
           f.AR.IsEnabled = false;
           f.AZ.IsEnabled = false;
           
       }

       //select lang
       void f_SelectLang(object sender, EventArgs e)
       {
           if (f.RandomFilterAZ.IsChecked == false)
           {
               if (f.EnRu.SelectedItem.ToString() == Engl.ENUMS.Lang.All.ToString())
               {
                   f.AZ.IsEnabled = true;
                   f.AR.IsEnabled = true;
               }
               else if (f.EnRu.SelectedItem.ToString() == Engl.ENUMS.Lang.En.ToString())
               {
                   f.AZ.IsEnabled = true;
                   f.AR.IsEnabled = false;
               }

               else if (f.EnRu.SelectedItem.ToString() == Engl.ENUMS.Lang.Ru.ToString())
               {
                   f.AZ.IsEnabled = false;
                   f.AR.IsEnabled = true;
               }
           }
       }

       // default po umolchaniyu
       void MethodDefaultTrue()
        {
            f.noun.IsChecked = true;
            f.adjective.IsChecked = true;
            f.adverb.IsChecked = true;
            f.pronoun.IsChecked = true;
            f.preposition.IsChecked = true;
            f.conjunction.IsChecked = true;
            f.verb.IsChecked = true;
            f.numer.IsChecked = true;


            // 3 column
            f.Topic2.SelectedItem = EnumsTopic.All.ToString();
            f.EnRu.SelectedItem = Lang.All;
            f.RandomFilterAZ.IsChecked = true;
            // pod tipi !!!\\
            List<System.Windows.Controls.ComboBox> com = new List<System.Windows.Controls.ComboBox>();
            com.Add(f.NounCombo);
            com.Add(f.adjectCombo);
            com.Add(f.AdvedCombo);
            com.Add(f.conjuctionCombo);
            com.Add(f.PreepositionCombo);
            com.Add(f.PronounCombo);
            com.Add(f.verbCombo);
            com.Add(f.numeralCombo);
            foreach (System.Windows.Controls.ComboBox c in com)
            {
                c.SelectedIndex = 0;
            }
        }
       void f_DefaultEvent(object sender, EventArgs e)
       {
            // put in true chasti rechi

            MethodDefaultTrue();
            f.MYselfList.IsChecked = false;


        }

      // obrabochik checkbox
      // check
       void f_ChecnumerUnEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecverbUncEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecconjuncEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecpreposiEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecpronounEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecadverbEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecadjectiEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }

       void f_ChecnounEv(object sender, EventArgs e)
       {
           MethoCheck(sender);
       }
   //   unchecked
       void f_numerUnchecEvent(object sender, EventArgs e)
       {
          if(InSideVentsPartsSpeech(sender))
          {
              f.numeralCombo.IsEnabled = false;
          }
           
       }

       void f_verbUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.verbCombo.IsEnabled = false;
           }
       }

       void f_conjunctionUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.conjuctionCombo.IsEnabled = false;
           }
       }

       void f_prepositionUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.PreepositionCombo.IsEnabled = false;
           }
       }

       void f_pronounUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.PronounCombo.IsEnabled = false;
           }
       }

       void f_adverbUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.AdvedCombo.IsEnabled = false;
           }
       }

       void f_adjectiveUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.adjectCombo.IsEnabled = false;
           }
       }

       void f_nounUnchecEvent(object sender, EventArgs e)
       {
           if (InSideVentsPartsSpeech(sender))
           {
               f.NounCombo.IsEnabled = false;
           }
       }



       #endregion

       // методы создания  списков для комбобокса
       #region create List for combobox
       private List<string> EnumList()
        {
            EnumTop= new List<string>();
            //Array ar = 

            Array ee = Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic));

            for (int i = 0; i < ee.Length; i++)
            {
                EnumTop.Add(ee.GetValue(i).ToString());
            }
         // добавить темы из текстового файла
            return EnumTop;
        }
       private List<string> RuAlflist()
       {
            RuAlf  = new List<string>();
            //Array ar = 

            Array ee = Enum.GetValues(typeof(Engl.ENUMS.RuAlf));

            for (int i = 0; i < ee.Length; i++)
            {
                RuAlf.Add(ee.GetValue(i).ToString());
            }
            return RuAlf;

       }

       private List<string> EnAlfList()
       {
           EnAlf = new List<string>();
           //Array ar = 

           Array ee = Enum.GetValues(typeof(Engl.ENUMS.EnAlf));

           for (int i = 0; i < ee.Length; i++)
           {
               EnAlf.Add(ee.GetValue(i).ToString());
           }
           return EnAlf;
       }

       
       #endregion

       #region properti
       //свойства возращаем лист для комбобоксов
       public List<string> RuList
       {
           get { return RuAlflist(); }
       }
       public List<string> Enlist
       {
           get { return EnAlfList(); }
       }

       public List<string> Topic
      {
          get { return EnumList(); }
      }
        public List<string> MethodAlyf
        {
            get { return svyazy.aZZa; }

        }
#endregion

       #region vspomogatelynie metodi
        private bool ProverkaALLChek(System.Windows.Controls.CheckBox last)
        {
            List<System.Windows.Controls.CheckBox> ChRC = new List<System.Windows.Controls.CheckBox>();
            ChRC.Add(f.noun);
            ChRC.Add(f.adjective);
            ChRC.Add(f.adverb);
            ChRC.Add(f.pronoun);

            ChRC.Add(f.preposition);
            ChRC.Add(f.conjunction);
            ChRC.Add(f.verb);
            ChRC.Add(f.numer);
            int count = 0;
            foreach(System.Windows.Controls.CheckBox e in ChRC)
            {
                if(e != last)
                {
                    if(e.IsChecked == true)
                    {
                        count++;

                    }
                }
            }

            if(count >0 )
            { return true; }
            else
            {
                return false;
            }
            

        }

        private bool InSideVentsPartsSpeech(object sender)
        {
            var sed1 = sender as System.Windows.Controls.CheckBox;
            if (ProverkaALLChek(sed1))
            {
                sed1.IsChecked = false;
                return true;
            }
            else
            {
                System.Windows.MessageBox.Show("Должна быть выбрана хотя бы одна ячейка (части речи)");
                sed1.IsChecked = true;
                return false;
            }
        }

        public void serial()
        {
            if(ChBx == null& CombBx == null)
            {
                Zapolnenielist();
            }
          

            foreach (CheckBox e in ChBx)
            {
                ser.CHECK.Add(e.IsChecked.Value);

            }
            foreach(ComboBox cb in CombBx)
            {
                ser.COMB.Add(cb.SelectedIndex);
            }
            Engl.MainModel.ForSerial.Chck = ser.CHECK;
            Engl.MainModel.ForSerial.Comb = ser.COMB;
            CombBx.Clear();
            ChBx.Clear();

            foreach(var my in ViewModel.DataMySelfList)
                {
                ser.Data.Add(my.id);
            }

            FileStream stream = new FileStream("Serialization.xml", FileMode.Create, FileAccess.Write, FileShare.Read);
       

            serializer.Serialize(stream, ser);

            
            stream.Close();
            

           

        }
      public void deserial()
        {
            Zapolnenielist();
            FileStream stream = new FileStream("Serialization.xml", FileMode.Open, FileAccess.Read, FileShare.Read);

        
            s2 = serializer.Deserialize(stream) as SEareliz;
            stream.Close();
            for (int i = 0; i < CombBx.Count;i++ )
            {
                CombBx[i].SelectedIndex = s2.COMB[i];
            }
            for (int i = 0; i < ChBx.Count; i++)
            {
                ChBx[i].IsChecked = s2.CHECK[i];
            }
          //foreach(var ee in s2.Data)
          //  {
          //      foreach( var w in ViewModel.DatagridList)
          //      {
          //          if(ee == w.id)
          //          {
          //              ViewModel.N.Add(w);
          //          }
          //      }
          //  }
         
        
        }
      
      public void Zapolnenielist()
      {

          ChBx.Add(f.noun);
          ChBx.Add(f.adjective);
          ChBx.Add(f.adverb);
          ChBx.Add(f.pronoun);
          ChBx.Add(f.preposition);
          ChBx.Add(f.conjunction);
          ChBx.Add(f.verb);
          ChBx.Add(f.numer);
          ChBx.Add(f.RandomFilterAZ);
            ChBx.Add(f.MYselfList);

            CombBx.Add(f.NounCombo);
            CombBx.Add(f.adjectCombo);
            CombBx.Add(f.AdvedCombo);
            CombBx.Add(f.PronounCombo);
            CombBx.Add(f.PreepositionCombo);
           CombBx.Add(f.conjuctionCombo);
            CombBx.Add(f.verbCombo);
            CombBx.Add(f.numeralCombo);
            CombBx.Add(f.Topic2);
            CombBx.Add(f.EnRu);
            CombBx.Add(f.AZorZA);
            CombBx.Add(f.AZ);
            CombBx.Add(f.AR);
        



      }

      public void MethoCheck(object sd)
  {
     var sekbox = sd as System.Windows.Controls.CheckBox;
     for (int i = 0; i < 8; i++)
     {
         if(ChBx[i].Name == sekbox.Name)
         {
             CombBx[i].IsEnabled = true;
         }
     }
  }

       #endregion

   } 

}
