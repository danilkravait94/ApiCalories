using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Xml;
using System;

namespace MyOwnApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        [HttpGet("{name}")]
        public string Get(string name)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetTranslate(name));

            string json = JsonConvert.SerializeXmlNode(doc);
            JObject search = JObject.Parse(json);
            Temperatures Str = JsonConvert.DeserializeObject<Temperatures>(search.ToString());
            return Str.String.Text;
        }
        public static string GetTranslate(string text)
        {
            var client = new RestClient($"https://microsoft-azure-translation-v1.p.rapidapi.com/translate?from=ru&to=en&text={text}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "microsoft-azure-translation-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "f3c3fd7010msh12f3c95b0b41b52p12dbd8jsnf07fab2c9479");
            request.AddHeader("accept", "application/json");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

    }
    public partial class Temperatures
    {
        [JsonProperty("string")]
        public String String { get; set; }
    }

    public partial class String
    {
        [JsonProperty("-xmlns")]
        public Uri Xmlns { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}