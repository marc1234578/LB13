using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB13
{
        internal class Program
        {
            static void Main(string[] args)
            {
                int opcion;

                do
                {
                    Console.Clear();
                    opcion = Pantalla.PantallaPrincipal();

                    switch (opcion)
                    {
                        case 1:
                            Pantalla.Satisfaccion();
                            break;
                        case 2:
                            Pantalla.VerDatosRegistrados();
                            break;
                        case 3:
                            Pantalla.EliminarDato();
                            break;
                        case 4:
                            Pantalla.OrdenarDatos();
                            break;
                        case 5:
                            break;
                    }
                } while (opcion != 5);
            }
        }
}

    

