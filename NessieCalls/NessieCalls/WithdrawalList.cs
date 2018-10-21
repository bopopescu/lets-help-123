using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class WithdrawalList
{
    [JsonProperty("results")]
    public List<Withdrawal> Withdrawals { get; set; }
}
