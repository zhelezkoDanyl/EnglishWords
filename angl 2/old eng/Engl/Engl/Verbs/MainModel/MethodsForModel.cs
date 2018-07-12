using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl.DataBase;
using System.Text.RegularExpressions;
using System.Threading;

namespace Engl.MainModel
{
   public class MethodsForModel
    {
        #region Getwords
        
        private int lang { get { return  Leng; } }
        int Leng = 1;
        int count = 0;
        private List<Word> ListofFilytr;
        private List<Word> ListOtherWords;
        private List<Word> LisFil { get { if (ListofFilytr == null)
                {
                    ListofFilytr = ListOfTema();
                    
                }
                return ListofFilytr;
            } }
        // вспомогательный класс для информации сколь частей речи подключено ЧЕКБОКСЕ
        private  List<int> FilyterOfPard()
        {
            List<int> coun = new List<int>();

            for (int i = 0; i < ForSerial.Chck.Count; i++)
            {
                if (i < 8)
                {
                    if (ForSerial.Chck[i] == true)
                    {
                        coun.Add(i + 1);
                    }
                }
            }
            return coun;

        }
        // метод для фильтрации по частям речи и возращает лист ворд
        // изменить на прайвет
        private  List<Word> ListOfQuestn()
        {
            
            List<Word> Listreturn = new List<Word>();
            if (ForSerial.Chck.ElementAt(9))
            {
                Listreturn = Engl.Operation.ViewModel.DataMySelfList.ToList();
                return Listreturn;
            }
            else
            {
                #region OTHERCHECKEDBOX
                if (FilyterOfPard().Count == 8)
                {
                    Listreturn = DataBaseWithMethod.GetListWord;

                    //  System.Windows.MessageBox.Show("count 8");
                }
                else
                {
                    foreach (var d in FilyterOfPard())
                    {
                        if (ForSerial.Comb[d - 1] == 0)
                        {
                            var query = from list in DataBaseWithMethod.GetListWord
                                        where list.NumberPart == d

                                        select list;
                            foreach (var q in query)
                            {
                                Listreturn.Add(q);
                            }
                        }
                        else
                        {
                            var query = from list in DataBaseWithMethod.GetListWord
                                        where list.NumberPart == d && list.NumberKind == ForSerial.Comb[d - 1]

                                        select list;
                            foreach (var q in query)
                            {
                                Listreturn.Add(q);
                            }

                        }




                    }
                    //  System.Windows.MessageBox.Show("count == " + FilyterOfPard().Count);
                }

                return Listreturn;
                #endregion
            }

        }
        // for other 5 words list method выпор по части речи
        private List<Word> ListOther()
        {

            List<Word> Listreturn = new List<Word>();
            if (FilyterOfPard().Count == 8)
            {
                Listreturn = DataBaseWithMethod.GetListWord;

              //  System.Windows.MessageBox.Show("count 8");
            }
            else
            {
                foreach (var d in FilyterOfPard())
                {
                   
                        var query = from list in DataBaseWithMethod.GetListWord
                                    where list.NumberPart == d

                                    select list;
                        foreach (var q in query)
                        {
                            Listreturn.Add(q);
                        }
                


                 
                }
              //  System.Windows.MessageBox.Show("count == " + FilyterOfPard().Count);
            }
            return Listreturn;
        }
        // properti listother
        private List<Word> LisFiveOther
        {
            get
            {
                if (ListOtherWords == null)
                {
                    ListOtherWords = ListOther();

                }
                return ListOtherWords;
            }
        }

        //method for Quest
       
        //метод делает фильтр по тематике 
        private  List<Word> ListOfTema()
        {
            List<Word> Teemareturn = new List<Word>();
            if(ForSerial.Comb[8]==0)
            {
                Teemareturn = ListOfQuestn();
            }
            else if(ForSerial.Comb[8] == 1)
            {
                var qvery = from l in ListOfQuestn()
                            where l.Tema == null
                            select l;
                foreach (var fl in qvery)
                {
                    Teemareturn.Add(fl);
                }
            }
            else
            {
                var regex = new Regex(Enum.Format(typeof(ENUMS.EnumsTopic), ForSerial.Comb[8], "G"));
                var qvery = from l in ListOfQuestn()
                            where l.Tema !=null && regex.IsMatch(l.Tema)
                            select l;
                foreach(var fl in qvery)
                {
                    Teemareturn.Add(fl);
                }
            }

            return Teemareturn;
        }

