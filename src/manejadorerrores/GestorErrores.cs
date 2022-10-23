using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.src.ManejadorErrores
{
    public class GestorErrores
    {
        private static Dictionary<TipoError, List<Error>> TABLA_ERRORES =
            new Dictionary<TipoError, List<Error>>();
        private static bool EstaInicializada = false;

        private static void Inicializar()
        {
            if (!EstaInicializada)
            {
                TABLA_ERRORES.Add(TipoError.LEXICO, new List<Error>());
                TABLA_ERRORES.Add(TipoError.SINTACTICO, new List<Error>());
                TABLA_ERRORES.Add(TipoError.SEMANTICO, new List<Error>());
                EstaInicializada = true;
            }
        }

        public static List<Error> obtenerErrores(TipoError error)
        {
            if (TipoError.LEXICO.Equals(error))
            {
                return TABLA_ERRORES[error];
            }
            else if (TipoError.SEMANTICO.Equals(error))
            {
                return TABLA_ERRORES[error];
            }
            else if (TipoError.SINTACTICO.Equals(error))
            {
                return TABLA_ERRORES[error];
            }
            else
            {
                return new List<Error>();
            }
        }

        public static void Agregar(Error Error)
        {
            Inicializar();

            if (Error != null)
            {
                TABLA_ERRORES[Error.GetTipo()].Add(Error);
            }
        }

        public static bool HayErrores(TipoError Tipo)
        {
            return TABLA_ERRORES[Tipo].Count > 0;
        }

        public static bool HayErroresAnalisis()
        {
            return HayErrores(TipoError.LEXICO) || HayErrores(TipoError.SINTACTICO) ||
                HayErrores(TipoError.SEMANTICO);
        }

        public static void Reiniciar()
        {
            EstaInicializada = false;
            TABLA_ERRORES.Clear();
            Inicializar();
        }
    }
}
