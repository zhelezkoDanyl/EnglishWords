using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Controls;

namespace Engl.ENUMS
{
    [XmlRoot("ClassSerialize")]
    [Serializable]
    public class SEareliz
    {
      
        List<bool> LisChBx = new List<bool>();
                List<int> LisComBx = new List<int>();
        List<int> datagrid = new List<int>();
                #region TEST
        //        // checboxs 
        //bool ChBX1no  ;
        //bool ChBX2adj ;
        //bool ChBX3adv ;
        //bool ChBX4proun;
        //bool ChBX5prepos;
        //bool ChBX6conj ;
        //bool ChBX7verb ;
        //bool ChBX8nurme;
        //bool ChBX9random;

        //// Comboboxs

        //string CmBx1no  ;
        //string CmBx2adj ;
        //string CmBx3adv ;
        //string CmBx4pro ;
        //string CmBx5pre ;
        //string CmBx6con ;
        //string CmBx7ver ;
        //string CmBx8nur ;
        //string CmBxTopic;
        //string CmBxEnRu ;
        //string CmBxAZorZA;
        //string CmBxAz ;
        //string CmBxAr ;

        //public SEareliz()
        //{
        //    LisChBx.Add(ChBX1no);
        //    LisChBx.Add(ChBX2adj);
        //    LisChBx.Add(ChBX3adv);
        //    LisChBx.Add(ChBX4proun);
        //    LisChBx.Add(ChBX5prepos);
        //    LisChBx.Add(ChBX6conj);
        //    LisChBx.Add(ChBX7verb);
        //    LisChBx.Add(ChBX8nurme);
        //    LisChBx.Add(ChBX9random);

        //    LisComBx.Add(CmBx1no );
        //    LisComBx.Add(CmBx2adj);
        //    LisComBx.Add(CmBx3adv);
        //    LisComBx.Add(CmBx4pro);
        //    LisComBx.Add(CmBx5pre);
        //    LisComBx.Add(CmBx6con);
        //    LisComBx.Add(CmBx7ver);
        //    LisComBx.Add(CmBx8nur);
        //    LisComBx.Add(CmBxTopic);
        //    LisComBx.Add(CmBxEnRu);
        //    LisComBx.Add(CmBxAZorZA);
        //    LisComBx.Add(CmBxAz);
        //    LisComBx.Add(CmBxAr);
            

        //}
#endregion




        [XmlArray("Listbool")]
        // Характеристика каждого элемента массива.
        [XmlArrayItem("Elementbool")] 
        public List<bool> CHECK
        {
            get { return LisChBx; }
            set { LisChBx = value; }
        }

        [XmlArray("ListString")]
        // Характеристика каждого элемента массива.
        [XmlArrayItem("ElementingStr")] 
        public List<int> COMB
        {
            get { return LisComBx; }
            set { LisComBx = value; }
        }

        [XmlArrayItem("ElementInt")]
        public List<int> Data
        {
            get { return datagrid; }
            set { datagrid = value; }
        }



    }
}
