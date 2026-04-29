using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCisterna
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICisterna
    {

        //dodavanja određenog materijala koji je opisan zapreminom koja je dodata i svojom gustinom.
        [OperationContract]
        void DodajMaterijal(string materijal, double V, double r);

        //ispusti određenu zapreminu.
        [OperationContract]
        void Ispusti(double r);

        //prikazati trenutno zauzeće cisterne i njenu gustinu.

        [OperationContract]
        Stanje TrenutnoStanje();


        //izlistati sve promene nad cisternom.
        [OperationContract]
        IList<string> VratiPromene();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Stanje
    {
        double zapremina = 0;
        double gustina = 1;

        [DataMember]
        public double Zapremina
        {
            get { return zapremina; }
            set { zapremina = value; }
        }

        [DataMember]
        public double Gustina
        {
            get { return gustina; }
            set { gustina = value; }
        }
    }
}
