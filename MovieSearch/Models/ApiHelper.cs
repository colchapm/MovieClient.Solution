using System.Threading.Tasks;
using RestSharp;

namespace MovieSearch.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"movies", Method.GET);
      var response = await client.ExecuteTaskAsync(request);

      return response.Content;
    }
    
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"movies/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);

      return response.Content;
    }

    public static async Task Post(string newMovie)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"movies", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMovie);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newMovie)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"movies/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMovie);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"movies/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}