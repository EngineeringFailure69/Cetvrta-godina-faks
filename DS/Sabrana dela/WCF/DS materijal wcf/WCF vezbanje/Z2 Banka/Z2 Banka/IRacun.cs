using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Z2_Banka
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRacun
    {
        [OperationContract]
        void Uplata(decimal iznos, string Naziv, decimal k);

        [OperationContract]
        void Isplata(decimal inzosRsd);

        [OperationContract]
        void SetKurs(decimal eur2rsd);

        [OperationContract]
        List<string> GetPromene();
    }
    [DataContract]
    public class Uplata
    {
        decimal iznos;
        string valuta;
        decimal koeficijent;

        [DataMember]
        public decimal Iznos
        {
            get { return iznos; }
            set { iznos = value; }
        }

        [DataMember]
        public string Valuta
        {
            get { return valuta; }
            set { valuta = value; }
        }

        [DataMember]
        public decimal Koeficijent
        {
            get { return koeficijent; }
            set { koeficijent = value; }
        }
    }

}
