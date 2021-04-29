using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    public static class QueueReceiver
    {
        public static void Consume(IModel channel)
        {
            channel.QueueDeclare("BasicTest",false,false,false,null);
          
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Received message {0}...", message);
            };
            channel.BasicConsume("BasicTest", true, consumer);
            Console.WriteLine("Consumer started..");

        }
    }
}