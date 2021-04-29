using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Producer2
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("tubaTest",ExchangeType.Direct);
            int count = 0;
            while (true)
            {
                string message = String.Format(".Net Core started with RabbitMQ, tubaTest Exchange account-init Count {0} ",count);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("tubaTest", "account.init-2", null, body);
                count++;
                Console.WriteLine("Sent message {0}...", message);
                Thread.Sleep(1000);
            }
        }
    }
}