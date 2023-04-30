using Assigment.Data;
using Assigment.Interfaces;
using Assigment.Models;
using Data_Access_Layer.Repository;
using Microsoft.EntityFrameworkCore;


namespace Assigment.Repository
{
    public class MetricRepository : GenericRepository<Metric>, IMetricRepository
    {
       
        public MetricRepository(DataContext context) : base(context)
        {
            
        }


        public ICollection<Metric> GetMetric()
        {
        
                return _db.OrderBy(p => p.Id).Include(e => e.Labels).Include(e => e.Values).ToList();

            
        }

        public Metric GetMetricByName(string name)
        {
            var x = _db.Where(i => i.MatricName == name).Include(e => e.Values).Include(e => e.Labels).FirstOrDefault();
            var y = x.Values.Min(i => i.Val);
            return x;
        }

    }
}
