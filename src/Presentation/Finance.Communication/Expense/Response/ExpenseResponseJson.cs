using Domain.Enums;

namespace Finance.Communication.Expense.Response;

public class ExpenseResponseJson {
    public long Id{ get; set; }
    public string Description{ get; set; }
    public double Value{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public PaymentMethod PaymentMethod{ get; set; }
    public long CategoryId{ get; set; }

    public ExpenseResponseJson(long id, string description, double value, DateTime createdAt, PaymentMethod paymentMethod, long categoryId){
        Id = id;
        Description = description;
        Value = value;
        CreatedAt = createdAt;
        PaymentMethod = paymentMethod;
        CategoryId = categoryId;
    }
}