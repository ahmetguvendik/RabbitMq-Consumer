
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

//Baglanti olusturma
ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://wqbvawvt:aTi_gA9eIEH4Ot3LV4PDfWHGFZieaNK-@shark.rmq.cloudamqp.com/wqbvawvt");

//Baglanti Aktiflestirme

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Olusturma
channel.QueueDeclare(queue: "example-queeue", exclusive:false); //Consumer"da da kuyruk puvlisherdaki ile birebir ayni yapilandirmada yapilmalidir.

//Queue den mesaj okuma
EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
channel.BasicConsume(queue: "example-queeue", false, consumer);
consumer.Received += (sender, e) =>
{
    //Kuyruga gelen mesajin islendigi yerdir.
    //e.Body : Kuyruktaki mesajin verisini butunsel olarak getirecektir.
    //e.Body.Span veua e.Body.ToArray() : Kuyruktaki mesaji byte verisini getirecektir.
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};

Console.Read();
