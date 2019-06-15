using System;
//using System.Threading;

// V 0.04b, 15-06-2019: 
//     Nacho, Ejemplo de cómo mover con las flechas e introducir datos
//     en cada casilla, con interfaz más parecido a Visicalc

namespace Visicalc
{

    class Interfaz
    {
        //protected bool salidainter = false;

        // protected int espaciocelda = 9;
        // protected const int altura = 25;
        // protected const int ancho = 80;
        // protected int cuentaltura2 = 1;
        // protected int cuentanchura2 = 0;
        // public casilla[,] tabla = new casilla[altura, ancho];

        const int ANCHO = 8;
        const int ALTO = 21;
        protected casilla[,] datos;

        protected string casillaActual;
        protected int filaActual, columnaActual;
        protected bool terminado;

        public Interfaz()
        {
            casillaActual = "A1";
            filaActual = 0;
            columnaActual = 0;
            datos = new casilla[ANCHO, ALTO];

            terminado = false;
        }

        public void Ejecutar()
        {
            /*
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A1");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            //TablasPreparar();

            Console.WriteLine();
            Console.WriteLine("Pulsa ESC para salir de la Interfaz");
            */

            
            do
            {
                DibujarPantalla();
                EsperarYProcesarTecla();

                /*
                CambiarTecla();
                TablasPreparar();

                Console.WriteLine();
                Console.WriteLine("Pulsa ESC para salir de la Interfaz");
                
                if ((tabla[cuentaltura2,
                    cuentanchura2].valor == 0) && 
                    (tabla[cuentaltura2, cuentanchura2].nombre == null))
                {
                    tabla[cuentaltura2, cuentanchura2].tipo = 'V';
                }

                Console.WriteLine("Valor:" + tabla[cuentaltura2,
                    cuentanchura2].valor + " / Nombre: " + tabla[cuentaltura2,
                    cuentanchura2].nombre + " / Tipo: " + tabla[cuentaltura2,
                    cuentanchura2].tipo);
                Console.WriteLine();
            }
            while (salidainter != true);
            */
            }
            while (!terminado);
        }


        // Dibuja todo el interfaz: líneas de información y cuadrícula
        protected void DibujarPantalla()
        {
            casillaActual = "" +
                Convert.ToChar('A' + columnaActual)+
                (filaActual + 1);
            Console.Clear();
            Console.WriteLine(casillaActual+ "  "+ 
                datos[columnaActual, filaActual].nombre, "az");
            Console.WriteLine("Pulse ESC para el menú");
            // Cabeceras de las columnas, con anchura 9
            for (char columna = 'A'; columna <= 'H'; columna++)
            {
                Escribir(3 + (columna-'A') * 9, 2, 
                    AlinearIzquierda(columna+"", 9), "inv");
            }
            // Comienzo de las filas, con anchura 3
            for (int fila = 1; fila <= 21; fila++)
            {
                Escribir(0, fila+2, AlinearDerecha(fila, 3), "inv");
            }

            // Datos de las casillas
            for (int fila = 0; fila <= 20; fila++)
                for (int columna = 0; columna < 8; columna++)
                {
                    Escribir(3 + columna * 9, fila + 3,
                        datos[columna, fila].nombre);
                }

            // Y nos colocamos en la casilla actual
            Console.SetCursorPosition(3 + columnaActual * 9, 3 + filaActual);

            Console.ResetColor();
        }

