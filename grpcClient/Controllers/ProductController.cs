using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService;
using Microsoft.AspNetCore.Mvc;

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

            //var clientRequested = new CategoryModel() { Name = "Phone" };

            //var product = await client.CreateNewCategoryAsync(clientRequested);

            //Console.WriteLine($"{product.Name}");

            return Ok();
        }
    }
}