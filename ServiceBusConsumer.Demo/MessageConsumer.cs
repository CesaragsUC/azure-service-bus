using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusConsumer.Demo
{
    public class MessageConsumerHandler
    {
        async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");
            await args.CompleteMessageAsync(args.Message);
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hoube um erro: {args.Exception.Message}");
            return Task.CompletedTask;
        }

        public async Task ReceiveMessages(string connectionString, string queueName)
        {
            var client = new ServiceBusClient(connectionString);
            ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Pressione qualquer tecla para encerrar a processamento da fila.");
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Encerrando processamento...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Processamento encerrado.");
                
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao consumir a menssagem: {ex.Message}");
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();

            }
        }

        public async Task ReceiveMessagesFromTopic(string connectionString, string topicName, string subscriberName)
        {
            var client = new ServiceBusClient(connectionString);
            ServiceBusProcessor processor = client.CreateProcessor(topicName, subscriberName, new ServiceBusProcessorOptions());

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Pressione qualquer tecla para encerrar a processamento do topico.");
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Encerrando processamento...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Processamento encerrado.");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao consumir a menssagem: {ex.Message}");
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();

            }
        }
    }
}
