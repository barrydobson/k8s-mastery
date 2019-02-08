using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Post([FromBody] string value)
        {
            var client = _httpClientFactory.CreateClient("sa-logic");
            string result = await client.GetStringAsync("");

        }
    }
}
