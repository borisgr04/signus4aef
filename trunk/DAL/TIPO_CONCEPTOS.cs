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
    
    public partial class TIPO_CONCEPTOS
    {
        public TIPO_CONCEPTOS()
        {
            this.CARTERAD = new HashSet<CARTERAD>();
            this.CODE_CDEC = new HashSet<CODE_CDEC>();
            this.CONC_CART = new HashSet<CONC_CART>();
        }
    
        public string TCON_COD { get; set; }
        public string TCON_NOM { get; set; }
        public string TCON_USAP { get; set; }
        public string TCON_USBD { get; set; }
        public System.DateTime TCON_FREG { get; set; }
        public System.DateTime TCON_FNOV { get; set; }
    
        public virtual ICollection<CARTERAD> CARTERAD { get; set; }
        public virtual ICollection<CODE_CDEC> CODE_CDEC { get; set; }
        public virtual ICollection<CONC_CART> CONC_CART { get; set; }
    }
}
