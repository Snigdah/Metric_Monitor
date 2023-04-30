using Assigment.Interfaces;
using Assigment.Queries;
using Business_Logic_Layer;
using MediatR;

namespace Assigment.Handlers
{
    public class GetAggregationHandler : IRequestHandler<GetAggregationQuery, int>
    {
        private readonly IMetricBLL _metricBLL;
        public GetAggregationHandler(IMetricBLL metricBLL)
        {
            _metricBLL = metricBLL;
        }

        public Task<int> Handle(GetAggregationQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_metricBLL.GetAggregation(request.MetricName, request.Query));

        }
    }
}
