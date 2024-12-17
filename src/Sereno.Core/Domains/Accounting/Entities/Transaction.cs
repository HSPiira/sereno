using Sereno.Core.Common;
using Sereno.Core.Domains.Accounting.ValueObjects;

namespace Sereno.Core.Domains.Accounting.Entities;

public class Transaction : BaseEntity
{
    public Transaction(decimal amount, TransactionType type, string description, PaymentMethod method)
    {
        if (amount <= 0)
            throw new ArgumentException("Transaction amount must be greater than zero.");

        Amount = amount;
        Type = type;
        Description = description;
        Method = method;
    }

    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public string Description { get; private set; }
    public PaymentMethod Method { get; private set; }
}