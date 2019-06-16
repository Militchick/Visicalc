using System;
using System.IO;

// V 0.04b, 15-06-2019: 
//     Nacho, Anulado cargado y guardado, que usaban datos
//     públicos

namespace Visicalc
{
    struct casilla
    {
        public string nombre;
        public double valor;
        public char tipo;
    }

    class HojaDeCalculo
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(4 + (692*9), 1000 + 3);
            const int tamanyo = 1000;
            int opcion = 4;
            int contar = 0;
            bool guardarsino = false;
            bool seguro = true;
            casilla[] cas = new casilla[tamanyo];

            do
            {
                Console.Clear();
                Interfaz inter = new Interfaz();
                inter.Ejecutar();
                Console.Clear();

                Console.WriteLine("1. Cargar desde fichero");
                //Console.WriteLine("2. Añadir un dato");
                Console.WriteLine("2. Guardar en fichero");
                Console.WriteLine("0. Salir");

                Console.WriteLine();
                Console.Write("Opcion: ");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (IOException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.Message);
                }

                Console.WriteLine();

                switch (opcion)
                {
                    case 1: //Cargar

                        try
                        {
                            if (contar > 0)
                            {
                                bool hayCambiosPendientes = false;
                                bool sihayCambiosPendientes = false;

                                do
                                {
                                    Console.Write("Desea sobreescribir " +
                                        "los datos?: ");
                                    string sobre =
                                        Console.ReadLine().ToLower();

                                    switch (sobre)
                                    {
                                        case "si":
                                        case "s":
                                            hayCambiosPendientes = true;
                                            sihayCambiosPendientes = true;
                                            break;
                                        case "no":
                                        case "n":
                                            hayCambiosPendientes = true;
                                            break;
                                        default:
                                            Console.WriteLine("Error, " +
                                                "respuesta de si o no");
                                            break;
                                    }
                                }
                                while (hayCambiosPendientes == false);

                                if (sihayCambiosPendientes == true)
                                {
                                    contar = 0;
                                }

                            }

                            Console.Write("Nombre del fichero a cargar?: ");
                            string nombrecargar = Console.ReadLine();

                            if (File.Exists(nombrecargar + ".txt"))
                            {
                                StreamReader cargar =
                                File.OpenText(nombrecargar + ".txt");

                                string linea;

                                do
                                {
                                    linea = cargar.ReadLine();
                                    if (linea != null)
                                    {
                                        string[] partes = linea.Split(' ');

                                        for (int i = 1; i <= 21; i++)
                                        {
                                            for (int j = 0; j < 8; j++)
                                            {
                                                /*
                                                inter.tabla[i, j].nombre = 
                                                    partes[2];
                                                inter.tabla[i, j].valor =
                                                    Convert.ToDouble
                                                    (partes[3]);
                                                */
                                                //Console.WriteLine(partes[2] + " " + partes[3]);

                                            }
                                        }
                                    }
                                }
                                while (linea != null);

                                cargar.Close();

                                guardarsino = false;
                                seguro = false;
                            }
                            else
                            {
                                Console.WriteLine("El archivo " +
                                    nombrecargar + ".txt no se puede " +
                                    "cargar porque no existe");
                            }

                        }
                        catch (PathTooLongException e1)
                        {
                            Console.WriteLine(e1.Message);
                        }
                        catch (IOException e2)
                        {
                            Console.WriteLine(e2.Message);
                        }
                        catch (Exception e3)
                        {
                            Console.WriteLine(e3.Message);
                        }
                        break;
                    /*case 2: //Añadir

                    try
                    {

                        if (contar < tamanyo)
                        {
                            Console.Write("Introduce Nombre: ");
                            cas[contar].nombre = Console.ReadLine();

                            Console.Write("Introduce Valor: ");
                            cas[contar].valor = 
                                Convert.ToDouble(Console.ReadLine());


                            guardarsino = false;
                            seguro = false;

                            contar++;
                        }
                        else
                        {
                            Console.WriteLine("Casillas llenas");
                        }
                    }
                    catch (IOException e1)
                    {
                        Console.WriteLine(e1.Message);
                    }
                    catch (Exception e2)
                    {
                        Console.WriteLine(e2.Message);
                    }

            break;*/

                    case 2: //Guardar

                        try
                        {
                            /*
                        Console.Write("Nombre del fichero a guardar?: ");
                        string nombreguardar = Console.ReadLine();

                        StreamWriter guardar = File.CreateText
                            (nombreguardar + ".txt");

                        for (int i = 1; i <= 21; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                    char letra = ' ';

                                    switch (j)
                                    {
                                        case 0: letra = 'A'; break;
                                        case 1: letra = 'B'; break;
                                        case 2: letra = 'C'; break;
                                        case 3: letra = 'D'; break;
                                        case 4: letra = 'E'; break;
                                        case 5: letra = 'F'; break;
                                        case 6: letra = 'G'; break;
                                        case 7: letra = 'H'; break;
                                    }
                                    if(inter.tabla[i, j].valor != 0)
                                    {

                                        guardar.WriteLine("Casilla "
                                            + letra + i
                                            + ": " + inter.tabla[i, j].nombre
                                            + " " + inter.tabla[i, j].valor);
                                    }
                                    else if(inter.tabla[i, j].nombre != null)
                                    {
                                        guardar.WriteLine("Casilla "
                                            + letra + i
                                            + ": " + inter.tabla[i, j].nombre
                                            + " " + inter.tabla[i, j].valor);
                                    }
                                }
                        }

                        guardar.Close();
                        */
                            guardarsino = true;
                            seguro = false;

                        }
                        catch (PathTooLongException e1)
                        {
                            Console.WriteLine(e1.Message);
                        }
                        catch (IOException e2)
                        {
                            Console.WriteLine(e2.Message);
                        }
                        catch (Exception e3)
                        {
                            Console.WriteLine(e3.Message);
                        }
                        break;
                    case 0: //Salir

                        if (guardarsino == false)
                        {
                            bool bucle = true;

                            do
                            {
                                Console.Write("Estas seguro de que " +
                                    "quieres salir?: ");
                                string segura =
                                    Console.ReadLine().ToLower();

                                switch (segura)
                                {
                                    case "si":
                                    case "s":
                                        bucle = true;
                                        seguro = true;
                                        break;
                                    case "no":
                                    case "n":
                                        bucle = true;
                                        seguro = false;
                                        break;
                                    default:
                                        Console.WriteLine("Error, " +
                                            "respuesta de si o no");
                                        break;
                                }
                            }
                            while (bucle == false);
                        }
                        else
                        {
                            seguro = true;
                        }

                        break;
                    default:
                        Console.WriteLine("Error de Selección");
                        seguro = false;
                        break;
                }

                Console.WriteLine();

            }
            while (seguro != true);
        }
    }
}
