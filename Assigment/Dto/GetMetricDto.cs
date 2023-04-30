namespace Assigment.Dto
{
    public class GetMetricDto
    {
        public string MatricName { get; set; }
        public ICollection<GetLabelDto> Labels { get; set; }
        public ICollection<GetValueDto> Values { get; set; }
    }
}
