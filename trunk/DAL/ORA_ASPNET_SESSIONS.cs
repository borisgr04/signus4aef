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
    
    public partial class ORA_ASPNET_SESSIONS
    {
        public string SESSIONID { get; set; }
        public System.DateTime CREATED { get; set; }
        public System.DateTime EXPIRES { get; set; }
        public System.DateTime LOCKDATE { get; set; }
        public System.DateTime LOCKDATELOCAL { get; set; }
        public decimal LOCKCOOKIE { get; set; }
        public decimal TIMEOUT { get; set; }
        public decimal LOCKED { get; set; }
        public byte[] SESSIONITEMSHORT { get; set; }
        public byte[] SESSIONITEMLONG { get; set; }
        public decimal FLAGS { get; set; }
    }
}