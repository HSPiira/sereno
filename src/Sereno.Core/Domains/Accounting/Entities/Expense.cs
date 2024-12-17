using Sereno.Core.Common;

namespace Sereno.Core.Domains.Accounting.Entities;

public class Expense : BaseEntity
{
    public Expense(string name, decimal amount, DateTime expenseDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Expense name cannot be empty.");
        if (amount <= 0)
            throw new ArgumentException("Expense amount must be greater than zero.");

        Name = name;
        Amount = amount;
        ExpenseDate = expenseDate;
    }

    public string Name { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime ExpenseDate { get; private set; }
}