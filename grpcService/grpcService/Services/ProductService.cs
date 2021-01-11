using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grpc.Domain;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace grpcService.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly ILogger<ProductService> _logger;

        public override Task<ProductModel> GetName(New request, ServerCallContext context)
        {
           var response = new ProductModel { Amount = 23, Name = request.Name };
           return Task.FromResult(response);
        }
        public override Task GetAllProduct(GetAllProductRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context)
        {
            return base.GetAllProduct(request, responseStream, context);
        }
        public override Task<ProductModel> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            return base.GetProduct(request, context);
        }
        public override Task<ProductModel> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            return base.AddProduct(request, context);
        }
        public override Task<ProductModel> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            return base.UpdateProduct(request, context);
        }
        public override Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            return base.DeleteProduct(request, context);
        }

    }
}
