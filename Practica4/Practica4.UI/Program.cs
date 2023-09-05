using Practica4.Entities;
using Practica4.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Practica 4: LINQ");
            bool toggleClose = false;
            do
            {
                int userChoice = PrintMenuReadChoice();
                switch (userChoice)
                {
                    case 0: toggleClose = true; continue;
                    case 1: Exercise1(); continue;
                    case 2: Exercise2(); continue;
                    case 3: Exercise3(); continue;
                    case 4: Exercise4(); continue;
                    case 5: Exercise5(); continue;
                    case 6: Exercise6(); continue;
                    case 7: Exercise7(); continue;
                    case 8: Exercise8(); continue;
                    case 9: Exercise9(); continue;
                    case 10: Exercise10(); continue;
                    case 11: Exercise11(); continue;
                    case 12: Exercise12(); continue;
                    case 13: Exercise13(); continue;
                    default:
                        Console.WriteLine("Seleccione un valor del 1 al 13.");
                        continue;
                }
            } while (!toggleClose);

        }
        public static void Exercise1()
        {
            Console.WriteLine("Query 1: Query para devolver objeto customer\n");
            CustomersLogic customersLogic = new CustomersLogic();
            // Lo pongo en una lista para poder reusar el metodo PrintCustomerList()
            List<Customers> customers = new List<Customers> { customersLogic.ReadFirst() };

            PrintCustomerList(customers, 0);
        }
        public static void Exercise2()
        {
            Console.WriteLine("Query 2: Query para devolver todos los productos sin stock\n");
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> productsWithoutStock = productsLogic.ProductsWithoutStock();

            PrintProductsList(productsWithoutStock);
        }
        public static void Exercise3()
        {
            Console.WriteLine("Query 3: Query para devolver todos los productos que tienen stock \n" +
                "y que cuestan más de 3 por ununidad\n");
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> productsWithStockAndPriceMoreThan3
                = productsLogic.ProductsWithStockAndPriceMoreThan3();

            PrintProductsList(productsWithStockAndPriceMoreThan3);
        }
        public static void Exercise4()
        {
            Console.WriteLine("Query 4: Query para devolver todos los customers de la Region WA\n");
            CustomersLogic customersLogic = new CustomersLogic();
            List<Customers> customers = customersLogic.ReadCustomersFromWA();

            PrintCustomerList(customers, 0);
        }
        public static void Exercise5()
        {
            Console.WriteLine("Query 5: Query para devolver el primer elemento o nulo de una lista de\n" +
                "productos donde el ID de producto sea igual a 789\n");
            CustomersLogic customersLogic = new CustomersLogic();

            List<Customers> customers = new List<Customers> { customersLogic.ReadId789FirstOrNull() };

            PrintCustomerList(customers, 0);
        }
        public static void Exercise6()
        {
            Console.WriteLine("Query 6: Query para devolver los nombre de los Customers. Mostrarlos en \n" +
                "Mayuscula y en Minuscula.\n");
            CustomersLogic customersLogic = new CustomersLogic();
            List<Customers> customers = customersLogic.ReadAll();

            PrintCustomerList(customers, 1);
        }
        public static void Exercise7()
        {
            Console.WriteLine("Query 7: Query para devolver Join entre Customers y Orders donde los\n" +
                "customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997\n");
            OrdersLogic ordersLogic = new OrdersLogic();
            List<Orders> joinCustomersOrders = ordersLogic.JoinCustomersRegionWAOrdersDateGreaterThan01011997();

            Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                "ID Cliente", "Nombre de contacto", "Region", "ID Orden", "Fecha de Orden");
            foreach (Orders order in joinCustomersOrders)
            {
                Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                    order.CustomerID, order.Customers.ContactName, order.Customers.Region,
                    order.OrderID, order.OrderDate);

            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Exercise8()
        {
            Console.WriteLine("Query 8: Query para devolver los primeros 3 Customers de la  Región WA\n");
            CustomersLogic customersLogic = new CustomersLogic();

            List<Customers> customers = customersLogic.ReadFirst3();

            PrintCustomerList(customers, 0);
        }
        public static void Exercise9()
        {
            Console.WriteLine("Query 9: Query para devolver lista de productos ordenados por nombre\n");
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> productsOrderByName = productsLogic.ProductsOrderByName();

            PrintProductsList(productsOrderByName);
        }
        public static void Exercise10()
        {
            Console.WriteLine("Query 10: Query para devolver lista de productos ordenados por unit " +
                "in stock de mayor a menor\n");
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> productsOrderByStockDesc = productsLogic.ProductsOrderByStockDesc();

            PrintProductsList(productsOrderByStockDesc);
        }
        public static void Exercise11()
        {
            Console.WriteLine("Query 11: Query para devolver las distintas categorías asociadas " +
                "a los productos\n");
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            List<Categories> categoriesInProducts = categoriesLogic.CategoriesInProducts();

            Console.WriteLine("{0,-15} {1,-25} {2,-15}",
                "ID Categoria", "Nombre de categoria", "Descripcion de categoria", "ID Orden", "Fecha de Orden");
            int descriptionMaxChar;
            foreach (Categories category in categoriesInProducts)
            {
                descriptionMaxChar = Math.Min(35, category.Description.Length);
                Console.WriteLine("{0,-15} {1,-25} {2,-35}",
                    category.CategoryID,
                    category.CategoryName,
                    category.Description.Substring(0, descriptionMaxChar));

            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Exercise12()
        {
            Console.WriteLine("Query 12: Query para devolver el primer elemento de una lista de productos\n");
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> firstProduct = productsLogic.ReadFirst();

            PrintProductsList(firstProduct);
        }
        public static void Exercise13()
        {
            Console.WriteLine("Query 13: Query para devolver los customer con la cantidad de ordenes asociadas\n");
            CustomersLogic customersLogic = new CustomersLogic();

            List<Customers> customers = customersLogic.ReadCostumersWithOrderCuantity();


            PrintCustomerList(customers, 2);
        }

        #region
        public static int PrintMenuReadChoice()
        {
            Console.WriteLine("Seleccione la query a ejecutar (1-13). 0 para salir.");
            int choice = -1;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Debe de ingresar un numero");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numero muy grande.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return choice;
        }
        public static void PrintCustomerList(List<Customers> customers, int type)
        {
            try
            {
                if (type == 0)
                {
                    Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                        "ID Cliente", "Compañia", "Region", "Ciudad", "Pais");
                }
                if (type == 1)
                {
                    Console.WriteLine("{0,-15} {1,-25} {2,-25} {3,-25} {4,-15}",
                        "ID Cliente", "Compañia", "Compañia Min", "Compañia May", "Pais");
                }
                if (type == 2)
                {
                    Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                                "ID Cliente", "Compañia", "Ciudad", "Pais", "Cantidad de ordenes");
                }
                int companyMaxChar;
                foreach (Customers customer in customers)
                {
                    if (customer != null)
                    {
                        companyMaxChar = Math.Min(25, customer.CompanyName.Length);
                        if (type == 0)
                        {
                            Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                                customer.CustomerID,
                                customer.CompanyName.Substring(0, companyMaxChar),
                                customer.Region,
                                customer.City,
                                customer.Country);
                            continue;
                        }
                        if (type == 1)
                        {
                            Console.WriteLine("{0,-15} {1,-25} {2,-25} {3,-25} {4,-15}",
                                customer.CustomerID,
                                customer.CompanyName.Substring(0, companyMaxChar),
                                customer.CompanyName.Substring(0, companyMaxChar).ToLower(),
                                customer.CompanyName.Substring(0, companyMaxChar).ToUpper(),
                                customer.Country);
                            continue;
                        }
                        if (type == 2)
                        {
                            companyMaxChar = Math.Min(25, customer.CompanyName.Length);
                            Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                                customer.CustomerID,
                                customer.CompanyName.Substring(0, companyMaxChar),
                                customer.City,
                                customer.Country,
                                customer.Orders.Count());
                            continue;
                        }
                    }
                    else { Console.WriteLine("NULL"); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void PrintProductsList(List<Products> products)
        {
            try
            {
                Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                    "ID Producto", "Nombre de producto", "Stock", "Precio", "ID de Categoria");
                int productMaxChar;
                foreach (Products product in products)
                {
                    if (product != null)
                    {
                        productMaxChar = Math.Min(25, product.ProductName.Length);
                        Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-15}",
                            product.ProductID, product.ProductName.Substring(0, productMaxChar), product.UnitsInStock, product.UnitPrice, product.CategoryID);
                    }
                    else { Console.WriteLine("NULL"); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion
    }
}
