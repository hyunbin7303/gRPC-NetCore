using Grpc.Core;
using Grpc.Net.Client;
using grpcService;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace grpc.Tests
{

    public class GreetServiceTest
    {

        private static GrpcChannel channel;
        const string Host = "localhost";
        private static Greeter.GreeterClient greeterClient;

        [OneTimeSetUp]
        public void Init()
        {
            channel = GrpcChannel.ForAddress("https://localhost:5001");
        }
        [Test]
        public async Task Unray_HelloRequest_GetResponse()
        {
            var GreeterClient = new Greeter.GreeterClient(channel);
            var response = await GreeterClient.SayHelloAsync(new HelloRequest { Name = "kevin" });
            Assert.AreEqual("SayHello Server got message :  kevin", response.Message);
        }
        [Test]
        public async Task StreamingServer_SyHelloStream_GetResponse()
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
        public async Task StreamingServer_CheckCancellationToken_gerMessage()// Cancellation Token Testing.
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
        public async Task Anray_CancellationToken_GetResponse()
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
        public async Task testing_Bidrectional()
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
        public async Task anray_sayHello_getHeader()
        {
            var client = new Greeter.GreeterClient(channel);
            using var call = client.SayHelloAsync(new HelloRequest { Name = "Kevin" });
            var headers = await call.ResponseHeadersAsync;
            var myValue = headers.GetValue("my-trailer-name");
            // not sure How I can test?
        }
    }
}