using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB13
{
    internal class Pantalla
    {
        public static int contador = 0;
        public static int[] encuestas = new int[20];
        public static int contadorEncuestas = 0;

        public static int PantallaPrincipal()
        {
            Console.Clear();

            string texto = "================================\n" +
                           "Encuestas de Calidad\n" +
                           "================================\n" +
                           "1: Realizar Encuesta\n" +
                           "2: Ver datos registrados\n" +
                           "3: Eliminar un dato\n" +
                           "4: Ordenar datos de menor a mayor\n" +
                           "5: Salir\n" +
                           "================================";

            Console.WriteLine(texto);

            return Operaciones.getEntero("Ingrese una opción:", texto);
        }

        public static void Satisfaccion()
        {
            int opcion;

            do
            {
                Console.Clear();

                MostrarTextoNivelSatisfaccion();

                opcion = Operaciones.getEntero("Ingrese una opción:", "Ingrese una opción válida (1-5).");

                if (opcion >= 1 && opcion <= 5)
                {
                    RegistrarSatisfaccion(opcion);

                    Console.Clear();
                    string textoGuardado = "================================\n" +
                                            "Nivel de Satisfacción\n" +
                                            "================================\n\n\n" +
                                            "¡Gracias por participar!\n\n\n" +
                                            "================================\n" +
                                            "Presione una tecla para\n" +
                                            " regresar al menú...";

                    Console.WriteLine(textoGuardado);
                    Console.ReadKey();

                }


            } while (opcion == null);
        }

        public static void VerDatosRegistrados()
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("Ver datos registrados");
            Console.WriteLine("================================");

            int contadorPersonas = 0;
            for (int i = 0; i < contadorEncuestas; i++)
            {
                if (i % 5 == 0 && i != 0)
                {
                    Console.WriteLine();
                }

                Console.Write("[" + encuestas[i] + "]");
                contadorPersonas++;
            }

            Console.WriteLine();
            Console.WriteLine();

            int[] conteoSatisfaccion = new int[5];
            for (int i = 0; i < contadorEncuestas; i++)
            {
                int nivel = encuestas[i] - 1;
                conteoSatisfaccion[nivel]++;
            }

            Console.WriteLine($"{conteoSatisfaccion[0]} personas: Nada satisfecho");
            Console.WriteLine($"{conteoSatisfaccion[1]} personas: No muy satisfecho");
            Console.WriteLine($"{conteoSatisfaccion[2]} personas: Tolerable");
            Console.WriteLine($"{conteoSatisfaccion[3]} personas: Satisfecho");
            Console.WriteLine($"{conteoSatisfaccion[4]} personas: Muy satisfecho");

            Console.WriteLine("================================");
            Console.WriteLine("Presione una tecla para regresar");
            Console.ReadKey();
        }

        private static void MostrarTextoNivelSatisfaccion()
        {
            Console.WriteLine("================================\n" +
                                "Nivel de Satisfacción\n" +
                                "================================\n" +
                                "¿Qué tan satisfecho está con la\n" +
                                " atención de nuestra tienda?\n" +
                                "1: Nada satisfecho\n" +
                                "2: No muy satisfecho\n" +
                                "3: Tolerable\n" +
                                "4: Satisfecho\n" +
                                "5: Muy satisfecho\n" +
                                "================================");
        }

        private static void RegistrarSatisfaccion(int opcion)
        {
            Console.Write(" ");

            switch (opcion)
            {
                case 1:
                    Console.Write("Nada satisfecho");
                    break;
                case 2:
                    Console.Write("No muy satisfecho");
                    break;
                case 3:
                    Console.Write("Tolerable");
                    break;
                case 4:
                    Console.Write("Satisfecho");
                    break;
                case 5:
                    Console.Write("Muy satisfecho");
                    break;
            }

            if (contadorEncuestas < encuestas.Length)
            {
                encuestas[contadorEncuestas] = opcion;
                contadorEncuestas++;
            }
            else
            {
                Console.WriteLine("Ya has alcanzado el límite de encuestas.");
            }
        }

        public static void EliminarDato()
        {
            Console.Clear();

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Eliminar un dato");
            Console.WriteLine("--------------------------------------------");

            MostrarEncuesta();
            Console.WriteLine("--------------------------------------------");

            Console.Write("Ingrese la posición a eliminar: ");
            int posicion;

            while (!int.TryParse(Console.ReadLine(), out posicion) || posicion < 1 || posicion > contadorEncuestas)
            {
                Console.WriteLine("Posición no válida. Ingrese nuevamente:");
            }

            EliminarEncuesta(posicion - 1);
            MostrarEncuesta();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Presione una tecla para regresar...");
            Console.ReadKey();
        }

        static void MostrarEncuesta()
        {
            for (int i = 0; i < contadorEncuestas; i++)
            {
                Console.Write($"{i + 1:D3}: [{encuestas[i]}]  ");
                if ((i + 1) % 5 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void EliminarEncuesta(int posicion)
        {
            for (int i = posicion; i < contadorEncuestas - 1; i++)
            {
                encuestas[i] = encuestas[i + 1];
            }
            contadorEncuestas--;
        }

        static string Respuesta(int valor)
        {
            switch (valor)
            {
                case 1:
                    return "Nada satisfecho";
                case 2:
                    return "No muy satisfecho";
                case 3:
                    return "Tolerable";
                case 4:
                    return "Satisfecho";
                case 5:
                    return "Muy satisfecho";
                default:
                    return "Desconocido";
            }
        }

        public static void OrdenarDatos()
        {
            int[] datosOrdenados = new int[contadorEncuestas];
            Array.Copy(encuestas, datosOrdenados, contadorEncuestas);

            Array.Sort(datosOrdenados);
            Array.Reverse(datosOrdenados);

            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Datos ordenados de mayor a menor");
            Console.WriteLine("================================");

            for (int i = 0; i < contadorEncuestas; i++)
            {
                Console.Write($"[{datosOrdenados[i]}] ");
                if ((i + 1) % 5 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine("\nPresione una tecla para regresar...");
            Console.ReadKey();
        }
    }
    internal class Operaciones
    {
        public static int getEntero(string prefijo, string reemplazo)
        {

            int respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = int.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.Clear();
                    Console.WriteLine(reemplazo);
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;

        }

        public static float getDecimal(string prefijo)
        {
            float respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = float.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;
        }

        public static string getTextoPantalla(string prefijo)
        {
            Console.Write(prefijo);
            return Console.ReadLine();
        }


        public static int getOpcion()
        {
            string opcionTexto = Console.ReadLine();
            return int.Parse(opcionTexto);
        }
    }
}

