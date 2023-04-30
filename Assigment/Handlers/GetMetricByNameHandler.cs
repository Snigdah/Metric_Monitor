using Assigment.Interfaces;
using Assigment.Models;
using Assigment.Queries;
using Business_Logic_Layer;
using MediatR;

namespace Assigment.Handlers
{
    public class GetMetricByNameHandler : IRequestHandler<GetMetricByNameQuery, Metric>
    {
        private readonly IMetricBLL _metricBLL;
        public GetMetricByNameHandler(IMetricBLL metricBLL)
        {
            _metricBLL = metricBLL;
        }


        Task<Metric> IRequestHandler<GetMetricByNameQuery, Metric>.Handle(GetMetricByNameQuery request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_metricBLL.GetMetricByName(request.Name));
            
        }
    }
}
