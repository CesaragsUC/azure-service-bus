using ServiceBusConsumer.Demo;

/// <summary>
/// A opcao de topico só esta disponivel na tier premium
/// </summary>


class SenderDemo
{
    // Se mudar a Tier do service bus de Basic para Premium essa connection string vai mudar.E vise versa
    static string connectionString = "<String_Conexao_Service_Bus>";
    static string queueName = "minha-fila";
    static string topicName = "topico-minha-fila";
    static string subscriberName = "sub-01";

    static async Task Main(string[] args)
    {
        var messageHandler = new MessageConsumerHandler();

        //// consome da fila
        await messageHandler.ReceiveMessages(connectionString, queueName);

        ////consome do topico
        await messageHandler.ReceiveMessagesFromTopic(connectionString, topicName, subscriberName);  

        Console.ReadKey();
    }
}
