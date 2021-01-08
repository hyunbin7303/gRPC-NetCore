using Grpc.Core;
using Grpc.Net.Client;
using grpcService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpcClient.Tests
{
    public class ProductClientTest
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
        Server server;
        private static Product.ProductClient productClient;


        [Test]
        static async Task testing_product()
        {
            productClient = new Product.ProductClient(channel);
            var model = await productClient.GetNameAsync(new New { Name = "PS5" });
            Console.WriteLine(model.Name);
        }
    }
}
