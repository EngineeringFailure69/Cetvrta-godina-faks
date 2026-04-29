using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _6.WCF__Sep_2018
{
    [ServiceContract]
    public interface IBank
    {
        [OperationContract]
        void uplati(double iznos, string valuta, double kursPremaEvru);
        [OperationContract]
        double isplatiDinare(double iznos);
        [OperationContract]
        void namestiKoef(double koef);
        [OperationContract]
        List<String> GetPromene();
      
    }

  
}
