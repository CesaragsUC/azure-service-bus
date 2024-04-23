using ServiceBus.Sender;


/// <summary>
/// A opcao de topico só esta disponivel na tier premium
/// </summary>

class SenderDemo
{
    // Se mudar a Tier do service bus de Basic para Premium essa connection string vai mudar. E vise versa
    static string connectionString = "<String_Conexao_Service_Bus>";
    static string queueName = "minha-fila";
    static string topicName = "topico-minha-fila";

    // quantidade de mensagens a serem enviadas para a fila ou topico
    static int numberOfMessages = 1;

    static async Task Main(string[] args)
    {
        var sender = new MessageSender();

        //// Demo Envio de mensagem simples
        //await sender.SendMessage(connectionString, queueName, numberOfMessages);

        var produto = new Produto();

        var produtoNovo = await produto.CriarProduto();
        var produtoList = await produto.CriarListaProduto(5);

        #region Demo Envio para fila

        //await sender.SendMessage(produtoNovo, connectionString, queueName, numberOfMessages);

        //await sender.SendMessage(produtoNovo, connectionString, queueName, numberOfMessages);

        #endregion

        #region Demo Envio para Topico

        await sender.SendMessageTopic(produtoNovo, connectionString, topicName, numberOfMessages);

        await sender.SendMessageTopic(produtoList, connectionString, topicName, numberOfMessages);

        #endregion

        Console.ReadKey();
    }
}
