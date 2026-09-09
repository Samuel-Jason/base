using Confluent.Kafka;
using System.Threading.Tasks;

namespace ConsoleApp1.Kafka
{
    public class ProducerService
    {
        private readonly ProducerConfig _config;
        public ProducerService(string bootstrapServers)
        {
            _config = new ProducerConfig { BootstrapServers = bootstrapServers };
        }

        public async Task ProduceAsync(string topic, string key, string value)
        {
            using var producer = new ProducerBuilder<string, string>(_config).Build();
            var msg = new Message<string, string> { Key = key, Value = value };
            var result = await producer.ProduceAsync(topic, msg);
            // opcional: tratar result.Status / Logging
        }
    }
}