        #region фильтер рендом и проядоk слов
        private int PickEnORRu(Word word)
        {
            if (ForSerial.Comb[9] == 0)
            {
                if(word.Count == 0)
                {
                    DateTime now = DateTime.Now;
                    int sec = now.Second;
                    if (sec % 2 == 0)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }

                }
                else
                {
                    if(word.Count%2==0)
                    {
                        return 2;
                    }

                    else
                    {
                        return 1;
                    }
                }
              
                

               
            }
            else if (ForSerial.Comb[9] == 1)
            {
                return 1;
            }
            else 
            {
                return 2;
            }
        }
        private IEnumerable<Word> ProverkaNaMinimalCount()
        {
            ForSerial.FCW = 1;
            ForSerial.LWFS = LisFil.ToList();
            for (int i = 3; i < 11; )
            {
                var QVERY = from list in LisFil
                            where list.Count < i
                            select list;
                if(QVERY.Count() != 0)
                {
                    // System.Windows.MessageBox.Show(" count " + i.ToString());
                    
                    return QVERY;
                    
                }
                i = i + 3;
                ForSerial.FCW++;
         
                if(i>9)
                {
                   // System.Windows.MessageBox.Show("Вы выучили все слова по вашему фильтру");
                    i = 10;
                }

            }
            System.Windows.MessageBox.Show("Не должно дойти до этой строки посмотреть counts  Слов");
            return null;


        }

