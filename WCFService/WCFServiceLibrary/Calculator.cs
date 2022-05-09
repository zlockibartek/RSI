using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Calculator : ICalculator
    {
        private static double sum = 0;

        public double Add(double n1, double n2)
        {
            Console.WriteLine("Adding " + n1 + " and " + n2);
            Console.WriteLine("Result is " + (n1 + n2));

            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            Console.WriteLine("Subtracting " + n2 + " from " + n1);
            Console.WriteLine("Result is " + (n1 - n2));

            return n1 - n2;
        }

        public double Multiply(double n1, double n2)
        {
            Console.WriteLine("Multiplying " + n1 + " by " + n2);
            Console.WriteLine("Result is " + (n1 * n2));

            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            Console.WriteLine("Dividing " + n1 + " by " + n2);

            if ( n2 == 0)
            {
                Console.WriteLine("Result of dividing by 0 is undefined");
                return double.NaN;
            }

            Console.WriteLine("Result is " + (n1 / n2));
            return n1 / n2;
        }

        public double Summarize(double n1)
        {
            Console.WriteLine("Adding " + n1 + " to service sum");
            Console.WriteLine("Current sum is " + sum);
            Console.WriteLine("After addition sum is " + (sum + n1));

            sum += n1;

            return sum;
        }
    }
}
