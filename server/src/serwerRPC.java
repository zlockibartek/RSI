import org.apache.xmlrpc.WebServer;

public class serwerRPC {

    public static void main(String[] args) {
        try {
            System.out.println("XML_RPC Server is startnig...");
            int port = 8080;
            WebServer server = new WebServer(port);

            server.addHandler("MojSerwer", new serwerRPC());
            server.start();

            System.out.println("Server listening on port " + port);
        } catch (Exception exception) {
            System.err.println("Server XML-RPC: " + exception);
        }
    }

    public int execAsy(int x) {
        System.out.println("start of async call...");
        try {
            Thread.sleep(x);
        } catch (InterruptedException ex) {
            ex.printStackTrace();
            Thread.currentThread().interrupt();
        }
        System.out.println("... end of async call");
        return 123;
    }

    public int myPrimes(int min, int max)
    {
        int[] returnArray = new int[2];
        if (min < 1 || max < 1) {
            System.out.println("Podano nieprawidłowe wartości!");
            returnArray[0] = -1;
//            return returnArray;
            return -1;
        }
        if (min > max) {
            System.out.println("Minimum nie może być większe od maksimum!");
            returnArray[0] = -1;
//            return returnArray;
            return -1;
        }
        System.out.println("Przedział wartości od " + min + " do " + max);
        boolean[] sieve = new boolean[max + 1];
        for (int i = 0; i <= max; i++)
        {
            sieve[i] = true;
        }
        double range = Math.sqrt(max);
        for (int i = 2; i < range; i++)
        {
            if (sieve[i])
            {
                for (int j = (i * i); j <= max; j = j + i)
                {
                    sieve[j] = false;
                }
            }
        }
        int maxPrime = 0;
        int result = 0;
        for (int i = min; i <= max; i++) {
            if (sieve[i])
            {
                maxPrime = i;
                result++;
            }
        }
        returnArray[0] = result;
        System.out.println("Ilość liczb pierwszych w przedziale: " + result);
        if (result > 0)
        {
            returnArray[1] = maxPrime;
            System.out.println("Największa liczba pierwsza w przedziale: " + maxPrime);
        }
//        return returnArray;
        return 1;
    }


    public int distance(double lat1, double lon1, double lat2, double lon2)
    {
        Double rad = Math.PI / 100;
        Double radius = 6371.0;
        Double latDistance =  (lat1 - lat2) * rad;
        Double lonDistance = (lon1 - lon2) * rad;
        Double a = Math.sin(latDistance / 2) * Math.sin(latDistance / 2) +
                Math.cos(lat1 * rad)  * Math.cos(lat2 * rad) *
                        Math.sin(lonDistance / 2) * Math.sin(lonDistance / 2);
        Double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        Double distance = radius * c;
        System.out.println("Dystans wynosi: " + distance + "km");
        return 0;

    }


    public String show()
    {
        String message = "distance: metoda liczaca dystans pomiedzy dwoma lokalizacjami; parametry to lat1, lon1, lat2, lon2, ktore odpowiadaja polozeniu geograficznemu dwoch lokalizacji\n";
//        message += "show: metoda wyświetlająca informacje o dostępnych metodach na serwerze; brak parametrów";
        message += "myPrimes: metoda liczaca ilosc liczb pierwszych w podanym przedziale oraz najwieksza znaleziona liczbe pierwsza; parametry: min, max; liczby naturalne wieksze od 1, ktore wskazuja przedzial poszukiwan liczb pierwszych";
        System.out.println(message);
        return message;
    }
}
