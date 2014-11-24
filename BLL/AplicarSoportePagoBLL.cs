using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entidades;
using AutoMapper;
using ByAUtil;
using DAL;

namespace BLL
{
   public class AplicarSoportePagoBLL
    {
        Entities db;
        ByARpt byaRpt = new ByARpt();
        public bool lErrorG { get; set; }

        public AplicarSoportePagoBLL()
        {
            Mapper.CreateMap<PAGOS_SOP, Pagos_Sop_DTO>();
            Mapper.CreateMap<Pagos_Sop_DTO, PAGOS_SOP>();

        }

        public List<Pagos_Sop_DTO> GetPendientes()
        {
            using (db = new Entities())
            {
                List<Pagos_Sop_DTO> l = new List<Pagos_Sop_DTO>();
                var q = db.PAGOS_SOP.Where(t => t.PAG_EST=="PE").ToList();
                Mapper.Map(q, l);
                return l;

            }
        }

    }
}
