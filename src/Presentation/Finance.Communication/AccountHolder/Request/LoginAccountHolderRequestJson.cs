using System.ComponentModel.DataAnnotations;

namespace Finance.Communication.AccountHolder.Request;

public class LoginAccountHolderRequestJson{
    
    [EmailAddress]
    public string Email{ get; set; }
    public string Password{ get; set; }

    public LoginAccountHolderRequestJson(string email, string password){
        Email = email;
        Password = password;
    }
}