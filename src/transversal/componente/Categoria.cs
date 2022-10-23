using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.src.Transversal.Componente
{
    public enum Categoria
    {
        FIN_ARCHIVO, FIN_LINEA, IDENTIFICADOR, DECIMAL, ENTERO, MAYOR, MENOR, IGUAL, MAYOR_IGUAL, MENOR_IGUAL, ASIGNACION,
        SELECT, FROM, ASC, DESC, WHERE, ORDER_BY, SUMA, RESTA, MULTIPLICACION, DIVISION, PARENTESIS_ABRE, PARENTESIS_CIERRA,
        MODULO,DIFERENTE_QUE
    }
}
