using Engl.MainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engl.Kateroris
{
    class DependencyPropertySub
    {
        static double prog = 0;
        public static double LvlProgres { get { return prog; }
            set {

                prog = value;
            } }
        static public List<string> otherTems { get { return ModelSub.Read(); } }
        static public string FirstTems
        {
            get
            {
                StringBuilder s = new StringBuilder();

                for (int i = 2; i < Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic)).Length; i++)
                {

                    s.AppendLine(Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic)).GetValue(i).ToString());
                }
                return s.ToString();

            }
        }
    static  public List<string> AllLIstTems
        { get
            {
                List<string> ret = new List<string>();
                for (int ie = 0; ie < Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic)).Length; ie++)
                {

                    ret.Add(Enum.GetValues(typeof(Engl.ENUMS.EnumsTopic)).GetValue(ie).ToString());
                }

                foreach( var nl in otherTems)
                {
                    ret.Add(nl);
                }


                return ret;

                }
            }
        
        static public Addwin WindAdd { get; set; }
    }
}
