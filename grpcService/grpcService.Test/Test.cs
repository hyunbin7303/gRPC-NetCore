using Grpc.Net.Client;
using grpcService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grpcService.Test
{
    class Test
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");

        //public LazyCounterServiceShould(TestServerFixture testServerFixture)
        //{
        //    var channel = testServerFixture.GrpcChannel;
        //    _clientService = channel.CreateGrpcService<ILazyCounterService>();
        //}
        private readonly ProductService _clientService;
        

        public void testing()
        {
            //var client = new Product.ProductClient(channel);
            //var model = await client.GetNameAsync(new New { Name = "PS5" });
            //Console.WriteLine(model.Name);
        }
    
    }
}
