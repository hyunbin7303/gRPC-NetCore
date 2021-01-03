using Grpc.Core;
using Grpc.Net.Client;
using grpcService;
using System;
using System.Threading.Tasks;
namespace grpcClient
{

    // both side should know about proto files. 

    class Program
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");

        static async Task Main(string[] args)
        {

            await testing_ServerStreamingCall();

        }

        static async Task testing_basic()
        {
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(new HelloRequest
            {
                Name = ".Net Conf"
            });
            Console.WriteLine("From server : " + response.Message);
        }
        static async Task testing_ServerStreamingCall()
        {
            var client = new Greeter.GreeterClient(channel);
            var call = client.SayHelloStream(new HelloRequest
            {
                Name = "Kevin Park Streaming "
            });
            await foreach (var item in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine("From Server : "+ item.Message);
            }
        }


        //gRPC workflow take place:
        //Protobufs --> protoc --> generated code /stubs --> client/server
        // You create your proto files, defining nol

    }
}
