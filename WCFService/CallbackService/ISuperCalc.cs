using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CallbackService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISuperCalcCallback))]
    public interface ISuperCalc
    {
        [OperationContract(IsOneWay = true)]
        void Factorial(double n);
        [OperationContract(IsOneWay = true)]
        void DoSomething(int sec);
        [OperationContract(IsOneWay = true)]
        void Fibonacci(int n);
        [OperationContract(IsOneWay = true)]
        void addRecord(PersonalData data);
        [OperationContract(IsOneWay = true)]
        void removeRecord(PersonalData data);
        [OperationContract(IsOneWay = true)]
        void findRecord(PersonalData data);
    }


    [DataContract]
    public class PersonalData
    {
        [DataMember]
        public String name;

        [DataMember]
        public int age;

        public PersonalData(String n, int a)
        {
            this.name = n;
            this.age = a;
        }
    }

    public interface ISuperCalcCallback
    {
        [OperationContract(IsOneWay = true)]
        void FactorialResult(double result);
        [OperationContract(IsOneWay = true)]
        void DoSomethingResult(string result);
        [OperationContract(IsOneWay = true)]
        void FibonacciResult(int n);
        [OperationContract(IsOneWay = true)]
        void RecordResult(List<PersonalData> data);
    }


}
