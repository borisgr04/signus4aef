using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ConSaldoFavor
    {
        Entities db = new Entities();

        public List<ConsultaSaldoFavor> DecConSaldoFavor(string cdec,string year, string periodo)
        {
            //&&
            List<ConsultaSaldoFavor> ld = db.CODE_CDEC.Where(t => t.DECLARACION.DEC_CDEC ==cdec && t.CODE_TICO == "F" && t.CODE_SECO == "VP" && t.DECLARACION.DEC_ANO == year && t.DECLARACION.DEC_PER == periodo && t.CODE_VADE > 0 && t.DECLARACION.DEC_EST!="AN" )
                .Select(t=>
                new ConsultaSaldoFavor { 
                     AGravable=t.DECLARACION.DEC_ANO,
                     PGravable = t.DECLARACION.DEC_PER,
                     Formulario = t.DECLARACION.DEC_COD,
                     SaldoFavor=t.CODE_VADE,
                     TotalAPagar=t.DECLARACION.DEC_PTOT,
                     AgenteRecaudador=t.DECLARACION.TERCEROS2.TER_NOM,
                     Estado=t.DECLARACION.DEC_EST
                })
                .ToList();
                    /*
                     ValorAPagar = t.DECLARACION.CODE_CDEC.Where(tt => t.CODE_TICO == "D" && t.CODE_SECO == "VP").Select(ttt => ttt.CODE_VADE).FirstOrDefault(),
                     Intereses = t.DECLARACION.CODE_CDEC.Where(tt => t.CODE_TICO == "I" && t.CODE_SECO == "VP").Select(ttt => ttt.CODE_VADE).FirstOrDefault(),
                     TotalAPagar = t.DECLARACION.CODE_CDEC.Where(tt => t.CODE_TICO == "T" && t.CODE_SECO == "VP").Select(ttt => ttt.CODE_VADE).FirstOrDefault(),
                     * */
            return ld;
        }

        public List<ConsultaRenglones> ConRenglones(string cod_dec)
        {
            List<ConsultaRenglones> ld = db.CODE_CDEC.Where(t=>t.CODE_DCOD==cod_dec)
                .Select(t =>
                new ConsultaRenglones
                {
                     Concepto=t.CODE_NOMB,
                      Valor =t.CODE_VADE
                })
                .ToList();
            return ld;
        }

        public class ConsultaSaldoFavor {
            public string Formulario { get; set; }
            public string AgenteRecaudador { get; set; }
            public string AGravable { get; set; }
            public string PGravable { get; set; }
            
            //public decimal? ValorAPagar { get; set; }
            //public decimal? Intereses { get; set; }
            public decimal? SaldoFavor { get; set; }
            public decimal? TotalAPagar { get; set; }
            public string Estado { get; set; }

        }

        public class ConsultaRenglones
        {
            public string Concepto { get; set; }
            public decimal? Valor { get; set; }
            }
        
    }
}
