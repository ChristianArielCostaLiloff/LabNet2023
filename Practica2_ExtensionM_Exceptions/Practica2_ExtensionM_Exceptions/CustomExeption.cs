using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionM_Exceptions
{
    public class CustomExeption : Exception
    {
        public CustomExeption() : base("¡Esto es una excepcion personalizada!") { }
    }
}
