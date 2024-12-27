using Domain.Enums;

namespace Domain.Entities;

public class AccountHolder {

    public long Id{ get; set; }
    public string FullName{ get; set; }
    public string Email{ get; set; }
    public string Password{ get; set; }
    public string? VerificationCode{ get; set; }
    public bool Enabled{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public List<Roles> Roles{ get; set; }

    public AccountHolder(){
    }

    public ICollection<Category> Categories =[];
    public ICollection<Expense> Expenses =[];

    public AccountHolder(string fullName, string email, string password, string verificationCode, bool enabled, DateTime createdAt, List<Roles> roles){
        FullName = fullName;
        Email = email;
        Password = password;
        VerificationCode = verificationCode;
        Enabled = enabled;
        CreatedAt = createdAt;
        Roles = roles;
    }
}