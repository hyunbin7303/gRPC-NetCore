using grpc.Domain;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
namespace grpcService.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }
        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();
            if (request.UserId == 1)
            {
                output.FName = "Kevin";
                output.LName = "Park";
                output.Email = "hyunbin7303@gmail.com";
                output.Age = 27;
            }
            else if (request.UserId == 2)
            {
                output.FName = "Doosan";
                output.LName = "Baek";
            }
            else
            {
                output.FName = "Julio";
                output.LName = "Rivas";
            }
            return Task.FromResult(output);
        }
        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FName = "Kevin",
                    LName = "Park",
                    Email = "hyunbin7303@gmail.com",
                    Age = 27,
                    IsAlive = true
                },
                new CustomerModel
                {
                    FName = "Doosan",
                    LName = "Baek",
                    Email = "Doosan@gmail.com",
                    Age = 29,
                    IsAlive = true
                },
                    new CustomerModel
                {
                    FName = "Habib",
                    LName = "Something",
                    Email = "Habib@gmail.com",
                    Age = 24,
                    IsAlive = true
                },

            };
            foreach(var customer in customers)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(customer);
            }
        }
        public override Task<CustomerModel> GetCustomerOrders(CustomerLookupModel request, ServerCallContext context)
        {
            return base.GetCustomerOrders(request, context);
        }
    }
}
