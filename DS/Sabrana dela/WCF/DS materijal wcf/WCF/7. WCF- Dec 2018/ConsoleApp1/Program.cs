using ConsoleApp1.ServiceReferenceRegistracija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistracijaClient proxy = new RegistracijaClient();
            Vlasnik v = new Vlasnik
            {
                Ime = "Milos",
                Prezime = "Petrovic",
                JMBG = "1"
            };
            Vozilo vozilo = new Vozilo
            {
                Marka = "Mercedel",
                Model = "190E",
                Boja = "Crvena"
            };
            proxy.dodajRegistraciju(v, vozilo);
            vozilo = new Vozilo
            {
                Marka = "Mercedes",
                Model = "200E",
                Boja = "Crvena"
            };
            proxy.dodajRegistraciju(v, vozilo);
            v = new Vlasnik
            {
                Ime = "Dusa",
                Prezime = "Stanicsavljevic",
                JMBG = "2"
            };
            proxy.dodajRegistraciju(v, vozilo);

            v.JMBG = "1";
            List<Vozilo> vozila = proxy.vratiVozilaVlasnika(v);
            foreach(Vozilo i in vozila)
            {
                Console.WriteLine(i.Marka + " " + i.Model + " " + i.Boja);
            }

            List<Vlasnik> vlasnici = proxy.posedujeVozilo("200E");
            foreach(Vlasnik i in vlasnici)
            {
                Console.WriteLine(i.JMBG + " " + i.Ime);
            }


        }
    }
}
