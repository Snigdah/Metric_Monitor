using Assigment.Data;
using Assigment.Dto;
using Assigment.Interfaces;
using Assigment.Models;
using Assigment.Queries;
using AutoMapper;
using Business_Logic_Layer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Dto;

namespace Assigment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMetricBLL _metricBLL;

        public MetricController( IMapper mapper, IMediator mediator, IMetricBLL metricBLL)
        {

            _mapper = mapper;
            _mediator = mediator;
            _metricBLL = metricBLL;
        }


        //BY Using Repository Pattern GellAllMetrics

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Metric>))]
        //[ProducesResponseType(400)]
        //public async Task<ICollection<Metric>> Getmetrics()
        //{
        //    return _mapper.Map<ICollection<Metric>>(_metricBLL.GetMetric());

        //    //var pokemon = _mapper.Map<ICollection<Metric>>(_MetricRepository.GetMetric());
        //    // var pokemon = _MetricRepository.GetMetric();
        //    //if (!ModelState.IsValid)
        //    //return BadRequest(ModelState);

        //}


        //BY Using Mediator Design Pattern GetAllMetrics

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Metric>))]
        [ProducesResponseType(400)]
        public async Task<ICollection<Metric>> GetAllMetrics()
        {
            return await _mediator.Send(new GetAllMetricQuery());
        }





        //By Using Mediator Pattern GetMetricByName

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Metric>))]
        [ProducesResponseType(400)]
        public async Task<Metric> GetMetricByName(string name)
        {
            if (!_metricBLL.MatricNameExists(name))
                return null;

            return await _mediator.Send(new GetMetricByNameQuery(name));
        }





        //By Using Mediator Pattern Using Aggregation

        [HttpGet("{metricName}/{query}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<int> GetAgregation(string metricName, string query)
        {
            return await _mediator.Send(new GetAggregationQuery(metricName, query));
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMetric(MetricDto payload)
        {

            var val = new List<Value>();

            foreach (var valuee in payload.Values)
            {
                Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                var v = new Value()
                {
                    Val = valuee.Val,
                    Time = unixTimestamp
                };

                val.Add(v);
            }

            var lab = new List<Label>();

            foreach (var label in payload.Labels)
            {
                var x = new Label()
                {
                    Key = label.Key,
                    Value = label.Value
                };
                lab.Add(x);
            }


            var finalPayload = new Metric()
            {
                MatricName = payload.MatricName,
                Values = val,
                Labels = lab
            };

            if (!_metricBLL.CreateMetric(finalPayload))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }


    }
}
