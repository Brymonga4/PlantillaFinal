using PlantillaFinal.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;

namespace PlantillaFinal.Data;
public class RestService
{
    //Templates
    public List<ModelA>? ItemsA { get; set; }
    public List<ModelB>? ItemsB { get; set; }
    public ModelA? ModelA { get; set; }
    public ModelB? ModelB { get; set; }
    public List<ModelAResults>? ItemsAResults { get; set; }

    //comun
    private HttpClient? client;
    private HttpRequestMessage? request;
    private HttpResponseMessage? response;
    private JsonSerializerOptions serializerOptions;
    public RestService()
    {
        serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

    }

    //Model A
    public async Task<ModelA> GetModelAById(string id)
    {
        using (client = new HttpClient())
        {
            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"SomethinURL/{id}"),
            };
            using (response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                ModelA = JsonSerializer.Deserialize<ModelA>(body, serializerOptions);
                return ModelA;
            }
        }
    }

    public async Task<List<ModelA>> GetAllModelA()
    {

        using (client = new HttpClient())
        {
            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://192.168.16.117:7777/artists/"),
            };
            using (response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Trace.WriteLine(body);
                Trace.WriteLine("Peta aqui");
                var results = JsonSerializer.Deserialize<List<ModelA>>(body, serializerOptions);
                Trace.WriteLine(results);
                ItemsA = results;

                return ItemsA;

            }
        }
    }


    //Model B
    public async Task<ModelB> GetModelBById(string id)
    {
        using (client = new HttpClient())
        {
            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"SomethinURL/{id}"),
            };
            using (response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                ModelB = JsonSerializer.Deserialize<ModelB>(body, serializerOptions);
                return ModelB;
            }
        }
    }

    public async Task<List<ModelB>> GetAllModelB()
    {

        using (client = new HttpClient())
        {
            request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://192.168.16.117:7777/images/"),
            };
            using (response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Trace.WriteLine(body);
                Trace.WriteLine("Peta aqui");
                var results = JsonSerializer.Deserialize<List<ModelB>>(body, serializerOptions);
                Trace.WriteLine(results);
                ItemsB = results;

                return ItemsB;

            }
        }
    }

}