        protected void EsperarYProcesarTecla()
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.Escape) { terminado = true; return; }
            else if (tecla.Key == ConsoleKey.RightArrow && columnaActual < ANCHO - 1)
                columnaActual++;
            else if (tecla.Key == ConsoleKey.LeftArrow && columnaActual > 0)
                columnaActual--;
            else if (tecla.Key == ConsoleKey.DownArrow && filaActual < ALTO - 1)
                filaActual++;
            else if (tecla.Key == ConsoleKey.UpArrow && filaActual > 0)
                filaActual--;
            else ProcesarLetra(tecla.KeyChar);
        }

        protected void ProcesarLetra(char letra)
        {
            // TO DO: Falta comprobar si es letra o número
            // Y limitar longitud en los números
            datos[columnaActual, filaActual].nombre += letra;
        }

        // ---------- Funciones auxiliares ------------

        // Función auxiliar para escribir en ciertas coordenadas
        // Colores permitidos por ahora: 
        // "bl" (y valor por defecto) = blanco sobre negro
        // "az" = azul (cyan) sobre negro
        // "inv" = invertido (negro sobre gris)
        protected void Escribir(int x, int y, string texto, string color="bl")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            if (color == "az")
                Console.ForegroundColor = ConsoleColor.White;
            else if (color == "inv")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(texto);
        }

        // Convierte un número en un string, alineado hacia
        // la derecha, rellenando con espacios hasta una cierta
        // longitud
        protected string AlinearDerecha(int num, int cifras)
        {
            string resultado = num.ToString();
            while (resultado.Length < cifras)
                resultado = " " + resultado;
            return resultado;
        }

        // Completa un string hasta una cierta longitud, 
        // rellenando con espacios al final
        protected string AlinearIzquierda(string texto, int letras)
        {
            while (texto.Length < letras)
                texto += " ";
            return texto;
        }


        // ------------------------------------
        // Aquí está la estructura anterior


        /*
        //Se preparan las tablas, añadiendo
        //los limites de anchura y las anchuras de celdas

        protected void TablasPreparar()
        {
            for (int cuentaltura = 0; 
                cuentaltura < 22; cuentaltura++)
            {
                for (int cuentanchura = 0;
                    cuentanchura < ancho; cuentanchura++)
                {

                    const byte anchoprimeracelda = 4;
                    const byte anchocelda = 9;

                    if (cuentanchura == 8)
                    {
                        creatablas(cuentaltura, cuentanchura,
                            anchoprimeracelda, anchocelda);
                    }

                    if (salidainter == true)
                    {
                        cuentaltura = altura;
                        cuentanchura = ancho;
                    }
                    else if (cuentanchura >= 8)
                    {
                        cuentaltura = altura;
                        cuentanchura = ancho;
                    }

                }
            }
        }
        
        //Sirve para pausar durante un tiempo la consola
        //Usa System.Threading

        public static void Pausa(int milisegundos)
        {
            Thread.Sleep(milisegundos);
        }

        //Aqui se limita las filas (altura) y se dibujan las tablas
        //Incluyendo las letras mientras la altura sea 0 (la primera linea)

        protected void creatablas(int cuentaltura, int cuentanchura,
            int anchoprimeracelda, int anchocelda)
        {

            char columna = 'A';
            
            for (int alt = 0; alt < 22; alt++)
            {

                for (byte i = 0; i < anchoprimeracelda; i++)
                {
                    if (i == 0)
                    {
                        if(alt > 0)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(alt);
                        Console.ResetColor();
                        if (alt < 10)
                            Console.Write("_");
                    }
                    else
                    {

                        Console.Write("_");
                    }
                }

                Console.Write("||");


                for (int i = 0; i < cuentanchura; i++)
                {
                    if (alt == 0)
                    {
                        for (byte j = 0; j < anchocelda-1; j++)
                        {
                            if (j == (anchocelda - 1) / 2)
                            {
                                if ((columna >= 'A') && (columna <= 'H'))
                                {
                                    Console.ForegroundColor = 
                                        ConsoleColor.Cyan;
                                    Console.Write(columna);
                                    Console.ResetColor();
                                    columna++;
                                }
                            }

                            Console.Write("_");
                        }

                        Console.Write("||");
                    }
                    else
                    {
                        for (byte j = 0; j < anchocelda; j++)
                        {
                            if ((alt == 0) && (j == (anchocelda - 1) / 2))
                            {
                                if ((columna >= 'A') && (columna <= 'H'))
                                {
                                    Console.ForegroundColor = 
                                        ConsoleColor.Cyan;
                                    Console.Write(columna);
                                    Console.ResetColor();
                                    columna++;
                                }

                            }

                            Console.Write("_");
                        }

                        Console.Write("||");
                    }
                }
                Console.WriteLine();
            }
        }
          
        //Se usa para ir mostrando en que casilla se esta actualmente
        //En la primera linea de la consola, se comprueba la casilla
        //despues del pulsar un boton
        
        protected void CambiarTecla()
        {

            Console.WriteLine();

            //const int TECLA_INT = Sdl.SDLK_KP_ENTER;
            //const int TECLA_ESP = Sdl.SDLK_SPACE;

            string letras = string.Empty;

            if (cuentanchura2 < 8)
            {
                Console.SetCursorPosition(7 + (11 * cuentanchura2),
                3 + cuentaltura2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("         ");
                Console.SetCursorPosition(7 + (11 * cuentanchura2),
                    3 + cuentaltura2);
            }
            ConsoleKeyInfo TeclaLeida = Console.ReadKey();

            if (TeclaLeida.Key == ConsoleKey.DownArrow)
            {
                if(cuentaltura2 < 21)
                {
                    cuentaltura2++;
                    if (tabla[cuentaltura2, cuentanchura2].tipo == 'V')
                    {
                        espaciocelda = 9;
                    }
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.UpArrow)
            {
                if (cuentaltura2 > 1)
                {
                    cuentaltura2--;
                    if (tabla[cuentaltura2, cuentanchura2].tipo == 'V')
                    {
                        espaciocelda = 9;
                    }
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.LeftArrow)
            {
                if (cuentanchura2 > 0)
                {
                    cuentanchura2--;
                    if (tabla[cuentaltura2, cuentanchura2].tipo == 'V')
                    {
                        espaciocelda = 9;
                    }
                    
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.RightArrow)
            {
                if (cuentanchura2 < 7)
                {
                    cuentanchura2++;
                    if(tabla[cuentaltura2, cuentanchura2].tipo == 'V')
                    {
                        espaciocelda = 9;
                    }
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                salidainter = true;

                Console.ResetColor();
            }
            else if ((TeclaLeida.Key == ConsoleKey.D0)
                || (TeclaLeida.Key == ConsoleKey.D1)
                || (TeclaLeida.Key == ConsoleKey.D2)
                || (TeclaLeida.Key == ConsoleKey.D3)
                || (TeclaLeida.Key == ConsoleKey.D4)
                || (TeclaLeida.Key == ConsoleKey.D5)
                || (TeclaLeida.Key == ConsoleKey.D6)
                || (TeclaLeida.Key == ConsoleKey.D7)
                || (TeclaLeida.Key == ConsoleKey.D8)
                || (TeclaLeida.Key == ConsoleKey.D9)
                || (TeclaLeida.Key == ConsoleKey.A)
                || (TeclaLeida.Key == ConsoleKey.B)
                || (TeclaLeida.Key == ConsoleKey.C)
                || (TeclaLeida.Key == ConsoleKey.D)
                || (TeclaLeida.Key == ConsoleKey.E)
                || (TeclaLeida.Key == ConsoleKey.F)
                || (TeclaLeida.Key == ConsoleKey.G)
                || (TeclaLeida.Key == ConsoleKey.H)
                || (TeclaLeida.Key == ConsoleKey.I)
                || (TeclaLeida.Key == ConsoleKey.J)
                || (TeclaLeida.Key == ConsoleKey.K)
                || (TeclaLeida.Key == ConsoleKey.L)
                || (TeclaLeida.Key == ConsoleKey.M)
                || (TeclaLeida.Key == ConsoleKey.N)
                || (TeclaLeida.Key == ConsoleKey.O)
                || (TeclaLeida.Key == ConsoleKey.P)
                || (TeclaLeida.Key == ConsoleKey.Q)
                || (TeclaLeida.Key == ConsoleKey.R)
                || (TeclaLeida.Key == ConsoleKey.S)
                || (TeclaLeida.Key == ConsoleKey.T)
                || (TeclaLeida.Key == ConsoleKey.U)
                || (TeclaLeida.Key == ConsoleKey.V)
                || (TeclaLeida.Key == ConsoleKey.W)
                || (TeclaLeida.Key == ConsoleKey.X)
                || (TeclaLeida.Key == ConsoleKey.Y)
                || (TeclaLeida.Key == ConsoleKey.Z)
                || (TeclaLeida.Key == ConsoleKey.Add)
                || (TeclaLeida.Key == ConsoleKey.Subtract)
                || (TeclaLeida.Key == ConsoleKey.Multiply)
                || (TeclaLeida.Key == ConsoleKey.Divide))
            {
                tabla[cuentaltura2, cuentanchura2].tipo = 'V';
                IntroduceValor(TeclaLeida);
            }

            char primeraletra = 'A';

            for (int i = 0; i < cuentanchura2; i++)
            {
                if ((primeraletra >= 'A') && (primeraletra < 'H'))
                {
                    primeraletra++;
                }
            }

            letras += primeraletra;
            
            Console.ResetColor();
            Console.Clear();
            Pausa(100);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(letras);
            Console.WriteLine(cuentaltura2);

            Console.ResetColor();

            //Segunda y Tercera Linea Vacias
            Console.WriteLine();
            Console.WriteLine();
            


        }

        protected void IntroduceValor(ConsoleKeyInfo PrimerValor)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            string valorinicial = string.Empty;
            double valorinicialdoble = 0;

            string sololetras = string.Empty;
            primercaraleido(PrimerValor, valorinicial, 
                valorinicialdoble, sololetras);

            char[] cara8 = new char[8];
            for (int i = 0; i < 8; i++)
            {
                ConsoleKeyInfo cki = Console.ReadKey();

                if (cki.Key != ConsoleKey.Enter)
                {
                    cara8[i] = Convert.ToChar(cki.KeyChar);
                }
                else
                {
                    i = 8;
                }
            }
            string valorfinal = new string(cara8);

            if (valorfinal != null)
            {
                try
                {
                    string valorfinalcadena = 
                        tabla[cuentaltura2, cuentanchura2].nombre + valorfinal;
                    double totalp1 = tabla[cuentaltura2, cuentanchura2].valor;
                    double totalp2 = 0;
                    bool suma = false;
                    bool resta = false;
                    bool multiplicar = false;
                    bool dividir = false;
                    
                    foreach (char c in valorfinalcadena)
                    {
                        switch (c)
                        {
                            case '0':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "0");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "0");
                                }
                                break;
                            case '1':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "1");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "1");
                                }
                                break;
                            case '2':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "2");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "2");
                                }
                                break;
                            case '3':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "3");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "3");
                                }
                                break;
                            case '4':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "4");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "4");
                                }
                                break;
                            case '5':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "5");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "5");
                                }
                                break;
                            case '6':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "6");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "6");
                                }
                                break;
                            case '7':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "7");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "7");
                                }
                                break;
                            case '8':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "8");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "8");
                                }
                                break;
                            case '9':
                                if ((suma == false) && (resta == false)
                                    && (multiplicar == false)
                                    && (dividir == false))
                                {
                                    totalp1 = double.Parse(totalp1.ToString() + "9");
                                }
                                else
                                {
                                    totalp2 = double.Parse(totalp2.ToString() + "9");
                                }
                                break;

                            case 'A':
                            case 'a':
                                sololetras = sololetras + "A"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'B':
                            case 'b':
                                sololetras = sololetras + "B"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'C':
                            case 'c':
                                sololetras = sololetras + "C"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'D':
                            case 'd':
                                sololetras = sololetras + "D"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'E':
                            case 'e':
                                sololetras = sololetras + "E"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'F':
                            case 'f':
                                sololetras = sololetras + "F"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'G':
                            case 'g':
                                sololetras = sololetras + "G"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'H':
                            case 'h':
                                sololetras = sololetras + "H"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'I':
                            case 'i':
                                sololetras = sololetras + "I"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'J':
                            case 'j':
                                sololetras = sololetras + "J"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'K':
                            case 'k':
                                sololetras = sololetras + "K"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'L':
                            case 'l':
                                sololetras = sololetras + "L"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'M':
                            case 'm':
                                sololetras = sololetras + "M"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'N':
                            case 'n':
                                sololetras = sololetras + "N"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'O':
                            case 'o':
                                sololetras = sololetras + "O"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'P':
                            case 'p':
                                sololetras = sololetras + "P"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'Q':
                            case 'q':
                                sololetras = sololetras + "Q"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'R':
                            case 'r':
                                sololetras = sololetras + "R"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'S':
                            case 's':
                                sololetras = sololetras + "S"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'T':
                            case 't':
                                sololetras = sololetras + "T"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'U':
                            case 'u':
                                sololetras = sololetras + "U"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'V':
                            case 'v':
                                sololetras = sololetras + "V"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'W':
                            case 'w':
                                sololetras = sololetras + "W"; 
                                tabla[cuentaltura2, cuentanchura2].nombre 
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'X':
                            case 'x':
                                sololetras = sololetras + "X"; 
                                tabla[cuentaltura2, cuentanchura2].nombre
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'Y':
                            case 'y':
                                sololetras = sololetras + "Y"; 
                                tabla[cuentaltura2, cuentanchura2].nombre
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case 'Z':
                            case 'z':
                                sololetras = sololetras + "Z";
                                tabla[cuentaltura2, cuentanchura2].nombre
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case ' ':
                                sololetras = sololetras + " ";
                                tabla[cuentaltura2, cuentanchura2].nombre
                                    = sololetras;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                                break;
                            case '+': suma = true;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                                break;
                            case '-': resta = true;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                                break;
                            case '*': multiplicar = true;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                                break;
                            case '/': dividir = true;
                                tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                                break;
                        }
                    }

                    double cortado = 0;
                    if(suma == true)
                    {
                        cortado = totalp1 + totalp2;
                        tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                    }
                    else if(multiplicar == true)
                    {
                        cortado = totalp1 * totalp2;
                        tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                    }
                    else if(resta == true)
                    {
                        if(totalp1 > totalp2)
                        {
                            cortado = totalp1 - totalp2;
                            tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                        }
                        else
                        {
                            cortado = totalp2 - totalp1;
                            tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                        }
                    }
                    else if (dividir == true)
                    {
                        if (totalp1 > totalp2)
                        {
                            cortado = totalp1 / totalp2;
                            tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                        }
                        else
                        {
                            cortado = totalp2 / totalp1;
                            tabla[cuentaltura2, cuentanchura2].tipo = 'F';
                        }
                    }
                    else if(totalp2 == 0)
                    {
                        cortado = totalp1;
                        tabla[cuentaltura2, cuentanchura2].tipo = 'N';
                    }


                    if ((tabla[cuentaltura2, cuentanchura2].nombre != null)
                        && (suma != true) && (resta != true) && 
                        (multiplicar != true) && (dividir != true))
                    {
                        tabla[cuentaltura2, cuentanchura2].tipo = 'T';
                        cortado = 0;
                    }

                    tabla[cuentaltura2, cuentanchura2].valor = cortado;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ResetColor();
            }

        }

        protected void primercaraleido (ConsoleKeyInfo PrimerValor, 
            string valorinicial, double valorinicialdoble, string sololetras)
        {
            switch (PrimerValor.Key)
            {
                case ConsoleKey.D0:
                    valorinicial = "0";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D1:
                    valorinicial = "1";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D2:
                    valorinicial = "2";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D3:
                    valorinicial = "3";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D4:
                    valorinicial = "4";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D5:
                    valorinicial = "5";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D6:
                    valorinicial = "6";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D7:
                    valorinicial = "7";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D8:
                    valorinicial = "8";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;
                case ConsoleKey.D9:
                    valorinicial = "9";
                    valorinicialdoble = Convert.ToDouble(valorinicial);
                    tabla[cuentaltura2, cuentanchura2].valor
                        = valorinicialdoble;
                    break;

                case ConsoleKey.A:
                    valorinicial = "A";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.B:
                    valorinicial = "B";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.C:
                    valorinicial = "C";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.D:
                    valorinicial = "D";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.E:
                    valorinicial = "E";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.F:
                    valorinicial = "F";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.G:
                    valorinicial = "G";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.H:
                    valorinicial = "H";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.I:
                    valorinicial = "I";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.J:
                    valorinicial = "J";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.K:
                    valorinicial = "K";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.L:
                    valorinicial = "L";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.M:
                    valorinicial = "M";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.N:
                    valorinicial = "N";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.O:
                    valorinicial = "O";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.P:
                    valorinicial = "P";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Q:
                    valorinicial = "Q";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.R:
                    valorinicial = "R";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.S:
                    valorinicial = "S";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.T:
                    valorinicial = "T";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.U:
                    valorinicial = "U";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.V:
                    valorinicial = "V";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.W:
                    valorinicial = "W";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.X:
                    valorinicial = "X";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Y:
                    valorinicial = "Y";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Z:
                    valorinicial = "Z";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Spacebar:
                    valorinicial = " ";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Add:
                    valorinicial = "+";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Subtract:
                    valorinicial = "-";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Multiply:
                    valorinicial = "*";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
                case ConsoleKey.Divide:
                    valorinicial = "/";
                    tabla[cuentaltura2, cuentanchura2].nombre = valorinicial;
                    sololetras = valorinicial; break;
            }
        }*/
    }
}
