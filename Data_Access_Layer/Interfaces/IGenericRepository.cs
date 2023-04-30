using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        ICollection<T> GetAll();
        T GetByName(string name);
        bool MatricNameExists(string name);
        bool CreateMetric(T payload);
        bool Save();
        int GetAggregation(string name, string query);
    }
}
