using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engl.Kateroris
{
public    class ModelSub
    {
        private static string text = "tema.txt";
        private string ErorAboutEquel = "Такая тема уже существует";
        public void addTem(string tema)
        {
            if(LenthChar(tema))
            {
                Write(tema);
            }
           
           
        }

        public void EditTema(string before,string after)
        {
            if(LenthChar(after))
            {
                Edit(before, after);
            }
            
        }
        public void Delet(string delstr)
        {
            try
            {
                List<string> newlist = new List<string>();
                foreach (var n in Read())
                {
                    if (n != delstr)
                    {
                        newlist.Add(n);
                    }
                  

                }

                System.IO.File.Delete(text);

                Stream s = new FileStream(text, FileMode.OpenOrCreate);

                StreamWriter d = new StreamWriter(s);
                StreamReader r = new StreamReader(s);
                //r.ReadToEnd();

                foreach (var z in newlist)
                {
                    d.WriteLine(z);
                }
                d.Close();



            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }

        }
        private void Write(string str)
        {
            if (ComperaChecEquel(str))
            {
                #region try write
                try
                {
                    Stream s = new FileStream(text, FileMode.OpenOrCreate);

                    StreamWriter d = new StreamWriter(s);
                    StreamReader r = new StreamReader(s);
                    r.ReadToEnd();

                    d.WriteLine(str);
                    d.Close();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }
                #endregion
            }
            else
            {
                System.Windows.MessageBox.Show(ErorAboutEquel);
            }
        }
        static     public List<string> Read()
        {
            Stream s = new FileStream(text, FileMode.OpenOrCreate);
            s.Close();
            List<string> strlist = new List<string>();
                strlist = File.ReadAllLines(text).ToList();
           
            #region dliniySposob
            //Stream f = new FileStream(text, FileMode.OpenOrCreate);
            //StreamReader read = new StreamReader(f);
            //bool tf = true;
            //while (tf)
            //{
            //    string test = read.ReadLine();
            //    if (test != null)
            //    {
            //        strlist.Add(test);
            //    }
            //    else
            //    {
            //        tf = false;
            //    }


            //}








            //read.Close();
            #endregion


            return strlist;
            
        }
        private void Edit(string before, string after)
        {
            if (!ComperaChecEquel(before))
            {
                #region PRoverka na Equel
                if (ComperaChecEquel(after))
                {
                    #region redact
                    try
                    {
                        List<string> newlist = new List<string>();
                        foreach (var n in Read())
                        {
                            if (n == before)
                            {
                                newlist.Add(after);
                            }
                            else
                            {
                                newlist.Add(n);
                            }

                        }

                        System.IO.File.Delete(text);

                        Stream s = new FileStream(text, FileMode.OpenOrCreate);

                        StreamWriter d = new StreamWriter(s);
                        StreamReader r = new StreamReader(s);
                        //r.ReadToEnd();

                        foreach (var z in newlist)
                        {
                            d.WriteLine(z);
                        }
                        d.Close();



                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show(e.ToString());
                    }
                    #endregion
                }
                else
                {
                    System.Windows.MessageBox.Show(ErorAboutEquel);
                }
                #endregion
            }
            else
            {
                System.Windows.MessageBox.Show("this Item not exist ");
            }
        }
        private bool ComperaChecEquel(string tema)
        {
            for (int i = 2; i < Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic)).Length; i++)
            {
                if (tema.ToLower() == Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic)).GetValue(i).ToString().ToLower())
                {
                    return false;
                }
            }
            foreach(var re in Read())
            {
                if(tema.ToLower() == re.ToLower())
                {
                    return false;
                }
            }
            return true;
        }
        private bool LenthChar(string text)
        {
            if(text.Length >20)
            {
                System.Windows.MessageBox.Show("Темама не должна иметь больше 20 символов!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
