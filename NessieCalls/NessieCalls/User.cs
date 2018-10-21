using System;
using Newtonsoft.Json;

public class User
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("balance")]
    public float Balance { get; set; }

    [JsonProperty("customer_id")]
    public string CustomerId { get; set; }

    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    [JsonProperty("rewards")]
    public float Rewards { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}
