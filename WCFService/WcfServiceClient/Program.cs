using CallbackService;
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
                Console.WriteLine("2. Mult complex numbers");
                Console.WriteLine("3. Div complex numbers");
                Console.WriteLine("4. Factorial");
                Console.WriteLine("5. Remove record");
                Console.WriteLine("6. Add Record");
                Console.WriteLine("7. Count Records");

                var leave = false;
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        leave = true;
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
                        ServiceReference1.CalculatorClient clientMult = new ServiceReference1.CalculatorClient("WSHttpBinding_ICalculator");
                        Console.WriteLine("Type first number:\nReal:");
                        var realMult1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Imaginary:");
                        var imagMult1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Type first number:\nReal:");
                        var realMult2 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Imaginary:");
                        var imagMult2 = float.Parse(Console.ReadLine());

                        ComplexNum cnumMult1 = new ComplexNum(realMult1, imagMult1);
                        ComplexNum cnumMult2 = new ComplexNum(realMult2, imagMult2);
                        ComplexNum resultMult = clientMult.multCNum(cnumMult1, cnumMult2);
                        Console.WriteLine(" multCNum(...) = ({0}; {1})", resultMult.real, resultMult.imag);
                        clientMult.Close();
                        break;
                    case 3:
                        ServiceReference1.CalculatorClient clientDiv = new ServiceReference1.CalculatorClient("WSHttpBinding_ICalculator");
                        Console.WriteLine("Type first number:\nReal:");
                        var realDiv1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Imaginary:");
                        var imagDiv1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Type first number:\nReal:");
                        var realDiv2 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Imaginary:");
                        var imagDiv2 = float.Parse(Console.ReadLine());

                        ComplexNum cnumDiv1 = new ComplexNum(realDiv1, imagDiv1);
                        ComplexNum cnumDiv2 = new ComplexNum(realDiv2, imagDiv2);
                        ComplexNum resultDiv = clientDiv.divCNum(cnumDiv1, cnumDiv2);
                        Console.WriteLine(" divCNum(...) = ({0}; {1})", resultDiv.real, resultDiv.imag);
                        clientDiv.Close();
                        break;
                    case 4:
                        ServiceReference3.SuperCalcClient client2 = new ServiceReference3.SuperCalcClient(instanceContext);
                        Console.WriteLine("Type record number:");
                        double value1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("...call of Factorial({0})...", value1);
                        client2.Factorial(value1);
                        Console.ReadLine();
                        client2.Close();
                        break;
                    case 5:
                        ServiceReference3.SuperCalcClient client4 = new ServiceReference3.SuperCalcClient(instanceContext);
                        Console.WriteLine("Type age:");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Type name:");
                        string name = Console.ReadLine();
                        client4.removeRecord(new PersonalData(name, age));

                        Console.ReadLine();
                        client4.Close();
                        break;
                    case 6:
                        ServiceReference3.SuperCalcClient clientAdd = new ServiceReference3.SuperCalcClient(instanceContext);
                        Console.WriteLine("Type age:");
                        int ageAdd = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Type name:");
                        string nameAdd = Console.ReadLine();
                        clientAdd.addRecord(nameAdd, ageAdd);
                        
                        Console.ReadLine();
                        clientAdd.Close();
                        break;
                    default:
                        break;
                }
                if (leave)
                {
                    break;
                }
            }

            

        }
    }
}
