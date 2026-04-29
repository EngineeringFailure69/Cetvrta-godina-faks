using System;
using System.ServiceModel;

namespace WcfCalc2020
{
    public interface ICalcCallback
    {
        [OperationContract(IsOneWay = true)]
        void Promena(double rezultat, string izraz);
    }
}