using System.ComponentModel.DataAnnotations;

namespace Assigment.Models
{
    public class Metric
    {
        [Key]
        public int Id { get; set; }
        public string MatricName { get; set; }
        public ICollection<Label> Labels { get; set; }
        public ICollection<Value> Values { get; set; }
    }
}
