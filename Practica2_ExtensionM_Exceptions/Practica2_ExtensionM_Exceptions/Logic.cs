using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionM_Exceptions
{
    public class Logic 
    {
        public static void Ejercicio3Exepcion()
        {
            throw new ArithmeticException();
        }
        public static void Ejercicio4Exepcion()
        {
            throw new CustomExeption();
        }

    }
}
