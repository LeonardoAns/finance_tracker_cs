using System.ComponentModel.DataAnnotations;

namespace Finance.Communication.AccountHolder.Request;

public class AccountHolderRequestJson {
    
    public string FullName{ get; set; }
    
    [EmailAddress]
    public string Email{ get; set; }
    public string Password{ get; set; }

    public AccountHolderRequestJson(string fullName, string email, string password){
        FullName = fullName;
        Email = email;
        Password = password;
    }
}