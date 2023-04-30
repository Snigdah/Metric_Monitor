using Assigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IMetricBLL
    {
        ICollection<Metric> GetMetric();
        Metric GetMetricByName(string name);
        bool MatricNameExists(string name);
        bool CreateMetric(Metric payload);
        int GetAggregation(string name, string query);

    }
}
