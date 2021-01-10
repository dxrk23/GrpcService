using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using GrpcService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpcClient.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetProductAsync()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Product.ProductClient(channel);

            var clientRequested = new ProductLookupModel { Id = 1 };

            var product = await client.GetProductInfoAsync(clientRequested);

            Console.WriteLine($"{product.Name} {product.Price}");

            return Ok();
        }
    }
}
