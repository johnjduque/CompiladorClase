using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador.src.Transversal.Componente;

namespace Compilador.src.Transversal.TablasSimbolos
{
    public class TablaMaestra
    {
        public static void Agregar(ComponenteLexico Componenete)
        {
            TablaPalabraReservada.Agregar(Componenete);
            TablaSimbolo.Agregar(Componenete);
            TablaLiteral.Agregar(Componenete);
            TablaDummie.Agregar(Componenete);
        }

        public static void Reiniciar()
        {
            TablaPalabraReservada.Reiniciar();
            TablaSimbolo.Reiniciar();
            TablaLiteral.Reiniciar();
            TablaDummie.Reiniciar();
        }

        public static List<ComponenteLexico> ObtenerComponente(Tipo Tipo)
        {
            if (Tipo.SIMBOLO.Equals(Tipo))
            {
                return TablaSimbolo.ObtenerComponentes();
            }
            else if (Tipo.DUMMY.Equals(Tipo))
            {
                return TablaDummie.ObtenerComponentes();
            }
            else if (Tipo.LITERAL.Equals(Tipo))
            {
                return TablaLiteral.ObtenerComponentes();
            }
            else
            {
                return TablaPalabraReservada.ObtenerComponentes();
            }
        }
    }
}
