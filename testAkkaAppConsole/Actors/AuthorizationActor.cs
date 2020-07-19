using System;
using System.Collections.Generic;
using System.Text;
using testAkkaAppConsole.Domain;

namespace testAkkaAppConsole.Actors
{
    using Domain;
    public sealed class AuthorizationActor : Akka.Actor.ReceiveActor
    {
        public AuthorizationActor()
        {
            Receive<Transaction>(data =>
            {
                if (data.TransactionType == TransactionType.Credicard)
                {
                    Console.WriteLine($"Authorized {data.Amount} | {data.TransactionType}");
                }
                else
                {
                    if(data.TransactionType == TransactionType.Debit
                    && data.Amount > 100)
                    {
                        Console.WriteLine($"Authorized {data.Amount} | {data.TransactionType}");
                    }
                    else
                    {
                        Console.WriteLine($"Authorized {data.Amount} | {data.TransactionType}");
                    }
                }
            });
        }
    }
}
