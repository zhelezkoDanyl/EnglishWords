using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl.DataBase;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Engl.Operation
{
 static   class SuportMethodAdd
    {
        private delegate List<Word> DelegatPUNCT(List<Word> lw, ComboBox c1, ComboBox c2);
        private delegate List<Word> DelegatTEMA(List<Word> Words, ComboBox C3);
        private delegate List<Word> DelegaWORDS(List<Word> Words, List<TextBox> tb);
        private delegate string del(string n, int t);
        

     static   public List<Word> FilytrChek ( bool ch  , List<Word> LW, List<ComboBox> LC,List<TextBox> LTB)
        {
            if(ch == false)
            {
                return ViewModel.DatagridList;
            }
            else
            {
                List<Word> ListNew = new List<Word>();
                  DelegatPUNCT punkt = new DelegatPUNCT(FilytrPUnct);
                DelegatTEMA tema = new DelegatTEMA(TemaFilytr);
                DelegaWORDS w = new DelegaWORDS(WordsEnRu);


                return w.Invoke(tema.Invoke(punkt.Invoke(LW, LC.ElementAt(0), LC.ElementAt(1)), LC.ElementAt(2)), LTB);

            }
            
        }
   
      
        static private List<Word> FilytrPUnct(List<Word> Words, ComboBox P1, ComboBox P2)
        {
            List<Word> WordsNew = new List<Word>();
            if( P1.SelectedIndex == 0)
            {
                return Words;
            }
            else
            {
                if(P2.SelectedIndex == 0)
                {
                    var quvery = from l in Words
                                 where  l.NumberPart == P1.SelectedIndex
                                 select l;
                    foreach(var w in quvery)
                    {
                        WordsNew.Add(w);
                    }
                    return WordsNew;
                }
                else
                {
                    var quvery = from l in Words
                                 where l.NumberPart == P1.SelectedIndex && l.NumberKind == P2.SelectedIndex
                                 select l;
                    foreach (var w in quvery)
                    {
                        WordsNew.Add(w);
                    }
                    return WordsNew;
                }
            }
        }
        static private List<Word> TemaFilytr(List<Word> Words, ComboBox P3)
        {
            List<Word> WordsNew = new List<Word>();
            if (P3.SelectedIndex == 0)
            {
                return Words;
            }
            else if(P3.SelectedIndex ==1 )
            {
                var quvery = from l in Words
                             where l.Tema == null
                             select l;
                foreach (var w in quvery)
                {
                    WordsNew.Add(w);
                }
                return WordsNew;
            }
            else
            {
                if (P3.SelectedItem is System.Windows.Controls.CheckBox)
                {
                    var ss = P3.SelectedItem as CheckBox;
                    var regex = new Regex(ss.Content.ToString());

                    var quvery = from l in Words
                                 where l.Tema != null && regex.IsMatch(l.Tema)
                                 select l;

                    foreach (var w in quvery)
                    {
                        
                            WordsNew.Add(w);
                        
                       
                    }
                    return WordsNew;
                }

                else
                {
                    System.Windows.MessageBox.Show(" Не правильно отработал Фильтр");
                    return WordsNew;
                }
            
               
            }

        }
        static private List<Word> WordsEnRu(List<Word> Words, List<TextBox> LB)
        {
            List<Word> WordsNew = new List<Word>();

            if(LB.ElementAt(0).Text==null && LB.ElementAt(1).Text==null )
            {
                return Words;
            }
            else
            {
                if(LB.ElementAt(0).Text == null)
                {
                    
                    var regex = new Regex(LB.ElementAt(1).Text.ToString().ToLowerInvariant());

                    var quvery = from l in Words
                                 where regex.IsMatch(l.Ru.ToLowerInvariant())
                                 select l;
                    foreach (var w in quvery)
                    {
                        WordsNew.Add(w);
                    }
                    return WordsNew;
                }
                else if (LB.ElementAt(1).Text == null)
                {
                    var regex = new Regex(LB.ElementAt(0).Text.ToString().ToLowerInvariant());

                    var quvery = from l in Words
                                 where regex.IsMatch(l.EN.ToLowerInvariant())
                                 select l;
                    foreach (var w in quvery)
                    {
                        WordsNew.Add(w);
                    }
                    return WordsNew;
                }
                else
                {
                    try
                    {
                        var regex = new Regex(LB.ElementAt(1).Text.ToString().ToLowerInvariant());
                        var r2 = new Regex(LB.ElementAt(0).Text.ToString().ToLowerInvariant());
                        var quvery = from l in Words
                                     where regex.IsMatch(l.Ru.ToLowerInvariant()) && r2.IsMatch(l.EN.ToLowerInvariant())
                                     select l;
                        foreach (var w in quvery)
                        {
                            WordsNew.Add(w);
                        }
                       
                    }
                    catch(Exception e)
                    {
                        System.Windows.MessageBox.Show("Возможно Вы ввели не допустимые символы -- error: " + e.Message.ToString());
                    }


                     return WordsNew;
                }

            }
        }
    }
   
}
