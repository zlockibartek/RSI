import java.rmi.Naming;

public class Client {

    public static void main(String[] args) {
        MyData.info();
	    double res;
	    CalcObject zObj;
	    CalcObject2 zObj2;
	    ResultType res2;
	    InputType inObj;

	    if (args.length == 0) {
            System.out.println("No RMI object found");
            return;
        }

	    String addr = args[0];
	    String addr2 = args[1];

	    try {
            zObj = (CalcObject) Naming.lookup(addr);
        }
	    catch (Exception e) {
            System.out.println("Cannot download the reference to " + addr);
            e.printStackTrace();
            return;
        }

	    inObj = new InputType();
	    inObj.x1 = 101.1;
	    inObj.x2 = 202.2;
        inObj.operation = "add";

        try {
            zObj2 = (CalcObject2) Naming.lookup(addr2);
        }
        catch (Exception e) {
            System.out.println("Cannot download the reference to " + addr2);
            e.printStackTrace();
            return;
        }

        System.out.println("Reference to " + addr + " downloaded");
        System.out.println("Reference to " + addr2 + " downloaded");

        try {
            res = zObj.calculate(0.7, 0.3);
        } catch (Exception e) {
            System.out.println("Error");
            e.printStackTrace();
            return;
        }

	    try {
           res2 = zObj2.calculate(inObj);
        } catch (Exception e) {
            System.out.println("Error");
            e.printStackTrace();
            return;
        }

        System.out.println("Result = " + res);
        System.out.println("Second result = " + res2.result + ", " + res2.result_description);
    }
}
