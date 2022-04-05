import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Server {

    public static void main(String[] args) {
        System.setProperty("java.security.policy", "D:\\Zlocki\\RSI\\out\\production\\server\\srv.policy");
        MyData.info();
	    if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }

	    if (System.getSecurityManager() == null) {
	        System.setSecurityManager(new SecurityManager());
        }
        System.out.println(System.getSecurityManager());
	    try {
            Registry reg = LocateRegistry.createRegistry(1099);
        } catch (RemoteException e) {
	        e.printStackTrace();
        }


	    try {
	        WorkerImpl worker = new WorkerImpl();
	        Naming.rebind(args[0], worker);
            System.out.println("Server is registered now");
        } catch (Exception e) {
            System.out.println("Server cant be registered");
            e.printStackTrace();
        }
    }
}
