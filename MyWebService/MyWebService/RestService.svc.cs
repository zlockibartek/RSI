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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MyRestService : IRestService
    {
        private static List<Book> items = new List<Book>() {
            new Book {ID=1,Name="Lalka",Author=1},
            new Book {ID=2,Name="Potop",Author=1},
            new Book {ID=3,Name="Zemsta",Author=2},
        };

        private static List<Author> authors = new List<Author>
        {
            new Author {ID=1, Name="Bartlomiej", Surname="Złocki"},
            new Author {ID=2, Name="Paweł", Surname="Kolman"},
        };

        public List<Book> getAllXml()
        {
            return items;
        }

        public Book getByIdXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = items.FindIndex(b => b.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            return items.ElementAt(idx);
        }

        public string addXml(Book item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);

            // Random rnd = new Random();

            // int newIdx = rnd.Next();

            int idx = items.FindIndex(b => b.ID == item.ID);
            if (idx == -1)
            {
                //item.ID = newIdx;
                items.Add(item);
                return "Added item with ID=" + item.ID;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }

        public string deleteXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = items.FindIndex(b => b.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            items.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public List<Book> getAllJson()
        {
            return items;
        }

        public Book getByIdJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = items.FindIndex(b => b.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            return items.ElementAt(idx);
        }

        public string addJson(Book item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);

            // Random rnd = new Random();

            // int newIdx = rnd.Next();

            int idx = items.FindIndex(b => b.ID == item.ID);
            if (idx == -1)
            {
                //item.ID = newIdx;
                items.Add(item);
                return "Added item with ID=" + item.ID;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }

        public string deleteJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = items.FindIndex(b => b.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            items.RemoveAt(idx);
            return "Removed item with ID=" + Id;
        }

        public string UpdateJson(string id, Book book) => UpdateXml(id, book);

        public string UpdateXml(string id, Book book)
        {
            if (!int.TryParse(id, out int parseId))
            {
                throw new WebFaultException<string>("400: Invalid arguments", HttpStatusCode.BadRequest);
            }

            int storedId = items.FindIndex(x => x.ID.Equals(parseId));
            int idx2 = authors.FindIndex(a => a.ID == book.Author);

            if (storedId == -1 || idx2 == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }

            if (parseId != book.ID)
            {
                if (items.Exists(x => x.ID.Equals(book.ID)))
                {
                    throw new WebFaultException<string>($"409: Book with ID={book.ID} already exists", HttpStatusCode.Conflict);
                }
            }

            items[storedId] = book;

            return "Updated item with ID=" + parseId;
        }

        public Author getAuthorByIdXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = authors.FindIndex(b => b.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            return authors.ElementAt(idx);
        }

        public Author getAuthorByIdJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = items.FindIndex(b => b.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            return authors.ElementAt(idx);
        }

        public List<Author> getAllAuthorsXml()
        {
            return authors;
        }

        public List<Author> getAllAuthorsJson()
        {
            return authors;
        }
    }
}
