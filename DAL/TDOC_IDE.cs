//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TDOC_IDE
    {
        public TDOC_IDE()
        {
            this.TERCEROS = new HashSet<TERCEROS>();
        }
    
        public string TDOC_COD { get; set; }
        public string TDOC_NOM { get; set; }
        public string TDOC_USAP { get; set; }
        public string TDOC_USBD { get; set; }
        public Nullable<System.DateTime> TDOC_FREG { get; set; }
        public Nullable<System.DateTime> TDOC_FNOV { get; set; }
    
        public virtual ICollection<TERCEROS> TERCEROS { get; set; }
    }
}
