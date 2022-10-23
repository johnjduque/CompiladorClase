using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.src.Transversal.Componente
{
    public class ComponenteLexico
    {
        private string Lexema;
        private Categoria Categoria;
        private Tipo Tipo;
        private int NumeroLinea;
        private int PosicionInicial;
        private int PosicionFinal;

        private ComponenteLexico(string lexema, Categoria categoria, Tipo tipo, int NumeroLinea, int posicionInicial, int posicionFinal)
        {
            this.Lexema = lexema;
            this.Categoria = categoria;
            this.Tipo = tipo;
            this.NumeroLinea = NumeroLinea;
            this.PosicionInicial = posicionInicial;
            this.PosicionFinal = posicionFinal;
        }

        public static ComponenteLexico CrearSimbolo(string Lexema, Categoria categoria, int NumeroLinea, int posicionInicial, int posicionFinal)
        {
            return new ComponenteLexico(Lexema, categoria, Tipo.SIMBOLO, NumeroLinea, posicionInicial, posicionFinal);
        }

        public static ComponenteLexico CrearDUMMY(string Lexema, Categoria categoria, int NumeroLinea, int posicionInicial, int posicionFinal)
        {
            return new ComponenteLexico(Lexema, categoria, Tipo.DUMMY, NumeroLinea, posicionInicial, posicionFinal);
        }

        public static ComponenteLexico CrearPalabraReservada(string Lexema, Categoria categoria, int NumeroLinea, int posicionInicial, int posicionFinal)
        {
            return new ComponenteLexico(Lexema, categoria, Tipo.PALABRA_RESERVADA, NumeroLinea, posicionInicial, posicionFinal);
        }

        public string GetLexema()
        {
            if (Lexema == null)
            {
                Lexema = "";
            }
            return Lexema;
        }

        public Categoria GetCategoria()
        {
            return Categoria;
        }

        public int GetNumeroLinea()
        {
            return NumeroLinea;
        }

        public int GetPosicionInicial()
        {
            return PosicionInicial;
        }

        public int GetPosicionFinal()
        {
            return PosicionFinal;
        }

        public Tipo GetTipo()
        {
            return Tipo;
        }

        public string ToString()
        {
            StringBuilder SB = new StringBuilder();
            String SaltoLinea = "\n";

            SB.Append("Tipo Componente: ").Append(GetTipo()).Append(SaltoLinea);
            SB.Append("Categoría: ").Append(GetCategoria()).Append(SaltoLinea);
            SB.Append("Lexema: ").Append(GetLexema()).Append(SaltoLinea);
            SB.Append("Número Línea: ").Append(GetNumeroLinea()).Append(SaltoLinea);
            SB.Append("Posición Inicial: ").Append(GetPosicionInicial()).Append(SaltoLinea);
            SB.Append("Posición Final: ").Append(GetPosicionFinal()).Append(SaltoLinea);

            return SB.ToString();
        }
    }
}
