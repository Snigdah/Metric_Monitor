using Assigment.Dto;
using Assigment.Interfaces;
using Assigment.Models;
using Assigment.Queries;
using Business_Logic_Layer;
using MediatR;

namespace Assigment.Handlers
{
    public class GetAllMetricHandler : IRequestHandler<GetAllMetricQuery, ICollection<Metric>>
    {
        private readonly IMetricBLL _metricBLL;
        public GetAllMetricHandler(IMetricBLL metricBLL)
        {
            _metricBLL = metricBLL;
        }

        public Task<ICollection<Metric>> Handle(GetAllMetricQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_metricBLL.GetMetric());
        }
    }
}
