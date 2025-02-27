using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyCookBookApp.Models;

namespace MyCookBookApp.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Recipe>?> GetRecipesAsync()
        {
            var response = await
            _httpClient.GetAsync("http://localhost:5044/api/recipe");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Recipe>?>(json);
        }

        // Search recipes by name
        public async Task<List<Recipe>> SearchRecipesAsync(string query)
        {
            var payload = new { Query = query };

            var content = new StringContent(JsonConvert.SerializeObject(payload),
            Encoding.UTF8, "application/json");

            var response = await
            _httpClient.PostAsync("http://localhost:5044/api/recipe/search", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Recipe>?>(responseString);
        }
    }
}