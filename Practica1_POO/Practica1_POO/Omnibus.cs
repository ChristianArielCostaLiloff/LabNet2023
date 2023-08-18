using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int cantidadPasajeros) : base( cantidadPasajeros) { }

        public override string Avanzar()
        {
            return string.Format("Omnibus avanzando con {0} pasajeros", CantidadPasajeros());
        }
        public override string Detenerse()
        {
            return string.Format("Omnibus deteniendose con {0} pasajeros", CantidadPasajeros());
        }
    }
}
