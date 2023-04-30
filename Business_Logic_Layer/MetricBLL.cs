using Assigment.Interfaces;
using Assigment.Models;
using Data_Access_Layer.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace Business_Logic_Layer
{
    public class MetricBLL : IMetricBLL
    {
        private readonly IMetricRepository _MetricRepository;
        private readonly IUnitOfWork _unitOfWork;
   
        public MetricBLL(IMetricRepository MetricRepository, IUnitOfWork unitOfWork)
        {
            _MetricRepository = MetricRepository;
            _unitOfWork = unitOfWork;
        }

        public bool CreateMetric(Metric payload)
        {
            return _unitOfWork.Metrics.CreateMetric(payload);
        }

        public int GetAggregation(string name, string query)
        {
            return _unitOfWork.Metrics.GetAggregation(name, query);
        }

        public ICollection<Metric> GetMetric()
        {
            return _unitOfWork.Metrics.GetMetric();
        }

        public Metric GetMetricByName(string name)
        {
            return _unitOfWork.Metrics.GetMetricByName(name);
        }

        public bool MatricNameExists(string name)
        {
            return _unitOfWork.Metrics.MatricNameExists(name);
        }

    }
}