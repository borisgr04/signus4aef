//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class ACUE_PAGO
    {
        public ACUE_PAGO()
        {
            this.ACPA_APG = new HashSet<ACPA_APG>();
            this.CUOT_ACPA = new HashSet<CUOT_ACPA>();
        }
    
        public string ACPA_CDEC { get; set; }
        public string ACPA_NUME { get; set; }
        public string ACPA_NIT_AR { get; set; }
        public string ACPA_TIP_AR { get; set; }
        public string ACPA_REP_LEG { get; set; }
        public string ACPA_NIT_REP_LEG { get; set; }
        public string ACPA_REP_EXP { get; set; }
        public string ACPA_GARA { get; set; }
        public string ACPA_USBD { get; set; }
        public string ACPA_USAP { get; set; }
        public System.DateTime ACPA_FREG { get; set; }
        public int ACPA_VALO { get; set; }
        public Nullable<decimal> ACPA_POCI { get; set; }
        public Nullable<int> ACPA_VACI { get; set; }
        public int ACPA_NCUO { get; set; }
        public Nullable<System.DateTime> ACPA_FNOV { get; set; }
        public Nullable<int> ACPA_SALD { get; set; }
        public string ACPA_EST { get; set; }
        public string ACPA_NEXP { get; set; }
    
        public virtual ICollection<ACPA_APG> ACPA_APG { get; set; }
        public virtual CLASE_DEC CLASE_DEC { get; set; }
        public virtual TERCEROS TERCEROS { get; set; }
        public virtual ICollection<CUOT_ACPA> CUOT_ACPA { get; set; }
    }
    
}