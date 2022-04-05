import java.io.File;
import java.io.FileInputStream;
import java.rmi.Naming;

public class Client {

    public static void main(String[] args) {
        MyData.info();
	    Worker worker;

	    if (args.length == 0) {
            System.out.println("No RMI object found");
            return;
        }

	    String address = args[0];
        try {
            worker = (Worker) Naming.lookup(address);
        } catch (Exception e) {
            System.out.println("Can not get reference to " + address);
            return;
        }
        System.out.println("Reference to " + address + " was found");

        try {
            String className = "MyData";

            ResultType result;
            TaskImpl task = new TaskImpl();
            Object[] params = {"hello", 8};
            result = (ResultType) worker.wCompute(task, params);
            System.out.println("Result description: " + result.result_description);
            System.out.println("Result: " + result.result);
        } catch (Exception e) {
            System.out.println("Error while computing");
            e.printStackTrace();
        }
    }
}
