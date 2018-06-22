using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engl.DataBase
{
    public static class CreateClassWords
    {
        static Words cust;

        public static Words MyWords {

            get {
                   if(cust != null)
                {
                    return cust;
                }
                   else
                {
                   return cust = new Words("Words");
                }

                 
                    
                    }
        }

    }
}
