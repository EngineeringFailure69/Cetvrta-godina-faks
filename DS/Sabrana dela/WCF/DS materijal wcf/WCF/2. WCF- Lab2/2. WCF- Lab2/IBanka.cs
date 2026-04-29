using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _2.WCF__Lab2
{
    [ServiceContract]
    public interface IBanka
    {
        [OperationContract]
        void uplati(double iznos, string naziv, double koefEur);
        [OperationContract]
        double isplati(double dinara);
        [OperationContract]
        void prebaciEurUDinar(double vrednost,double koef);
        [OperationContract]
        List<string> Promene();

    }
}
