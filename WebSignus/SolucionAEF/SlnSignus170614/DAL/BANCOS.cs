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
    public partial class BANCOS
    {
        public BANCOS()
        {
            this.CTA_BANCO = new HashSet<CTA_BANCO>();
        }
    
        public string BAN_COD { get; set; }
        public string BAN_NOM { get; set; }
        public string BAN_USAP { get; set; }
        public string BAN_USBD { get; set; }
        public string BAN_EST { get; set; }
        public Nullable<System.DateTime> BAN_FREG { get; set; }
        public Nullable<System.DateTime> BAN_FNOV { get; set; }
    
        public virtual ICollection<CTA_BANCO> CTA_BANCO { get; set; }
    }
    
}