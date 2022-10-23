using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador.src.Transversal.Componente;
using Compilador.src.ManejadorErrores;
using System.Windows.Forms;
using Compilador.src.analizadorlexico;

namespace Compilador.src.analizadorsintactico
{
    public class AnalisisSintactico
    {

        AnalizadorLexico Analex = AnalizadorLexico.Crear();
        ComponenteLexico Componente;
        Stack<double> Pila = new Stack<double>();

        private void PedirComponente()
        {
            Componente = Analex.DevolverComponente();
        }

        public void Analizar()
        {
            PedirComponente();
            Expresion();

            if (GestorErrores.HayErroresAnalisis())
            {
                MessageBox.Show("Hay errores dentro del proceso de compilación");
            }
            else if (Categoria.FIN_ARCHIVO.Equals(Componente.GetCategoria()))
            {
                if (Pila.Count == 1)
                {
                    MessageBox.Show("El programa esta bien escrito");
                    MessageBox.Show("Resultado: " + Pila.Pop());
                }
                else
                {
                    MessageBox.Show("El programa esta bien escrito, pero faltaron componentes por evaluar");
                }
            }
            else
            {
                MessageBox.Show("El programa esta bien escrito, pero faltaron componentes por evaluar");
            }
        }
        //<Expresion>-><Termino><ExpresionPrima>
        private void Expresion()
        {
            Termino();
            ExpresionPrima();
        }

        //<Termino>-><Factor><TerminoPrima>
        private void Termino()
        {
            Factor();
            Termino();
        }

        //<ExpresionPrima>->+<Expresion>{PUSH{POP2+POP1}}|-<Expresion>{PUSH{POP2-POP1}}|Epsilon
        private void ExpresionPrima()
        {
            if (Categoria.SUMA.Equals(Componente.GetCategoria()))
            {
                PedirComponente();
                Expresion();

                if (!GestorErrores.HayErroresAnalisis())
                {
                    double derecho = Pila.Pop();
                    double izquierdo = Pila.Pop();
                    Pila.Push(izquierdo + derecho);
                }
            }
            else if (Categoria.RESTA.Equals(Componente.GetCategoria()))
            {
                PedirComponente();
                Expresion();

                if (!GestorErrores.HayErroresAnalisis())
                {
                    double derecho = Pila.Pop();
                    double izquierdo = Pila.Pop();
                    Pila.Push(izquierdo - derecho);
                }
            }
        }

        //<Factor>->NUMERO ENTERO{PUSH}|NUMERO DECIMAL{PUSH}|(<Expresion>)
        private void Factor()
        {
            if (Categoria.ENTERO.Equals(Componente.GetCategoria()))
            {
                Pila.Push(Convert.ToDouble(Componente.GetLexema()));
                PedirComponente();
            }
            else if (Categoria.DECIMAL.Equals(Componente.GetCategoria()))
            {
                PedirComponente();
            }
            else if (Categoria.PARENTESIS_ABRE.Equals(Componente.GetCategoria()))
            {
                PedirComponente();
                Expresion();

                if (Categoria.PARENTESIS_CIERRA.Equals(Componente.GetCategoria()))
                {
                    PedirComponente();
                }
                else
                {
                    string Falla = "No se cerró paréntesis";
                    string Causa = "Esperaba \")\" y se recibí \"" + Componente.GetLexema() + "\"";
                    string Solucion = "Asegurese de tener en la posición indicada un paréctesis que cierra";

                    int PosicionInicial = Componente.GetPosicionInicial();
                    int PosicionFinal = Componente.GetPosicionFinal();
                    int NumeroLinea = Componente.GetNumeroLinea();

                    Error Error = Error.CrearErrorSintactico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
                    GestorErrores.Agregar(Error);

                    throw new Exception("Se ha presentando un problema durante el análisis " +
                        "Sintáctico, dado que se esperaba un \")\" y se recibió: " + Componente.GetLexema());
                }
            }
            else
            {
                string Falla = "Componente no válido";
                string Causa = "Esperaba \"ENTERO\", \"DECIMAL\", \"(\" y se recibí \"" + Componente.GetLexema() + "\"";
                string Solucion = "Asegurese de tener en la posición indicada un \"ENTERO\", \"DECIMAL\", \"(\"";

                int PosicionInicial = Componente.GetPosicionInicial();
                int PosicionFinal = Componente.GetPosicionFinal();
                int NumeroLinea = Componente.GetNumeroLinea();

                Error Error = Error.CrearErrorSintactico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
                GestorErrores.Agregar(Error);

                throw new Exception("Se ha presentando un problema durante el análisis " +
                    "Sintáctico, dado que se esperaba un \"ENTERO\", \"DECIMAL\", \"(\" y se recibió: " + Componente.GetLexema());
            }
        }

        //<TerminoPrima>->*<Termino>{PUSH{POP2*POP1}}|/<Termino>{PUSH{POP2/POP1}}|Epsilon
        private void TerminoPrima()
        {
            if (Categoria.MULTIPLICACION.Equals(Componente.GetCategoria()))
            {
                PedirComponente();
                Termino();

                if (!GestorErrores.HayErroresAnalisis())
                {
                    double derecho = Pila.Pop();
                    double izquierdo = Pila.Pop();
                    Pila.Push(izquierdo * derecho);
                }
            }
            else if (Categoria.DIVISION.Equals(Componente.GetCategoria()))
            {
                PedirComponente();
                Termino();

                if (!GestorErrores.HayErroresAnalisis())
                {
                    double derecho = Pila.Pop();
                    double izquierdo = Pila.Pop();

                    if(derecho == 0)
                    {
                        string Falla = "Componente no válido";
                        string Causa = "Esperaba \"ENTERO\", \"DECIMAL\", \"(\" y se recibí \"" + Componente.GetLexema() + "\"";
                        string Solucion = "Asegurese de tener en la posición indicada un \"ENTERO\", \"DECIMAL\", \"(\"";

                        int PosicionInicial = Componente.GetPosicionInicial();
                        int PosicionFinal = Componente.GetPosicionFinal();
                        int NumeroLinea = Componente.GetNumeroLinea();

                        Error Error = Error.CrearErrorSintactico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
                        GestorErrores.Agregar(Error);
                    }
                    else
                    {
                        Pila.Push(izquierdo / derecho);
                    }                    
                }
            }
        }
    }
}
