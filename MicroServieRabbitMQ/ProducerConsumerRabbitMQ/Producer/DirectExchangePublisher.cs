using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Producer
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl",3000}
            };
            channel.ExchangeDeclare("demo-direct-exchange-2",ExchangeType.Direct,arguments:ttl);
            int count = 0;
            while (true)
            {
                string message = String.Format(".Net Core started with RabbitMQ, demo-direct-exchange-2 exchange account-init Count {0} ",count);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("demo-direct-exchange-2", "account.init-2", null, body);
                count++;
                Console.WriteLine("Sent message {0}...", message);
                Thread.Sleep(1000);
            }
        }
    }
}