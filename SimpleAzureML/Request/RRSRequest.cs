using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleAzureML.Exception;
using SimpleAzureML.Extension;
using SimpleAzureML.Model.Azure;

namespace SimpleAzureML.Request
{
    internal class RRSRequest : IRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mappedValues">
        /// List<columnName,value>
        /// </param>
        /// <param name="predictionApiUrl"></param>
        /// <param name="predictionApiKey"></param>
        /// <returns></returns>
        public async Task<RRSScoreGenericResponseModel> SendRequest(IEnumerable<IDictionary<string, object>> mappedValues, string predictionApiUrl,
            string predictionApiKey)
        {

            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, object>()
                    {
                        {   
                            "input1",
                            mappedValues
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", predictionApiKey);

                client.BaseAddress = new Uri(predictionApiUrl);

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var jsonResult = JsonConvert.DeserializeObject<RRSScoreGenericResponseModel>(result);

                    return jsonResult;
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

#if DEBUG
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());
                    Console.WriteLine(responseContent);
#endif

                    throw new RRSRequestFailedException(
                        string.Format("The request failed with HTTP status code: {0} - {1}\nDetails: {2}",
                            (int)response.StatusCode, response.StatusCode, responseContent));
                }

            }
        }
    }
}