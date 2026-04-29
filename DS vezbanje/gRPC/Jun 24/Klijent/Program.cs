using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using Jun24;
using Google.Protobuf.WellKnownTypes;

var channel = GrpcChannel.ForAddress("https://localhost:7040");
var client = new UpravljanjePorukama.UpravljanjePorukamaClient(channel);

var requestSend1 = new Poruka { Id = 1, Tekst = "Hej1" };
var requestSend2 = new Poruka { Id = 2, Tekst = "Hej2" };
var requestSend3 = new Poruka { Id = 3, Tekst = "Hej3" };
var requestSend4 = new Poruka { Id = 4, Tekst = "Hej4" };
var requestSend5 = new Poruka { Id = 5, Tekst = "Hej5" };
var requestSend6 = new Poruka { Id = 6, Tekst = "Hej6" };
var requestDel1 = new PorukaID { Id = 2 };
var requestDel2 = new PorukaID { Id = 6 };

Console.WriteLine(client.SendMessage(requestSend1));
Console.WriteLine(client.SendMessage(requestSend2));
Console.WriteLine(client.SendMessage(requestSend3));
Console.WriteLine(client.SendMessage(requestSend4));
Console.WriteLine(client.SendMessage(requestSend5));
Console.WriteLine(client.SendMessage(requestSend6));

Console.WriteLine(client.DeleteMessage(requestDel1));
Console.WriteLine(client.DeleteMessage(requestDel2));

Empty praznaPoruka = new Empty();

var call = client.ListMessages(praznaPoruka);
await foreach (Poruka poruka in call.ResponseStream.ReadAllAsync())
{
    Console.WriteLine(poruka.Tekst);
}