using Grpc.Core;
using Drugi;
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;

namespace Server.Services
{
    public class Service : CelobrojniPodatakServis.CelobrojniPodatakServisBase
    {
        static int acc = 1;
        public override async Task<Empty> SrVrednostPrirodnihBrojeva(Broj broj, ServerCallContext context) 
        {
            int brojac = 0, sum = 0;
            for (int i = 1; i < broj.Vrednost; i++) 
            {
                brojac++;
                sum += i;
            }
            acc += sum / brojac;
            return await Task.FromResult(new Empty());
        }

        public override async Task PomnoziSvakiTreciElement(IAsyncStreamReader<Broj> brojevi, IServerStreamWriter<Broj> serverBrojevi, ServerCallContext context) 
        {
            int brojac = 0;
            await foreach (Broj broj in brojevi.ReadAllAsync()) 
            {
                brojac++;
                if (brojac % 3 == 0)
                    broj.Vrednost *= acc;
                else
                    broj.Vrednost -= acc;

                await serverBrojevi.WriteAsync(new Broj { Vrednost = broj.Vrednost });
            }
        }
    }
}