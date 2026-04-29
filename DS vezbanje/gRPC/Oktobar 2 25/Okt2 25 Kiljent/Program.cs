using Grpc.Core;
using Grpc.Net.Client;
using Okt2;

using var channel = GrpcChannel.ForAddress("https://localhost:7091");
var client = okt25.okt25Client(channel);
