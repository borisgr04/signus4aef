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
    public partial class ORA_ASPNET_PATHS
    {
        public ORA_ASPNET_PATHS()
        {
            this.ORA_ASPNET_PERSONALIZNALLUSERS = new HashSet<ORA_ASPNET_PERSONALIZNALLUSERS>();
            this.ORA_ASPNET_PERSONALIZNPERUSER = new HashSet<ORA_ASPNET_PERSONALIZNPERUSER>();
        }
    
        public System.Guid APPLICATIONID { get; set; }
        public System.Guid PATHID { get; set; }
        public string PATH { get; set; }
        public string LOWEREDPATH { get; set; }
    
        public virtual ORA_ASPNET_APPLICATIONS ORA_ASPNET_APPLICATIONS { get; set; }
        public virtual ICollection<ORA_ASPNET_PERSONALIZNALLUSERS> ORA_ASPNET_PERSONALIZNALLUSERS { get; set; }
        public virtual ICollection<ORA_ASPNET_PERSONALIZNPERUSER> ORA_ASPNET_PERSONALIZNPERUSER { get; set; }
    }
    
}
