using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using testapp.Models;

namespace testapp.Controllers;

    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastDbController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastDbController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastDb")]
        //public WeatherForecast Get()
        public async Task<string> Get()
        {
            // var configuration = new ConfigurationBuilder()
            //     .AddEnvironmentVariables()
            //     .Build();
            //var hostname = configuration.GetSection("host").Value;

            string forecast = "No DB access";
            //var connectionString = "Host=127.0.0.1;Username=postgres;Password=bubble7;Database=postgres";
            var connectionString = Environment.GetEnvironmentVariable("DB_CONN_STRING");
            
            var dataSource = NpgsqlDataSource.Create(connectionString);   
            var cmd = dataSource.CreateCommand("SELECT datname from pg_database");
            await using(var reader =  await cmd.ExecuteReaderAsync())
            {
            while (await reader.ReadAsync())
                forecast += reader.GetString(0);
            }
            return forecast;
            // WeatherForecastContext db = new WeatherForecastContext();
            
            // return db.weatherforecast.SingleOrDefault(w => w.id == 1);  
        }
    }
