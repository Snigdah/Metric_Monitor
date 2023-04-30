using Assigment.Dto;
using Assigment.Models;
using AutoMapper;

namespace Assigment.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Metric, MetricDto>();
            CreateMap<Label, LabelDto>();
            CreateMap<Value, ValueDto>();

            CreateMap<Metric, GetMetricDto>();
            CreateMap<Label, GetLabelDto>();
            CreateMap<Value, GetValueDto>();
        }
    }
}
