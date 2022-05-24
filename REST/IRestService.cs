using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Cars")]
        List<Car> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/Cars", ResponseFormat = WebMessageFormat.Json)]
        List<Car> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/Car/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Car getByIdXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/Car/{id}", ResponseFormat = WebMessageFormat.Json)]
        Car getByIdJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Car", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string addXml(Car car);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/Car", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string addJson(Car car);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Car/{id}", Method = "DELETE")]
        string deleteXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/Car/{id}", Method = "DELETE")]
        string deleteJson(string id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Car
    {
        public Car(int id, string model, double price)
        {
            this.identifier = id;
            this.modelName = model;
            this.price = price;
        }

        [DataMember(Order = 0)]
        public int identifier { get; set; }

        [DataMember(Order = 1)]
        public string modelName { get; set; }

        [DataMember(Order = 2)]
        public double price { get; set; }
    }
}
