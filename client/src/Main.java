import org.apache.xmlrpc.XmlRpcClient;
import org.apache.xmlrpc.XmlRpcException;

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
            AC cb = new AC();

            int result = 0;
            boolean exit = false;
            while (true)
            {
                System.out.println("Wybierz metodę:");
                System.out.println("1: Fibbonacci");
                System.out.println("2: distance");
                System.out.println("3: show");
                System.out.println("4. primes");
                System.out.println("Aby zakończyć program wprowadź 0");
                result = scan.nextInt();
                switch (result) {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        System.out.println("Podaj parametr n: ");
                        Vector<Integer> n = new Vector<>();
                        n.addElement(scan.nextInt());
                        Object fibResult = srv.execute("MojSerwer.fib",  n);
                        System.out.println(fibResult);
                        break;
                    case 2:
//                        52,229675
//                        21,012230
//                        50,064651
//                        19,944981
                        System.out.println("Podaj parametr lat pierwszej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        System.out.println("Podaj parametr lon pierwszej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        System.out.println("Podaj parametr lat drugiej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        System.out.println("Podaj parametr lon drugiej lokalizacji");
                        distance.addElement(scan.nextDouble());
                        Object distanceResult = srv.execute("MojSerwer.distance", distance);
                        System.out.println(distanceResult);
                        distance.clear();
                        break;
                    case 3:
                        Object showResult = srv.execute("MojSerwer.show", new Vector());
                        System.out.println(showResult);
                        break;
                    case 4:
                        System.out.println("Podaj min: ");
                        primes.addElement(scan.nextInt());
                        System.out.println("Podaj max: ");
                        primes.addElement(scan.nextInt());

                        long startTime = System.currentTimeMillis();
                        srv.executeAsync("MojSerwer.myPrimes", primes, cb);

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
