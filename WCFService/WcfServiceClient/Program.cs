using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfService2;
using WcfServiceClient.ServiceReference2;
using WcfServiceClient.ServiceReference2;
using WcfServiceClient.ServiceReference3;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
                        SuperCalcCallback myCbHandler = new SuperCalcCallback();
                        InstanceContext instanceContext = new InstanceContext(myCbHandler);
            while(true)
            {
                Console.WriteLine("Choose action:");
                Console.WriteLine("0. Leave");
                Console.WriteLine("1. Add complex numbers");
                Console.WriteLine("2. Factorial");
                Console.WriteLine("3. Fibonacci");
                Console.WriteLine("4. Records");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        ServiceReference1.CalculatorClient client1 = new ServiceReference1.CalculatorClient("WSHttpBinding_ICalculator");
                        Console.WriteLine("Type first number:\nReal:");
                        var real1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Imaginary:");
                        var imag1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Type first number:\nReal:");
                        var real2 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Imaginary:");
                        var imag2 = float.Parse(Console.ReadLine());

                        ComplexNum cnum1 = new ComplexNum(real1, imag1);
                        ComplexNum cnum2 = new ComplexNum(real2, imag2);
                        ComplexNum result1 = client1.addCNum(cnum1, cnum2);
                        Console.WriteLine(" addCNum(...) = ({0}; {1})", result1.real, result1.imag);
                        client1.Close();
                        break;
                    case 2:
                        ServiceReference3.SuperCalcClient client2 = new ServiceReference3.SuperCalcClient(instanceContext);
                        Console.WriteLine("Type factorial number:");
                        double value1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("...call of Factorial({0})...", value1);
                        client2.Factorial(value1);
                        Console.ReadLine();
                        client2.Close();
                        break;
                    case 3:
                        ServiceReference3.SuperCalcClient client3 = new ServiceReference3.SuperCalcClient(instanceContext);
                        Console.WriteLine("Type fibonacci number:");
                        int value3 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("...call of Fibonacci({0})...", value3);
                        client3.Fibonacci(value3);
                        Console.ReadLine();
                        client3.Close();
                        break;
                    case 4:
                        ServiceReference3.SuperCalcClient client4 = new ServiceReference3.SuperCalcClient(instanceContext);
                        Console.WriteLine("Type fibonacci number:");
                        int value4 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("...call of Fibonacci({0})...", value4);
                        //client4.addRecord("Bartek", 22);
                        Console.ReadLine();
                        client4.Close();
                        break;
                    default:
                        break;
                }
            }

            

        }
    }
}
