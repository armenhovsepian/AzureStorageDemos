using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

string connectionString = "UseDevelopmentStorage=true";
string queueName = "emails";

QueueClient queueClient = new QueueClient(connectionString, queueName);

await SendMessageAsync(queueClient, $"Message {DateTimeOffset.Now}");

Console.WriteLine("...");
await Task.Delay(5000);

await RecieveMessageAsync(queueClient);




async Task SendMessageAsync(QueueClient queueClient, string message)
{
    if (null != await queueClient.CreateIfNotExistsAsync())
    {
        Console.WriteLine("The queue was created!");
    }

    await queueClient.SendMessageAsync(message);
    Console.WriteLine($"Messsage ({message}) Sent!");
}

async Task<string> RecieveMessageAsync(QueueClient queueClient)
{
    if (await queueClient.ExistsAsync())
    {
        var properties = queueClient.GetProperties();

        QueueMessage[] messagess = await queueClient.ReceiveMessagesAsync(1);
        var message = messagess[0].Body.ToString();
        Console.WriteLine($"Message {message} recieved!");

        return message;
    }
    else
    {
        Console.WriteLine("The queue is empty!");
    }

    return string.Empty;
}


