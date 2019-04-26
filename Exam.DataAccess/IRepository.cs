using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DataAccess
{
    public interface IRepository<T> : IDisposable
    {
        ICollection<T> Select();
        void Insert(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
