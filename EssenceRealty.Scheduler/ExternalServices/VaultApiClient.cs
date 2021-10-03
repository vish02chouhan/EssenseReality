using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler.ExternalServices
{
    public class VaultApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<VaultApiClient> _logger;

        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public VaultApiClient(HttpClient httpClient, ILogger<VaultApiClient> logger,
            IOptions<VaultApiClientOptions> apiOptions)
        {
            _httpClient = httpClient;
            _logger = logger;

            var endpointAddress = apiOptions?.Value?.BaseAddress ?? string.Empty;
            var bearerToken = apiOptions?.Value?.BearerToken ?? string.Empty;
            var apiKey = apiOptions?.Value?.ApiKey ?? string.Empty;

            if (string.IsNullOrEmpty(endpointAddress))
                throw new Exception("Invalid API base address");

            _httpClient.BaseAddress = new Uri(endpointAddress);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        }

        public async Task<string> GetEssenceData(string uri, CancellationToken cancellationToken = default)
        {
           
            using var httpResponse = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            try
            {
               return await httpResponse.Content.ReadAsStringAsync();
              
            }
            catch // Could be ArgumentNullException or UnsupportedMediaTypeException
            {
                Console.WriteLine("HTTP Response was invalid or could not be deserialised.");
            }

            return null;
        }
    }
}
