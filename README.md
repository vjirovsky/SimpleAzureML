# SimpleAzureML
.NET SDK for Azure Machine Learning Web Services (AMLWS)

[![NuGet version (SimpleAzureML)](https://img.shields.io/nuget/v/SimpleAzureML.svg?style=flat-square)](https://www.nuget.org/packages/SimpleAzureML/)

Simple Azure Machine Learning SDK provides easy way how to use AMLWS. Via this SDK you can do Response-Request Service requests by few lines. 

## How to install package

### Install with NuGet (recommended)

```sh
PM> Install-Package SimpleAzureML
```

### Works for .NET applications
- .NET Standard 2.0
- .NET Framework 4.6.1
- .NET Framework 4.6
- .NET Framework 4.5.2
- .NET Framework 4.5.1

### Prerequisites
- Newtonsoft.Json


## Usage

### Initialize SimpleAzure.Client

Create instance of SimpleAzure.Client, with arguments:
- AMLWS's URL (looks like `https://ussouthcentral.services.azureml.net/workspaces/xxxxxx/services/yyyyyyyy/execute?api-version=2.0&format=swagger`)
- AMLWS's API key

sample code:
```csharp
var simpleAzureMlClient = new SimpleAzureML.Client(
                "!----AMLWS-URL----!",
                "!----AMLWS-API-KEY----!"
                );
```

### Request-Response Service request

#### Request model

RRS use `RRSScoreGenericRequestModel` for requests.
This model contains only key-value<string,object> pair inputs for web service.

sample code:
```csharp
var myRequest = new RRSScoreGenericRequestModel()
                    {
                        {"myColumnString", "my string"},
                        {"myColumnInt", 2}
                    };
```

#### Do RRS requests

### Single request

Use `DoRRSRequest` method of SimpleAzureML.Client with request as parameter.

sample code:
```csharp

var myRequest = new RRSScoreGenericRequestModel()
                    {
                        {"hour", 10},
                        {"minute", 22},
                        {"freeParkingSpacesCount", 0}
                    };
var response = await simpleAzureMlClient.DoRRSRequest(myRequest);
```

### Multiple requests
You can combine more request in one call. 
Use `DoRRSRequest` method of SimpleAzureML.Client with List of requests as parameter.

sample code:
```csharp

var myRequests = new List<RRSScoreGenericRequestModel>();

var myRequest = new RRSScoreGenericRequestModel()
                    {
                        {"hour", 10},
                        {"minute", 22},
                        {"freeParkingSpacesCount", 0}
                    };

myRequests.Add(myRequest);

var myRequest2 = new RRSScoreGenericRequestModel()
                    {
                        {"hour", 10},
                        {"minute", 23},
                        {"freeParkingSpacesCount", 0}
                    };                  
                    
myRequests.Add(myRequest2);


var response = await simpleAzureMlClient.DoRRSRequest(myRequests);
```

#### Response model

`RRSScoreGenericResponseModel` is used for response from RRS. Results from RRS endpoint are inside `response.Results.Output1`.

sample code:
```csharp
 foreach (var myResponse in response.Results.Output1.Select((values, i) => new { i, values }))
            {

                Console.WriteLine("=== Result #" + myResponse.i);
                foreach(var myData in myResponse.values)
                {
                    Console.WriteLine("   "+ myData.Key +": " + myData.Value);
                }
            }
```

sample output:
```
=== Result #0
   freeParkingSpacesCount: 133
=== Result #1
   freeParkingSpacesCount: 118
=== Result #2
   freeParkingSpacesCount: 22
```

### Batch Execution request
_(Batch Execution requests support coming soon..)_

