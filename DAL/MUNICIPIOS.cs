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
    
    public partial class MUNICIPIOS
    {
        public MUNICIPIOS()
        {
            this.TERCEROS = new HashSet<TERCEROS>();
        }
    
        public string MUN_COD { get; set; }
        public string MUN_NOM { get; set; }
        public string MUN_USAP { get; set; }
        public string MUN_USBD { get; set; }
        public Nullable<System.DateTime> MUN_FREG { get; set; }
        public Nullable<System.DateTime> MUN_FNOV { get; set; }
        public string MUN_DPCO { get; set; }
    
        public virtual ICollection<TERCEROS> TERCEROS { get; set; }
    }
}