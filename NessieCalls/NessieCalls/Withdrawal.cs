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

    public string idInput;
    public string mediumInput;  // balance or rewards
    public double amountInput;
    public string statusInput;  // pending, cancelled, completed
    public string descriptionInput;
    public string transactionDate; // yyyy-mm-dd

    public Withdrawal()
    {
        // mandatory
        idInput = "";
        mediumInput = "";
        amountInput = 0.0;

        // optional
        transactionDate = "";
        statusInput = "";
        descriptionInput = "";
    }
}
