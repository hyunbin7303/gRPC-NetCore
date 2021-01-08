using Grpc.Core;
using Grpc.Net.Client;
using grpcService;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
namespace grpcClient
{
    [TestFixture]
    class GreeterClientTest
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
        Server server;
        private static Greeter.GreeterClient greeterClient;
        [OneTimeSetUp]
        public void Init()
        {
            //server = new Server(new[] { new ChannelOption(ChannelOptions.SoReuseport, 0) })
            //{
            //    Services = { Math.BindService(new MathServiceImpl()) },
            //    Ports = { { Host, ServerPort.PickUnused, ServerCredentials.Insecure } }
            //};
            //server.Start();
            //channel = new Channel(Host, server.Ports.Single().BoundPort, ChannelCredentials.Insecure);
            //client = new Math.MathClient(channel);
        }

        [Test]
        static async Task testing_basic()
        {
           greeterClient = new Greeter.GreeterClient(channel);
            var response = await greeterClient.SayHelloAsync(new HelloRequest { Name = ".Net Conf" });
            Assert.Equals("", response.Message);
        }

        [Test]
        static async Task testing_ServerStreamingCall()
        {
            greeterClient = new Greeter.GreeterClient(channel);
            var call = greeterClient.SayHelloStream(new HelloRequest
            {
                Name = "Kevin Park Streaming "
            });
            await foreach (var item in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine("From Server : " + item.Message);
            }
        }
        [Test]
        static async Task testing_ServerStreamingCall_ct()// Cancellation Token Testing.
        {
            var client = new Greeter.GreeterClient(channel);
            var call = client.SayHelloStream_useCt(new HelloRequest
            {
                Name = "Kevin Park Streaming "
            });
            await foreach (var item in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine("From Server : " + item.Message);
            }

        }
        [Test]
        static async Task testing_UnaryCall()
        {
            greeterClient = new Greeter.GreeterClient(channel);
            // grpc-internal-encoidng-request is a special metadata value that tells the client to compress the request.
            //This metadata uis only used in the client is not sent as a header to the server
            var metadata = new Metadata();
            metadata.Add("grpc-internal-encoding-request", "gzip");
            var response = await greeterClient.SayHelloAsync(new HelloRequest { Name = "KevinCLient" }, headers: metadata);
            Console.WriteLine("From server : " + response.Message);
        }
        [Test]
        static async Task testing_Bidrectional()
        {
            var greaterClient = new Greeter.GreeterClient(channel);
            //using (var call = customerClient.)
            using (var call = greaterClient.StreamingBothWays())
            {
                while (await call.ResponseStream.MoveNext())
                {

                }
            }
        }
        [Test]
        static async Task testing_getHeader()
        {
            var client = new Greeter.GreeterClient(channel);
            using var call = client.SayHelloAsync(new HelloRequest { Name = "Reuqest name : Kevin" });

            var headers = await call.ResponseHeadersAsync;
            var myValue = headers.GetValue("my-trailer-name");
            Console.WriteLine("Header value " + myValue);
            var response = await call.ResponseAsync;
            Console.WriteLine("Message we've got : " + response);        
        }


    }
}
