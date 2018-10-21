using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using RestSharp;

public class Nessie
{
    private string linkStart;
    private string link;
    private string key;

    public Dictionary<string, Customer> nameToCustomer;
    public List<string> listId;

    private Dictionary<string, User> idToAccount;
    private Dictionary<string, Customer> idToCustomer;
    private Dictionary<string, Bill> idToBill;
    private Dictionary<string, Deposit> idToDeposit;
    private Dictionary<string, Withdrawal> idToWithdrawal;

    public Nessie()
    {
        key = "7b4938d97b175918846a155f0b9c0b77";
        linkStart = "http://api.reimaginebanking.com/enterprise/";
        link = "http://api.reimaginebanking.com/";
        listId = new List<string>();
        nameToCustomer = new Dictionary<string, Customer>();

        //idToCustomer = getAllCustomers();
        //idToAccount = getAllAccounts();

        //foreach(KeyValuePair<string, Customer> kv in idToCustomer){
        //    string id = kv.Key;
        //    Customer c = kv.Value;

        //    c.FullName = c.FirstName + " " + c.LastName;
        //    //Console.WriteLine("Id = " + id + "; fullName = " + c.FullName);

        //    if(!nameToCustomer.ContainsKey(c.FullName)){
        //        nameToCustomer.Add(c.FullName, c);
        //    }
        //}

        //idToBill = getAllBills();
        //idToDeposit = getAllDeposits();
        //idToWithdrawal = getAllWithdrawals();
    }

    public bool makeDeposit(Deposit d){
        bool ret = false;
        Console.WriteLine("Making a deposit...");

        var client = new RestClient(link + "accounts/" + d.id + "/deposits?key=" + key);
        var request = new RestSharp.RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");

        string jsonBody = "{\n\"medium\": \"" + d.medium +
                                                 "\",\"amount\": " + d.amountInput;
        if(d.transactionDate != ""){
            jsonBody += ",\"transaction_date\": \"" + d.transactionDate + "\"";
        }

        if (d.status != "")
        {
            jsonBody += ",\"status\": \"" + d.status + "\"";
        }

        if (d.description != "")
        {
            jsonBody += ",\"description\": \"" + d.description + "\"";
        }

        jsonBody += "}";
        request.AddParameter("undefined", jsonBody, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);

        Console.WriteLine(response.Content);

        var returnResponse = JsonConvert.DeserializeObject<ReturnResponse>(response.Content);

        if(returnResponse.Code == 201){
            ret = true;
            Console.WriteLine("Deposited successfully.");
        }

        return ret;
    }

    public bool makeWithdrawal(Withdrawal d)
    {
        bool ret = false;
        Console.WriteLine("Making a withdrawal...");

        var client = new RestClient(link + "accounts/" + d.id + "/withdrawals?key=" + key);
        var request = new RestSharp.RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");

        string jsonBody = "{\n\"medium\": \"" + d.medium +
                                                 "\",\"amount\": " + d.amountInput;
        if (d.transactionDate != "")
        {
            jsonBody += ",\"transaction_date\": \"" + d.transactionDate + "\"";
        }

        if (d.status != "")
        {
            jsonBody += ",\"status\": \"" + d.status + "\"";
        }

        if (d.description != "")
        {
            jsonBody += ",\"description\": \"" + d.description + "\"";
        }

        jsonBody += "}";
        request.AddParameter("undefined", jsonBody, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);

        Console.WriteLine(response.Content);

        var returnResponse = JsonConvert.DeserializeObject<ReturnResponse>(response.Content);

        if (returnResponse.Code == 201)
        {
            ret = true;
            Console.WriteLine("Withdrawn successfully.");
        }

        return ret;
    }

    public User getAccount(string id){
        User ret = null;
        idToAccount.TryGetValue(id, out ret);
        return ret;
    }

    public Customer getCustomer(string id){
        Customer ret = null;
        idToCustomer.TryGetValue(id, out ret);
        return ret;
    }

    public Bill getBill(string id){
        Bill ret = null;
        idToBill.TryGetValue(id, out ret);
        return ret;
    }

