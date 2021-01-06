using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var response = new HelloReply { Message = "SayHello Server got message :  " + request.Name };
            return Task.FromResult(response);
        }
        // Server streaming method. 
        // gets the request message as a parameter. 
        // The client has no way to send additional messages or data once the server streaming method has started.
        public override async Task SayHelloStream(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for (int i = 0; i<10; i++)
            {
                var response = new HelloReply { Message = "Hello" + request.Name + " " + i };
                await responseStream.WriteAsync(response);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        //A client can cancel the call when it's no longer needed; The cancellationToken should be used on the server with async methods so that:
        // Any async work is cancelled together with the streaming call.
        public override async Task SayHelloStream_useCt(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            while(!context.CancellationToken.IsCancellationRequested)
            {
                var response = new HelloReply { Message = "Hello" + request.Name};
                await responseStream.WriteAsync(response);
                await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
            }
        }

        // Streaming from client.
        public override async Task<HelloReply> SayHelloFromClient(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                var mmsg = requestStream.Current;
            }
            return new HelloReply();
        }

        // streaming Bi-directional streaming
        //Sends a response for each request.
        public override async Task StreamingBothWays(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            await foreach(var msg in requestStream.ReadAllAsync())
            {
                await responseStream.WriteAsync(new HelloReply());
            }
        }
    }
}
