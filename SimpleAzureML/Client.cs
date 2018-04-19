using System;

namespace SimpleAzureML
{
    public class Client
    {
        private string _webServiceUrl = String.Empty;



        public Client(string webServiceUrl)
        {
            _webServiceUrl = webServiceUrl;
        }


        public bool DoRRSRequest()
        {
            throw new NotImplementedException();
        }

        public bool DoBESRequest()
        {
            throw new NotImplementedException();
        }

    }
}
