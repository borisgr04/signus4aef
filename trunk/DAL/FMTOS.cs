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
    
    public partial class FMTOS
    {
        public FMTOS()
        {
            this.FMTO_IMP = new HashSet<FMTO_IMP>();
        }
    
        public string FMTO_CODI { get; set; }
        public string FMTO_NOMB { get; set; }
        public string FMTO_DESC { get; set; }
        public string FMTO_CDEC { get; set; }
        public string FMTO_EST { get; set; }
        public string FMTO_USAP { get; set; }
        public string FMTO_USBD { get; set; }
        public Nullable<System.DateTime> FMTO_FREG { get; set; }
        public Nullable<System.DateTime> FMTO_FNOV { get; set; }
    
        public virtual ICollection<FMTO_IMP> FMTO_IMP { get; set; }
    }
}