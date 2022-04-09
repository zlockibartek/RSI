using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GRPCproto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting gRPC Client");
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new GRPCservice.GRPCserviceClient(channel);

            Console.Write("Enter the name: ");
            String str = Console.ReadLine();
            int val = 21;

            var reply = await client.GrpcProcAsync(new GrpcRequest
            {
                Name = str,
                Age = val
            });
            Console.WriteLine("From server: " + reply.Message);
            Console.WriteLine("From server: " + val + " years = " + reply.Days + " days");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }
    }
}
