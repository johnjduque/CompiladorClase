using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.src.Transversal.Componente
{
    public class CategoriaGramatical
    {
        public static string FIN_ARCHIVO = "@EOF@";
        public static string FIN_LINEA = "@FL@";
        public static string CAMPO = "CAMPO";
        public static string TABLA = "TABLA";
        public static string LITERAL = "LITERAL";
        public static string WHERE = "WHERE";
        public static string FROM = "FROM";
        public static string SELECT = "SELECT";
        public static string ORDER_BY = "ORDER_BY";
        public static string AND = "AND";
        public static string OR = "OR";
        public static string ASC = "ASC";
        public static string DESC = "DESC";
        public static string DECIMAL = "DECIMAL";
        public static string ENTERO = "ENTERO";
        public static string IGUAL = "IGUAL";
        public static string DIFERENTE_QUE = "DIFERENTE QUE";
        public static string MAYOR_QUE = "MAYOR QUE";
        public static string MENOR_QUE = "MENOR QUE";
        public static string MENOR_O_IGUAL_QUE = "MENOR O IGUAL QUE";
        public static string MAYOR_O_IGUAL_QUE = "MAYOR O IGUAL QUE";
    }
}
