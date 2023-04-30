using MediatR;

namespace Assigment.Queries
{
    public record GetAggregationQuery : IRequest<int>
    {
        public string MetricName { get;}
        public string Query { get;}

        public GetAggregationQuery(string metricName, string query)
        {
            MetricName = metricName;
            Query = query;
        }
    }
}
