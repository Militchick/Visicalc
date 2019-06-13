using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Visicalc
{
    struct casilla
    {
        public string nombre;
        public double valor;
    }

    class HojaDeCalculo
    {
        static void Main(string[] args)
        {
            try
            {
                const int tamanyo = 1000;
                int opcion = 1;
                int contar = 0;
                bool guardarsino = true;
                bool seguro = true;
                casilla[] cas = new casilla[tamanyo];

                do
                {
                    Console.WriteLine("1. Cargar desde fichero");
                    Console.WriteLine("2. Añadir un dato");
                    Console.WriteLine("3. Guardar en fichero");
                    Console.WriteLine("0. Salir");

                    Console.WriteLine();
                    Console.Write("Opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    switch (opcion)
                    {
                        case 1: //Cargar

                            if(contar > 0)
                            {
                                bool sno = false;
                                bool sobresno = false;

                                do
                                {
                                    Console.Write("Desea sobreescribir los datos?: ");
                                    string sobre = Console.ReadLine().ToLower();

                                    switch (sobre)
                                    {
                                        case "si":
                                        case "s":
                                            sno = true;
                                            sobresno = true;
                                            break;
                                        case "no":
                                        case "n":
                                            sno = true;
                                            break;
                                        default:
                                            Console.WriteLine("Error, respuesta de si o no");
                                            break;
                                    }
                                }
                                while (sno == false);
                            
                                if(sobresno == true)
                                {
                                    contar = 0;
                                }

                            }

                            Console.Write("Nombre del fichero a cargar?: ");
                            string nombrecargar = Console.ReadLine();

                            StreamReader cargar = File.OpenText(nombrecargar + ".txt");

                            string linea;

                            do
                            {
                                linea = cargar.ReadLine();
                                if(linea != null)
                                {
                                    string[] partes = linea.Split(' ');

                                    cas[contar].nombre = partes[0];
                                    cas[contar].valor = Convert.ToDouble(partes[1]);

                                    contar++;
                                }
                            }
                            while (linea != null);

                            cargar.Close();

                            guardarsino = false;
                            seguro = false;

                            break;
                        case 2: //Añadir

                            if (contar < tamanyo)
                            {
                                Console.Write("Introduce Nombre: ");
                                cas[contar].nombre = Console.ReadLine();

                                Console.Write("Introduce Valor: ");
                                cas[contar].valor = Convert.ToDouble(Console.ReadLine());


                                guardarsino = false;
                                seguro = false;
                            }
                            else
                            {
                                Console.WriteLine("Casillas llenas");
                            }

                            contar++;


                            break;

                        case 3: //Guardar

                            Console.Write("Nombre del fichero a guardar?: ");
                            string nombreguardar = Console.ReadLine();

                            StreamWriter guardar = File.AppendText(nombreguardar + ".txt");

                            for (int i = 0; i < contar; i++)
                            {
                                guardar.WriteLine(cas[i].nombre + " " + cas[i].valor);
                            }

                            guardar.Close();

                            guardarsino = true;
                            seguro = false;

                            break;
                        case 0: //Salir

                            if(guardarsino == false)
                            {

                                bool bucle = true;

                                do
                                {
                                    Console.WriteLine("Quedan datos por guardar");
                                    Console.Write("Estas seguro de que quieres salir?: ");
                                    string segura = Console.ReadLine().ToLower();

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
                                            Console.WriteLine("Error, respuesta de si o no");
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
                            break;
                    }

                    Console.WriteLine();
                    
                }
                while (seguro != true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
