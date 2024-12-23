using Domain.Enums;

namespace Finance.Communication.Expense.Request;

public class ExpenseRequestJson {
    public string Description{ get; set; }
    public double Value{ get; set; }
    public PaymentMethod PaymentMethod{ get; set; }
    public long CategoryId{ get; set; }

    public ExpenseRequestJson(string description, double value, PaymentMethod paymentMethod, long categoryId){
        Description = description;
        Value = value;
        PaymentMethod = paymentMethod;
        CategoryId = categoryId;
    }
} 