using System;

namespace GrpcClient
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Grpc.Net.Client;
    using GrpcClient;
    using System.Net;
    using GrpcGreeter;

    class MyData
    {
        public static void static_info()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Paweł Kolman 256778");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion.ToString());
            Console.WriteLine(Environment.Version.ToString());
            Console.WriteLine(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString());

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyData.static_info();
     
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
           
            Boolean end = false;
            String str = "";

            while (!end)
            {
                Console.Write("Enter option: \n");
                Console.Write("1. Repeat\n2. Show age as days\n3. Count Fibbonachi\n0. Leave\n");
                int option;
                str = Console.ReadLine();

                if (int.TryParse(str, out option))
                {
                    switch (option)
                    {
                     
                        case 1:
                            var client2 = new Greeter.GreeterClient(channel);

                            Console.Write("Enter word: ");
                            str = Console.ReadLine();
                            int repeat;
                            Console.Write("Enter repeat number: ");
                            string str2 = Console.ReadLine();
                            if (int.TryParse(str2, out repeat))
                            {


                                var reply2 = client2.SayHello(new HelloRequest
                                {
                                    Name = str,
                                    Repeat = repeat
                                }) ;
                                Console.WriteLine("From server: " + reply2.Message);
                            }
                            break;

                        case 2:
                            var client4 = new GrpcService.GrpcServiceClient(channel);

                            int age;

                            Console.Write("Enter age: ");
                            str = Console.ReadLine();

                            if (int.TryParse(str, out age))
                            {
                                Console.Write("Enter name: ");
                                str = Console.ReadLine();
                                var reply = client4.GrpcProc(new GrpcRequest
                                {
                                    Name = str,
                                    Age = age
                                });
                                Console.WriteLine("From server: days " + reply.Days + ", message " + reply.Message);
                            }

                            else
                                Console.WriteLine("Wrong value!");

                            break;


                        case 3:
                            var client5 = new Fibbonachi.FibbonachiClient(channel);

                            int num5;

                            Console.Write("Enter number to get n: ");
                            str = Console.ReadLine();

                            if (int.TryParse(str, out num5))
                            {
                                var reply = client5.countFibbonachi(new FibbonachiRequest
                                {
                                    Value = num5
                                });
                                Console.WriteLine("From server: " + reply.Message);

                            }

                            else
                                Console.WriteLine("Wrong value!");

                            break;

                        case 0:
                            end = true;
                            break;
                    }
                }

                else
                    Console.WriteLine("Wrong value!");
            }

            Console.WriteLine("Stopping gRPC Client");
            channel.ShutdownAsync().Wait();
        }
    }
}
