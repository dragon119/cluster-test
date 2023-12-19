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
    
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastMsg")]
        public async Task<string> Get()
        {

             IConfiguration configuration = new ConfigurationBuilder()
            .AddIniFile(args[0])
            .Build();

        const string topic = "purchases";

        string[] users = { "eabara", "jsmith", "sgarcia", "jbernard", "htanaka", "awalther" };
        string[] items = { "book", "alarm clock", "t-shirts", "gift card", "batteries" };

        using (var producer = new ProducerBuilder<string, string>(
            configuration.AsEnumerable()).Build())
        {
            var numProduced = 0;
            Random rnd = new Random();
            const int numMessages = 10;
            for (int i = 0; i < numMessages; ++i)
            {
                var user = users[rnd.Next(users.Length)];
                var item = items[rnd.Next(items.Length)];

                producer.Produce(topic, new Message<string, string> { Key = user, Value = item },
                    (deliveryReport) =>
                    {
                        if (deliveryReport.Error.Code != ErrorCode.NoError) {
                            return ErrorCode.ToString();
                        }
                        else {
                            Console.WriteLine($"Produced event to topic {topic}: key = {user,-10} value = {item}");
                            numProduced += 1;
                        }

                    });
            }

            producer.Flush(TimeSpan.FromSeconds(10));
        }   return "Successfully sent messages to purchases"
        }
