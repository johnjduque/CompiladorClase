using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador.src.Cache;
using Compilador.src.Transversal.Componente;
using Compilador.src.ManejadorErrores;
using Compilador.src.Transversal.TablasSimbolos;

namespace Compilador.src.analizadorlexico
{
    public class AnalizadorLexico
    {
        private int Puntero;
        private int NumeroLinea;
        private Linea LineaActual;
        private string CaracterActual;
        private string Lexema;
        private int EstadoActual;
        private bool ContinuarAnalisis;

        private AnalizadorLexico()
        {
            CargarNuevaLinea();
        }

        public static AnalizadorLexico Crear()
        {
            return new AnalizadorLexico();
        }

        private void CargarNuevaLinea()
        {
            NumeroLinea = NumeroLinea + 1;
            LineaActual = ProgramaFuente.obtenerProgramaFuente().obtenerLinea(NumeroLinea);
            NumeroLinea = LineaActual.GetNumeroLinea();
            Puntero = 1;
        }

        private void DevolverPuntero()
        {
            if (Puntero > 1)
            {
                Puntero = Puntero - 1;
            }
        }

        private void AumentarPuntero()
        {
            Puntero = Puntero + 1;
        }

        private void LeerSiguienteCaracter()
        {
            if (LineaActual.EsFinArchivo())
            {
                CaracterActual = LineaActual.GetContenido();
            }
            else if (Puntero > LineaActual.ObtenerLongitudContenido())
            {
                CaracterActual = "@FL@";
                Puntero = LineaActual.ObtenerLongitudContenido() + 1;
                CargarNuevaLinea();
            }
            else
            {
                CaracterActual = LineaActual.GetContenido().Substring(Puntero - 1, 1);
                AumentarPuntero();
            }
        }

        private void Reiniciar()
        {
            Lexema = "";
            EstadoActual = 0;
            ContinuarAnalisis = true;
            CaracterActual = "";
        }

        public ComponenteLexico DevolverComponente()
        {
            ComponenteLexico Retorno = null;
            Reiniciar();

            while (ContinuarAnalisis)
            {
                if (EstadoActual == 0)
                {
                    ProcesarEstado0();
                }
                else if (EstadoActual == 1)
                {
                    ProcesarEstado1();
                }
                else if (EstadoActual == 2)
                {
                    ProcesarEstado2();
                }
                else if (EstadoActual == 3)
                {
                    ProcesarEstado3();
                }
                else if (EstadoActual == 4)
                {
                    ProcesarEstado4();
                }
                else if (EstadoActual == 5)
                {
                    Retorno = ProcesarEstado5();
                }
                else if (EstadoActual == 6)
                {
                    Retorno = ProcesarEstado6();
                }
                else if (EstadoActual == 7)
                {
                    Retorno = ProcesarEstado7();
                }
                else if (EstadoActual == 8)
                {
                    ProcesarEstado8();
                }
                else if (EstadoActual == 9)
                {
                    Retorno = ProcesarEstado9();
                }
                else if (EstadoActual == 10)
                {
                    Retorno = ProcesarEstado10();
                }
                else if (EstadoActual == 11)
                {
                    Retorno = ProcesarEstado11();
                }
                else if (EstadoActual == 12)
                {
                    Retorno = ProcesarEstado12();
                }
                else if (EstadoActual == 13)
                {
                    ProcesarEstado13();
                }
                else if (EstadoActual == 14)
                {
                    Retorno = ProcesarEstado14();
                }
                else if (EstadoActual == 15)
                {
                    Retorno = ProcesarEstado15();
                }
                else if (EstadoActual == 16)
                {
                    Retorno = ProcesarEstado16();
                }
                else if (EstadoActual == 17)
                {
                    Retorno = ProcesarEstado17();
                }
                else if (EstadoActual == 18)
                {
                    ProcesarEstado18();
                }
                else if (EstadoActual == 19)
                {
                    Retorno = ProcesarEstado19();
                }
                else if (EstadoActual == 20)
                {
                    ProcesarEstado20();
                }
                else if (EstadoActual == 21)
                {
                    ProcesarEstado21();
                }
                else if (EstadoActual == 22)
                {
                    ProcesarEstado22();
                }
                else if (EstadoActual == 23)
                {
                    Retorno = ProcesarEstado23();
                }
                else if (EstadoActual == 24)
                {
                    Retorno = ProcesarEstado24();
                }
                else if (EstadoActual == 25)
                {
                    Retorno = ProcesarEstado25();
                }
                else if (EstadoActual == 26)
                {
                    Retorno = ProcesarEstado26();
                }
                else if (EstadoActual == 27)
                {
                    Retorno = ProcesarEstado27();
                }
                else if (EstadoActual == 28)
                {
                    Retorno = ProcesarEstado28();
                }
                else if (EstadoActual == 29)
                {
                    Retorno = ProcesarEstado29();
                }
                else if (EstadoActual == 30)
                {
                    ProcesarEstado30();
                }
                else if (EstadoActual == 31)
                {
                    Retorno = ProcesarEstado31();
                }
                else if (EstadoActual == 32)
                {
                    Retorno = ProcesarEstado32();
                }
                else if (EstadoActual == 33)
                {
                    Retorno = ProcesarEstado33();
                }
                else if (EstadoActual == 34)
                {
                    ProcesarEstado34();
                }
                else if (EstadoActual == 35)
                {
                    ProcesarEstado35();
                }
                else if (EstadoActual == 36)
                {
                    ProcesarEstado36();
                }
            }

            TablaMaestra.Agregar(Retorno);

            return Retorno;
        }

