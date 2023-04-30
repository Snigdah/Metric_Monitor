using Assigment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assigment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<Value> Value { get; set; }
    }
}
