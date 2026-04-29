using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCalc2020
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICalcCallback))]
    public interface ICalc
    {

        [OperationContract(IsOneWay = true)]
        void Obrisi();

        [OperationContract(IsOneWay = true)]
        void Dodaj(double a);

        [OperationContract(IsOneWay = true)]
        void Oduzmi(double a);

        [OperationContract(IsOneWay = true)]
        void Pomnozi(double a);

        [OperationContract(IsOneWay = true)]
        void Podeli(double a);
    }
}
