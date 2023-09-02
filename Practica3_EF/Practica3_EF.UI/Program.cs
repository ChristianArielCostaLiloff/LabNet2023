using Practica3_EF.Entities;
using Practica3_EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Practica 3");
            bool continueFlag = true;
            do
            {
                Console.WriteLine("Menu [Entidades: Customers y Suppliers]:");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Crear");
                Console.WriteLine("2 - Leer");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                int menuCrud = 0, submenuCrud = 0;
                try
                {
                    menuCrud = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    LogicExceptions.ExceptionMessage(ex);
                    continue;
                }

                switch (menuCrud)
                {
                    case 0:
                        {
                            continueFlag = false;
                            continue;
                        }
                    case 1:
                        {
                            Console.WriteLine("Crear:");
                            Console.WriteLine("0 - Retroceder");
                            Console.WriteLine("1 - Crear cliente");
                            Console.WriteLine("2 - Crear proveedor");
                            try
                            {
                                submenuCrud = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                LogicExceptions.ExceptionMessage(ex);
                            }

                            switch (submenuCrud)
                            {
                                case 0: continue;
                                case 1:
                                    {
                                        Console.WriteLine("Ingrese los datos necesarios para crear un cliente:");
                                        Console.WriteLine("ID del cliente");
                                        string customerID = Console.ReadLine();
                                        Console.WriteLine("Nombre de la empresa");
                                        string companyName = Console.ReadLine();

                                        IABMLogic<Customers> customersLogic = new CustomersLogic();
                                        customersLogic.CreateOne(new Customers { CustomerID = customerID, CompanyName = companyName });
                                        continue;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Ingrese los datos necesarios para crear un proveedor:");
                                        Console.WriteLine("Nombre de la empresa");
                                        string supplierName = Console.ReadLine();

                                        IABMLogic<Suppliers> suppliersLogic = new SuppliersLogic();
                                        suppliersLogic.CreateOne(new Suppliers { CompanyName = supplierName });
                                        continue;
                                    }
                                default:
                                    Console.WriteLine("Seleccione una opcion válida. Volviendo al menu principal.");
                                    continue;
                            }
                        }
                    case 2:
                        {
                            Console.WriteLine("Submenu leer:");
                            Console.WriteLine("0 - Retroceder");
                            Console.WriteLine("1 - Mostrar lista de clientes");
                            Console.WriteLine("2 - Mostrar lista de proveedores");
                            try
                            {
                                submenuCrud = int.Parse(Console.ReadLine());

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                LogicExceptions.ExceptionMessage(ex);
                            }

                            switch (submenuCrud)
                            {
                                case 0: continue;
                                case 1:
                                    {
                                        Console.WriteLine("Lista de clientes:");
                                        IABMLogic<Customers> customersLogic = new CustomersLogic();
                                        Console.WriteLine("ID \t Nombre Empresa");
                                        foreach (Customers customer in customersLogic.ReadAll())
                                        {
                                            Console.WriteLine($"{customer.CustomerID} -- {customer.CompanyName}");
                                        }
                                        continue;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Lista de proveedores:");
                                        IABMLogic<Suppliers> suppliersLogic = new SuppliersLogic();
                                        Console.WriteLine("ID \t Nombre Empresa");
                                        foreach (Suppliers supplier in suppliersLogic.ReadAll())
                                        {
                                            Console.WriteLine($"{supplier.SupplierID} -- {supplier.CompanyName}");
                                        }
                                        continue;
                                    }
                                default:
                                    Console.WriteLine("Seleccione una opcion válida. Volviendo al menu principal.");
                                    continue;
                            }
                        }
                    case 3:
                        {
                            Console.WriteLine("Submenu modificar:");
                            Console.WriteLine("0 - Retroceder");
                            Console.WriteLine("1 - Modificar cliente");
                            Console.WriteLine("2 - Modificar proveedor");
                            try
                            {
                                submenuCrud = int.Parse(Console.ReadLine());

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                LogicExceptions.ExceptionMessage(ex);
                            }
                            switch (submenuCrud)
                            {
                                case 0: continue;
                                case 1:
                                    {
                                        Console.WriteLine("Ingrese los datos necesarios para modificar un cliente:");
                                        Console.WriteLine("ID del cliente a modificar");
                                        string customerID = Console.ReadLine();
                                        Console.WriteLine("Nombre de la empresa modificado");
                                        string companyName = Console.ReadLine();

                                        IABMLogic<Customers> customersLogic = new CustomersLogic();
                                        var customerUpdated = customersLogic.UpdateOne(new Customers { CustomerID = customerID, CompanyName = companyName });

                                        Console.WriteLine("Modificacion introducida:");
                                        Console.WriteLine($"{customerUpdated.CustomerID} -- {customerUpdated.CompanyName}");
                                        continue;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Ingrese los datos necesarios para modificar un proveedor:");
                                        Console.WriteLine("ID del proveedor a modificar");
                                        int supplierID = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Nombre de la empresa modificado");
                                        string supplierName = Console.ReadLine();

                                        IABMLogic<Suppliers> suppliersLogic = new SuppliersLogic();
                                        var supplierUpdated = suppliersLogic.UpdateOne(new Suppliers { SupplierID = supplierID, CompanyName = supplierName });

                                        Console.WriteLine("Proveedor modificado:");
                                        Console.WriteLine($"{supplierUpdated.SupplierID} -- {supplierUpdated.CompanyName}");
                                        continue;
                                    }
                                default:
                                    Console.WriteLine("Seleccione una opcion válida. Volviendo al menu principal.");
                                    continue;
                            }
                        }
                    case 4:
                        {
                            Console.WriteLine("Submenu eliminar:");
                            Console.WriteLine("0 - Retroceder");
                            Console.WriteLine("1 - Eliminar un cliente");
                            Console.WriteLine("2 - Eliminar un proveedor");
                            try
                            {
                                submenuCrud = int.Parse(Console.ReadLine());

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                LogicExceptions.ExceptionMessage(ex);
                            }

                            switch (submenuCrud)
                            {
                                case 0: continue;
                                case 1:
                                    {
                                        Console.WriteLine("ID del cliente a eliminar");
                                        string customerID = Console.ReadLine();

                                        IABMLogic<Customers> customersLogic = new CustomersLogic();
                                        var customerDeleted = customersLogic.DeleteOne(new Customers { CustomerID = customerID });
                                        Console.WriteLine("Cliente eliminado:");
                                        Console.WriteLine($"{customerDeleted.CustomerID} -- {customerDeleted.CompanyName}");
                                        continue;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("ID del proveedor a eliminar");
                                        int supplierID = int.Parse(Console.ReadLine());

                                        IABMLogic<Suppliers> suppliersLogic = new SuppliersLogic();
                                        var suppliersDeleted = suppliersLogic.DeleteOne(new Suppliers { SupplierID = supplierID });
                                        Console.WriteLine("Proveedor eliminado:");
                                        Console.WriteLine($"{suppliersDeleted.SupplierID} -- {suppliersDeleted.CompanyName}");
                                        continue;
                                    }
                                default:
                                    Console.WriteLine("Seleccione una opcion válida. Volviendo al menu principal.");
                                    continue;
                            }
                        }
                    default:
                        Console.WriteLine("Seleccione una opcion válida.");
                        continue;
                }
            } while (continueFlag);
        }
    }
}
