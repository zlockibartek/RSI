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
            Console.WriteLine(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString());
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
                    Console.WriteLine("Podaj metode:");
                    
                    string method = Console.ReadLine();


                    Console.WriteLine("Podaj URI:");
                    string uri = Console.ReadLine();
                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = method.ToUpper();

           
                    switch (method.ToUpper())
                    {
                        case "GET":
                            break;
                        case "POST":
                            req.ContentType = "application/json"; 
                                 Console.WriteLine("Wklej zawartosc XML-a lub JSON - a(w jednej linii!)");

                            string dane = Console.ReadLine();
                            //przekodowanie tekstu wiadomosci:
                            byte[] bufor = Encoding.UTF8.GetBytes(dane);
                            req.ContentLength = bufor.Length;
                            Stream postData = req.GetRequestStream();
                            postData.Write(bufor, 0, bufor.Length);
                            postData.Close();
                            break;
                        case "PUT":
                            Console.WriteLine("Wklej zawartosc XML-a lub JSON - a(w jednej linii!)");

                            string danePUT = Console.ReadLine();
                            //przekodowanie tekstu wiadomosci:
                            byte[] buforPUT = Encoding.UTF8.GetBytes(danePUT);
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
