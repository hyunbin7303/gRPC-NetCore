using Grpc.Net.Client;
using grpcService;
using System;

namespace grpc.client
{
    class Program
    {
        private static GrpcChannel channel;

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            channel = GrpcChannel.ForAddress("http://localhost:5001");
            var GreeterClient = new Greeter.GreeterClient(channel);
            var response = await GreeterClient.SayHelloAsync(new HelloRequest { Name = ".Net Conf" });
            Console.WriteLine(response.Message);
        }
    }
}
