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
    
    public partial class PAR_LIQ_DET
    {
        public string PALI_PLCO { get; set; }
        public string PALI_COID { get; set; }
        public System.DateTime PALI_FEIN { get; set; }
        public System.DateTime PALI_FEFI { get; set; }
        public string PALI_VALO { get; set; }
        public string PAR_DEC { get; set; }
        public Nullable<decimal> PALI_VANU { get; set; }
        public Nullable<System.DateTime> PALI_VADA { get; set; }
        public string PALI_USAP { get; set; }
        public string PALI_USBD { get; set; }
        public Nullable<System.DateTime> PALI_FREG { get; set; }
        public Nullable<System.DateTime> PALI_FNOV { get; set; }
    
        public virtual PARA_LIQU PARA_LIQU { get; set; }
    }
}
