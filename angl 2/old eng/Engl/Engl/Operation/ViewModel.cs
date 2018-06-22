using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl.DataBase;
using Engl.ENUMS;
using System.Windows;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace Engl.Operation
{
   public class ViewModel 
    {
        static public List<Word> N;
        static private bool ch;


 
            static  public List<Word> DatagridList
        {
            get { return DataBaseWithMethod.GetListWord; }
        }

        static public List<VerbsWord> DataVerbs
        {
          get  {
                var qvery = from dv in DatagridList
                            where dv.NumberKind == 2 & dv.NumberPart == 7
                            select new { ID = dv.id, Ru = dv.Ru, VerbForm1 = dv.EN, form2 = dv.PastSimiple, form3 = dv.PastPart };
                List<VerbsWord> w = new List<VerbsWord>();
                foreach (var q in qvery)
                {
                    VerbsWord ww = new VerbsWord();
                    ww.id = q.ID;
                    ww.Ru = q.Ru;
                    ww.EnForms1 = q.VerbForm1;
                    ww.VerbForms2 = q.form2;
                    ww.VerbForms3 = q.form3;
                    w.Add(ww);
                }
                return w; }
        }
        static private void deserialCHec()
        {

            FileStream stream = new FileStream("Serialization.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Engl.ENUMS.SEareliz s2 = new ENUMS.SEareliz();
            XmlSerializer serializer = new XmlSerializer(typeof(SEareliz));

            s2 = serializer.Deserialize(stream) as SEareliz;
            stream.Close();

            foreach (var ee in s2.Data)
            {
                foreach (var w in ViewModel.DatagridList)
                {
                    if (ee == w.id)
                    {
                        ViewModel.N.Add(w);
                    }
                }
            }


           


        }
        static public List<Word> DataMySelfList
        {
            get { if (N == null)
                   { N = new List<Word>();
                    deserialCHec();
                }

                return N;
            }
         
        }
        static public List<Word> DataAllCreateMyself
        {
            get
            {
                List<Word> NW = new List<Word>();
                foreach(var q in DatagridList)
                {
                    int count = 0;
                    foreach(var vv in DataMySelfList)
                    {
                        if(q ==vv)
                        {
                            count++;
                        }
                    }

                    if(count==0)
                    {
                        NW.Add(q);
                    }
                }
                return NW;
                   

            }
        }


        // получаем аррай список ЧАСТЕЙ речи для подтипа метод
       static Array GetPodType()
        {
     

            if (DataBaseWithMethod.PartOfSpechtype == 1)
            {
                return Enum.GetValues(typeof(noun));
            }
            else if(DataBaseWithMethod.PartOfSpechtype == 2)
            {
                return Enum.GetValues(typeof(adjective));
            }
            else if (DataBaseWithMethod.PartOfSpechtype == 3)
            {
                return Enum.GetValues(typeof(adverb));
            }
            else if (DataBaseWithMethod.PartOfSpechtype == 4)
            {
                return Enum.GetValues(typeof(pronoun));
            }
            else if (DataBaseWithMethod.PartOfSpechtype == 5)
            {
                return Enum.GetValues(typeof(preposition));
            }
            else if (DataBaseWithMethod.PartOfSpechtype == 6)
            {
                return Enum.GetValues(typeof(coujunction));
            }
            else if (DataBaseWithMethod.PartOfSpechtype == 7)
            {
                return Enum.GetValues(typeof(Verb));
            }
            else if (DataBaseWithMethod.PartOfSpechtype == 8)
            {
                return Enum.GetValues(typeof(numeral));
            }
            else
            {
                return null;
            }
        }
        // получаем аррай список ЧАСТЕЙ речи для подтипа СВОЙСТВО
        static public Array PodTypeProperty
        { get {  return  GetPodType(); } }



        // Буль для Комбомбокс Енабле - под ТИП
        static public bool BoolPodType
        {
            
            get {   if(DataBaseWithMethod.PartOfSpechtype > 0)
                        {
                           return true;
                        }
                    else
                      {
                          return false;
                      }

                }
              }

     static public string TopicStringMethod(System.Windows.Controls.ComboBox comb)
        {
            string str = null;
            foreach (var item in comb.Items)
            {
                if (item is System.Windows.Controls.CheckBox)
                {
                    var ss = item as System.Windows.Controls.CheckBox;
                    if (ss.IsChecked == true)
                    {
                        if (str == null)
                        {
                            str = ss.Content.ToString();
                        }
                        else
                        {
                            str = str + "/" + ss.Content.ToString();
                        }
                    }

                }

            }
            return str;
        }

        static public System.Windows.Controls.ComboBox RegularTopicComb(System.Windows.Controls.ComboBox comb, string str)
        {
            foreach (var item in comb.Items)
            {
                if (item is System.Windows.Controls.CheckBox)
                {
                    var ss = item as System.Windows.Controls.CheckBox;
                    var regex = new Regex(ss.Content.ToString());
                    bool match;
                    if (str != null)
                    {
                        match = regex.IsMatch(str);
                    }
                    else
                    {
                        match = false;
                    }


                    ss.IsChecked = match;
                    // item  = ss as object;



                }

            }
            return comb;
        }
        //  // записываем инт для определения ТИПА
        //static  public int  Part
        //  {
        //     get { return DataBaseWithMethod.PartOfSpechtype ; }
        //      set { DataBaseWithMethod.PartOfSpechtype = value; }
        //  }

        public bool ProverkaVolidate(Word w, out string str,int i)
        {
            str = "";
            List<bool> b = new List<bool>();
            StringBuilder sb = new StringBuilder();
            if (w.EN != ""&& w.Ru!="")
            {
               if(i!=1)
                {
                    var q = from word in DataBaseWithMethod.GetListWord
                            where word.EN == w.EN && word.Ru == w.Ru
                            select word;
                    if (q.ToList().FirstOrDefault() == null)
                    {
                        b.Add(true);
                    }
                    else
                    {
                        b.Add(false);
                        sb.Append("Это слово уже существует " + w.EN + " - " + w.Ru + "  \n");
                    }
                }
            }
            else
            {
                b.Add(false);
                sb.Append("Есть не  заполниные поля En  или Ru \n");
            }

            if(w.Tema == null)
            {
                b.Add(false);
                sb.Append("Не выбрана тема \n");
            }
            if(w.NumberKind<1||w.NumberPart<1)
            {
                b.Add(false);
                sb.Append("Не выбрана часть речи ");
            }
            str = sb.ToString();
            foreach(var e in b)
            {
                if (e == false)
                    return false;
            }
            return true;

        }

    }

     class MyFirstControl : FrameworkElement
    {






        //public EnumsTopic animal;

        //// 1. Создание свойства зависимостей.
        //// Идентификатор свойства зависимости - поле представляющее свойство зависимости.
        //public static DependencyProperty DataProperty;

        //// 2. регистрация свойства зависимостей
        //static MyFirstControl()
        //{
        //    // параметр 1: Имя свойства.
        //    // параметр 2: Тип данных свойства.
        //    // параметр 3: Тип, которому принадлежит это свойство.
        //    DataProperty = DependencyProperty.Register("ET", typeof(int), typeof(EnumsTopic));
        //}

        //// 3. Упаковка свойства зависимостей в традиционное свойство.
        //// Методы SetValue и GetValue унаследованы от класса DependencyObject


        //public EnumsTopic ET
        //{
        //    get { return animal; }
        //    set { animal = value; }
        //}



        // 1. Создание свойства зависимостей.
        // Идентификатор свойства зависимости - поле представляющее свойство зависимости.
         static DependencyProperty DataProperty;
         static DependencyProperty DataProperty2;
         static DependencyProperty VoiceProperty;
        static FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(new PropertyChangedCallback(change), new CoerceValueCallback(Corect));

         int? volume = null;
    
        // 2. регистрация свойства зависимостей
        static MyFirstControl()
        {
            // параметр 1: Имя свойства.
            // параметр 2: Тип данных свойства.
            // параметр 3: Тип, которому принадлежит это свойство.
           VoiceProperty = DependencyProperty.Register("Voice", typeof(int), typeof(MyFirstControl),metadata);
            DataProperty = DependencyProperty.Register("Data", typeof(int), typeof(MyFirstControl));
        
            DataProperty2 = DependencyProperty.Register("chekMyself", typeof(bool), typeof(MyFirstControl));
        }

        // 3. Упаковка свойства зависимостей в традиционное свойство.
        // Методы SetValue и GetValue унаследованы от класса DependencyObject


        public int Voice
        {
            get
            {
                return (int)GetValue(VoiceProperty);
            }
            set
            {
               SetValue(VoiceProperty, value);
            }
        }
        public int Data
        {
            get
            {
                return (int)GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
            }

        }
        public bool chekMyself
        {
            get
            {
                return (bool)GetValue(DataProperty2);
            }
            set { SetValue(DataProperty2, value); }
        }
        static object Corect(DependencyObject obg, object val)
        {
          
            var b = (MyFirstControl)obg;
            if (b.volume == null)
            {
                b.volume = 100;
                val = b.volume;
                
            }
          
            else
            {

               b.volume = (int)val;
            }

            

            return val;
        }
        static void change (DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            
        }

    }


}
