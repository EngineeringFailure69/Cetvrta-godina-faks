using Grpc.Core;
using Prvi;
using System.Xml.Linq;

namespace Server.Services
{
    public class Service : ListaKorisnika.ListaKorisnikaBase
    {
        List<Korisnik> listaKorisnika = new List<Korisnik>();

        public override async Task<OdgovorServera> DodajKorisnika(Korisnik korisnik, ServerCallContext context) 
        {
            listaKorisnika.Add(korisnik);
            return await Task.FromResult(new OdgovorServera { Odgovor = "Korisnik uspesno dodat!" });
        }

        public override async Task<OdgovorServera> ObrisiKorisnika(KorisnikID korisnikID, ServerCallContext context) 
        {
            for (int i = 0; i < listaKorisnika.Count; i++) 
            {
                if (listaKorisnika[i].Id == korisnikID.Id) 
                {
                    listaKorisnika.RemoveAt(i);
                    return await Task.FromResult(new OdgovorServera { Odgovor = $"Korisnik sa Id={korisnikID.Id} uspesno obrisan!" });
                }
            }
            return await Task.FromResult(new OdgovorServera { Odgovor = $"Korisnik sa Id={korisnikID.Id} ne postoji!" });
        }

        public override async Task<OdgovorServera> IzmeniKorisnika(Korisnik korisnik, ServerCallContext context) 
        {
            foreach (Korisnik korisnik1 in listaKorisnika) 
            {
                if (korisnik.Id == korisnik1.Id) 
                {
                    korisnik1.Ime = korisnik.Ime;
                    korisnik1.Prezime = korisnik.Prezime;
                    korisnik1.Adresa = korisnik.Adresa;
                    korisnik1.BrojeviTelefona.Clear();
                    korisnik1.BrojeviTelefona.AddRange(korisnik.BrojeviTelefona);
                    return await Task.FromResult(new OdgovorServera { Odgovor = "Korisnik uspesno izmenjen!" });
                }
            }
            return await Task.FromResult(new OdgovorServera { Odgovor = "Korisnik ne postoji!" });
        }

        public override async Task DobaviListuKorisnika(OpsegKorisnika opsegKorisnika, IServerStreamWriter<Korisnik> korisnici, ServerCallContext context) 
        {
            foreach (Korisnik korisnik in listaKorisnika) 
                if (korisnik.Id >= opsegKorisnika.PocetniId && korisnik.Id <= opsegKorisnika.KrajnjiId) 
                    await korisnici.WriteAsync(korisnik);
        }

        public override async Task ObrisiListuKorisnika(IAsyncStreamReader<KorisnikID> korisnikIDs, IServerStreamWriter<OdgovorServera> odgovoriServera, ServerCallContext context) 
        {
            bool pronadjen = false;
            await foreach (KorisnikID korisnikId in korisnikIDs.ReadAllAsync()) 
            {
                for (int i = 0; i < listaKorisnika.Count; i++) 
                    if (korisnikId.Id == listaKorisnika[i].Id)
                    {
                        pronadjen = true;
                        listaKorisnika.RemoveAt(i);
                        await odgovoriServera.WriteAsync(new OdgovorServera { Odgovor = "Uspesno obrisan korisnik iz liste!" });
                        break;
                    }
                if (!pronadjen)
                    await odgovoriServera.WriteAsync(new OdgovorServera { Odgovor = "Korisnik nije pronadjen!" });
            }
        }
    }
}