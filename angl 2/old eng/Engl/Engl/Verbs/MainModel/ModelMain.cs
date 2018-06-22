using Engl.DataBase;
using Engl.ENUMS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engl.MainModel
{
   public static class ForSerial
    {
        public static List<Word> listWordForSravneniya;
        public static List<Word> LWFS
        {
            //get
            //{
            //    if (listWordForSravneniya != null)
            //    {
            //        return listWordForSravneniya;
            //    }
            //    else
            //    {
            //        listWordForSravneniya = new List<Word>();
            //        return listWordForSravneniya;
            //    }
            //}
            set {
                if (listWordForSravneniya == null)
                    listWordForSravneniya = new List<Word>();
                listWordForSravneniya = value;
            }
        }
        public static string sravnenieOstatka
        {
            get
            {
                int till = 0;
                int now = 0;
                int s1 = 0;
                int s2 = 0;
                int next = 0;
                int needGoAhead = 0;
                int quest = 0;
                int progres = 0;
                int c1, c2, c3, c4;
                string ostatok;

                int j = 1;
                #region podschet
                for (int i = 0; i < 10; )
                {
                    
                    if (FCW == j)
                    {
                        var q = from f in listWordForSravneniya
                                where f.Count == i || f.Count < i 
                                select f;
                       
                        till = q.ToList().Count;

                        var q2 = from f in listWordForSravneniya
                                 where f.Count == i+1 
                                 select f;
                        s1 = q2.ToList().Count;
                        var q22 = from f in listWordForSravneniya
                                 where  f.Count == i + 2
                                 select f;
                        s2 = q22.ToList().Count;
                        var q3 = from f in listWordForSravneniya
                                 where f.Count == i+3 || f.Count > i+3
                                 select f;
                        next = q3.ToList().Count;

                    }
                    j++;
                    i = i + 3;
                }
                #endregion

                now = s1 + s2;
                needGoAhead = till + now;
                int allWordThisLvl = needGoAhead +next;

                #region Formula

                c1 = till * 3;
                c2 = s1 * 2;
                c3 = s2;
                c4 = 0;
                quest = c1 + c2 + c3 + c4;// ostalosy voprosov dlya perehoda v sled lvl
                double w1 = allWordThisLvl;
                double w2 = quest;
                double ost = 100 - (w2 /( w1 * 3 / 100)) ;
                
                Engl.Kateroris.DependencyPropertySub.LvlProgres = ost;
                #endregion
                ostatok = string.Format("         Осталось cлов = {0} / {2} Вопросв > {3}  progress {1:P} ", needGoAhead, ost/100,allWordThisLvl,quest);
                return ostatok;
           
            }
        }
        public static string Lvl
        { get {
                
                if(ForCounWord >3)
                {
                    string s1 = "По выбраному вильтру вы вучили все слова Level 3/" + 3;
                    return s1;
                }
                else
                {
                    string s = "Level " + ForCounWord + " / " + 3;
                    return s;
                }
                
                 } }
     
       

        static int ForCounWord= 1;
      public  static int FCW { get { return ForCounWord; }
       set { ForCounWord = value; }
        }

        static List<bool> ChBx;
        static List<int> CombBx;

        public static List<int> Comb
        {
            get
            {
                if (CombBx != null)
                {
                    return CombBx;
                }
                else
                {
                    CombBx = new List<int>();
                    return CombBx = deserialComb();
                }
             }
            set { CombBx = value; }
        }
        public static List<bool> Chck
        {
            get
            {
                if (ChBx != null)
                {
                    return ChBx;
                }
                else
                {
                    ChBx = new List<bool>();
                    return ChBx = deserialCHec();
                }
            }
            set { ChBx = value; }
        }

        static private List<int> deserialComb()
        {
           
            FileStream stream = new FileStream("Serialization.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Engl.ENUMS.SEareliz s2 = new ENUMS.SEareliz();
            XmlSerializer serializer = new XmlSerializer(typeof(SEareliz));

            s2 = serializer.Deserialize(stream) as SEareliz;
            stream.Close();
            for (int i = 0; i < s2.COMB.Count; i++)
            {
                CombBx.Add(s2.COMB[i]);
            }
            //for (int i = 0; i < ChBx.Count; i++)
            //{
            //    ChBx[i].IsChecked = s2.CHECK[i];
            //}
            return CombBx;


        }
        static private List<bool> deserialCHec()
        {

            FileStream stream = new FileStream("Serialization.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Engl.ENUMS.SEareliz s2 = new ENUMS.SEareliz();
            XmlSerializer serializer = new XmlSerializer(typeof(SEareliz));

            s2 = serializer.Deserialize(stream) as SEareliz;
            stream.Close();

            for (int i = 0; i < s2.CHECK.Count; i++)
            {
                ChBx.Add(s2.CHECK[i]);
            }
          

            return ChBx;


        }

    }
    class ModelMain
    {


      
        public string L1
        {
            get;set;
          


        }
         public string L2
        {
            get;set;
        }
        public string GetWord
        {
            get;set;
            
        }
        public  List<string> GetWordsQuest { get; set; }
        public string GetSynonym { get; set; }



    }

    class ForFiveword
    {
        public Engl.DataBase.Word Word { get; set; }
        public int CountChar { get; set; }
    }

}