        //Publics methods
        public Word RandomQuesion()
        {
            if (ForSerial.Chck[8] == true)
            {
                Random r = new Random();
                int randint = r.Next(ProverkaNaMinimalCount().Count() - 1);

                Leng = PickEnORRu( ProverkaNaMinimalCount().ElementAt(randint));
               
                return ProverkaNaMinimalCount().ElementAt(randint);
            }
            else
            {
               
                if (count < ENRUlist().Count)
                {
                    Word w = ENRUlist().ElementAt(count);
                
                    count++;
                    return w;
                }
                else
                {
                    count = 0;
                    Word w = ENRUlist().ElementAt(count);
                   
                    count++;
                    return w;
                }
              
              

            }
        }
        public List<Word> MethorOtherFiveRandom(Word word )
        {
            
            List<Word> list = new List<Word>();
            List<Word> FiveOteher = new List<Word>();

           
            #region region tupova rendoma который херова работает 
            
            DateTime d = DateTime.Now;
            int time = d.Millisecond;
         
            int et = time / 100;
            
           int w =  et;
            if (w > 5)
            {
                w = w - 5;
            }
            #endregion
            #region otobraty slova gde ne odinakovie zna4eniy
            //if (lang == 1)
            //{

            //    string patern = "[" + word.Ru + "]+$";
            //    var rex = new Regex(patern);
            //    var q = from en in LisFiveOther
            //            where en.Ru != word.Ru && en.NumberPart == word.NumberPart && en != word && rex.IsMatch(en.Ru)
            //            select en;
            //    foreach (var ww in q)
            //    {
            //        FiveOteher.Add(ww);
            //    }

            //}
            //else
            //{
            //    string patern = "[" + word.EN + "]+$";
            //    var rex = new Regex(patern);
            //    var q = from en in LisFiveOther
            //            where en.EN != word.EN && en.NumberPart == word.NumberPart && en != word && rex.IsMatch(en.EN)
            //            select en;
            //    foreach (var ww in q)
            //    {
            //        FiveOteher.Add(ww);
            //    }
            //}

            #endregion
            FiveOteher = FiveOtheMaxSimvol(LisFiveOther,word);
            List<Word> otbor5 = new List<Word>();
            for (int i = 0; i < 6; i++)
            {
                otbor5.Add(FiveOteher.ElementAt(i));

            }

            #region потбор рендомно в цикле ВИЛЛ
            bool tr = true;
            List<Word> Random5 = new List<Word>();
          
            Random random = new Random();
            int ran = random.Next(0, 5);
            while (tr)
            {             
                          
                   if(ran<6)
                    {
                        Random5.Add(otbor5.ElementAt(ran));
                    }
                    else
                    {
                        ran = 0;
                        Random5.Add(otbor5.ElementAt(ran));
                    }
                ran++;

                if (Random5.Count==6)
                {
                    tr = false;
                }
            }

            #endregion
            int rrt = FiveOteher.Count;
            List<Word> sixwords = new List<Word>();
            for (int i = 0; i < 6; i++)
            {
                if(i ==w)
                {
                    sixwords.Add(word);
                }
                else
                {
                    sixwords.Add(Random5.ElementAt(i));
                }
            }

               

             list = sixwords;


            #region для рандома первый вариант
            //for (int i = 0; i < 6; i++)
            //{
            //    if (w == i)
            //    {
            //        list.Add(word);
            //    }
            //    else
            //    {




            //            if (list.Count == 0)
            //            {
            //            try
            //            {
            //                int rr = R.Next(FiveOteher.Count - 1);
            //                list.Add(FiveOteher.ElementAt(rr));
            //            }
            //            catch
            //            {
            //                int rand1 = R.Next(SuportMethodForFiveRandom(list, LisFiveOther, word).Count - 1);
            //                list.Add(SuportMethodForFiveRandom(list, LisFiveOther, word).ElementAt(rand1));

            //            }
            //        }
            //            else
            //            {
            //                //List<Word> el = new List<Word>();
            //                //foreach(var elem in list)
            //                //{
            //                //    el.Add(elem);
            //                //}


            //                List<Word> recur = new List<Word>();


            //                // System.Windows.MessageBox.Show(recur.Equals(FiveOteher).ToString());
            //                var query = from ar in FiveOteher
            //                            where ar != list.ElementAt(i - 1)
            //                            select ar;

            //                foreach (var ww1 in query)
            //                {
            //                    recur.Add(ww1);
            //                }

            //                try
            //                {
            //                    FiveOteher = recur;
            //                    int rand = R.Next(FiveOteher.Count - 1);
            //                    list.Add(FiveOteher.ElementAt(rand));
            //                }
            //                catch 
            //                {

            //                int rand1 = R.Next(SuportMethodForFiveRandom(list, LisFiveOther, word).Count - 1);
            //                list.Add(SuportMethodForFiveRandom(list, LisFiveOther, word).ElementAt(rand1));

            //            }



            //        }



            //    }

            //}
            #endregion

        
            return list;

        }
        private List<Word> SuportMethodForFiveRandom(List<Word> five,List<Word> All, Word w)
        {
            List<Word> newlist = new List<Word>();
            var qur = from nl in All
                      where nl != w
                      select nl;
            foreach(var l in qur)
            {
                newlist.Add(l);
            }
        


            for (int i = 0; i < five.Count; i++)
            {
                List<Word> recur = new List<Word>();

                var query = from ar in newlist
                            where ar != five.ElementAt(i )
                            select ar;

                foreach (var ww1 in query)
                {
                    recur.Add(ww1);
                }
                newlist = recur;
            }

            return newlist;



        }
        public object GetStringObject(Word w, List<Word> quest)
        {
            
