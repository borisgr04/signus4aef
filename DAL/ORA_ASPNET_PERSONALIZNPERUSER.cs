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
    
    public partial class ORA_ASPNET_PERSONALIZNPERUSER
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> PATHID { get; set; }
        public Nullable<System.Guid> USERID { get; set; }
        public byte[] PAGESETTINGS { get; set; }
        public System.DateTime LASTUPDATEDDATE { get; set; }
    
        public virtual ORA_ASPNET_PATHS ORA_ASPNET_PATHS { get; set; }
        public virtual ORA_ASPNET_USERS ORA_ASPNET_USERS { get; set; }
    }
}