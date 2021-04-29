﻿using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer2
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Tuba-Queue2",false,false,false,null);
                //channel.ExchangeDeclare();
                string message = ".Net Core started with RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);
                DirectExchangePublisher.Publish(channel);
                // channel.BasicPublish("","BasicTest",null,body);
                Console.WriteLine("Sent message {0}...",message);
            }
            
            Console.WriteLine("Press [Enter] to exit..");
            Console.ReadLine();
        }
    }
}