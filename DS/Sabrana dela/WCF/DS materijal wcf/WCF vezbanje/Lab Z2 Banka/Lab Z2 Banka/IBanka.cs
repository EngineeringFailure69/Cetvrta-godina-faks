using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab_Z2_Banka
{
    [ServiceContract]
    public interface IBanka
    {
        [OperationContract]
        void Uplati(decimal iznos, string valuta, decimal koef);
        [OperationContract]
        decimal Isplati(decimal iznos);
        [OperationContract]
        void PostaviEur(decimal koef);
        [OperationContract]
        List<string> VratiPromene();
    }
}
