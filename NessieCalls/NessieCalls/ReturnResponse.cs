using System;
using Newtonsoft.Json;

public class ReturnResponse
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}
