using Assigment.Data;
using Assigment.Interfaces;
using Assigment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.IConfiguration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
       // public IMetricRepository metricRepository { get; private set; }

        public IMetricRepository Metrics { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Metrics = new MetricRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //public async Task Dispose()
        //{
        //     await _context.DisposeAsync();
        //}
    }
}
