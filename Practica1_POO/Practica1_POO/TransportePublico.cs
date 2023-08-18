using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public abstract class TransportePublico
    {
        // Personalmente usaría el modificador de acceso protected ahorrando la funcion CantidadPasajeros()
        private int _cantidadPasajeros;

        public TransportePublico(int cantidadPasajeros)
        {
            _cantidadPasajeros = cantidadPasajeros;
        }

        public int CantidadPasajeros()
        {
            return _cantidadPasajeros;
        }
        public virtual string Avanzar()
        {
            return string.Format("Transporte publico avanzando con {0} pasajeros", _cantidadPasajeros);
        }

        public virtual string Detenerse()
        {
            return string.Format("Transporte publico deteniendose con {0} pasajeros", _cantidadPasajeros);
        }
    }
}
