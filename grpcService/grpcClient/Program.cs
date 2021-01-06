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
            await testing_getHeader();

            await testing_product();
            //await testing_UnaryCall();
            //await testing_basic();
            //await testing_ServerStreamingCall();
            //await testing_ServerStreamingCall_ct();
            //await testing_customer(2);
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
        static async Task testing_UnaryCall()
        {
            Greeter.GreeterClient client = new Greeter.GreeterClient(channel);
            // grpc-internal-encoidng-request is a special metadata value that tells the client to compress the request.
            //This metadata uis only used in the client is not sent as a header to the server
            var metadata = new Metadata();
            metadata.Add("grpc-internal-encoding-request", "gzip");
            var response = await client.SayHelloAsync(new HelloRequest { Name = "KevinCLient" }, headers: metadata);
            Console.WriteLine("From server : " + response.Message);
        }
        static async Task testing_customer(int userId)
        {
            var customerClient = new Customer.CustomerClient(channel);
            var clientRequested = new CustomerLookupModel { UserId = userId };
            var customer = await customerClient.GetCustomerInfoAsync(clientRequested);
            Console.WriteLine($"{customer.FName} {customer.LName}");
            Console.WriteLine();
            Console.WriteLine("New customer List : ");
            using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    var currentCustomer = call.ResponseStream.Current;
                    Console.WriteLine($"{currentCustomer.FName} {currentCustomer.LName} : {currentCustomer.Email}");
                }
            }
        }
        static async Task testing_Bidrectional()
        {
            var greaterClient = new Greeter.GreeterClient(channel);
            //using (var call = customerClient.)
            using(var call = greaterClient.StreamingBothWays())
            {
                while(await call.ResponseStream.MoveNext())
                {

                }
            }
        }
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

        static async Task testing_product()
        {
            var client = new Product.ProductClient(channel);
            var model = await client.GetNameAsync(new New  { Name = "PS5"});

            Console.WriteLine(model.Name);
        }
    }
}
