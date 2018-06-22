using System;
using System.Collections.Generic;
using System.Collections;
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
using Engl.ENUMS;
using System.Xml.Serialization;
using Engl.Kateroris;

namespace Engl
{
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        
        SvyazyFilter FilteVsEnum;
        #region counts for enter in checkedbox and reliaz
        int coun = 0;
        int e1 = 0;
        int e2 = 0;
        int e3 = 0;
        int e4 = 0;
        int e5 = 0;
        int e6 = 0;
        int e7 = 0;
        int e8 = 0;
        #endregion

        public Filter()//MainWindow w)
        {
            
            InitializeComponent();
           // win = w;
         FilteVsEnum = new SvyazyFilter(this);
            

            Topic2.ItemsSource = DependencyPropertySub.AllLIstTems;
            AZorZA.ItemsSource = FilteVsEnum.MethodAlyf;
         EnRu.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.Lang));
            AZ.ItemsSource = FilteVsEnum.Enlist;
            AR.ItemsSource = FilteVsEnum.RuList;

            //  AR.SelectedItem = FilteVsEnum.RuList[0];
            // AZ.SelectedItem = FilteVsEnum.Enlist[0];
            //  EnRu.SelectedItem = Engl.ENUMS.Lang.All;
            // AZorZA.SelectedItem = FilteVsEnum.MethodAlyf[0];
            //Topic2.SelectedItem = FilteVsEnum.Topic[0];

            // цепляем нумералы на части речи
            NounCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.noun));
            adjectCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.adjective));
            AdvedCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.adverb));
            PronounCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.pronoun));
            PreepositionCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.preposition));
            conjuctionCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.coujunction));
            verbCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.Verb));
            numeralCombo.ItemsSource = Enum.GetValues(typeof(Engl.ENUMS.numeral));
               

          //numeralCombo.SelectedItem = Engl.ENUMS.numeral.Все;
            //verbCombo.SelectedItem = Engl.ENUMS.Verb.Все;
            //conjuctionCombo.SelectedItem = Engl.ENUMS.coujunction.Все;
            //PreepositionCombo.SelectedItem = Engl.ENUMS.preposition.Все;
            // PronounCombo.SelectedItem = Engl.ENUMS.pronoun.Все;
            // AdvedCombo.SelectedItem = Engl.ENUMS.adverb.Все;
            //adjectCombo.SelectedItem = Engl.ENUMS.adjective.Все;
            //NounCombo.SelectedItem = Engl.ENUMS.noun.Все;


            // десерелизируем последние данные
            FilteVsEnum.deserial();


        }

        #region create vent
        public event EventHandler SelectLang = null;
        public event EventHandler RandommyEvent = null;
        public event EventHandler RandommyEventuUnChek = null;
        public event EventHandler DefaultEvent = null;
        //eventi k chastyamrechi un chek
        public event EventHandler nounUnchecEvent;
        public event EventHandler adjectiveUnchecEvent;
        public event EventHandler adverbUnchecEvent;
        public event EventHandler pronounUnchecEvent;
        public event EventHandler prepositionUnchecEvent;
        public event EventHandler conjunctionUnchecEvent;
        public event EventHandler verbUnchecEvent;
        public event EventHandler numerUnchecEvent;
        // chek
         public event EventHandler ChecnounEv;
         public event EventHandler ChecadjectiEv;
         public event EventHandler ChecadverbEv;
         public event EventHandler ChecpronounEv;
         public event EventHandler ChecpreposiEv;
         public event EventHandler ChecconjuncEv;
         public event EventHandler ChecverbUncEv;
         public event EventHandler ChecnumerUnEv;
        
        // ok close() save
        public event EventHandler OkSave;
        public event EventHandler ADDWord;
        public event EventHandler DelWord;
        public event EventHandler ClearAll;
        public event EventHandler chekeMY;
        #endregion


        #region obrobotchik sobitiy

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            OkSave.Invoke(sender, e);
           
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll.Invoke(sender, e);
        }
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            ADDWord.Invoke(sender, e);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            DelWord.Invoke(sender, e);
        }
        private void MYselfList_Checked(object sender, RoutedEventArgs e)
        {
            chekeMY.Invoke(sender, e);
        }
        private void RandomFilterAZ_Checked(object sender, RoutedEventArgs e)
        {
            
            if(coun > 0)
            {
                RandommyEvent.Invoke(sender, e);
               
            }
            else
            {
                coun++;
            }
           
        }

        private void Random_Unchecked(object sender, RoutedEventArgs e)
        {
            RandommyEventuUnChek.Invoke(sender, e);
        }

        private void EnRu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectLang.Invoke(sender, e);
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            DefaultEvent.Invoke(sender, e);
        }



        // obrobotca eventov chastey rechi

        //unchec
        private void nounUnchecked(object sender, RoutedEventArgs e) { nounUnchecEvent.Invoke(sender, e); }
        private void adjectiveUnchecked(object sender, RoutedEventArgs e) { adjectiveUnchecEvent.Invoke(sender, e); }
        private void adverbUnchecked(object sender, RoutedEventArgs e) { adverbUnchecEvent.Invoke(sender, e); }
        private void pronounUnchecked(object sender, RoutedEventArgs e) { pronounUnchecEvent.Invoke(sender, e); }
        private void prepositionUnchecked(object sender, RoutedEventArgs e) { prepositionUnchecEvent.Invoke(sender, e); }
        private void conjunctionUnchecked(object sender, RoutedEventArgs e) { conjunctionUnchecEvent.Invoke(sender, e); }
        private void verbUnchecked(object sender, RoutedEventArgs e) { verbUnchecEvent.Invoke(sender, e); }
        private void numerUnchecked(object sender, RoutedEventArgs e) { numerUnchecEvent.Invoke(sender, e); }

        // check
        private void noun_Checked(object sender, RoutedEventArgs e)
        {
           
            if (e1 > 0)
            {
                ChecnounEv.Invoke(sender, e);

            }
            else
            {
                e1++;
            }
        }

        private void adjective_Checked(object sender, RoutedEventArgs e)
        {
           
            if (e2 > 0)
            {
                ChecadjectiEv.Invoke(sender, e);

            }
            else
            {
                e2++;
            }
        }

        private void adverb_Checked(object sender, RoutedEventArgs e)
        {
           
            if (e3 > 0)
            {
                ChecadverbEv.Invoke(sender, e);

            }
            else
            {
                e3++;
            }
        }

        private void pronoun_Checked(object sender, RoutedEventArgs e)
        {
           
            if (e4 > 0)
            {
                ChecpronounEv.Invoke(sender, e);

            }
            else
            {
                e4++;
            }
        }

        private void preposition_Checked(object sender, RoutedEventArgs e)
        {
         
            if (e5 > 0)
            {
                ChecpreposiEv.Invoke(sender, e);

            }
            else
            {
                e5++;
            }
            
        }

        private void conjunction_Checked(object sender, RoutedEventArgs e)
        {
        

            if (e6 > 0)
            {
                ChecconjuncEv.Invoke(sender, e);

            }
            else
            {
                e6++;
            }
        }

        private void verb_Checked(object sender, RoutedEventArgs e)
        {
        
            if (e7 > 0)
            {
                ChecverbUncEv.Invoke(sender, e);

            }
            else
            {
                e7++;
            }
        }

        private void numer_Checked(object sender, RoutedEventArgs e)
        {

            if (e8 > 0)
            {
                ChecverbUncEv.Invoke(sender, e);

            }
            else
            {
                e8++;
            }
        }


















        #endregion

      
    }
}
