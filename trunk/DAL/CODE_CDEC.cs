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
    
    public partial class CODE_CDEC
    {
        public string CODE_CDEC1 { get; set; }
        public string CODE_CODI { get; set; }
        public string CODE_TICO { get; set; }
        public string CODE_NOMB { get; set; }
        public string CODE_TMOV { get; set; }
        public string CODE_ABVB { get; set; }
        public Nullable<decimal> CODE_VADE { get; set; }
        public string CODE_ABVD { get; set; }
        public Nullable<decimal> CODE_VACA { get; set; }
        public string CODE_SECO { get; set; }
        public Nullable<decimal> CODE_TARI { get; set; }
        public string CODE_IMPTO { get; set; }
        public string CODE_TSAN { get; set; }
        public string CODE_CART { get; set; }
        public Nullable<decimal> CODE_VABA { get; set; }
        public string CODE_ISVB { get; set; }
        public string CODE_REDE { get; set; }
        public string CODE_DENR { get; set; }
        public decimal CODE_VASU { get; set; }
        public Nullable<decimal> CODE_VAOF { get; set; }
        public string CODE_USBD { get; set; }
        public string CODE_USAP { get; set; }
        public string CODE_DEES { get; set; }
        public Nullable<System.DateTime> CODE_FREG { get; set; }
        public string CODE_PESA { get; set; }
        public string CODE_AÑSA { get; set; }
        public string CODE_CCAR { get; set; }
        public string CODE_SUM { get; set; }
        public string CODE_DCOD { get; set; }
        public string CODE_VIG { get; set; }
        public string CODE_DOAD { get; set; }
        public string CODE_CTAR { get; set; }
        public Nullable<System.DateTime> CODE_FNOV { get; set; }
        public Nullable<long> CODE_VBCA { get; set; }
        public Nullable<decimal> CODE_TACA { get; set; }
    
        public virtual CLASE_DEC CLASE_DEC { get; set; }
        public virtual DECLARACION DECLARACION { get; set; }
        public virtual SECCIONES SECCIONES { get; set; }
        public virtual TIPO_CONCEPTOS TIPO_CONCEPTOS { get; set; }
        public virtual TIPO_DOC TIPO_DOC { get; set; }
        public virtual VIGENCIA VIGENCIA { get; set; }
    }
}
