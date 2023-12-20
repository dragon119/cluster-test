using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Confluent.Kafka;
using System;
using Microsoft.Extensions.Configuration;

namespace testapp.Controllers;

 [ApiController]
    [Route("[controller]")]
    public class WeatherForecastMsgController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastMsgController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastMsg")]
        public async Task<string> Get()
        {

                string topic = Environment.GetEnvironmentVariable("KAFKA_TOPIC");

                var config = new ProducerConfig
                {
                        BootstrapServers = Environment.GetEnvironmentVariable("KAFKA_BOOTSTRAP_SERVER"),
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                        var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value="a message" });
                }

                return "Successfully sent messages to Kafka topic";
        }
}
