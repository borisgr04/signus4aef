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
    
    public partial class EXPEDIENTES
    {
        public EXPEDIENTES()
        {
            this.EXPE_APG = new HashSet<EXPE_APG>();
            this.EXPE_NOTIF = new HashSet<EXPE_NOTIF>();
            this.EXPE_TRAM = new HashSet<EXPE_TRAM>();
        }
    
        public string EXPE_NIT { get; set; }
        public string EXPE_CDEC { get; set; }
        public System.DateTime EXPE_FELA { get; set; }
        public Nullable<System.DateTime> EXPE_FCIE { get; set; }
        public string EXPE_TRAC { get; set; }
        public string EXPE_USBD { get; set; }
        public string EXPE_USAP { get; set; }
        public System.DateTime EXPE_FREG { get; set; }
        public string EXPE_DOAD { get; set; }
        public string EXPE_DONU { get; set; }
        public System.DateTime EXPE_FNOV { get; set; }
        public string EXPE_OBSE { get; set; }
        public string EXPE_TPRO { get; set; }
        public string EXPE_PROC { get; set; }
        public string EXPE_ANEX { get; set; }
        public string EXPE_NUME { get; set; }
        public string EXPE_NPRO { get; set; }
        public Nullable<System.DateTime> EXPE_FEXP { get; set; }
        public Nullable<decimal> EXPE_EXTRID { get; set; }
    
        public virtual CLASE_DEC CLASE_DEC { get; set; }
        public virtual ICollection<EXPE_APG> EXPE_APG { get; set; }
        public virtual ICollection<EXPE_NOTIF> EXPE_NOTIF { get; set; }
        public virtual ICollection<EXPE_TRAM> EXPE_TRAM { get; set; }
        public virtual PROCESOS PROCESOS { get; set; }
        public virtual TIPO_DOC TIPO_DOC { get; set; }
        public virtual TIPO_PROCESO TIPO_PROCESO { get; set; }
        public virtual TRAMITES TRAMITES { get; set; }
    }
}
