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
    
    public partial class TERCEROS
    {
        public TERCEROS()
        {
            this.ACUE_PAGO = new HashSet<ACUE_PAGO>();
            this.DECLARACION = new HashSet<DECLARACION>();
            this.DECLARACION1 = new HashSet<DECLARACION>();
            this.DECLARACION2 = new HashSet<DECLARACION>();
            this.RELA_AGETER1 = new HashSet<RELA_AGETER>();
        }
    
        public int TER_CONS { get; set; }
        public string TER_TDOC { get; set; }
        public string TER_NIT { get; set; }
        public string TER_DVER { get; set; }
        public string TER_NOM { get; set; }
        public string TER_TIP { get; set; }
        public string TER_MPIO { get; set; }
        public string TER_EMAI { get; set; }
        public string TER_TEL { get; set; }
        public string TER_DIR { get; set; }
        public string TER_CED { get; set; }
        public string TER_REP { get; set; }
        public string TER_USU { get; set; }
        public string TER_TUS { get; set; }
        public System.DateTime TER_FREG { get; set; }
        public System.DateTime TER_FNOV { get; set; }
        public Nullable<System.DateTime> TER_FFIN { get; set; }
        public string TER_EST { get; set; }
        public string TER_OBS { get; set; }
        public string TER_USAP { get; set; }
        public string TER_USBD { get; set; }
        public string TER_REP_TD { get; set; }
        public string TER_REP_EXP { get; set; }
    
        public virtual ICollection<ACUE_PAGO> ACUE_PAGO { get; set; }
        public virtual ICollection<DECLARACION> DECLARACION { get; set; }
        public virtual ICollection<DECLARACION> DECLARACION1 { get; set; }
        public virtual ICollection<DECLARACION> DECLARACION2 { get; set; }
        public virtual MUNICIPIOS MUNICIPIOS { get; set; }
        public virtual RELA_AGETER RELA_AGETER { get; set; }
        public virtual ICollection<RELA_AGETER> RELA_AGETER1 { get; set; }
        public virtual TDOC_IDE TDOC_IDE { get; set; }
    }
}