using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Entidades
{
   public class Pagos_Sop_DTO
    {
        
            public string PAG_NDOC { get; set; }
            public decimal PAG_TOT { get; set; }
            public System.DateTime PAG_FPAG { get; set; }
            public string PAG_EST { get; set; }
            public string PAG_USAP { get; set; }
            public string PAG_CTAB { get; set; }
            public string PAG_BACO { get; set; }
            public string PAG_NIT { get; set; }
            public byte[] PAG_SOP { get; set; }
            public string PAG_TIP { get; set; }

    }
}
