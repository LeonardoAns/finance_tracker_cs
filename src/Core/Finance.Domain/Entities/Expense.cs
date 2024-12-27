using Domain.Enums;

namespace Domain.Entities;

public class Expense {

    public long Id{ get; set; }
    public string Description{ get; set; }
    public double Value{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public PaymentMethod PaymentMethod{ get; set; }
    public long CategoryId{ get; set; }
    public Category Category{ get; set; }
    
    public long AccountHolderId{ get; set; }
    
    public AccountHolder AccountHolder{ get; set; }

    public Expense(){
    }

    public Expense(string description, double value, DateTime createdAt, PaymentMethod paymentMethod, long categoryId, Category category){
        Description = description;
        Value = value;
        CreatedAt = createdAt;
        PaymentMethod = paymentMethod;
        CategoryId = categoryId;
        Category = category;
    }
}