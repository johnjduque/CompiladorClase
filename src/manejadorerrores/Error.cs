using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.src.ManejadorErrores
{
    public class Error
    {
        private int NumeroLinea;
        private int PosicionInicial;
        private int PosicionFinal;
        private string Falla;
        private string Causa;
        private string Solucion;
        private TipoError Tipo;

        public static Error CrearErrorSintactico(int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion)
        {
            return new Error(numeroLinea, posicionInicial, posicionFinal, falla, causa, solucion, TipoError.SINTACTICO);
        }

        public static Error CrearErrorSemantico(int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion)
        {
            return new Error(numeroLinea, posicionInicial, posicionFinal, falla, causa, solucion, TipoError.SEMANTICO);
        }

        public static Error CrearErrorLexico(int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion)
        {
            return new Error(numeroLinea, posicionInicial, posicionFinal, falla, causa, solucion, TipoError.LEXICO);
        }

        private Error(int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion, TipoError tipo)
        {
            this.NumeroLinea = numeroLinea;
            this.PosicionInicial = posicionInicial;
            this.PosicionFinal = posicionFinal;
            this.Falla = falla;
            this.Causa = causa;
            this.Solucion = solucion;
            this.Tipo = tipo;
        }

        public int GetNumeroLinea()
        {
            if (NumeroLinea <= 0)
            {
                NumeroLinea = 1;
            }
            return NumeroLinea;
        }

        public int GetPosicionInicial()
        {
            if (PosicionInicial <= 0)
            {
                PosicionInicial = 1;
            }
            return PosicionInicial;
        }

        public int GetPosicionFinal()
        {
            if (PosicionFinal <= 0)
            {
                PosicionFinal = 1;
            }
            return PosicionFinal;
        }

        public string GetFalla()
        {
            if (Falla == null)
            {
                Falla = "";
            }
            return Falla;
        }

        public string GetCausa()
        {
            if (Causa == null)
            {
                Causa = "";
            }
            return Causa;
        }

        public string GetSolucion()
        {
            if (Solucion == null)
            {
                Solucion = "";
            }
            return Solucion;
        }

        public TipoError GetTipo()
        {
            if (Tipo == null)
            {
                Tipo = TipoError.LEXICO;
            }
            return Tipo;
        }
    }
}
