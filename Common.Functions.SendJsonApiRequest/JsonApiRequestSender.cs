using Common.Structures.HttpAuthentication;
using Common.Structures.HttpJsonRequest;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Functions.SendJsonApiRequest
{
    public static class JsonApiRequestSender
    {
        public static async Task<HttpResponseMessage> ApiRequest(ApiRequest request, HttpAuthentication authentication = null)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            using (var client = new HttpClient { BaseAddress = request.BaseAddress })
            {
                if (authentication != null)
                    client.DefaultRequestHeaders.Authorization = authentication.Header;

                return await client.SendAsync(request.Message);
            }
        }
    }
}
