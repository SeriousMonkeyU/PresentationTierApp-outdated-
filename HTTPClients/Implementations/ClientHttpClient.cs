using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HTTPClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.Implementations;

public class ClientHttpClient : IClientService
{
    private HttpClient httpClient;

    public ClientHttpClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Client> Create(ClientCreationDTO dto)
    {
        string uri = "http://localhost:8090/clients";
        string clientSerialized = JsonSerializer.Serialize(dto);
        StringContent content = new StringContent(
            clientSerialized,
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage response = await httpClient.PostAsync(uri, content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ToString());
        }
        string result = await response.Content.ReadAsStringAsync();
        Client client = JsonSerializer.Deserialize<Client>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return client;
    }
}