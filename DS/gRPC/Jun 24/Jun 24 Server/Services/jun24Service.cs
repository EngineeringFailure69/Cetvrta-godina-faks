using Grpc.Core;
using Jun24;
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;

namespace Jun_24_Server.Services
{
    public class jun24Service : UpravljanjePorukama.UpravljanjePorukamaBase
    {
        Dictionary<int, string> listaPoruka = new Dictionary<int, string>();

        public override async Task<OdgovorServera> SendMessage(Poruka poruka, ServerCallContext context) 
        {
            listaPoruka.Add(poruka.Id, poruka.Tekst);
            return await Task.FromResult(new OdgovorServera { Odgovor = "Poruka dodata" });
        }

        public override async Task<OdgovorServera> DeleteMessage(PorukaID porukaID, ServerCallContext context) 
        {
            listaPoruka.Remove(porukaID.Id);
            return await Task.FromResult(new OdgovorServera { Odgovor = "Poruka obrisana" });
        }

        public override async Task ListMessages(Empty request, IServerStreamWriter<Poruka> vracenePoruke, ServerCallContext context) 
        {
            foreach (var poruke in listaPoruka) 
            {
                Poruka poruka = new Poruka { Id = poruke.Key, Tekst = poruke.Value };
                await vracenePoruke.WriteAsync(poruka);
            }
        }
    }
}