    public Deposit getDeposit(string id){
        Deposit ret = null;
        idToDeposit.TryGetValue(id, out ret);
        return ret;
    }

    public Withdrawal getWithdrawal(string id){
        Withdrawal ret = null;
        idToWithdrawal.TryGetValue(id, out ret);
        return ret;
    }

    public Dictionary<string, Customer> getAllCustomers()
    {
        Console.WriteLine("\nGetting all customers...");

        Dictionary<string, Customer> ret = new Dictionary<string, Customer>();
        IRestResponse response = null;

        try
        {
            var client = new RestClient(linkStart + "customers?key=" + key);
            var request = new RestSharp.RestRequest(Method.GET);
            response = client.Execute(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Cannot get customers");
            Console.WriteLine(ex);
        }

        var customerList = JsonConvert.DeserializeObject<CustomerList>(response.Content);

        foreach (Customer c in customerList.Customers)
        {
            listId.Add(c.Id);
            ret.Add(c.Id, c);
        }

        Console.WriteLine("Retrieved all customers.");

        return ret;
    }

    public Dictionary<string, User> getAllAccounts()
    {
        Console.WriteLine("Getting all accounts...");

        Dictionary<string, User> ret = new Dictionary<string, User>();
        IRestResponse response = null;

        try
        {
            var client = new RestClient(linkStart + "accounts?key=" + key);
            var request = new RestSharp.RestRequest(Method.GET);
            response = client.Execute(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Cannot get accounts");
            Console.WriteLine(ex);
        }

        var userList = JsonConvert.DeserializeObject<UserList>(response.Content);

        foreach (User u in userList.Users)
        {
            ret.Add(u.Id, u);
        }

        Console.WriteLine("Retrieved all accounts.");

        return ret;
    }

    public Dictionary<string, Bill> getAllBills()
    {
        Console.WriteLine("Getting all bills...");

        Dictionary<string, Bill> ret = new Dictionary<string, Bill>();
        IRestResponse response = null;

        try
        {
            var client = new RestClient(linkStart + "bills?key=" + key);
            var request = new RestSharp.RestRequest(Method.GET);
            response = client.Execute(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Cannot get bills");
            Console.WriteLine(ex);
        }

        var list = JsonConvert.DeserializeObject<BillList>(response.Content);

        foreach (Bill b in list.Bills)
        {
            ret.Add(b.Id, b);
        }

        Console.WriteLine("Retrieved all bills.");

        return ret;
    }

    public Dictionary<string, Deposit> getAllDeposits()
    {
        Console.WriteLine("Getting all deposits...");

        Dictionary<string, Deposit> ret = new Dictionary<string, Deposit>();
        IRestResponse response = null;

        try
        {
            var client = new RestClient(linkStart + "deposits?key=" + key);
            var request = new RestSharp.RestRequest(Method.GET);
            response = client.Execute(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Cannot get deposits");
            Console.WriteLine(ex);
        }

        var list = JsonConvert.DeserializeObject<DepositList>(response.Content);

        foreach (Deposit b in list.Deposits)
        {
            ret.Add(b.Id, b);
        }

        Console.WriteLine("Retrieved all deposits.");

        return ret;
    }

    public Dictionary<string, Withdrawal> getAllWithdrawals()
    {
        Console.WriteLine("Getting all withdrawals...");

        Dictionary<string, Withdrawal> ret = new Dictionary<string, Withdrawal>();
        IRestResponse response = null;

        try
        {
            var client = new RestClient(linkStart + "withdrawals?key=" + key);
            var request = new RestSharp.RestRequest(Method.GET);
            response = client.Execute(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Cannot get withdrawals");
            Console.WriteLine(ex);
        }

        var list = JsonConvert.DeserializeObject<WithdrawalList>(response.Content);

        foreach (Withdrawal b in list.Withdrawals)
        {
            ret.Add(b.Id, b);
        }

        Console.WriteLine("Retrieved all withdrawals.");

        return ret;
    }

}