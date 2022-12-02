# OmieSharp - Simple Omie Client for .NET

### License: MIT

Omie is a ERP Software

https://www.omie.com.br/

OmieSharp is a client that allows .NET applications communicate with Omie system to execute this operations:
.	Get, Insert and Update clients


## 1- Create a Omie account

To use OmieSharp client you need a Omie account, you can create a free account in website:

https://www.omie.com.br/


## 2- Create a Omie AccessKey

The second step is create a AccessKey to use in client, to create this, follow the instructions in the link below:

https://ajuda.omie.com.br/pt-BR/articles/499061-obtendo-a-chave-de-acesso-para-integracoes-de-api


## 3- Add nuget reference to your project

(available soon)



## 4- Examples

### 4.1- Basic Example

```csharp
var httpClient = new HttpClient(); 
//TIP: HttpClient is intended to be instantiated once and reused throughout the life of an application, more info: https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
//TIP: You can use a retry policy with Poly, more info: https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly

var omieClient = new OmieSharp.OmieClient("AppKey_xxxxxxxxxxxxxxxx", "AppSecret_xxxxxxxxxxxxx", httpClient);
var clientes = await OmieClient.ListarClientesAsync(new ListarClientesRequest());
```




## 5- Explore source code / debug

Open solution "OmieSharp.sln" in Visual Studio 2022

To Run Tests, you need to create a file "main.json"
1.	create a file "main.json" in folder: \OmieSharp.IntegrationTests\config\ using the example file
2.	add your Omie credentials to this file
3.	change main.json file configuration to "Copy if newer"

