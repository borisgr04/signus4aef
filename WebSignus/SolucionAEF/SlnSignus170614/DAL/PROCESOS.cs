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
    public partial class PROCESOS
    {
        public PROCESOS()
        {
            this.EXPEDIENTES = new HashSet<EXPEDIENTES>();
        }
    
        public string PROC_CODI { get; set; }
        public string PROC_NOMB { get; set; }
        public string PROC_TPCO { get; set; }
        public string PROC_USAP { get; set; }
        public string PROC_USBD { get; set; }
        public System.DateTime PROC_FREG { get; set; }
        public System.DateTime PROC_FNOV { get; set; }
        public string PROC_HAB { get; set; }
        public string PROC_TINI { get; set; }
        public string PROC_TFIN { get; set; }
    
        public virtual ICollection<EXPEDIENTES> EXPEDIENTES { get; set; }
        public virtual TIPO_PROCESO TIPO_PROCESO { get; set; }
    }
    
}