           ModelMain Main = new ModelMain();
            Main.GetWordsQuest = new List<string>();
            if (lang == 1)
            {
                Main.L1 = "En";
                Main.L2 = "Ru";

                if (w.NumberPart == 7)
                {
                    Main.GetWord = "to " + w.EN;
                    if (w.SynonymsEn == null)
                    {
                        Main.GetSynonym = null;
                    }
                    else
                    {
                        Main.GetSynonym = "Синоним ( " + w.SynonymsEn + " )";
                    }


                }
                else
                {
                    Main.GetWord = w.EN;
                    if (w.SynonymsEn == null)
                    {
                        Main.GetSynonym = null;
                    }
                    else
                    {
                        Main.GetSynonym= "Синоним ( " + w.SynonymsEn + " )";
                    }
                }
                for (int i = 0; i < quest.Count; i++)
                {
                    Main.GetWordsQuest.Add(quest.ElementAt(i).Ru.ToString());
                }


            }
            else
            {
                Main.L1 = "Ru";
                Main.L2 = "En";
                Main.GetWord = w.Ru;

                if (w.SynonymsRu == null)
                {
                    Main.GetSynonym = "";
                }
                else
                {
                    Main.GetSynonym = "Синоним ( " + w.SynonymsRu + " )";
                }

                if (w.NumberPart == 7)
                {

                    for (int i = 0; i < quest.Count; i++)
                    {
                        Main.GetWordsQuest.Add("to " + quest.ElementAt(i).EN.ToString());
                    }


                }
                else
                {
                    for (int i = 0; i < quest.Count; i++)
                    {
                        Main.GetWordsQuest.Add(quest.ElementAt(i).EN.ToString());
                    }
                }

            }



            return Main;
        }



        #region po alfa
        private List<Word> ENRUlist()
        {
           if(ForSerial.Comb[9] == 0)
            {
                DateTime now = DateTime.Now;
                int sec = now.Second;
                if (sec % 2 == 0)
                {
                    Leng = 2;
                    return RuList();
                }
                else
                {
                    Leng = 1;   
                    return EnLIst();
                }
            }
           else if(ForSerial.Comb[9] ==1)
            {
                Leng = 1;
                return EnLIst();
            }
            else {
                Leng = 2;
                return RuList(); }
        }
    private List<Word> EnLIst()
    {
        if (ForSerial.Comb[10] == 0)
        {
            var q = from len in ProverkaNaMinimalCount()
                    orderby len.EN ascending
                    select len;
            List<Word> w = new List<Word>();
            foreach (var en in q)
            {
                w.Add(en);
            }
            return w;


        }
        else
        {
            var q = from len in ProverkaNaMinimalCount()
                    orderby len.EN descending
                    select len;
            List<Word> w = new List<Word>();
            foreach (var en in q)
            {
                w.Add(en);
            }
            return w;
        }
    }
        private List<Word> RuList()
        {
            if (ForSerial.Comb[10] == 0)
            {
                var q = from len in ProverkaNaMinimalCount()
                        orderby len.Ru ascending
                        select len;
                List<Word> w = new List<Word>();
                foreach (var en in q)
                {
                    w.Add(en);
                }
                return w;


            }
            else
            {
                var q = from len in ProverkaNaMinimalCount()
                        orderby len.Ru descending
                        select len;
                List<Word> w = new List<Word>();
                foreach (var en in q)
                {
                    w.Add(en);
                }
                return w;
            }
        }
        #endregion


        #endregion
        #endregion

