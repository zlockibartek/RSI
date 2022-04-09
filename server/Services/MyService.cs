using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GRPCproto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace gRPCserver
{
    public class MyService : GRPCservice.GRPCserviceBase
    {

        private static string tempString = "";

        private readonly ILogger<MyService> _logger;
        public MyService(ILogger<MyService> logger)
        {
            _logger = logger;
        }

        public override Task<GrpcResponse> GrpcProc(GrpcRequest request, ServerCallContext context)
        {
            string msg;
            int val;
            val = request.Age * 12 * 365;
            msg = "Hello " + request.Name + " being " + request.Age + " years old.";
            return Task.FromResult(new GrpcResponse { Message = msg, Days = val });
        }

        public override Task<RepeatStringReply> RepeatString(RepeatStringRequest request, ServerCallContext context)
        {
            Console.WriteLine("Called repeatString task");
            tempString = request.Str;
            return Task.FromResult(new RepeatStringReply
            {
                Result = "".PadLeft(request.Num, 'X').Replace("X", request.Str)
            });
        }

        public override async Task<TimeoutPrintReply> TimeoutPrint(TimeoutPrintRequest request, ServerCallContext context)
        {
            Console.WriteLine("Called async timeout print task");
            await Task.Delay((int)request.Secs * 1000);
            try
            {
                return await Task.FromResult(new TimeoutPrintReply
                {
                    Result = tempString[request.Index] + ""
                });
            }
            catch (Exception)
            {
                Console.WriteLine("String does not have as many chars!");
                return await Task.FromResult(new TimeoutPrintReply
                {
                    Result = "Something went wrong"
                });
            }
        }
    }
}
