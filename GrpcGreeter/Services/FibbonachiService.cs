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

        private int fibbonachi(int n)
        {
            if (n == 0) return 0;
            if (n < 2) return 1;
            return fibbonachi(n-1) + fibbonachi(n-2);
        }
    }
}
