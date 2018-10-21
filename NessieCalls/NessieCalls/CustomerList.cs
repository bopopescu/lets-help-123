using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CustomerList
{
    [JsonProperty("results")]
    public List<Customer> Customers { get; set; }
}