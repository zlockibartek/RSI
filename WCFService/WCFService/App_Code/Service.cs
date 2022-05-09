using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : ICalculator
{
	public double Add(double n1, double n2)
    {
        Console.WriteLine("Adding " + n1 + " and " + n2);
        Console.WriteLine("Result is " + (n1 + n2));
        return n1 + n2;
    }

    public double Sub(double n1, double n2)
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
        if (n2 == 0)
        {
            Console.WriteLine("You cannot divide by 0! Result is undefined");
            return double.NaN;
        }

        Console.WriteLine("Result is " + (n1 / n2));

        return n1 / n2;
    }
}
