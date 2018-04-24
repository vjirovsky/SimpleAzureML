using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleAzureML.Model.Azure
{

    public partial class RRSScoreGenericResponseModel
    {
        [JsonProperty("Results")]
        public Results Results { get; set; }
    }

    public partial class Results
    {
        [JsonProperty("output1")]
        public IList<IDictionary<string, object>> Output1 { get; set; }
    }
    
}
//jsonResult.Results["output1"]