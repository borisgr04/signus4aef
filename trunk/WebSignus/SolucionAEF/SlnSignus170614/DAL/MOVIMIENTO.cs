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
    public partial class MOVIMIENTO
    {
        public decimal MOV_CONS { get; set; }
        public string MOV_NIT { get; set; }
        public string MOV_CDEC { get; set; }
        public string MOV_CCAR { get; set; }
        public string MOV_TICO { get; set; }
        public string MOV_AÑO { get; set; }
        public string MOV_PER { get; set; }
        public string MOV_CID { get; set; }
        public string MOV_SIG { get; set; }
        public Nullable<decimal> MOV_VDB { get; set; }
        public Nullable<decimal> MOV_VCR { get; set; }
        public Nullable<System.DateTime> MOV_FMOV { get; set; }
        public string MOV_EST { get; set; }
        public string MOV_USAP { get; set; }
        public string MOV_USBD { get; set; }
        public Nullable<System.DateTime> MOV_FNOV { get; set; }
        public string MOV_VIG { get; set; }
        public string MOV_TMOV { get; set; }
        public string MOV_TDOC { get; set; }
        public string MOV_NDOC { get; set; }
        public string MOV_PAG { get; set; }
        public Nullable<decimal> MOV_PAID { get; set; }
        public Nullable<System.DateTime> MOV_FREG { get; set; }
    
        public virtual CALENDARIO CALENDARIO { get; set; }
        public virtual TIPO_DOC TIPO_DOC { get; set; }
        public virtual TIPO_MOV TIPO_MOV { get; set; }
    }
    
}