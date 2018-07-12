using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Engl.DataBase
{
    [Table("word")]
    public class Word
    {
        [Key]
        public int id { get; set; }
        public string EN { get; set; }
        public string Ru { get; set; }
        public string SynonymsEn { get; set; }
        public string SynonymsRu { get; set; }
        public string PastSimiple { get; set; }
        public string PastPart { get; set; }

        public int NumberPart { get; set; }
        public int NumberKind { get; set; }
        public string Tema { get; set; }
        public int Count { get; set; }
        public int MistakeCount { get; set; }
        public int CompleteMistakeCount { get; set; }



    }
}
