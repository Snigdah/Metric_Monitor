using System.ComponentModel.DataAnnotations;

namespace Assigment.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Metric Metric { get; set; }
    }
}
