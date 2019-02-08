using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace sa_webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SentimentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SentenceModel value)
        {
            var client = _httpClientFactory.CreateClient("sa-logic");
            var result = await client.PostAsJsonAsync("/analyse/sentiment", value);
            var sentiment = await result.Content.ReadAsAsync<SentimentModel>();
            return Ok(sentiment);
        }
    }
}
