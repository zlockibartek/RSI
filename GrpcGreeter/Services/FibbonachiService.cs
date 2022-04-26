using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcGreeter.Services
{
    public class FibbonachiService : Fibbonachi.FibbonachiBase
    {
        private readonly ILogger<GreeterService> _logger;
        public FibbonachiService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<FibbonachiReply> countFibbonachi(FibbonachiRequest request, ServerCallContext context)
        {
            var reply = new FibbonachiReply();
            reply.Message = fibbonachi(request.Value);
            return Task.FromResult(reply);
        }

        private ulong fibbonachi(int n)
        {
            ulong p1 = 0;
            ulong p2 = 0;
            ulong c = 1;
            for (int i =0; i< n; i++)
            {
                p2 = p1;
                p1 = c;
                c = p1 + p2;
            }
            return c;
        }
    }
}
