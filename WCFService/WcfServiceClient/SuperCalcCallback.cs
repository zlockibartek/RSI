using CallbackService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient.ServiceReference3;

namespace WcfServiceClient
{
    class SuperCalcCallback : ServiceReference3.ISuperCalcCallback
    {
        public void FactorialResult(double result)
        {
            //here the result is consumed
            Console.WriteLine(" Factorial = {0}", result);
        }
        public void DoSomethingResult(string info)
        {
            //here the result is consumed
            Console.WriteLine(" Calculations: {0}", info);
        }

        public void FibonacciResult(int result)
        {
            Console.WriteLine(" Fibonacci: {0}", result);
        }

        public void RecordResult(List<PersonalData> datas)
        {
            foreach (var data in datas)
            {
                Console.WriteLine(data.age + " " + data.name);

            }
        }

        public void RecordResult(PersonalData[] data)
        {
            throw new NotImplementedException();
        }
    }
}
