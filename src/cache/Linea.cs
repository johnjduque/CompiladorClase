using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.src.Cache
{
    /*Se busca que sirva de mecanismo para leer las líneas del archivo*/
    public class Linea
    {
        private int NumeroLinea;
        private string Contenido;

        private Linea(int NumeroLinea, string contenido)
        {
            this.NumeroLinea = NumeroLinea;
            this.Contenido = contenido;
        }

        public static Linea Crear(int NumeroLinea, string Contenido)
        {
            return new Linea(NumeroLinea, Contenido);
        }

        public string GetContenido()
        {
            if (Contenido == null)
            {
                Contenido = "";
            }

            return Contenido;
        }

        public int GetNumeroLinea()
        {
            if (NumeroLinea < 0)
            {
                NumeroLinea = 0;
            }

            return NumeroLinea;
        }

        public bool EsFinArchivo()
        {
            return "@EOF@".Equals(GetContenido());
        }

        public int ObtenerLongitudContenido()
        {
            return GetContenido().Length;
        }
    }
}
