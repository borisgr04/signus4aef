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
    
    public partial class ACPA_DEUDA
    {
        public string APDE_APNU { get; set; }
        public string APDE_CDEC { get; set; }
        public string APDE_AGRA { get; set; }
        public string APDE_PGRA { get; set; }
        public string APDE_COCO { get; set; }
        public int APDE_VALO { get; set; }
        public string APDE_DOAD { get; set; }
        public string APDE_NDOC { get; set; }
        public System.DateTime APDE_FNOV { get; set; }
        public string APDE_NOMC { get; set; }
        public string APDE_USBD { get; set; }
        public string APDE_USAP { get; set; }
        public System.DateTime APDE_FREG { get; set; }
    
        public virtual CALENDARIO CALENDARIO { get; set; }
        public virtual CONC_CART CONC_CART { get; set; }
        public virtual TIPO_DOC TIPO_DOC { get; set; }
    }
}
