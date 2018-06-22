using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl.DataBase;
using Engl.Operation;
using System.Text.RegularExpressions;

namespace Engl.Verbs
{
    public class ModelVerbs
    {
        public List<VerbsWord> Fyltr(List<System.Windows.Controls.CheckBox> LCB, List<System.Windows.Controls.CheckBox> LB)
        {
            return ChecRimalist(LB, CheckedList(LCB));
        }

        private List<VerbsWord> CheckedList(List<System.Windows.Controls.CheckBox> LCB)
        {
            int coun = 0;
            List<VerbsWord> lc = new List<VerbsWord>();
            for (int i = 0; i < LCB.Count; i++)
            {
                if (LCB.ElementAt(i).IsChecked == true)
                {
                    coun++;
                    foreach (var ff in listList().ElementAt(i))
                    {
                        lc.Add(ff);
                    }
                }

            }

            if (coun == 0)
            {

                return ViewModel.DataVerbs;
            }
            else
            {

                return lc;
            }
        }

       private List<VerbsWord> ChecRimalist(List<System.Windows.Controls.CheckBox> LB, List<VerbsWord> L)
        {
            int coun = 0;
            List<VerbsWord> lc = new List<VerbsWord>();
            for (int i = 0; i < LB.Count; i++)
            {
                if (LB.ElementAt(i).IsChecked == true)
                {
                    coun++;
                    foreach (var ff in listMethodsRima(L).ElementAt(i))
                    {
                        lc.Add(ff);
                    }
                }

            }

            if (coun == 0)
            {

                return L;
            }
            else
            {

                return lc;
            }

        }

        // list of methods for fyltr of Verbs
        private List<List<VerbsWord>> listList()
        {
            List<List<VerbsWord>> ll = new List<List<VerbsWord>>();
            ll.Add(AllVerbsRaven());
            ll.Add(v1Rv2NV3());
            ll.Add(v1Nv2RV3());
            ll.Add(v1Rv3NV2());
            ll.Add(AllVerbsDONTRaven());
            return ll;
        }
        // list of methods for fylytr RIMA
        private List<List<VerbsWord>> listMethodsRima(List<VerbsWord> lvw)
        {
            List<List<VerbsWord>> ll = new List<List<VerbsWord>>();
            ll.Add(FyltrpppGHT( lvw));
            ll.Add(FyltrpppTD(lvw));

            ll.Add(FyltrpppNM(lvw));
            ll.Add(FyltrpppEN(lvw));
            ll.Add(FyltrpppWN(lvw));

            ll.Add(FyltrpppKG(lvw));
            return ll;
        }
        #region methods for fyltr of Verbs
        //1
        private List<VerbsWord> AllVerbsRaven()
        {

            var qvery = from vd in ViewModel.DataVerbs
                        where vd.EnForms1 == vd.VerbForms2 & vd.VerbForms2 == vd.VerbForms3
                        select vd;
            List<VerbsWord> vw = new List<VerbsWord>();
            foreach (var q in qvery)
            {
                vw.Add(q);
            }
            return vw;
        }

        //2
        private List<VerbsWord> v1Rv2NV3()
        {
            var qvery = from vd in ViewModel.DataVerbs
                        where vd.EnForms1 == vd.VerbForms2 & vd.VerbForms2 != vd.VerbForms3
                        select vd;
            List<VerbsWord> vw = new List<VerbsWord>();
            foreach (var q in qvery)
            {
                vw.Add(q);
            }
            return vw;
        }
        //3
        private List<VerbsWord> v1Nv2RV3()
        {
            var qvery = from vd in ViewModel.DataVerbs
                        where vd.EnForms1 != vd.VerbForms2 & vd.VerbForms2 == vd.VerbForms3
                        select vd;
            List<VerbsWord> vw = new List<VerbsWord>();
            foreach (var q in qvery)
            {
                vw.Add(q);
            }
            return vw;
        }
        //4
        private List<VerbsWord> v1Rv3NV2()
        {
            var qvery = from vd in ViewModel.DataVerbs
                        where vd.EnForms1 == vd.VerbForms3 & vd.VerbForms2 != vd.VerbForms3
                        select vd;
            List<VerbsWord> vw = new List<VerbsWord>();
            foreach (var q in qvery)
            {
                vw.Add(q);
            }
            return vw;
        }

