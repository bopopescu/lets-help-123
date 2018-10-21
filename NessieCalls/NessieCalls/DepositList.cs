using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DepositList
{
    [JsonProperty("results")]
    public List<Deposit> Deposits { get; set; }
}