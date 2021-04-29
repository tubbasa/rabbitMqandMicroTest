using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Producer
{
    public class QueueSender
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("BasicTest", false, false, false, null);
            //channel.ExchangeDeclare();

            int count = 0;
            while (true)
            {
                string message = String.Format(".Net Core started with RabbitMQ. Count {0} ",count);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasicTest", null, body);
                count++;
                Console.WriteLine("Sent message {0}...", message);
                Thread.Sleep(1000);
            }
        }
    }
}