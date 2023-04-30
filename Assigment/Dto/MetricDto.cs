namespace Assigment.Dto
{
    public class MetricDto
    {
        public string MatricName { get; set; }
        public ICollection<LabelDto> Labels { get; set; }
        public ICollection<ValueDto> Values { get; set; }
    }
}
