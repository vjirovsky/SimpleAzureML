using System;
using System.Collections.Generic;

namespace SimpleAzureML.Model.Azure
{
    /// <summary>
    /// Input model for RRS requests
    /// </summary>
    /// <example>
    /// var myRequest = new RRSScoreGenericRequestModel(){
    ///     {"myStringColumn1", "my string"},
    ///     {"myIntColumn2", 123}
    /// };
    /// </example>
    public class RRSScoreGenericRequestModel : Dictionary<string, object>
    {
        public override string ToString()
        {
            var output = String.Empty;

            foreach (var row in this)
            {
                output += row.Key + ":" + row.Value + ";";
            }

            return output;
        }
    }
}
