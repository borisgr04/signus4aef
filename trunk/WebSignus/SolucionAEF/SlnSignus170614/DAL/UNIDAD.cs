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
    public partial class UNIDAD
    {
        public UNIDAD()
        {
            this.IMPUESTOS = new HashSet<IMPUESTOS>();
        }
    
        public string UNI_COD { get; set; }
        public string UNI_NOM { get; set; }
        public string UNI_USAP { get; set; }
        public string UNI_USBD { get; set; }
        public Nullable<System.DateTime> UNI_FREG { get; set; }
        public Nullable<System.DateTime> UNI_FNOV { get; set; }
    
        public virtual ICollection<IMPUESTOS> IMPUESTOS { get; set; }
    }
    
}