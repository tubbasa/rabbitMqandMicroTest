using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    public class DirectExchangeReceiver
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-direct-exchange-2", ExchangeType.Direct);
          //  var queueName=channel.QueueDeclare().QueueName;
            channel.QueueBind("BasicTest", "demo-direct-exchange-2", "account.init-2");
            channel.BasicQos(0,10,false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Received message {0}... {1}", message,ea.Exchange);
            };
            channel.BasicConsume("BasicTest", true, consumer);
            Console.WriteLine("Consumer started..");
        }
    }
}