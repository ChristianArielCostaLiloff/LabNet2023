using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practica3_EF.Logic
{
    public interface IABMLogic<T>
    {
        void CreateOne(T entity);
        T UpdateOne(T entity);
        List<T> ReadAll();
        T DeleteOne(T entity);
    }
}
