using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using DogDirectory.viewmodels;



namespace DogDirectory.Controllers
{
    public class DogDirectoryController : ApiController
    {
        [HttpGet]
        [Route("api/DogDirectory/getallbreeds")]
        public IHttpActionResult getallbreeds()
        {
            var response = getallbreedsfromwebapi("breeds/list");
            Breeds result = JsonConvert.DeserializeObject<Breeds>(response.Result);
            if (result.status == "success")
            {
                return Ok(new { breeds = result.message });
            }
            else
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/DogDirectory/getrandomimage")]
        public IHttpActionResult getrandomimage(string Breed)
        {
            ;
            var response = getallbreedsfromwebapi(string.Format("breed/{0}/images/random", Breed));
            BreedImage result = JsonConvert.DeserializeObject<BreedImage>(response.Result);
            if (result.status == "success")
            {
                return Ok(new { image = result.message });
            }
            else
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public async Task<string> getallbreedsfromwebapi(string url)
        {
          
            string jresult = await RunAsync("api/" + url);           
            return jresult;
            
        }


        public static async Task<string> RunAsync(string url)
        {
            string domain = "https://dog.ceo/";
            string jsonString = string.Empty;              
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri(domain);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        jsonString = await response.Content.ReadAsStringAsync();

                    }
                    return jsonString;
                }
            
        }

    }
}