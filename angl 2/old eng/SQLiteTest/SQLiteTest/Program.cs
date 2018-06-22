using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace SQLiteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var wr = new Words("Words");
            var w = wr.wordList.ToList();
            var dbAllword = new Engl2Entities();


            //foreach (var dd in dbAllword.TestAllWords)
            //{

            //    Word wor = new Word();
            //    wor.id = dd.Id;
            //    wor.EN = dd.Engword;
            //    wor.Ru = dd.RuWord;
            //    wor.SinonimEn = dd.SinonimEn;
            //    wor.SinonimRu = dd.SinonimRu;
            //    wor.PastSimiple = dd.PastSimple;
            //    wor.PastPart = dd.PastPart;
            //    wor.NumberPart = dd.numberPart;
            //    wor.NumberKind = dd.numberKind;
            //    wr.wordList.Add(wor);
            //}
            //wr.SaveChanges();

            foreach (var dd in wr.wordList.ToList())
            {
                Console.WriteLine(dd.id);
                Console.WriteLine(dd.EN);
                Console.WriteLine(dd.Ru);
            }

            Console.WriteLine("The end");

            Console.ReadLine();
        }
    }

    public class Words : DbContext
    {
        public Words(string constr)
            : base(constr)
        { }

        public DbSet<Word> wordList { get; set; }
        


    }


    [Table("word")]
    public class Word 
    {
       [Key]
        public int id { get; set; }
        public string EN { get; set; }
        public string Ru { get; set; }
        public string SinonimEn { get; set; }
        public string SinonimRu { get; set; }
        public string PastSimiple { get; set; }
        public string PastPart { get; set; }

        public int NumberPart { get; set; }
         public int NumberKind { get; set; }
        public string Tema { get; set; }






    }

}
