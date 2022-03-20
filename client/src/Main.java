import org.apache.xmlrpc.XmlRpcClient;

import java.util.Scanner;
import java.util.Vector;

public class Main {
    public static void main(String[] args) {
        MyData.info();
	    try {
            XmlRpcClient srv = new XmlRpcClient("http://192.168.0.73:8080");
            Scanner scan = new Scanner(System.in);
            Vector<Integer> primes = new Vector<>();
            Vector<Double> distance = new Vector<>();
//            primes.addElement(2);
//            primes.addElement(4);
            AC cb = new AC();
//            srv.executeAsync("MojSerwer.myPrimes", primes, cb);
            Object show = srv.execute("MojSerwer.show", new Vector());
            System.out.println(show);

            int result = 0;
            boolean exit = false;
            while (true)
            {
                System.out.println("Wybierz metodę:");
                System.out.println("1: myPrimes");
                System.out.println("2: distance");
                System.out.println("3: ");
                System.out.println("4: show");
                System.out.println("Aby zakończyć program wprowadź 0");
                result = scan.nextInt();
                switch (result) {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        System.out.println("Podaj parametr min: ");
                        primes.addElement(scan.nextInt());
                        System.out.println("Podaj parametr max: ");
                        primes.addElement(scan.nextInt());
                        srv.execute("MojSerwer.myPrimes", primes);
                        primes.clear();
                        break;
                    case 2:
                        System.out.println("Podaj parametr lat pierwszej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        System.out.println("Podaj parametr lon pierwszej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        System.out.println("Podaj parametr lat drugiej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        System.out.println("Podaj parametr lon drugiej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        srv.execute("MojSerwer.distance", distance);
                        distance.clear();
                        break;
                    case 3:
                        break;
                    case 4:
                        srv.executeAsync("MojSerwer.show", new Vector(), cb);
                        break;
                    default:
                        exit = true;
                        break;
                }
                if (exit) {
                    break;
                }
            }

        } catch (Exception exception) {
            System.err.println("Client XML-RPC: " + exception);
        }
    }
}
