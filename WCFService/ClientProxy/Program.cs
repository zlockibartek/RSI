using ClientProxy.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient client1 = new CalculatorClient("WSHttpBinding_ICalculator");
            CalculatorClient client2 = new CalculatorClient("BasicHttpBinding_ICalculator");
            CalculatorClient client3 = new CalculatorClient("myEndpoint3");

            Console.WriteLine("WSHttpBinding Calculator: ");

            double result = client1.Add(1, 2);
            Console.WriteLine(result);

            result = client1.Subtract(1, 2);
            Console.WriteLine(result);

            result = client1.Multiply(2, 3);
            Console.WriteLine(result);

            result = client1.Divide(6, 3);
            Console.WriteLine(result);

            result = client1.Divide(6, 0);
            Console.WriteLine(result);

            result = client1.Summarize(4);
            Console.WriteLine(result);

            result = client1.Summarize(6);
            Console.WriteLine(result);

            client1.Close();

            Console.WriteLine("BasicHttpBinding Calculator: ");

            result = client2.Add(1, 2);
            Console.WriteLine(result);

            result = client2.Subtract(1, 2);
            Console.WriteLine(result);

            result = client2.Multiply(2, 3);
            Console.WriteLine(result);

            result = client2.Divide(6, 3);
            Console.WriteLine(result);

            result = client2.Divide(6, 0);
            Console.WriteLine(result);

            result = client2.Summarize(4);
            Console.WriteLine(result);

            result = client2.Summarize(6);
            Console.WriteLine(result);

            client2.Close();

            Console.WriteLine("myEndpoint3 Calculator: ");

            result = client3.Add(1, 2);
            Console.WriteLine(result);

            result = client3.Subtract(1, 2);
            Console.WriteLine(result);

            result = client3.Multiply(2, 3);
            Console.WriteLine(result);

            result = client3.Divide(6, 3);
            Console.WriteLine(result);

            result = client3.Divide(6, 0);
            Console.WriteLine(result);

            result = client3.Summarize(4);
            Console.WriteLine(result);

            result = client3.Summarize(6);
            Console.WriteLine(result);

            client3.Close();

            Console.ReadKey();
        }
    }
}
