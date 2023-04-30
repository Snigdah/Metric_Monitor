using Assigment.Models;
using MediatR;

namespace Assigment.Queries
{
    public class GetMetricByNameQuery : IRequest<Metric>
    {
        public string Name { get;}
        public GetMetricByNameQuery(string name)
        {
            Name = name;
        }
    }
}
