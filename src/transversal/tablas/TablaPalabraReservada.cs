using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador.src.Transversal.Componente;



namespace Compilador.src.Transversal.TablasSimbolos
{
    public class TablaPalabraReservada
    {
        private static Dictionary<string, List<ComponenteLexico>> TABLA =
new Dictionary<string, List<ComponenteLexico>>();

        private static Dictionary<string, Categoria> PALABRAS_RESERVADAS =
            new Dictionary<string, Categoria>();

        static TablaPalabraReservada()
        {
            PALABRAS_RESERVADAS.Add("SELECT", Categoria.SELECT);
            PALABRAS_RESERVADAS.Add("FROM", Categoria.FROM);
            PALABRAS_RESERVADAS.Add("WHERE", Categoria.WHERE);
            PALABRAS_RESERVADAS.Add("ASC", Categoria.ASC);
            PALABRAS_RESERVADAS.Add("DESC", Categoria.DESC);


        }
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

        private static bool EsPalabraReservada(string Lexema)
        {
            return PALABRAS_RESERVADAS.ContainsKey(Lexema);
        }

        public static void Agregar(ComponenteLexico Componente)
        {
            if (Componente != null && EsPalabraReservada(Componente.GetLexema()))
            {
                Componente = ComponenteLexico.CrearPalabraReservada(Componente.GetLexema(),
                    PALABRAS_RESERVADAS[Componente.GetLexema()], Componente.GetNumeroLinea(),
                    Componente.GetPosicionFinal(), Componente.GetPosicionFinal());
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
