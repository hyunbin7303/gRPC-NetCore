using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grpc.Domain;
using Grpc.Core;


namespace grpcService.Services
{
    public class ProductService : Product.ProductBase
    {
        public override Task<ProductModel> GetName(New request, ServerCallContext context)
        {
           var response = new ProductModel { Amount = 23, Name = request.Name };
           return Task.FromResult(response);
        }
    }
}
