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