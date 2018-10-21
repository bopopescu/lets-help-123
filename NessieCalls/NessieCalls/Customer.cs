using System;
using Newtonsoft.Json;

public class Customer
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("address")]
    public Address Address { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    public string FullName { get; set; }
}
