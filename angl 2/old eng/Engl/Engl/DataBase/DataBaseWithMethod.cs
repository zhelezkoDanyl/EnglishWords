using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engl.DataBase
{
   static class DataBaseWithMethod
    {
        // for combobox PartofSpech
        static public int PartOfSpechtype;
        static  public List<Word> GetListWord
        { get { return CreateClassWords.MyWords.wordList.ToList(); } }

     static   public void add(Word w)
        {
       
            try
            {
                CreateClassWords.MyWords.wordList.Add(w);
                CreateClassWords.MyWords.SaveChanges();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
     static   public void del(Word w)
        {

            try
            {

                CreateClassWords.MyWords.wordList.Remove(w);
                CreateClassWords.MyWords.SaveChanges();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        
                

          
        }
        static public void Cancel()
        {

            try
            {




              //  CreateClassWords.MyWords.Dispose();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
        static public void UpDate()
        {

            
            try
            {

               


                CreateClassWords.MyWords.SaveChanges();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
     static   public void ClearAllCount()
        {

            foreach (var words in DataBaseWithMethod.GetListWord)
            {
                words.Count = 0;
                words.MistakeCount = 0;
                words.CompleteMistakeCount = 0;
            }
            CreateClassWords.MyWords.SaveChanges();
        }
    }
}