        //5
        private List<VerbsWord> AllVerbsDONTRaven()
        {

            var qvery = from vd in ViewModel.DataVerbs
                        where vd.EnForms1 != vd.VerbForms2 & vd.VerbForms2 != vd.VerbForms3 & vd.EnForms1 != vd.VerbForms3
                        select vd;
            List<VerbsWord> vw = new List<VerbsWord>();
            foreach (var q in qvery)
            {
                vw.Add(q);
            }
            return vw;
        }
        #endregion

    
        #region fylytr rifma All methods
        private List<VerbsWord> FyltrpppGHT(List<VerbsWord> lvw)
        {
            List<VerbsWord> listNewVerbWord = new List<VerbsWord>();



            string patern = "ght+$";
        
            Regex r = new Regex(patern);
         

            var qvery = from l in lvw
                        where r.IsMatch(l.VerbForms3) 
                        select l;
            listNewVerbWord = qvery.ToList();

            return listNewVerbWord;
        }
        private List<VerbsWord> FyltrpppTD(List<VerbsWord> lvw)
        {
            List<VerbsWord> listNewVerbWord = new List<VerbsWord>();



            string patern = "t+$";
            string patern1 = "d+$";
            string patern2 = "ght+$";
            string paternDE = "de+$";

            Regex r = new Regex(patern);
            Regex r2 = new Regex(patern2);
            Regex r1 = new Regex(patern1);
            Regex r1DE = new Regex(paternDE);


            var qvery = from l in lvw
                        where r.IsMatch(l.VerbForms3) & r2.IsMatch(l.VerbForms3) == false || r1.IsMatch(l.VerbForms3) || r1DE.IsMatch(l.VerbForms3)
                        select l;
            listNewVerbWord = qvery.ToList();

            return listNewVerbWord;

        }



        private List<VerbsWord> FyltrpppNM(List<VerbsWord> lvw)
        {
            List<VerbsWord> listNewVerbWord = new List<VerbsWord>();
         


            string patern = "n+$";
            string patern1 = "en+$";
            string patern2 = "wn+$";
            string paternm = "m+$";
            string paternNE = "ne+$";
            string paternME = "me+$";

            Regex r = new Regex(patern);
            Regex r2 = new Regex(patern2);
            Regex r1 = new Regex(patern1);
            Regex rm = new Regex(paternm);
            Regex rNE = new Regex(paternNE);
            Regex rME = new Regex(paternME);

            var qvery = from l in lvw
                        where r.IsMatch(l.VerbForms3) & r2.IsMatch(l.VerbForms3) == false
                        & r1.IsMatch(l.VerbForms3) == false || rm.IsMatch(l.VerbForms3) 
                        || rNE.IsMatch(l.VerbForms3) || rME.IsMatch(l.VerbForms3)
                        select l;
            listNewVerbWord = qvery.ToList();

            return listNewVerbWord;

        }
        private List<VerbsWord> FyltrpppEN (List<VerbsWord> lvw)
        {
            List<VerbsWord> listNewVerbWord = new List<VerbsWord>();
            string patern = "en+$";
            Regex r = new Regex(patern);

            var qvery = from l in lvw
                        where r.IsMatch(l.VerbForms3)
                        select l;
          
                listNewVerbWord = qvery.ToList();
            
            return listNewVerbWord;

        }

        private List<VerbsWord> FyltrpppWN(List<VerbsWord> lvw)
        { 
            List<VerbsWord> listNewVerbWord = new List<VerbsWord>();
            string patern = "wn+$";
            Regex r = new Regex(patern);

            var qvery = from l in lvw
                        where r.IsMatch(l.VerbForms3)
                        select l;
            listNewVerbWord = qvery.ToList();


            return listNewVerbWord;

        }



        private List<VerbsWord> FyltrpppKG(List<VerbsWord> lvw)
        {
            List<VerbsWord> listNewVerbWord = new List<VerbsWord>();



            string patern = "k+$";
            string patern1 = "g+$";
            

            Regex r = new Regex(patern);
        
            Regex r1 = new Regex(patern1);


            var qvery = from l in lvw
                        where r.IsMatch(l.VerbForms3) || r1.IsMatch(l.VerbForms3)
                        select l;
            listNewVerbWord = qvery.ToList();

            return listNewVerbWord;

        }

        #endregion


    }
}
