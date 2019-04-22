using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace iconic.web.Services.BotConductor
{
    public class BotConductorService
    {
        private HttpClient _client { get; set; }
        private readonly IOptions<BotConductorOptions> _options;
        public BotConductorService(HttpClient httpClient, IOptions<BotConductorOptions> options)
        {
            _options = options;
            _client = httpClient;
            _client.BaseAddress = new Uri(options.Value.BaseAddress);
        }

        public async Task<HttpResponseMessage> SendMessage(string message)
        {
            return await _client.PostAsJsonAsync($"{_client.BaseAddress}{_options.Value.EndPointSendMessage}", message);

        }
    }
}