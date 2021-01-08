using Grpc.Core;
using Grpc.Net.Client;
using grpcService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpcClient.Tests
{
    public class CustomerClientTest
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
        Server server;
        private static Customer.CustomerClient customerClient;
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
                while (await call.ResponseStream.MoveNext())
                {
                    var currentCustomer = call.ResponseStream.Current;
                    Console.WriteLine($"{currentCustomer.FName} {currentCustomer.LName} : {currentCustomer.Email}");
                }
            }
        }
    }
}
