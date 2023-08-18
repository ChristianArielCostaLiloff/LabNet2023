using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> ListaTaxi = ListaVehiculos("taxi");
            List<TransportePublico> ListaOmnibus = ListaVehiculos("omnibus");
            MostrarListaVehiculos(ListaTaxi, "taxi");
            MostrarListaVehiculos(ListaOmnibus, "omnibus");

            Console.WriteLine("---------------------");
            Console.ReadLine();
        }
        public static List<TransportePublico> ListaVehiculos(string tipoVehiculo)
        {
            List<TransportePublico> ListaVehiculos = new List<TransportePublico>();
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine("Ingrese la cantidad de pasajeros de {0} {1}:", tipoVehiculo, i + 1);
                bool positivo = int.TryParse(Console.ReadLine(), out int cantidadPersonas);

                if (positivo && cantidadPersonas >= 0)
                {
                    i++;
                    if (tipoVehiculo.Equals("omnibus", StringComparison.OrdinalIgnoreCase))
                    {
                        ListaVehiculos.Add(new Omnibus(cantidadPersonas));
                        continue;
                    }
                    if (tipoVehiculo.Equals("taxi", StringComparison.OrdinalIgnoreCase))
                    {
                        ListaVehiculos.Add(new Taxi(cantidadPersonas));
                        continue;
                    }
                    Console.WriteLine("Error en tipo de vehículo.");
                }
                else
                {
                    Console.WriteLine("El número no puede ser menor a 0.");
                }
            }
            return ListaVehiculos;
        }
        public static void MostrarListaVehiculos(List<TransportePublico> ListaVehiculos, string tipoVehiculo)
        {
            Console.WriteLine("---------------------");
            foreach (var item in ListaVehiculos.Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{tipoVehiculo} {item.i + 1}: {item.value.CantidadPasajeros()} pasajeros.");

            }
        }
    }
}
