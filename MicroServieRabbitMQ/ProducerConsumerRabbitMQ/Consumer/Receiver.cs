﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    public class Receiver
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            DirectExchangeReceiver.Consume(channel);
            
            // channel.QueueDeclare("BasicTest",false,false,false,null);
            //
            //     var consumer = new EventingBasicConsumer(channel);
            //     consumer.Received += (ch, ea) =>
            //     {
            //         var body = ea.Body.ToArray();
            //         var message = Encoding.UTF8.GetString(body);
            //         Console.WriteLine("Received message {0}...", message);
            //     };
            //     
            //     channel.BasicConsume("BasicTest", true, consumer);
            //
            Console.WriteLine("Press [Enter] to exitt..");
            Console.ReadLine();
        }
    }
}