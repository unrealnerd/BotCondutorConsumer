using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace iconic.web.Services.BotConductor
{
    public class BotConductorService
    {
        private HttpClient _client { get; set; }
        private IOptions<Options> _options;
        public BotConductorService(HttpClient httpClient, IOptions<Options> options)
        {
            _options = options;
            _client.BaseAddress = new Uri(options.Value.BaseAddress);
            _client = httpClient;
        }

        public async Task<string> SendMessage(string message)
        {
            return await _client.GetStringAsync($"{_client.BaseAddress}/{_options.Value.EndPointSendMessage}");

        }
    }
}