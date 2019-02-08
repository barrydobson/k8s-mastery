using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sa_webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            var client = _httpClientFactory.CreateClient("sa-logic");
            var result = await client.GetStringAsync("/analyse/sentiment");
            return Ok(result);
        }
    }
}
