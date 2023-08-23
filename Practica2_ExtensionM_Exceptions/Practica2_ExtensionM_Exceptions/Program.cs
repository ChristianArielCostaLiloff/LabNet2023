using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_ExtensionM_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercice1();
            Exercice2();
            Exercice3();
            Exercice4();
            Console.WriteLine("Enter para finalizar");
            Console.ReadLine();
        }
        public static void Exercice1()
        {
            try
            {
                Console.WriteLine("Ejercicio 1: Division por 0");
                Console.WriteLine("Escriba un numero:");
                int numero = int.Parse(Console.ReadLine());
                numero /= 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mensaje de la excepcion:");
                Console.WriteLine(ex.Message);

                Console.WriteLine("StackTrace de la excepcion:");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Se termino la operacion del ejercicio 1.");
                Console.WriteLine("----------------------------------");
            }

        }
        public static void Exercice2()
        {
            try
            {
                // Utilizo int porque al usar float, double o decimal la division por 0 es infinita, lo que no salta la excepcion DivideByZeroException
                Console.WriteLine("Ejercicio 2: Dividendo y divisor");
                Console.WriteLine("Escriba el dividendo:");
                int dividendo = int.Parse(Console.ReadLine());

                Console.WriteLine("Escriba el divisor:");
                int divisor = int.Parse(Console.ReadLine());

                int resulado = dividendo / divisor;
                Console.WriteLine($"El resultado es: {resulado}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException)
            {
                Console.WriteLine("¡Seguro ingreso una letra o no ingreso nada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mensaje de la excepcion:");
                Console.WriteLine(ex.Message);

                Console.WriteLine("StackTrace de la excepcion:");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Se termino la operacion del ejercicio 2.");
                Console.WriteLine("----------------------------------");
            }

        }
        public static void Exercice3()
        {
            try
            {
                Console.WriteLine("Ejercicio 3: Llamade de exepcion");
                Logic.Ejercicio3Exepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mensaje de la excepcion:");
                Console.WriteLine(ex.Message);

                Console.WriteLine("StackTrace de la excepcion:");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Se termino la operacion del ejercicio 3.");
                Console.WriteLine("----------------------------------");
            }
        }
        public static void Exercice4()
        {
            try
            {
                Console.WriteLine("Ejercicio 4: Llamade de exepcion personalizada");
                Logic.Ejercicio4Exepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mensaje de la excepcion:");
                Console.WriteLine(ex.Message);

                Console.WriteLine("StackTrace de la excepcion:");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Se termino la operacion del ejercicio 4.");
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