        #region Other method
        public string TrueOrFalse(bool tf)
        {
            string returnstring;
            if (tf)
            {
                returnstring = "ВЕРНО";
            }
            else
            {
                returnstring = "НЕ ВЕРНО!!!  ";
            }
            return returnstring;
        }
        public int ProverkaCounWordsForFilyter()
        {
            int count = ListOfTema().Count;
            return count;
        }
        public List<Word> FiveOtheMaxSimvol(List<Word> Lwor, Word word)
        {
            List<Word> ForReturn = new List<Word>();
            List<ForFiveword> fiveword = new List<MainModel.ForFiveword>();

            if (lang == 2)
            {
                string paternrREP = Regex.Replace(word.EN,  // Исходная строка.
                                       "-",                      // Шаблон.
                                        "");
                string patern = "[" + paternrREP + "]";
                var rex = new Regex(patern);
                var qv = from qq in Lwor
                         where qq.EN.ToCharArray().Count() < word.EN.ToCharArray().Count() + 3
                         && qq.EN.ToLowerInvariant() != word.EN.ToLowerInvariant()
                         && qq.NumberPart == word.NumberPart
                         && qq.Ru.ToLowerInvariant() != word.Ru.ToLowerInvariant()
                        

                         select qq;
                var filter2 = qv.ToList();
                var qv2 = from f2 in filter2
                          where word.SynonymsEn != null ? (f2.EN.ToLowerInvariant() != word.SynonymsEn.ToLowerInvariant()) : (true)
                                  && word.SynonymsRu != null ? (f2.Ru.ToLowerInvariant() != word.SynonymsRu.ToLowerInvariant()) : (true)
                          select f2;
                foreach (var w in qv2)
                {
                    int maxcount = 0;
                    for (int i = 0; i < w.EN.ToCharArray().Count(); i++)
                    {

                        string str = w.EN.ElementAt(i).ToString();
                        if (rex.IsMatch(str))
                        {
                            maxcount++;
                        }


                    }
                    ForFiveword supFiveword = new ForFiveword();
                    supFiveword.CountChar = maxcount;
                    supFiveword.Word = w;
                    fiveword.Add(supFiveword);
                }
            }
            else
            {
                string paternrREP = Regex.Replace(word.EN,  // Исходная строка.
                                             "-",                      // Шаблон.
                                              "");
                string patern = "[" + paternrREP + "]";
                var rex = new Regex(patern);
                var qv = from qq in Lwor
                         where qq.EN.ToCharArray().Count() < word.EN.ToCharArray().Count() + 3
                         && qq.Ru.ToLowerInvariant() != word.Ru.ToLowerInvariant()
                         && qq.NumberPart == word.NumberPart
                         && qq.EN.ToLowerInvariant() != word.EN.ToLowerInvariant()
                        
                         select qq;
                var filter2 = qv.ToList();

                var qv2 = from f2 in filter2
                          where word.SynonymsEn != null ? (f2.EN.ToLowerInvariant() != word.SynonymsEn.ToLowerInvariant()) : (true)
                                && word.SynonymsRu != null ? (f2.Ru.ToLowerInvariant() != word.SynonymsRu.ToLowerInvariant()) : (true)
                          select f2;
                foreach (var w in qv2)
                {
                    int maxcount = 0;
                    for (int i = 0; i < w.EN.ToCharArray().Count(); i++)
                    {

                        string str = w.EN.ElementAt(i).ToString();
                        if (rex.IsMatch(str))
                        {
                            maxcount++;
                        }

                    }
                    ForFiveword supFiveword = new ForFiveword();
                    supFiveword.CountChar = maxcount;
                    supFiveword.Word = w;
                    fiveword.Add(supFiveword);
                }

            }
            //  если коунт fiveword меньше 6 то добавить еще слов
            try
            {


                #region esli malo slow
                if (fiveword.Count < 6)
                {
                    List<ForFiveword> AddOtherword = new List<ForFiveword>();
                    foreach (var f in fiveword)
                    {
                        AddOtherword.Add(f);
                    }
                    List<Word> testadd = new List<Word>();
                    var qver = from qu in Lwor
                               where qu.NumberPart == word.NumberPart
                               select qu;
                    foreach (var test in qver)
                    {
                        int countWord = 0;
                        foreach (var tf in AddOtherword)
                        {
                            if (test == tf.Word)
                            {
                                countWord++;
                            }
                        }
                        if (countWord == 0)
                        {
                            testadd.Add(test);
                        }

                    }

                    for (int i = 0; i < 6 - fiveword.Count; i++)
                    {

                        ForFiveword supFiveword = new ForFiveword();
                        supFiveword.CountChar = -1;

                        supFiveword.Word = testadd.ElementAt(i);

                        AddOtherword.Add(supFiveword);


                    }

                    fiveword = AddOtherword;

                }
                #endregion
            }
            catch(Exception ee)
            {
                System.Windows.MessageBox.Show("Мало слов для вриантов ответов  " + ee.ToString());
            }


            var quer = from f in fiveword
                       where f.Word != word
                       orderby  f.CountChar descending, f.Word.Tema == word.Tema//, f.Word.Tema != word.Tema
                       select f;
            foreach (var q in quer)
            {

                ForReturn.Add(q.Word);
            }
            List<Word> ZapasVariant = new List<Word>();
            ZapasVariant = ForReturn.ToList();
            #region начало чистки от одинаковых слов
           if (ForReturn.Count>6)
           {
                List<Word> otbor = new List<Word>();
                List<Word> var2 = new List<Word>();
                otbor = ForReturn.ToList();

                bool tr = true;   
           while(tr)
                {
                    tr = false;
                for (int i = 0; i < otbor.Count; i++)
                {
                var2 = ForReturn.ToList();
                      
                int count = 0;
                    for (int j = 0; j < var2.Count; j++)
                    {

                        if (otbor.ElementAt(i).Ru == var2.ElementAt(j).Ru || otbor.ElementAt(i).EN == var2.ElementAt(j).EN)
                        {
                            count++;
                            if (count > 1)
                            {
                                    tr = true;
                                ForReturn.Remove(ForReturn.ElementAt(j));
                                break;

                            }

                        }
                    }

           

                 }
                }

            }
            #endregion
            if(ForReturn.Count<5)
            {
                return ZapasVariant;
            }
            else
            {
                return ForReturn;
            }

        }

