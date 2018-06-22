using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Engl.DataBase
{
    public class Words : DbContext
    {
        public Words(string constr)
            : base(constr)
        { }

        public DbSet<Word> wordList { get; set; }



    }





      

}
