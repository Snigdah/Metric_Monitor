using Assigment.Models;
using Data_Access_Layer.Interfaces;

namespace Assigment.Interfaces
{
    public interface IMetricRepository : IGenericRepository<Metric>
    {
        ICollection<Metric> GetMetric();
        Metric GetMetricByName(string name);

        
    }
}
