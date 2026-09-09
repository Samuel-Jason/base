using ConsoleApp1.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

internal static class KafkaDemoProgram
{
    static async Task Main()
    {
        const string bootstrap = "localhost:9092";
        const string topic = "test-topic";

        var producer = new ProducerService(bootstrap);
        var consumer = new ConsumerService(bootstrap, "demo-group");

        using var cts = new CancellationTokenSource();
        var consumerTask = consumer.StartConsumingAsync(topic, cts.Token);

        // Produz algumas mensagens
        for (int i = 0; i < 5; i++)
        {
            await producer.ProduceAsync(topic, $"key-{i}", $"mensagem-{i}");
            await Task.Delay(200);
        }

        // aguarde consumo
        await Task.Delay(2000);
        cts.Cancel();
        await consumerTask;
    }
}