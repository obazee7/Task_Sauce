
using Microsoft.Extensions.Configuration;

namespace Task_Sauce.Support
{
    public class readFromConfig
    {
        private IConfigurationRoot _config;
        public readFromConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            _config = builder.Build();
        }

        public string GetConfigData(string key) => _config[key]!;
    }
}
