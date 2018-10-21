using System;
using Newtonsoft.Json;

public class Withdrawal
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public float Amount { get; set; }

    [JsonProperty("medium")]
    public string Medium { get; set; }

    [JsonProperty("payer_id")]
    public string PayerId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("transaction_date")]
    public string TransactionDate { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    public string id;
    public string medium;  // balance or rewards
    public double amountInput;
    public string status;  // pending, cancelled, completed
    public string description;
    public string transactionDate; // yyyy-mm-dd

    public Withdrawal()
    {
        // mandatory
        id = "";
        medium = "";
        amountInput = 0.0;

        // optional
        transactionDate = "";
        status = "";
        description = "";
    }
}
