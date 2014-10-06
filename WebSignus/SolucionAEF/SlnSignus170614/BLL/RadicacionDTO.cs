using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RadicacionDTO
    {
        public string dcod { get; set; }
        public DateTime dfpre { get; set; }
        public string dest { get; set; }
        public string ban_cod { get; set; }
        public string ban_cta { get; set; }
        public string usap { get; set; }
        public List<Dec_RequiDTO> lstReq { get; set; }
    }
}
