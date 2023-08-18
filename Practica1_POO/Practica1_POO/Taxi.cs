using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public class Taxi : TransportePublico
    {
        public Taxi(int cantidadPasajeros) : base(cantidadPasajeros) { }
        public override string Avanzar()
        {
            return string.Format("Taxi avanzando con {0} pasajeros", CantidadPasajeros());
        }
        public override string Detenerse()
        {
            return string.Format("Taxi deteniendose con {0} pasajeros", CantidadPasajeros());
        }
    }
}
