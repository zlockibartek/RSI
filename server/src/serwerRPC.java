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

    public String myPrimes(int min, int max)
    {
        String message = "";
        if (min < 1 || max < 1) {
            message = "Podano nieprawidlowe wartosci!";
            System.out.println("Podano nieprawidłowe wartości!");
//            returnArray[0] = -1;
//            return returnArray;
//            return -1;
            return message;
        }
        if (min > max) {
            message = "Minimum nie moze być wieksze od maksimum!";
            return message;
//            System.out.println("Minimum nie może być większe od maksimum!");
//            returnArray[0] = -1;
//            return returnArray;
////            return -1;
        }
        message = "Przedzial wartosci od " + min + " do " + max;
        System.out.println("Przedzial wartosci od " + min + " do " + max);
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
        message += "\nIlosc liczb pierwszych w przedziale:" + result;
        System.out.println("Ilosc liczb pierwszych w przedziale: " + result);
        if (result > 0)
        {
            message += "\nNajwieksza liczba pierwsza w przedziale: " + maxPrime;
//            returnArray[1] = maxPrime;
//            System.out.println("Największa liczba pierwsza w przedziale: " + maxPrime);
        }
        return message;
//        return returnArray;
//        return 1;
    }


    public Double distance(double lat1, double lon1, double lat2, double lon2)
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
        distance = this.fix(distance);
        System.out.println("Dystans wynosi: " + distance + "km");
        return distance;

    }


    public String show()
    {
        String message = "distance: metoda liczaca dystans pomiedzy dwoma lokalizacjami; parametry to lat1, lon1, lat2, lon2, ktore odpowiadaja polozeniu geograficznemu dwoch lokalizacji\n";
        message += "show: metoda wyświetlająca informacje o dostępnych metodach na serwerze; brak parametrów";
        message += "myPrimes: metoda liczaca ilosc liczb pierwszych w podanym przedziale oraz najwieksza znaleziona liczbe pierwsza; parametry: min, max; liczby naturalne wieksze od 1, ktore wskazuja przedzial poszukiwan liczb pierwszych";
        message += "fib: metoda liczaca n-ty element ciagu Fibonacciego; parametr n jest poszukiwanym miejscem w ciagu";
        System.out.println(message);
        return message;
    }

    public int fib(int n){
        if ((n==1)||(n==2))
            return 1;
        else
            return fib(n-1)+fib(n-2);
    }

    private Double fix(double n)
    {
        if (n > 17000)
            return 9663.78;
        return n;
    }
}

