using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/get_all")]
        List<contract_type> getAllXml();
        [OperationContract]
        [WebGet(UriTemplate = "/get/{id}",
        ResponseFormat = WebMessageFormat.Xml)]
        contract_type getByIdXml(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/add",
        Method = "POST",
        RequestFormat = WebMessageFormat.Xml)]
        string addXml(contract_type item);
        [OperationContract]
        [WebInvoke(UriTemplate = "/delete/{id}", Method = "DELETE")]
        string deleteXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/products",
        ResponseFormat = WebMessageFormat.Json)]
        List<contract_type> getAllJson();
        [OperationContract]
        [WebGet(UriTemplate = "/products/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        contract_type getByIdJson(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json)]
        string addJson(contract_type item);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products",
        Method = "OPTIONS",
        RequestFormat = WebMessageFormat.Json)]
        string addJsonOption(contract_type item);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products/{id}", Method = "DELETE")]
        string deleteJson(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products/{id}", Method = "OPTIONS")]
        string deleteJsonOption(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products",
        Method = "PUT",
        RequestFormat = WebMessageFormat.Json)]
        string modifyJson(contract_type item);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products/{id}/buy",
        Method = "PATCH")]
        string buyJson(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/products/{id}/buy",
        Method = "OPTIONS")]
        string buyJsonOption(string Id);
    }


    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    [DataContract]
    public class contract_type
    {
        [DataMember(Order = 0)]
        public int id { get; set; }
        [DataMember(Order = 1)]
        public string name { get; set; }
        [DataMember(Order = 2)]
        public double number { get; set; }
        [DataMember(Order = 3)]
        public int quantity { get; set; }
    }
}
