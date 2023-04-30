using Assigment.Dto;
using Assigment.Models;
using MediatR;

namespace Assigment.Queries
{
    public record GetAllMetricQuery() : IRequest<ICollection<Metric>>;
}
        