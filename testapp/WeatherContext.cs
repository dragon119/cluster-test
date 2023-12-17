using System;
 using Npgsql;
 using Microsoft.EntityFrameworkCore;
 using testapp.Models;
 using System.Collections.Generic;

 namespace testapp;

 public class WeatherForecastContext : DbContext
    {
        public int maxretry = 3;
        public TimeSpan interval = TimeSpan.FromMilliseconds(500);
         private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "Weather";
        private static string Password = "bubble7";
        private static string Port = "5432";

        public DbSet<WeatherForecast> weatherforecast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(
                    String.Format(
                        "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                        Host,
                        User,
                        DBname,
                        Port,
                        Password),
            options => options.EnableRetryOnFailure(maxretry,interval,null));
    }
