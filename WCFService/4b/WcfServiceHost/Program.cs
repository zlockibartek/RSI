using CallbackService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfService2;

namespace WcfServiceHost
{
    class MyData
    {
        public static void static_info()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Bartłomiej Złocki 256766");
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
            Uri baseAddress = new Uri("http://localhost:8002/wcf");
            ServiceHost myHost = new ServiceHost(typeof(MyComplexCalc), baseAddress);
            WSHttpBinding myBinding = new WSHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(typeof(ICalculator), myBinding, "endpoint1");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);

            Console.WriteLine("\nService endpoint {0}:", endpoint1.Name);
            Console.WriteLine("Binding: {0}", endpoint1.Binding.ToString());
            Console.WriteLine("ListenUri: {0}", endpoint1.ListenUri.ToString());


            Uri baseAddress2 = new Uri("http://localhost:8002/wcf2");
            ServiceHost myHost2 = new ServiceHost(typeof(AsyncService), baseAddress2);
            ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IAsyncService), myBinding, "endpoint2");
            myHost2.Description.Behaviors.Add(smb);

            Console.WriteLine("\nService endpoint {0}:", endpoint2.Name);
            Console.WriteLine("Binding: {0}", endpoint2.Binding.ToString());
            Console.WriteLine("ListenUri: {0}", endpoint2.ListenUri.ToString());

            Uri baseAddress3 = new Uri("http://localhost:8002/wcf3");
            ServiceHost myHost3 = new ServiceHost(typeof(MySuperCalc), baseAddress3);
            WSDualHttpBinding myBinding3 = new WSDualHttpBinding();
            ServiceEndpoint endpoint3 = myHost3.AddServiceEndpoint(typeof(ISuperCalc), myBinding3, "ThirdService");
            myHost3.Description.Behaviors.Add(smb);

            Console.WriteLine("\nService endpoint {0}:", endpoint3.Name);
            Console.WriteLine("Binding: {0}", endpoint3.Binding.ToString());
            Console.WriteLine("ListenUri: {0}", endpoint3.ListenUri.ToString());


            try
            {
                myHost.Open();
                Console.WriteLine("Serwis jest uruchomiony");

                myHost2.Open();
                Console.WriteLine("--> Async service is running");

                myHost3.Open();
                Console.WriteLine("--> Callback SuperCalc is running.");

                Console.WriteLine("Naciśnij <Enter> aby zakończyć");
                Console.WriteLine();
                Console.ReadLine();

                myHost2.Close();
                Console.WriteLine("--> Async service finished");

                myHost3.Close();
                Console.WriteLine("--> Callback SuperCalc finished");

                myHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystąpił wyjątek: {0}", ce.Message);
                myHost.Abort();
                myHost2.Abort();
                myHost3.Abort();
            }


            

        }
    }
}
