using Grpc.Core;
using Grpc.Net.Client;
using grpcService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grpc.Tests
{
    public class CustomerServiceTest
    {
        private static GrpcChannel channel;
        const string Host = "localhost";
        private static Customer.CustomerClient customerClient;

        [OneTimeSetUp]
        public void Init()
        {
            channel = GrpcChannel.ForAddress("https://localhost:5001");
        }
    

        [Test]
        static async Task Unray_GetCustomerInfo_GetcustomerFromServer(int userId)
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

            Assert.AreEqual("", "");
        }

    }
}
