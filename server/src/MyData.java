import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.net.*;
import java.net.InetAddress;

public class MyData {
    public static void info() {
        DateTimeFormatter f = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();
        String ip = null;
        try {
            ip = InetAddress.getLocalHost().getHostAddress();
        }
        catch (UnknownHostException e) {
            e.printStackTrace();
        }

        System.out.println("---------- MyData ----------");
        System.out.println(f.format(now));
        System.out.println("Paweł Kolman 256778");
        System.out.println(System.getProperty("user.name"));
        System.out.println(System.getProperty("os.name"));
        System.out.println(System.getProperty("java.version"));
        System.out.println(ip);
        System.out.println("----------------------------");
    }
}
