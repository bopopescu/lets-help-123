using System;
using Newtonsoft.Json;

public class Deposit
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("amount")]
    public double Amount { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("medium")]
    public string Medium { get; set; }

    [JsonProperty("payee_id")]
    public string PayeeId { get; set; }

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

    public Deposit(){
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
