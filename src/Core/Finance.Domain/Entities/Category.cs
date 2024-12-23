namespace Domain.Entities;

public class Category {
    public long Id{ get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    public ICollection<Expense> Expenses{ get; set; } = new List<Expense>();

    public Category(){
    }
    
    public Category(string name, string description){
        Name = name;
        Description = description;
    }
}