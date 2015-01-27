using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entidades;
using AutoMapper;
using ByAUtil;

namespace BLL
{
  public  class Pagos_SopBLL
    {
        Entities db;
        ByARpt byaRpt = new ByARpt();
        public bool lErrorG { get; set; }

        public Pagos_SopBLL()
        {
            Mapper.CreateMap<PAGOS_SOP, Pagos_Sop_DTO>();
            Mapper.CreateMap<Pagos_Sop_DTO, PAGOS_SOP>();

        }


        public ByARpt Insertar(Pagos_Sop_DTO sop)
        {
            try
            {
                using (db = new Entities())
                {
                    DECLARACION d = db.DECLARACION.Where(t => t.DEC_COD == sop.PAG_NDOC && t.DEC_NIT==sop.PAG_NIT).FirstOrDefault();
                    if (d == null)
                    {

                        byaRpt.Error = true;
                        byaRpt.Mensaje = String.Format( "No se encontró la declaración {0}, asociada al agente recaudador {1} ",sop.PAG_NDOC, sop.PAG_NIT);
                    }
                    else {
                        PAGOS_SOP spa = db.PAGOS_SOP.Where(t => t.PAG_NDOC == sop.PAG_NDOC).FirstOrDefault();

                        if (spa != null)
                        {
                            
                            byaRpt.Error = true;
                            byaRpt.Mensaje = "Ya tiene un soporte de pago registrado para esta declaración.";
                        }
                        else
                        {
                            spa = new PAGOS_SOP();
                            Mapper.Map(sop, spa);
                            spa.PAG_EST = "PE";
                            //spa.CTA_BANCO
                            db.PAGOS_SOP.Add(spa);
                            byaRpt.Filas = db.SaveChanges();
                            byaRpt.Error = false;
                            byaRpt.Mensaje = "Se realizó la operación satisfactoriamente";
                        }
                    }
                    
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                        ByAExcep.AdminException(byaRpt, ex);
                        lErrorG = true;
            }
            catch (Exception ex)
            {
                ByAExcep.AdminException(byaRpt, ex);
                lErrorG = true;
            }
            return byaRpt;
        
        }



        public ByARpt Eliminar(string Nro_Dec)
        {
            try
            {
                using (db = new Entities())
                {
                    PAGOS_SOP spa = db.PAGOS_SOP.Where(t => t.PAG_NDOC == Nro_Dec).FirstOrDefault();
                    if (spa == null)
                    {
                        byaRpt.Error = true;
                        byaRpt.Mensaje = "No se encuentra soporte de pago registrado";
                     }
                     else
                    {

                        if (spa.PAG_EST == "AP")
                        {
                            byaRpt.Error = true;
                            byaRpt.Mensaje = "El soporte de pago ya fue aplicado, comunicace con la oficina de Rentas";
                        }
                        else
                        {
                            db.PAGOS_SOP.Remove(spa);
                            byaRpt.Filas = db.SaveChanges();
                            byaRpt.Error = false;
                            byaRpt.Mensaje = "Se eliminó el soporte de pago";
                        }
                     }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                ByAExcep.AdminException(byaRpt, ex);
                lErrorG = true;
            }
            catch (Exception ex)
            {
                ByAExcep.AdminException(byaRpt, ex);
                lErrorG = true;
            }
            return byaRpt;

        }
        public List<CTA_BANCO> GetCuentas() {
            using (db = new Entities()) {

                return db.CTA_BANCO.ToList();
            
            }   
        }

        public List<Pagos_Sop_DTO> GetAll(string NIT)
        {
            using (db = new Entities())
            {
                List<Pagos_Sop_DTO> l= new List<Pagos_Sop_DTO>();
                var q=db.PAGOS_SOP.Where(t=>t.PAG_NIT==NIT).ToList();
                Mapper.Map(q,l);
                return l;
            }
        }

        public Pagos_Sop_DTO GetPk(string Nro_Dec)
        {
            Pagos_Sop_DTO dto = new Pagos_Sop_DTO();
            using (db = new Entities())
            {
                var q = db.PAGOS_SOP.Where(t => t.PAG_NDOC == Nro_Dec).FirstOrDefault();
                Mapper.Map(q, dto);
                return dto;

            }
        }
    }
}
