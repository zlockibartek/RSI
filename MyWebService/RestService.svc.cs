using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IRestService
    {
        private static List<contract_type> Yyy;

        public Service1() {
            Yyy = new List<contract_type>() {
                 new contract_type {id=0,name="banan",number=1.1, quantity = 5},
                 new contract_type {id=1,name="woda",number=5.1, quantity = 10},
                 new contract_type {id=2,name="sok",number=6.0, quantity = 2},
                 new contract_type {id=3, name="ser", number=4.99, quantity = 50}
            };
        }

        private static List<Author> authors = new List<Author>
        {

            new Author {ID=1, Name="Bartlomiej", Time=(DateTime.Now).ToString(), Surname="Złocki", Index="256766", Username=Environment.UserName, System=Environment.OSVersion.ToString(), Version=Environment.Version.ToString(), Adres=Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString()},
            new Author {ID=1, Name="Paweł", Time=(DateTime.Now).ToString(), Surname="Kolman", Index="256778", Username=Environment.UserName, System=Environment.OSVersion.ToString(), Version=Environment.Version.ToString(), Adres=Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString()},
        };


        public contract_type getByIdXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = Yyy.FindIndex(b => b.id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            return Yyy.ElementAt(idx);
        }

        public List<Author> getAllAuthors()
        {
            return authors;
        }

        public string addXml(contract_type item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);

            int newIdx = Yyy.Count;
            int idx = Yyy.FindIndex(b => b.id == newIdx);
                 if (idx == -1) {
                     item.id = newIdx;
                     Yyy.Add(item);
                     return "Added item with ID=" + item.id;
                 } else
                 throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
       }

        public string deleteXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = Yyy.FindIndex(b => b.id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            Yyy.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public List<contract_type> getAllJson()
        {
            return Yyy;
        }

        public contract_type getByIdJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = Yyy.FindIndex(b => b.id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            return Yyy.ElementAt(idx);
        }

        public string addJson(contract_type item)
        {

            if (item == null)
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);

            int idx;
            int newIdx;
            do
            {
                newIdx = Yyy.Count;
                idx = Yyy.FindIndex(b => b.id == newIdx);
            }
            while (idx != -1);
            if (idx == -1)
            {
                item.id = newIdx;
                Yyy.Add(item);
                return "Added item with ID=" + item.id;
            }
            else
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
        }

        public string deleteJson(string Id)
        {

            int intId = int.Parse(Id);
            int idx = Yyy.FindIndex(b => b.id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            Yyy.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public string modifyJson(contract_type item)
        {

            if (item == null)
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);
            
            int idx = Yyy.FindIndex(b => b.id == item.id);
            if (idx == -1)
                throw new WebFaultException<string>("404: Conflict", HttpStatusCode.NotFound);
            else
            {
                Yyy.ElementAt(idx).name = item.name;
                Yyy.ElementAt(idx).number = item.number;
                Yyy.ElementAt(idx).quantity = item.quantity;
                return "Modified item with ID=" + item.id;
            }
        }

        public string addJsonOption(contract_type item)
        {
            return null;
        }

        public string deleteJsonOption(string Id)
        {
            return null;
        }

        public string buyJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = Yyy.FindIndex(b => b.id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            Yyy.ElementAt(idx).quantity--;
            return "Patched item with ID=" + Id;
        }

        public string buyJsonOption(string Id)
        {
            return null;
        }

        public List<contract_type> getAllXml()
        {
            throw new NotImplementedException();
        }

        List<contract_type> IRestService.getAllAuthors()
        {
            throw new NotImplementedException();
        }
    }
}
