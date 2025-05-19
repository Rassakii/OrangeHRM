using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Configration
{
    internal class ConfigurationManager
    {
        static readonly IConfiguration _configuration;
        static ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string BrowserName => GetConfigurationValue("Browser");
        public static string Url => GetConfigurationValue("BaseUrl");
        static string GetConfigurationValue(string key)
        {
            var value = _configuration[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"Configuration value for '{key}' is missing or empty.");
            }
            return value;
        }
    }
}
