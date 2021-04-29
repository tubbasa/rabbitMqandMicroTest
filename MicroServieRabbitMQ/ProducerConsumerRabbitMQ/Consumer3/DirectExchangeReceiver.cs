using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer3
{
    public class DirectExchangeReceiver
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("tubaTest", ExchangeType.Direct);
          //  var queueName=channel.QueueDeclare().QueueName;
            channel.QueueBind("Tuba-Queue", "tubaTest", "account.init-2");
            channel.BasicQos(0,10,false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Received message {0}... {1}", message,ea.Exchange);
            };
            channel.BasicConsume("Tuba-Queue", true, consumer);
            Console.WriteLine("Consumer started..");
        }
    }
}