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
    
    public partial class RELA_AGETER
    {
        public Nullable<decimal> REL_CONS { get; set; }
        public string REL_TDOC { get; set; }
        public string REL_AGE { get; set; }
        public string REL_DVER { get; set; }
        public string REL_TDOCREV { get; set; }
        public string REL_REV { get; set; }
        public string REL_TREV { get; set; }
        public string REL_TARPRO { get; set; }
        public string REL_TDOCDEC { get; set; }
        public string REL_DEC { get; set; }
        public string REL_TDEC { get; set; }
        public string REL_EST { get; set; }
        public string REL_USBD { get; set; }
        public string REL_USAP { get; set; }
        public Nullable<System.DateTime> REL_FNOV { get; set; }
        public Nullable<System.DateTime> REL_FREG { get; set; }
    
        public virtual TERCEROS TERCEROS { get; set; }
        public virtual TERCEROS TERCEROS1 { get; set; }
    }
}
