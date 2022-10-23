using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador.src.Transversal.Componente;


namespace Compilador.src.Transversal.TablasSimbolos
{
    public class TablaDummie
    {
        private static Dictionary<string, List<ComponenteLexico>> TABLA =
    new Dictionary<string, List<ComponenteLexico>>();
        public static void Reiniciar()
        {
            TABLA.Clear();
        }

        private static List<ComponenteLexico> ObtenerCompoenetes(string Lexema)
        {
            if (!TABLA.ContainsKey(Lexema))
            {
                TABLA.Add(Lexema, new List<ComponenteLexico>());
            }

            return TABLA[Lexema];
        }

        public static void Agregar(ComponenteLexico Componente)
        {
            if (Componente != null && Tipo.DUMMY.Equals(Componente.GetTipo()))
            {
                ObtenerCompoenetes(Componente.GetLexema()).Add(Componente);
            }
        }

        public static List<ComponenteLexico> ObtenerComponentes()
        {
            var Componentes = new List<ComponenteLexico>();

            foreach (List<ComponenteLexico> Lista in TABLA.Values)
            {
                Componentes.AddRange(Lista);
            }

            return Componentes;
        }
    }
}
