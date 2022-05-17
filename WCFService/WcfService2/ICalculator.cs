using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService2
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        ComplexNum addCNum(ComplexNum n1, ComplexNum n2);
        [OperationContract]
        ComplexNum multCNum(ComplexNum n1, ComplexNum n2);
        [OperationContract]
        ComplexNum divCNum(ComplexNum n1, ComplexNum n2);


        // TODO: dodaj tutaj operacje usługi
    }

    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    // Możesz dodać pliki XSD do projektu. Po skompilowaniu projektu możesz bezpośrednio użyć zdefiniowanych w nim typów danych w przestrzeni nazw „WcfService2.ContractType”.
    [DataContract]
    public class ComplexNum
    {
        string description = "Complex number";

        [DataMember]
        public double real;

        [DataMember]
        public double imag;

        [DataMember]
        public string Desc
        {
            get { return description; }
            set { description = value; }
        }

        public ComplexNum(double r, double i)
        {
            this.real = r;
            this.imag = i;
        }
    }
    
}
