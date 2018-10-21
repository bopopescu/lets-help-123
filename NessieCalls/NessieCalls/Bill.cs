using System;
using Newtonsoft.Json;

public class Bill
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("account_id")]
    public string AccountId { get; set; }

    [JsonProperty("creation_date")]
    public string CreationDate { get; set; }

    [JsonProperty("payee")]
    public string Payee { get; set; }

    [JsonProperty("payment_amount")]
    public string PaymentAmount { get; set; }

    [JsonProperty("payment_date")]
    public string PaymentDate { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}
