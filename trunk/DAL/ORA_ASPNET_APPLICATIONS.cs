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
    
    public partial class ORA_ASPNET_APPLICATIONS
    {
        public ORA_ASPNET_APPLICATIONS()
        {
            this.ORA_ASPNET_ROLES = new HashSet<ORA_ASPNET_ROLES>();
            this.ORA_ASPNET_MEMBERSHIP = new HashSet<ORA_ASPNET_MEMBERSHIP>();
            this.ORA_ASPNET_PATHS = new HashSet<ORA_ASPNET_PATHS>();
            this.ORA_ASPNET_SITEMAP = new HashSet<ORA_ASPNET_SITEMAP>();
            this.ORA_ASPNET_USERS = new HashSet<ORA_ASPNET_USERS>();
        }
    
        public string APPLICATIONNAME { get; set; }
        public string LOWEREDAPPLICATIONNAME { get; set; }
        public System.Guid APPLICATIONID { get; set; }
        public string DESCRIPTION { get; set; }
    
        public virtual ICollection<ORA_ASPNET_ROLES> ORA_ASPNET_ROLES { get; set; }
        public virtual ICollection<ORA_ASPNET_MEMBERSHIP> ORA_ASPNET_MEMBERSHIP { get; set; }
        public virtual ICollection<ORA_ASPNET_PATHS> ORA_ASPNET_PATHS { get; set; }
        public virtual ICollection<ORA_ASPNET_SITEMAP> ORA_ASPNET_SITEMAP { get; set; }
        public virtual ICollection<ORA_ASPNET_USERS> ORA_ASPNET_USERS { get; set; }
    }
}