        #endregion
        public void MethodReadCount(bool tf , Word w , Word w2)
        {
            if(tf)
            {
                if(w.Count <9)
                {
                    w.Count = w.Count + 1;
                }
                else { w.Count = 9; }
              
            }

            else
            {
                w.MistakeCount = +1;
                w2.MistakeCount = +1;
                w2.CompleteMistakeCount = +1;
                w.CompleteMistakeCount = +1;
                if (w.Count > 0)
                {
                    w.Count = w.Count - 1;
                    
                }
                else { w.Count = 0; }
                // усложнения на втором уровне - за ниправильный ответ отнимается звезды в двух словах которе паказано и которое было выбрано!
                if(ForSerial.FCW>1)
                {
                    if (w2.Count > 0)
                    {
                        w2.Count = w2.Count - 1;
                    }
                    else { w2.Count = 0; }
                }
            }

            DataBaseWithMethod.UpDate();
        }
        //public void Blink(System.Windows.Controls.Label label, System.Windows.Media.SolidColorBrush br1)
        //{
        //    label.Foreground = br1;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        label.Opacity = 0.4;
        //        Thread.Sleep(1000);
        //        label.Opacity = 1;
        //        Thread.Sleep(1000);
        //    }
            
        //}
     
        static private void Zapolnenielist()
        {
            //ChBx.Add(f.noun);                  ----- gotovo
            //ChBx.Add(f.adjective);             ----- gotovo
            //ChBx.Add(f.adverb);                ----- gotovo
            //ChBx.Add(f.pronoun);               ----- gotovo
            //ChBx.Add(f.preposition);           ----- gotovo
            //ChBx.Add(f.conjunction);           ----- gotovo
            //ChBx.Add(f.verb);                  ----- gotovo
            //ChBx.Add(f.numer);                 ----- gotovo
            //ChBx.Add(f.RandomFilterAZ);



            //1  //CombBx.Add(f.NounCombo);                              --- gotovo
            //CombBx.Add(f.adjectCombo);                             --- gotovo
            //CombBx.Add(f.AdvedCombo);                              --- gotovo
            //CombBx.Add(f.PronounCombo);                            --- gotovo
            //CombBx.Add(f.PreepositionCombo);                       --- gotovo
            //CombBx.Add(f.conjuctionCombo);                         --- gotovo
            //CombBx.Add(f.verbCombo);                               --- gotovo
            //8  //CombBx.Add(f.numeralCombo);                          --- gotovo

            //9  //CombBx.Add(f.Topic2);                                 --- gotovo

            //10    //CombBx.Add(f.EnRu);
            //11    //CombBx.Add(f.AZorZA);
            //12    //CombBx.Add(f.AZ);
            //13    //CombBx.Add(f.AR);




        }
    }
}
