using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFServiceLibrary;

namespace WCFServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://xxxxxxxxxxxxxxxx:15612/Calculator");
            ServiceHost host = new ServiceHost(typeof(Calculator), baseAddress);
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.None;
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ICalculator), myBinding, "Calculator");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            try
            {
                BasicHttpBinding binding2 = new BasicHttpBinding();
                ServiceEndpoint endpoint2 = host.AddServiceEndpoint(typeof(ICalculator), binding2, "endpoint2");
                ServiceEndpoint endpoint3 = host.Description.Endpoints.Find(new Uri("http://xxxxxxxxxxxxx:15612/Calculator/endpoint3"));
                host.Open();
                Console.WriteLine("Service have started...");
                Console.WriteLine("Press <Enter> to finish.");
                Console.WriteLine();
                Console.WriteLine("\n---> Endpoints:");
                Console.WriteLine("\nService endpoint {0}:", endpoint.Name);
                Console.WriteLine("Binding: {0}", endpoint.Binding.ToString());
                Console.WriteLine("ListeinUri: {0}", endpoint.ListenUri.ToString());
                Console.WriteLine("\nService endpoint {0}:", endpoint2.Name);
                Console.WriteLine("Binding: {0}", endpoint2.Binding.ToString());
                Console.WriteLine("ListeinUri: {0}", endpoint2.ListenUri.ToString());
                Console.WriteLine("\nService endpoint {0}:", endpoint3.Name);
                Console.WriteLine("Binding: {0}", endpoint3.Binding.ToString());
                Console.WriteLine("ListeinUri: {0}", endpoint3.ListenUri.ToString());
                Console.ReadLine();
                host.Close();
            } catch (CommunicationException e)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", e.Message);
                host.Abort();
            }
        }
    }
}
