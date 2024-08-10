using System.Net;

namespace OmieSharp.EventHandlers;

public delegate void ApiCallExecutedEventHandler(
    HttpMethod httpMethod,
    Uri fullUrl,
    HttpStatusCode httpStatusCode,
    bool isSuccess,
    string? jsonRequest,
    string? jsonResponse,
    long elapsedMilliseconds);
