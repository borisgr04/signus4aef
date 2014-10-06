using System;
using System.Data.Entity;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using ByAUtil;

namespace BLL
{
    public class Radicar
    {
        
        public RadicacionDTO rad { get; set; }

        Entities db = new Entities();
        DECLARACION decl;
        List<CARTERAD> lCart;
        decimal TotalCartera;
        int ConsPago;

        public List<CARTERAD> lCartPago {get;set;}
        public List<CARTERAD> lCartSFavor { get; set; }
        public List<MOVIMIENTO> lCartMov { get; set; }
        PAGOS p;
        decimal mov_cons=0;

        public bool lErrorG{get;set;}

        public string RadicarD()
        {
            lCartMov = new List<MOVIMIENTO>();
            ByARpt byaRpt = new ByARpt();
            CargarDeclaracion();
            //crear consecutivo
            RegistrarReqDeclaracion();
            if (decl != null)
            {
                if (decl.DEC_EST == "DC")
                {
                    try
                    {
                        CargarCartera();
                        ActDeclaracion();
                        getConsecutivo();
                        InsertarPago();
                        InicializarConsecutivoMovimiento();
                        lCartPago = Pagar();
                        lCartSFavor = SaldoAFavor();
                        ActualizarSoportePago();
                        db.SaveChanges();
                        byaRpt.Mensaje = "Se realizó el pago";
                        lErrorG = false;

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
                }
                else {
                    if (decl.DEC_EST == "AN")
                    {
                        byaRpt.Mensaje = "La declaración esta anulada";
                        lErrorG = true;
                    }
                    else if (decl.DEC_EST == "PR")
                    {
                        byaRpt.Mensaje = "La declaración ya esta presentada";
                        lErrorG = true;
                    }
                    else {
                        byaRpt.Mensaje = "La declaración esta en un estado que no se puede aplicar pago " + decl.DEC_EST;
                        lErrorG = true;
                    }
                    
                }
        }
            return byaRpt.Mensaje;
        }

        private void ActualizarSoportePago()
        {
                PAGOS_SOP spa = db.PAGOS_SOP.Where(t => t.PAG_NDOC == decl.DEC_COD ).FirstOrDefault();
                if (spa != null)
                {
                    if (spa.PAG_EST == "AP")
                    {
                        throw new Exception("El soporte de pago ya fue aplicado.");
                    }
                    else
                    {
                        spa.PAG_EST="AP";
                        db.Entry(spa).State= EntityState.Modified;
                    }
                }
        }

        private void RegistrarReqDeclaracion()
        {
            int cons = db.CONSECUTIVOS.Where(t => t.CONS_ID == 4).Select(t => t.CONS_PRX).FirstOrDefault();
            if (rad.lstReq != null)
            {
                foreach (Dec_RequiDTO dr in rad.lstReq)
                {
                    DEC_REQUI oDr = new DEC_REQUI();
                    oDr.DR_ANO = decl.DEC_COD;
                    oDr.DR_CDEC = decl.DEC_CDEC;
                    oDr.DR_ESTADO = dr.DR_ESTADO;
                    oDr.DR_CODREQ = dr.DR_CODREQ;
                    oDr.DR_USAP = rad.usap;
                    oDr.DR_FECPRE = dr.DR_FECPRE;
                    oDr.DR_NRORAD = cons.ToString();
                    cons++;
                }
            }
        }

        private void InicializarConsecutivoMovimiento()
        {
            mov_cons = db.MOVIMIENTO.Max(t => t.MOV_CONS);
            
        }

    //    Public Function InList(ByVal toExpression As Object, ByVal ParamArray toItems() As Object) As Boolean
    //    Return Array.IndexOf(toItems, toExpression) > -1
    //    End Function 'InList

        public List<CARTERAD> Pagar()
        {
            TotalCartera = SumCartera();
            decimal? ValorPago = getTotal();
            decimal? Distribuir = 0;
            decimal? Sobrante = 0;
            decimal? Subtotal = 0;
            if (ValorPago > TotalCartera)
            {
                Distribuir = TotalCartera;
                Sobrante = ValorPago - TotalCartera;
            }
            else
            {
                Distribuir = ValorPago;
            }
            CARTERAD c;
            //Aplicar concepto
            for (int i = 0; i < lCart.Count - 1; i++)
            {
                c = lCart[i];
                decimal Valor = SaldoCartera(c);
                long porcion = (long)Math.Round((decimal)Distribuir * (Valor / TotalCartera), 0);
                Subtotal = Subtotal + porcion;
                c.CAR_VPA += porcion;
                InsMovimientoPago(c,porcion);
                db.Entry(c).State = EntityState.Modified;
            }
            if (lCart.Count >= 1)
            {
                c = lCart[lCart.Count-1];
                c.CAR_VPA += (long)(Distribuir - Subtotal);
                InsMovimientoPago(c, c.CAR_VPA);
                db.Entry(c).State = EntityState.Modified;
            }
            return lCart;
        }

        public List<CARTERAD> SaldoAFavor()
        {
            TotalCartera = SumCartera();
            decimal? ValorPago = getSaldoAFavor();
            if (ValorPago > 0)
            {
                decimal? Distribuir = 0;
                decimal? Sobrante = 0;
                decimal? Subtotal = 0;
                if (ValorPago > TotalCartera)
                {
                    Distribuir = TotalCartera;
                    Sobrante = ValorPago - TotalCartera;
                }
                else
                {
                    Distribuir = ValorPago;
                }
                CARTERAD c;
                //Aplicar concepto
                for (int i = 0; i < lCart.Count - 1; i++)
                {
                    c = lCart[i];
                    decimal Valor = SaldoCartera(c);
                    long porcion = (long)Math.Round((decimal)Distribuir * (Valor / TotalCartera), 0);
                    Subtotal = Subtotal + porcion;
                    c.CAR_VCR = porcion;
                    InsMovimientoSFavor(c,porcion);
                    db.Entry(c).State = EntityState.Modified;
                }
                
                if (lCart.Count >= 1)
                {
                    c = lCart[lCart.Count-1];
                    c.CAR_VCR = (long)(Distribuir - Subtotal);
                    InsMovimientoSFavor(c, c.CAR_VCR);
                    db.Entry(c).State = EntityState.Modified;
                }
                 
            }
            return lCart;
        }

        private void ActDeclaracion()
        {
            decl.DEC_FPRE = rad.dfpre;
            decl.DEC_BACO = rad.ban_cod;
            decl.DEC_CTA = rad.ban_cta;
            decl.DEC_EST = "PR";
            db.Entry(decl).State = EntityState.Modified;
        }

        private void InsertarPago()
        {
            decimal TotalPag=(decimal)getTotal();
            string estpag="AP";
            p= new PAGOS();
            p.PAG_ID = ConsPago;
            p.PAG_CDEC= decl.DEC_CDEC;
            p.PAG_TDOC= decl.DEC_DOAD;
            p.PAG_NDOC=decl.DEC_COD ;
            p.PAG_ANO = decl.DEC_ANO;
            p.PAG_PER = decl.DEC_PER;
            p.PAG_TOT= TotalPag;
            p.PAG_FPAG = rad.dfpre;
            p.PAG_EST = estpag;
            p.PAG_SALD= TotalPag;
            p.PAG_USBD = "DERWEB";
            p.PAG_USAP = rad.usap;
            decl.DEC_CTA = rad.ban_cta;
            p.PAG_CTAB= decl.DEC_CTA;
            p.PAG_BACO = decl.DEC_BACO;
            p.PAG_NIT = decl.DEC_NIT;
            db.PAGOS.Add(p);
  
        }

        private string GetVigencia() {
            return db.VIGENCIA.Where(t => t.VIG_EST == "AC").OrderByDescending(t => t.VIG_COD).Select(t=>t.VIG_COD).FirstOrDefault(); 
        }

        private int getConsecutivo()
        {
            string vig = GetVigencia();
           // CONSECUTIVOS cons=db.VIGENCIA.Where(t => t.VIG_EST == "AC").OrderByDescending(t => t.VIG_COD).FirstOrDefault().CONSECUTIVOS.Where(t.CONS_NOM == "PAGOS").FirstOrDefault();
            CONSECUTIVOS cons = db.CONSECUTIVOS.Where(t => t.CONS_NOM == "PAGOS" && t.CONS_VIG==vig ).OrderByDescending(t => t.CONS_VIG).FirstOrDefault();
            //arreglar
            ConsPago = cons.CONS_PRX+1;
            cons.CONS_PRX = cons.CONS_PRX + 1;
            db.Entry(cons).State =EntityState.Modified;
            return ConsPago;
            
        }

        private void CargarDeclaracion()
        {
            decl = db.DECLARACION.Where(t => t.DEC_COD == rad.dcod).FirstOrDefault(); 
        }

        private void CargarCartera()
        {
            lCart = db.CARTERAD
                .Where(t => t.CAR_CDEC == decl.DEC_CDEC
                    && t.CAR_NIT == decl.DEC_NIT
                    && t.CAR_ANO == decl.DEC_ANO
                    && t.CAR_PER == decl.DEC_PER
                    && t.CAR_TCON != "A"
                    && (t.CAR_VADE + t.CAR_VDB - t.CAR_VCR - t.CAR_VPA) > 0
                    ).OrderByDescending(t=> (t.CAR_VADE + t.CAR_VDB - t.CAR_VCR - t.CAR_VPA)).ToList();
            TotalCartera = SumCartera();
        }

        private decimal SaldoCartera(CARTERAD t) {
            return (t.CAR_VADE + t.CAR_VDB - t.CAR_VCR - t.CAR_VPA);
        }

        private decimal SumCartera()
        {
            return lCart.Sum(t => t.CAR_VADE + t.CAR_VDB - t.CAR_VCR - t.CAR_VPA);
        }

        private decimal? getSaldoAFavor()
        {
            decimal? ValorPago = db.CODE_CDEC.Where(t => t.CODE_TICO == "F" && t.CODE_SECO == "VP" && t.CODE_DCOD == decl.DEC_COD).Select(t => t.CODE_VADE).FirstOrDefault();
            return ValorPago;
        }

        private decimal getTotal()
        {
            decimal? ValorPago = db.CODE_CDEC.Where(t => t.CODE_TICO == "T" && t.CODE_SECO == "VP" && t.CODE_DCOD == decl.DEC_COD).Select(t => t.CODE_VADE).FirstOrDefault();
            return (decimal)ValorPago;
        }

        private void InsMovimientoPago(CARTERAD c,decimal porcion)
        {
            mov_cons++;
            MOVIMIENTO m = new MOVIMIENTO();
            m.MOV_CONS = mov_cons;
            m.MOV_NIT = c.CAR_NIT;
            m.MOV_CDEC = c.CAR_CDEC;
            m.MOV_PER = c.CAR_PER;
            m.MOV_AÑO = c.CAR_ANO;
            m.MOV_CID = "";
            m.MOV_CCAR = c.CAR_COCA;
            m.MOV_TICO = c.CAR_TCON;
            m.MOV_SIG = "-";
            m.MOV_VCR = porcion;
            m.MOV_VDB = 0;
            m.MOV_FMOV = decl.DEC_FPRE;
            m.MOV_EST = "AC";
            m.MOV_USAP = rad.usap;
            m.MOV_USAP = rad.usap;
            m.MOV_FNOV = DateTime.Now;
            m.MOV_VIG = c.CAR_VIG;
            m.MOV_TDOC = decl.DEC_DOAD;
            m.MOV_NDOC = decl.DEC_COD;
            m.MOV_PAG = "S";
            m.MOV_PAID = ConsPago;
            m.MOV_USAP = rad.usap;
            db.Entry(m).State = EntityState.Added;
           //lCartMov.Add(m);
        }

        private void InsMovimientoSFavor(CARTERAD c,decimal porcion)
        {
            mov_cons++;
            MOVIMIENTO m = new MOVIMIENTO();
            m.MOV_CONS = mov_cons;
            m.MOV_NIT = c.CAR_NIT;
            m.MOV_CDEC = c.CAR_CDEC;
            m.MOV_PER = c.CAR_PER;
            m.MOV_AÑO = c.CAR_ANO;
            m.MOV_CID = "";
            m.MOV_CCAR = c.CAR_COCA;
            m.MOV_TICO = c.CAR_TCON;
            m.MOV_SIG = "-";
            m.MOV_VCR = porcion;
            m.MOV_VDB = 0;
            m.MOV_FMOV = decl.DEC_FPRE;
            m.MOV_EST = "AC";
            m.MOV_USAP = rad.usap;
            m.MOV_FNOV = DateTime.Now;
            m.MOV_VIG = "";
            m.MOV_TDOC = decl.DEC_DOAD;
            m.MOV_NDOC = decl.DEC_COD;
            m.MOV_PAG = "N";
            //m.MOV_PAID = ConsPago;
            m.MOV_USAP = rad.usap;
            db.Entry(m).State = EntityState.Added;
            //lCartMov.Add(m);
        }

    }

   
}
