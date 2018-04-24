using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAzureML.Model.Azure;
using SimpleAzureML.Request;

namespace SimpleAzureML
{
    public class Client
    {
        private string _webServiceUrl = String.Empty;
        private string _predictionApiKey = String.Empty;


        /// <summary>
        ///  Creates the Simple Azure ML client
        /// </summary>
        /// <param name="webServiceUrl">URL of Azure ML Web Service RRS endpoint
        /// Can be found in Web Service's generated documentation
        /// Example: https://ussouthcentral.services.azureml.net/workspaces/XXXXX/services/YYYYYY/execute?api-version=2.0&details=true
        /// </param>
        /// <param name="predictionApiKey">API key of generated Azure ML Web Service (can be found in Azure ML Studio)</param>
        public Client(string webServiceUrl, string predictionApiKey)
        {
            _webServiceUrl = webServiceUrl;
            _predictionApiKey = predictionApiKey;
        }


        /// <summary>
        /// Creates Request-Response request (on initialized Azure ML Web Service's client RRS endpoint) for multiple inputs
        /// </summary>
        /// <param name="myRequestsList"></param>
        /// <returns>
        /// Predicted outputs for all given inputs (in same order)
        /// </returns>
        public async Task<RRSScoreGenericResponseModel> DoRRSRequest(IEnumerable<RRSScoreGenericRequestModel> myRequestsList)
        {
            var request = new RRSRequest();

            return await request.SendRequest(
                myRequestsList,
                _webServiceUrl,
                _predictionApiKey
            );
        }

        /// <summary>
        /// Creates Request-Response request (on initialized Azure ML Web Service's client RRS endpoint) for single input
        /// </summary>
        /// <param name="myRequestsList"></param>
        /// <returns>
        /// Predicted outputs for given input
        /// </returns>
        public async Task<RRSScoreGenericResponseModel> DoRRSRequest(RRSScoreGenericRequestModel mySingleRequest)
        {
            var request = new RRSRequest();

            return await request.SendRequest(
                new List<RRSScoreGenericRequestModel>() { mySingleRequest },
                _webServiceUrl,
                _predictionApiKey
            );
        }

    }
}
