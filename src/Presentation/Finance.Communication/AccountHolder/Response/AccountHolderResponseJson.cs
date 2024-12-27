namespace Finance.Communication.AccountHolder.Response;

public class AccountHolderResponseJson {
    public string Token{ get; set; }

    public AccountHolderResponseJson(string token){
        Token = token;
    }
}