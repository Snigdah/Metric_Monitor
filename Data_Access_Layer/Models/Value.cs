using System.ComponentModel.DataAnnotations;

namespace Assigment.Models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public int Val { get; set; }
        public Int32 Time { get; set; }
        public Metric Metric { get; set; }

    }
}
