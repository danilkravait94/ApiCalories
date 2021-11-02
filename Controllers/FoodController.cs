using Microsoft.AspNetCore.Mvc;
using MyOwnApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyOwnApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {

        [HttpGet("{name}")]
        public async Task<Food> GetAsync(string name)
        {
            JObject search;
            if (name.Split('&').ToList().Count == 2)
            {
                List<string> doublemame = name.Split('&').ToList();
                search = JObject.Parse(await GetFood($"https://api.edamam.com/api/food-database/parser?nutrition-type=logging&ingr={doublemame[0]}%20{doublemame[1]}&app_id=a3574067&app_key={your_api_key}"));
            }
            else
            {
                search = JObject.Parse(await GetFood($"https://api.edamam.com/api/food-database/parser?nutrition-type=logging&ingr={name}&app_id=a3574067&app_key={your_api_key}"));
            }
            Food food = JsonConvert.DeserializeObject<Food>(search["hints"][0]["food"].ToString());
            food.Round();
            return food;
        }
        public static async Task<string> GetFood(string linkoffood)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(linkoffood);
            HttpContent content = response.Content;
            string result = await content.ReadAsStringAsync();
            return result;
        }
    }
}
