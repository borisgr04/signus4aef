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
    
    public partial class FORM_AYUD
    {
        public string FOAY_CODI { get; set; }
        public Nullable<short> FOAY_NREN { get; set; }
        public string FOAY_FDCO { get; set; }
        public string FOAY_TITU { get; set; }
        public string FOAY_DESC { get; set; }
        public string FOAY_USAP { get; set; }
        public string FOAY_USBD { get; set; }
        public Nullable<System.DateTime> FOAY_FREG { get; set; }
        public Nullable<System.DateTime> FOAY_FNOV { get; set; }
    
        public virtual FORMULARIOS_DEC FORMULARIOS_DEC { get; set; }
    }
}