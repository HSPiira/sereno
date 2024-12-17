using Sereno.Core.Common;
using Sereno.Core.Domains.Accounting.ValueObjects;
using Sereno.Core.Domains.Payments.ValueObjects;

namespace Sereno.Core.Domains.Payments.Entities;

public class Payment : BaseEntity
{
    public Payment(Guid transactionId, decimal amount, PaymentMethod method)
    {
        if (amount <= 0)
            throw new ArgumentException("Payment amount must be greater than zero.");

        TransactionId = transactionId;
        Amount = amount;
        Method = method;
        Status = PaymentStatus.Pending;
    }

    public Guid TransactionId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public PaymentMethod Method { get; private set; }

    public void MarkAsCompleted()
    {
        Status = PaymentStatus.Completed;
    }

    public void MarkAsFailed()
    {
        Status = PaymentStatus.Failed;
    }
}