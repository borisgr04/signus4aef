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