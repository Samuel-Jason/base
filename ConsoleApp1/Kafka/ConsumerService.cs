using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Kafka
{
    public class ConsumerService
    {
        private readonly ConsumerConfig _config;
        public ConsumerService(string bootstrapServers, string groupId)
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public Task StartConsumingAsync(string topic, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                using var consumer = new ConsumerBuilder<string, string>(_config).Build();
                consumer.Subscribe(topic);
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var cr = consumer.Consume(cancellationToken);
                        Console.WriteLine($"Consuming: key={cr.Message.Key} value={cr.Message.Value} partition={cr.Partition} offset={cr.Offset}");
                        // processar mensagem...
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    consumer.Close();
                }
            }, cancellationToken);
        }
    }
}