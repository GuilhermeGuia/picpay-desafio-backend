using DesafioPicPay.Domain.Services.AuthNotify.Dto;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace DesafioPicPay.Domain.Services.AuthNotify;

public class AuthNotifyService : IAuthNotifyService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AuthNotifyService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task<AuthorizationResponseOutput> GetAuthorization()
    {
        var urlAuthorization = _configuration.GetSection("AuthNotify")["authorization"];

        var request = await _httpClient.GetAsync(urlAuthorization);

        var mappedContent = await request.Content.ReadFromJsonAsync<AuthorizationResponseOutput>();

        return mappedContent;
    }

    public async Task SendNotification()
    {
        var urlAuthorization = _configuration.GetSection("AuthNotify")["notification"];
        await _httpClient.PostAsync(urlAuthorization, null);
    }
}
