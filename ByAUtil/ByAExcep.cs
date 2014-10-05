using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByAUtil
{
    public class ByAExcep
    {
        public static void AdminException(ByARpt byaRpt, System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            foreach (var eve in ex.EntityValidationErrors)
            {
                foreach (var valErr in eve.ValidationErrors)
                {
                    byaRpt.Mensaje += "DE" + valErr.PropertyName + ":" + valErr.ErrorMessage + "<br/>";
                }
            }
            byaRpt.Error = true;
        }

        public static void AdminException(ByARpt byaRpt, Exception ex)
        {
            if (ex.InnerException != null)
            {
                byaRpt.Mensaje = "Ex" + mostrarMensaje(ex);

                byaRpt.Error = true;
            }
            else
            {
                byaRpt.Mensaje = ex.Message;
                byaRpt.Error = true;
            }
        }
        private static string mostrarMensaje(Exception ex)
        {
            if (ex.InnerException != null)
                return mostrarMensaje(ex.InnerException);
            else
                return ex.Message + ex.StackTrace;


        }
    }

}