        private void DevorarEspaciosEnBlanco()
        {
            string Blanco = " ";

            while (Blanco.Equals(CaracterActual) || esTabulacion())
            {
                LeerSiguienteCaracter();
            }
        }

        private bool esTabulacion()
        {
            return "\t".Equals(CaracterActual);
        }

        private bool EsLetra()
        {
            return Char.IsLetter(CaracterActual.ToCharArray()[0]);
        }

        private bool EsDigito()
        {
            return Char.IsDigit(CaracterActual.ToCharArray()[0]);
        }
        private bool EsGuionBajo()
        {
            return "_".Equals(CaracterActual);
        }

        private bool EsSignopesos()
        {
            return "$".Equals(CaracterActual);
        }
        private bool EsMas()
        {
            return "+".Equals(CaracterActual);
        }
        private bool EsResta()
        {
            return "-".Equals(CaracterActual);
        }
        private bool EsAsterisco()
        {
            return "*".Equals(CaracterActual);
        }
        private bool EsSlash()
        {
            return "/".Equals(CaracterActual);
        }
        private bool EsModulo()
        {
            return "%".Equals(CaracterActual);
        }
        private bool EsParentesisAbre()
        {
            return "(".Equals(CaracterActual);
        }
        private bool EsParentesisCierra()
        {
            return ")".Equals(CaracterActual);
        }
        private bool EsFinArchivo()
        {
            return "@EOF@".Equals(CaracterActual);
        }
        private bool EsIgual()
        {
            return "=".Equals(CaracterActual);
        }
        private bool EsMayor()
        {
            return ">".Equals(CaracterActual);
        }
        private bool EsMenor()
        {
            return "<".Equals(CaracterActual);
        }
        private bool EsDosPuntos()
        {
            return ":".Equals(CaracterActual);
        }
        private bool EsExclamacion()
        {
            return "!".Equals(CaracterActual);
        }
        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual);
        }

        private bool EsComa()
        {
            return ",".Equals(CaracterActual);
        }

        private void Concatenar()
        {
            Lexema = Lexema + CaracterActual;
        }

        private void ProcesarEstado0()
        {
            LeerSiguienteCaracter();
            DevorarEspaciosEnBlanco();

            if (EsLetra() || EsGuionBajo() || EsSignopesos())
            {
                EstadoActual = 4;
                Concatenar();
            }
            else if (EsDigito())
            {
                EstadoActual = 1;
                Concatenar();
            }
            else if (EsMas())
            {
                EstadoActual = 5;
                Concatenar();
            }
            else if (EsResta())
            {
                EstadoActual = 6;
                Concatenar();
            }
            else if (EsAsterisco())
            {
                EstadoActual = 7;
                Concatenar();
            }
            else if (EsSlash())
            {
                EstadoActual = 8;
                Concatenar();
            }
            else if (EsModulo())
            {
                EstadoActual = 9;
                Concatenar();
            }
            else if (EsParentesisAbre())
            {
                EstadoActual = 10;
                Concatenar();
            }
            else if (EsParentesisCierra())
            {
                EstadoActual = 11;
                Concatenar();
            }
            else if (EsFinArchivo())
            {
                EstadoActual = 12;
                Concatenar();
            }
            else if (EsIgual())
            {
                EstadoActual = 19;
                Concatenar();
            }
            else if (EsMenor())
            {
                EstadoActual = 20;
                Concatenar();
            }
            else if (EsMayor())
            {
                EstadoActual = 21;
                Concatenar();
            }
            else if (EsDosPuntos())
            {
                EstadoActual = 22;
                Concatenar();
            }
            else if (EsExclamacion())
            {
                EstadoActual = 30;
                Concatenar();
            }
            else if (EsFinLinea())
            {
                EstadoActual = 13;
            }
            else
            {
                EstadoActual = 18;
            }
        }
        private void ProcesarEstado1()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 1;
                Concatenar();
            }
            else if (EsComa())
            {
                EstadoActual = 2;
                Concatenar();
            }
            else
            {
                EstadoActual = 14;
            }
        }
        private void ProcesarEstado2()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 3;
                Concatenar();
            }
            else
            {
                EstadoActual = 17;
            }
        }
        private void ProcesarEstado3()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 3;
                Concatenar();
            }
            else
            {
                EstadoActual = 15;
            }
        }
        private void ProcesarEstado4()
        {
            LeerSiguienteCaracter();

            if (EsLetra() || EsDigito() || EsGuionBajo() || EsSignopesos())
            {
                EstadoActual = 4;
                Concatenar();
            }
            else
            {
                EstadoActual = 16;
            }
        }

        private ComponenteLexico ProcesarEstado5()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.SUMA, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado6()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.RESTA, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado7()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.MULTIPLICACION, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private void ProcesarEstado8()
        {
            LeerSiguienteCaracter();

            if (EsAsterisco())
            {
                EstadoActual = 34;
                Concatenar();
            }
            else if (EsSlash())
            {
                EstadoActual = 36;
                Concatenar();
            }
            else
            {
                EstadoActual = 33;
            }
        }
        private ComponenteLexico ProcesarEstado9()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.MODULO, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado10()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.PARENTESIS_ABRE, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado11()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.PARENTESIS_CIERRA, NumeroLinea, PosicionInicial, PosicionFinal);
        }

        private ComponenteLexico ProcesarEstado12()
        {
            ContinuarAnalisis = false;
            return ComponenteLexico.CrearSimbolo("@EOF@", Categoria.FIN_ARCHIVO, NumeroLinea, 1, 1);
        }

        private void ProcesarEstado13()
        {
            CargarNuevaLinea();
            EstadoActual = 0;
        }

        private ComponenteLexico ProcesarEstado14()
        {
            ContinuarAnalisis = false;
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.ENTERO, NumeroLinea, PosicionInicial, PosicionFinal);
        }

        private ComponenteLexico ProcesarEstado15()
        {
            ContinuarAnalisis = false;
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.DECIMAL, NumeroLinea, PosicionInicial, PosicionFinal);
        }

        private ComponenteLexico ProcesarEstado16()
        {
            ContinuarAnalisis = false;
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.IDENTIFICADOR, NumeroLinea, PosicionInicial, PosicionFinal);
        }

        private ComponenteLexico ProcesarEstado17()
        {
            ContinuarAnalisis = false;
            DevolverComponente();

            string Falla = "Número decimal no válido";
            string Causa = "Luego del separador decimal se debe recibir un dígito y se recibió \"" + CaracterActual + "\"";
            string Solucion = "Luego del separador decimal se debe recibir un dígito";

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            Error Error = Error.CrearErrorLexico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
            GestorErrores.Agregar(Error);

            return ComponenteLexico.CrearDUMMY(Lexema + "0", Categoria.DECIMAL, NumeroLinea, PosicionInicial,
                PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado18()
        {
            string Falla = "Símbolo no reconocido por el lenguaje";
            string Causa = "Recibí \"" + CaracterActual + "\"";
            string Solucion = "Asegurese que el programa de entrada solo contenga símbolos válidos";

            int PosicionInicial = Puntero - 1;
            int PosicionFinal = Puntero - 1;

            Error Error = Error.CrearErrorLexico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
            GestorErrores.Agregar(Error);
            throw new Exception("Se ha presentado un problema durante el análisis léxico, dado que se leyo un símbolo desconocido" + CaracterActual);
        }

        private ComponenteLexico ProcesarEstado19()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.IGUAL, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private void ProcesarEstado20()
        {
            LeerSiguienteCaracter();

            if (EsMayor())
            {
                EstadoActual = 23;
                Concatenar();
            }
            else if (EsIgual())
            {
                EstadoActual = 24;
                Concatenar();
            }
            else
            {
                EstadoActual = 25;
            }
        }
        private void ProcesarEstado21()
        {
            LeerSiguienteCaracter();

            if (EsIgual())
            {
                EstadoActual = 26;
                Concatenar();
            }
            else
            {
                EstadoActual = 27;
            }
        }
        private void ProcesarEstado22()
        {
            LeerSiguienteCaracter();

            if (EsIgual())
            {
                EstadoActual = 28;
                Concatenar();
            }
            else
            {
                EstadoActual = 29;
            }
        }
        private ComponenteLexico ProcesarEstado23()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.DIFERENTE_QUE, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado24()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.MENOR_IGUAL, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado25()
        {
            ContinuarAnalisis = false;
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.MENOR, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado26()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.MAYOR_IGUAL, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado27()
        {
            ContinuarAnalisis = false;
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.MAYOR, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado28()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.ASIGNACION, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado29()
        {
            ContinuarAnalisis = false;
            DevolverComponente();

            string Falla = "Asignación no válida";
            string Causa = "Luego de los dos puntos (:) se esperaba un igual (=) y se recibió \"" + CaracterActual + "\"";
            string Solucion = "Luego de los dos puntos (:) se debe recibir un igual (=)";

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            Error Error = Error.CrearErrorLexico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
            GestorErrores.Agregar(Error);

            return ComponenteLexico.CrearDUMMY(Lexema + "=", Categoria.ASIGNACION, NumeroLinea, PosicionInicial,
                PosicionFinal);
        }
        private void ProcesarEstado30()
        {
            LeerSiguienteCaracter();

            if (EsIgual())
            {
                EstadoActual = 31;
                Concatenar();
            }
            else
            {
                EstadoActual = 32;
            }
        }
        private ComponenteLexico ProcesarEstado31()
        {
            ContinuarAnalisis = false;

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.DIFERENTE_QUE, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado32()
        {
            ContinuarAnalisis = false;
            DevolverComponente();

            string Falla = "Asignación no válida";
            string Causa = "Luego del signo ! se esperaba un igual (=) y se recibió \"" + CaracterActual + "\"";
            string Solucion = "Luego del signo ! se debe recibir un igual (=)";

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            Error Error = Error.CrearErrorLexico(NumeroLinea, PosicionInicial, PosicionFinal, Falla, Causa, Solucion);
            GestorErrores.Agregar(Error);

            return ComponenteLexico.CrearDUMMY(Lexema + "=", Categoria.ASIGNACION, NumeroLinea, PosicionInicial,
                PosicionFinal);
        }
        private ComponenteLexico ProcesarEstado33()
        {
            ContinuarAnalisis = false;
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            return ComponenteLexico.CrearSimbolo(Lexema, Categoria.DIVISION, NumeroLinea, PosicionInicial, PosicionFinal);
        }
        private void ProcesarEstado34()
        {
            LeerSiguienteCaracter();

            if (!EsAsterisco())
            {
                EstadoActual = 34;
                Concatenar();
            }
            else
            {
                EstadoActual = 35;
                Concatenar();
            }
        }
        private void ProcesarEstado35()
        {
            LeerSiguienteCaracter();

            if (EsAsterisco())
            {
                EstadoActual = 35;
                Concatenar();
            }
            else if (EsSlash())
            {
                EstadoActual = 0;
                Concatenar();
            }
            else
            {
                EstadoActual = 34;
                Concatenar();
            }
        }
        private void ProcesarEstado36()
        {
            LeerSiguienteCaracter();

            if (!EsFinLinea())
            {
                EstadoActual = 36;
                Concatenar();
            }
            else
            {
                EstadoActual = 13;
            }
        }

    }
}
