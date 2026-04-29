using Grpc.Core;
using Okt2;
namespace Oktobar_2_25_Server.Services
{
    public class Okt2Service : okt25.okt25Base
    {
        public override async Task kvadratBroja(IAsyncStreamReader<AiB> brojevi, IServerStreamWriter<odgovorServera> odgovoriServera, ServerCallContext context) 
        {
            await foreach (AiB broj in brojevi.ReadAllAsync()) 
            {
                if (broj.B == broj.A * broj.A)
                    await odgovoriServera.WriteAsync(new odgovorServera { Odgovor = "Da" });
                else
                    await odgovoriServera.WriteAsync(new odgovorServera { Odgovor = "Ne" });
            }
        }
    }
}