using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Domain;
using Todo.Domain.Common;

namespace Todo.Infrastructure.Data
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private List<T> _data = new List<T>();

        public void Delete(T entity)
        {
             _data.Remove(entity);
        }

        public T Get(long id)
        {
            return _data.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public void Insert(T entity)
        {
            _data.Add(entity);
        }

        public void Update(T entity)
        {
            var origin = _data.FirstOrDefault(e => e.Id == entity.Id);

            _ = _data.Remove(origin);
            _data.Add(entity);
        }
    }
}
