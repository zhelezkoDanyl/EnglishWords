using System;

using System.Windows.Controls;

using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl.DataBase;
using Engl.Kateroris;

namespace Engl.ENUMS
{

    #region перечесления подтипов частейречи


    public enum PartOfSpech
    {
        All = 0,
        Noun = 1,
        Adjective,
        Adverb,
        Pronoun,
        Preposition,
        Conjunction,
        Verb,
        Numeral
    }

    public enum Verb
    {
        Все = 0,
        Правильные,
        Неправильные,
        Фразовые,
        Другое


    } // ok
    public enum noun
    {
        Все = 0,
        Абстрактные,
        Конкретные,
        Другое

    } //ok
    public enum adjective
    {
        Все = 0,
        Другое


    } //ok
    public enum adverb
    {
        Все = 0,
        Место,
        Время,
        Причина,
        Цель,
        Способ,
        Количество,
        Другое


    }
    public enum pronoun
    {
        Все = 0,
        Личные,
        Притяжательные,
        Возвратные,
        Указательные,
        Вопросительные,

        Другое







    }
    public enum preposition
    {
        Все = 0,
        Абстрактные,
        Место,
        Время,
        Другое


    }
    public enum coujunction
    {
        Все = 0,
        Связные,
        Разделительные,
        Контраст,
        ПричинноСледстинные,
        Другое

    }
    public enum numeral
    {
        Все = 0,
        Парядковые,
        Количественные,
        Другое

    }

    #endregion
    public enum EnumsTopic
    {
        All = 0,
        None,
        General,
        Business,
        Technical,
        Sea

    }

    public enum Lang
    {
        All,
        En,
        Ru
        
        

    }

    public enum RuAlf
    {

        А = 0,
        Б,
        В,
        Г,
        Д,
        Е,
        Ё,
        Ж,
        З,
        И,
        Й,
        К,
        Л,
        М,
        Н,
        О,
        П,
        Р,
        С,
        Т,
        У,
        Ф,
        Х,
        Ц,
        Ч,
        Ш,
        Щ,
        Ъ,
        Ы,
        Ь,
        Э,
        Ю,
        Я
    }
    public enum EnAlf
    {
        A = 0,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }
    public class AzzA
    {
        private List<string> st = new List<string>();
       // private ArrayList ChBx = StatiItemsForMenu.ChBxOriginal;

        public AzzA()
        {
            st.Add("A --> Z");
            st.Add("Z --> A");

        }

        public List<string> aZZa
        {
            get
            {
                return st;

            }
        }
     static   public ArrayList LISTCHECBOX()
        {
            
             ArrayList test = StatiItemsForMenu.OriginalChecBox;
             
           
         
            return test;
        }

        public Array parOfsp
        {
            get { return Enum.GetValues(typeof(PartOfSpech)); }
        }

        public Array topic
        {
            get { return Enum.GetValues(typeof(EnumsTopic)); }
        }
        public Array podtip(int s)
        {
            return Enum.GetValues(typeof(noun));

        }


     static   public ArrayList Tema
        {
            get { return StatiItemsForMenu.OriginalChecBox; }

        }
    }


    public static class StatiItemsForMenu
    {
        private static ArrayList ChBxOriginal;

        static public ArrayList OriginalChecBox
        {
            get { 
                
                    return MethodZapalneniyaTem();
                }
            
    
        }
        static private ArrayList MethodZapalneniyaTem()
        {
            ArrayList ret = new ArrayList();
            for (int ie = 0; ie < DependencyPropertySub.AllLIstTems.Count; ie++)
            {
                if (ie <2)
                {
                    ret.Add(DependencyPropertySub.AllLIstTems.ElementAt(ie));
                }

            

                else
                {
                    try
                    {
                        CheckBox test = new CheckBox();
                        test.Name = "n"+1;
                        test.Content = DependencyPropertySub.AllLIstTems.ElementAt(ie);
                        ret.Add(test);
                    }
                    catch (Exception err)
                    {
                        System.Windows.MessageBox.Show(err.ToString());
                    }
                   
                }

            }

            // plase for reder

          

            Button NewTem = new Button();
            NewTem.Content = "NewItem";
            NewTem.Name = "ButonNew";
            NewTem.Click += NewTem_Click;
            ret.Add(NewTem);

            return ret;
            }

        private static void NewTem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // System.Windows.MessageBox.Show("sdsdsd");
            Kateroris.Subjects sub = new Kateroris.Subjects();
            sub.ShowDialog();
        }
    }



    
}
