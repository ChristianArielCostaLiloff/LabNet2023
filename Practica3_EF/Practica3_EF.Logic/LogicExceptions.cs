using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_EF.Logic
{
    public class LogicExceptions
    {
        public static void NullReferenceExceptionMessage(NullReferenceException ex)
        {
            Console.WriteLine("Mensaje de la excepcion:");
            Console.WriteLine(ex.Message);
        }
        public static void DbUpdateExceptionMessage(DbUpdateException ex)
        {
            Console.WriteLine("Mensaje de la excepcion:");
            Console.WriteLine(ex.Message);
        }
        public static void DbEntityValidationExceptionMessage(DbEntityValidationException ex)
        {
            foreach (var collectionEntities in ex.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    collectionEntities.Entry.Entity.GetType().Name, collectionEntities.Entry.State);

                foreach (var entity in collectionEntities.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        entity.PropertyName, entity.ErrorMessage);
                }
            }
        }
        public static void ExceptionMessage(Exception ex)
        {
            Console.WriteLine("Mensaje de la excepcion:");
            Console.WriteLine(ex.Message);

            Console.WriteLine("StackTrace de la excepcion:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
