using System;
using System.Collections.Generic;
using System.Text;

namespace testAkkaAppConsole.Domain
{
    /// <summary>
    /// immutable transaction
    /// </summary>
    public sealed class Transaction
    {
        public TransactionType TransactionType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Transaction(
            TransactionType transactionType,
            decimal amount,
            DateTime dateTime)
        {
            TransactionType = transactionType;
            Amount = amount;
            CreatedAt = CreatedAt;
        }
    }
}
