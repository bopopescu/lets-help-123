using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class BillList
{
    [JsonProperty("results")]
    public List<Bill> Bills { get; set; }
}