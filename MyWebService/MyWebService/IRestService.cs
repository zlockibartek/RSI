using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/items")]
        List<Book> getAllXml();
        [OperationContract]
        [WebGet(UriTemplate = "/items/{id}",
        ResponseFormat = WebMessageFormat.Xml)]
        Book getByIdXml(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/items",
        Method = "POST",
        RequestFormat = WebMessageFormat.Xml)]
        string addXml(Book book);
        [OperationContract]
        [WebInvoke(UriTemplate = "/items/{id}", Method = "DELETE")]
        string deleteXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/items", ResponseFormat = WebMessageFormat.Json)]
        List<Book> getAllJson();
        [OperationContract]
        [WebGet(UriTemplate = "/json/items/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Book getByIdJson(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/json/items",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json)]
        string addJson(Book book);
        [OperationContract]
        [WebInvoke(UriTemplate = "/json/items/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string deleteJson(string Id);


        [OperationContract]
        [WebInvoke(UriTemplate = "/json/items/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UpdateJson(string id, Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/items/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        string UpdateXml(string id, Book book);


        [OperationContract]
        [WebGet(UriTemplate = "/authors/{id}",
        ResponseFormat = WebMessageFormat.Xml)]
        Author getAuthorByIdXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/authors/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Author getAuthorByIdJson(string Id);


        [OperationContract]
        [WebGet(UriTemplate = "/authors")]
        List<Author> getAllAuthorsXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/authors", ResponseFormat = WebMessageFormat.Json)]
        List<Author> getAllAuthorsJson();
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Book
    {
        [DataMember(Order = 0)]
        public int ID { get; set; }
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public int Author { get; set; }
    }

    [DataContract]
    public class Author
    {
        [DataMember(Order = 0)]
        public int ID { get; set; }
        [DataMember(Order = 1)]
        public string Time { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Surname { get; set; }
        [DataMember(Order = 4)]
        public string Index { get; set; }
        [DataMember(Order = 5)]
        public string Username { get; set; }
        [DataMember(Order = 6)]
        public string System { get; set; }
        [DataMember(Order = 7)]
        public string Version { get; set; }
        [DataMember(Order = 8)]
        public string Adres { get; set; }


    }
}
