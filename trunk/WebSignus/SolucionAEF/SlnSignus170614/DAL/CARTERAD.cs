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
    public partial class CARTERAD
    {
        public string CAR_ID { get; set; }
        public string CAR_NIT { get; set; }
        public string CAR_ANO { get; set; }
        public string CAR_PER { get; set; }
        public string CAR_COCA { get; set; }
        public string CAR_TCON { get; set; }
        public long CAR_VADE { get; set; }
        public long CAR_VDB { get; set; }
        public long CAR_VCR { get; set; }
        public long CAR_VPA { get; set; }
        public string CAR_CDEC { get; set; }
        public string CAR_CCON { get; set; }
        public string CAR_CIMP { get; set; }
        public string CAR_TPAG { get; set; }
        public string CAR_VIG { get; set; }
        public System.DateTime CAR_FNOV { get; set; }
        public string CAR_EST { get; set; }
        public Nullable<System.DateTime> CAR_FREG { get; set; }
        public string CAR_USAP { get; set; }
        public string CAR_USBD { get; set; }
        public string CAR_DCOD { get; set; }
        public Nullable<System.DateTime> CAR_FVEN { get; set; }
        public string CAR_TDOC { get; set; }
        public string CAR_SUIM { get; set; }
        public string CAR_ACPA { get; set; }
    
        public virtual CALENDARIO CALENDARIO { get; set; }
        public virtual CONC_CART CONC_CART { get; set; }
        public virtual TIPO_CONCEPTOS TIPO_CONCEPTOS { get; set; }
        public virtual TIPO_DOC TIPO_DOC { get; set; }
    }
    
}
