using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace ServiceBus.Sender
{
    public class MessageSender
    {
        public async Task SendMessage(string connectionString, string queue_name, int numberOfMsg)
        {
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queue_name);

            using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

            for (int i = 0; i < numberOfMsg; i++)
            {
                if (!batch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes($"Message {i}"))))
                    Console.WriteLine($"The message {i} is too large to fit in the batch.");
            }

            try
            {
                await sender.SendMessagesAsync(batch);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mensagem foi enviada para fila: {queue_name}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Falha ao enviar a mensagem: {ex.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
                Console.ResetColor();
            }

        }

        public async Task SendMessage<T>(T obj,string connectionString, string queue_name, int numberOfMsg) where T : class
        {
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queue_name);

            using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

            for (int i = 0; i < numberOfMsg; i++)
            {
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)));

                if (!batch.TryAddMessage(message))
                    Console.WriteLine($"A mensagem {i} é muito grande para caber no lote.");
            }

            try
            {
                await sender.SendMessagesAsync(batch);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mensagem enviada para a fila: {queue_name}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Houve uma falha ao enviar a messagem: {ex.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
                Console.ResetColor();
            }

        }

        public async Task SendMessage<T>(List<T> obj, string connectionString, string queue_name, int numberOfMsg) where T : class
        {
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queue_name);

            using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

            for (int i = 0; i < numberOfMsg; i++)
            {
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)));

                if (!batch.TryAddMessage(message))
                    Console.WriteLine($"A mensagem {i} é muito grande para caber no lote.");
            }

            try
            {
                await sender.SendMessagesAsync(batch);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mensagem enviada para a fila: {queue_name}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Houve uma falha ao enviar a messagem: {ex.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
                Console.ResetColor();
            }

        }


        public async Task SendMessageTopic<T>(T obj, string connectionString, string topicName, int numberOfMsg) where T : class
        {
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(topicName);

            using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

            for (int i = 0; i < numberOfMsg; i++)
            {
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)));

                if (!batch.TryAddMessage(message))
                    Console.WriteLine($"A mensagem {i} é muito grande para caber no lote.");
            }

            try
            {
                await sender.SendMessagesAsync(batch);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mensagem enviada para o topico: {topicName}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Houve uma falha ao enviar a messagem: {ex.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
                Console.ResetColor();
            }

        }

        public async Task SendMessageTopic<TEntity>(List<TEntity> obj, string connectionString, string topicName, int numberOfMsg) where TEntity : class
        {
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(topicName);

            using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
 
            for (int i = 0; i < numberOfMsg; i++)
            {
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)));

                if (!batch.TryAddMessage(message))
                    Console.WriteLine($"A mensagem {i} é muito grande para caber no lote.");
            }

            try
            {
                await sender.SendMessagesAsync(batch);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mensagem enviada para o topico: {topicName}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Houve uma falha ao enviar a messagem: {ex.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
                Console.ResetColor();
            }

        }
    }
}
