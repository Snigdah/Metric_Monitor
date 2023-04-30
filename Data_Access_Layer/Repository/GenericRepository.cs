using Assigment.Data;
using Data_Access_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
   
        private readonly DataContext _context;
        public readonly DbSet<T> _db;
        public GenericRepository(DataContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public bool MatricNameExists(string name)
        {
            return _context.Metrics.Any(x => x.MatricName == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool CreateMetric(T payload)
        {
            _db.Add(payload);

               return Save();
        }

        public int GetAggregation(string name, string query)
        {
            var x = _context.Metrics.Where(i => i.MatricName == name).Include(e => e.Values).Include(e => e.Labels).FirstOrDefault();

            if (query == "max")
            {
                return x.Values.Max(i => i.Val);
            }
            else if (query == "min")
            {
                return x.Values.Min(i => i.Val);
            }
            else
            {
                return x.Values.Sum(i => i.Val);
            }
        }


        public T GetByName(string name)
        {
            var x = _context.Metrics.OrderBy(x => x.MatricName).Include(e => e.Values).Include(e => e.Labels).FirstOrDefault();
            // return x;
            return null;
        }

    }
}
