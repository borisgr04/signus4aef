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
    public partial class ESTADOS
    {
        public ESTADOS()
        {
            this.VIGENCIA = new HashSet<VIGENCIA>();
        }
    
        public string EST_COD { get; set; }
        public string EST_DES { get; set; }
        public string EST_USAP { get; set; }
        public string EST_USBD { get; set; }
        public Nullable<System.DateTime> EST_FREG { get; set; }
        public Nullable<System.DateTime> EST_FNOV { get; set; }
    
        public virtual ICollection<VIGENCIA> VIGENCIA { get; set; }
    }
    
}
