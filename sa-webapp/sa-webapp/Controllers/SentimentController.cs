using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var camelCaseLoad = JsonConvert.SerializeObject(value, settings);
            var content = new StringContent(camelCaseLoad, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("/analyse/sentiment", content);

            if (!result.IsSuccessStatusCode) return BadRequest(value);

            var sentiment = await result.Content.ReadAsAsync<SentimentModel>();
            return Ok(sentiment);
        }
    }
}
