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
            Vlasnik vlasnik = new Vlasnik
            {
                Ime = "Milos",
                Prezime = "Petrovic",
                JMBG = "1"
            };
            Vozilo vozilo = new Vozilo
            {
                Marka = "Mercedes",
                Model = "190e",
                Boja = "Plava"
            };
            Vozilo vozilo1 = new Vozilo
            {
                Marka = "Mercedes",
                Model = "200e",
                Boja = "Plava"
            };
            proxy.dodajRegistraciju(vlasnik, vozilo);
            proxy.dodajRegistraciju(vlasnik, vozilo1);
            Vlasnik vlasnik1 = new Vlasnik
            {
                Ime = "Aleksandar",
                Prezime = "Aleksic",
                JMBG = "2"
            };
            proxy.dodajRegistraciju(vlasnik1, vozilo);

            List<Vozilo> vozila = proxy.vratiVozilaVlasnike(vlasnik);
            foreach(Vozilo v in vozila)
            {
                Console.WriteLine(v.Marka + "  " + v.Model);
            }

            List<Vlasnik> vlasnici = proxy.posedujeModel("190e");
            foreach(Vlasnik v in vlasnici)
            {
                Console.WriteLine(v.JMBG + " " + v.Ime);
            }


        }
    }
}
