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
    public partial class ACPA_APG
    {
        public string APG_APNU { get; set; }
        public string APG_CDEC { get; set; }
        public string APG_AGRA { get; set; }
        public string APG_PGRA { get; set; }
        public System.DateTime APG_FNOV { get; set; }
        public string APG_USBD { get; set; }
        public string APG_USAP { get; set; }
        public System.DateTime APG_FREG { get; set; }
    
        public virtual ACUE_PAGO ACUE_PAGO { get; set; }
        public virtual CALENDARIO CALENDARIO { get; set; }
    }
    
}