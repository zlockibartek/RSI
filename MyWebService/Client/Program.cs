using System;
using System.IO;
using System.Net;
using System.Text;

namespace Client
{
    class MyData
    {
        public static void static_info()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Paweł Kolman 256778");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion.ToString());
            Console.WriteLine(Environment.Version.ToString());
            Console.WriteLine(Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyData.static_info();
            do
            {
                try
                {
                    string uri = "http://zpi03.solidcp.ii.pwr.edu.pl/RestService.svc";
                    //string uri = "http://localhost:49736/RestService.svc";

                    Console.WriteLine("1: Wybierz wszystkie książki");
                    Console.WriteLine("2: Wybierz książkę o podanym ID");
                    Console.WriteLine("3. Wybierz wszystkich autorów");
                    Console.WriteLine("4: Wybierz autora o podanym ID");
                    Console.WriteLine("5: Dodaj książkę");
                    Console.WriteLine("6: Aktualizuj książke");
                    Console.WriteLine("7: Usuń książkę");

                    int option = Convert.ToInt32(Console.ReadLine());
                    int id = 0;
                    string method = "get";
                        string json = "{ ";
                    switch (option)
                    {
                        case 1:
                            uri += "/json/items";
                            break;
                        case 2:
                            Console.WriteLine("Podaj ID:");
                            id = Convert.ToInt32(Console.ReadLine());
                            uri += "/json/items/" + id;
                            break;
                        case 3:
                            uri += "/json/authors";
                            break;
                        case 4:
                            Console.WriteLine("Podaj ID:");
                            id = Convert.ToInt32(Console.ReadLine());
                            uri += "/json/authors/" + id;
                            break;
                        case 5:
                            Console.WriteLine("Podaj ID:");
                            id = Convert.ToInt32(Console.ReadLine());
                            json += "\"ID\": " + id + ", ";
                            Console.WriteLine("Podaj tytuł:");
                            json += "\"Name\": \"" + Console.ReadLine() + "\", ";
                            Console.WriteLine("Podaj ID autora:");
                            json += "\"Author\": " + Convert.ToInt32(Console.ReadLine()) + " }";
                            uri += "/json/items";
                            method = "post";
                            break;
                        case 6:
                           Console.WriteLine("Podaj ID:");
                           id = Convert.ToInt32(Console.ReadLine());
                           json += "\"ID\": " + id + ", ";
                           Console.WriteLine("Podaj tytuł:");
                           json += "\"Name\": \"" + Console.ReadLine() + "\", ";
                           Console.WriteLine("Podaj ID autora:");
                           json += "\"Author\": " + Convert.ToInt32(Console.ReadLine()) + " }";
                           uri += "/json/items/" + id;
                           method = "put";
                           break;
                       case 7:
                           Console.WriteLine("Podaj ID:");
                           method = "delete";
                           id = Convert.ToInt32(Console.ReadLine());
                           uri += "/json/items/" + id;
                           break;
                        default:
                            break;
                    }
                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;

                    req.KeepAlive = false;
                    req.Method = method.ToUpper();
                   


                    switch (method.ToUpper())
                    {
                        case "GET":
                            break;
                        case "POST":
                            req.ContentType = "application/json"; 

                            byte[] bufor = Encoding.UTF8.GetBytes(json);
                            req.ContentLength = bufor.Length;
                            Stream postData = req.GetRequestStream();
                            postData.Write(bufor, 0, bufor.Length);
                            postData.Close();
                            break;
                        case "PUT":
                            req.ContentType = "application/json";
                            //przekodowanie tekstu wiadomosci:
                            byte[] buforPUT = Encoding.UTF8.GetBytes(json);
                            req.ContentLength = buforPUT.Length;
                            Stream putData = req.GetRequestStream();
                            putData.Write(buforPUT, 0, buforPUT.Length);
                            putData.Close();
                            break;
                        case "DELETE":
                            break;
                        default:
                            break;
                    }
                    HttpWebResponse resp = req.GetResponse()
                    as HttpWebResponse;
                    //przekodowanie tekstu odpowiedzi: 
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    Encoding enc = Encoding.GetEncoding(1252);
                    StreamReader responseStream =
                    new StreamReader(resp.GetResponseStream(), enc);
                    string responseString = responseStream.ReadToEnd();
                    responseStream.Close();
                    resp.Close();
                    Console.WriteLine(responseString);
                    }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to continue?");
            } while (Console.ReadLine().ToUpper() == "Y");
        }
    }
}
