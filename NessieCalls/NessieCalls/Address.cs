using System;
using Newtonsoft.Json;

public class Address
{
    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("street_name")]
    public string StreetName { get; set; }

    [JsonProperty("street_number")]
    public string StreetNumber { get; set; }

    [JsonProperty("zip")]
    public string Zip { get; set; }
}
