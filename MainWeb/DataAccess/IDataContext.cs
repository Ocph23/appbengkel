using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWeb.DataAccess
{
    public interface IDataContext<T>
    {
        IEnumerable<T> Get();

        T GetById(int Id);
        T Insert(T item);

        T Update(T item);

        bool Delete(int Id);



    }
}
