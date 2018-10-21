using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class UserList
{
    [JsonProperty("results")]
    public List<User> Users { get; set; }

}
