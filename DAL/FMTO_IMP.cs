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
    
    public partial class FMTO_IMP
    {
        public string FMIM_CAMP { get; set; }
        public string FMIM_TIDA { get; set; }
        public string FMIM_CODI { get; set; }
        public short FMIM_INDX { get; set; }
        public string FMIM_LONG { get; set; }
        public string FMIM_USAP { get; set; }
        public string FMIM_USBD { get; set; }
        public Nullable<System.DateTime> FMIM_FREG { get; set; }
        public Nullable<System.DateTime> FMIM_FNOV { get; set; }
        public string FMIM_EST { get; set; }
    
        public virtual TIPO_DATO TIPO_DATO { get; set; }
        public virtual FMTOS FMTOS { get; set; }
    }
}