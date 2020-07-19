using System;

namespace testAkkaAppConsole
{
    using Domain;
    using Akka.Actor;
    using testAkkaAppConsole.Actors;

    public class Greet
    {
        public Greet(string who)
        {
            Who = who;
        }
        public string Who { get; private set; }
    }

    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(
                greet => Console.WriteLine("Hello {0}", greet.Who));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");

            //создает актора и получает ссылку на него
            //такой "ActorRef" который не явл ссылкой
            //но является клиентом или прокси к нему.
            var greeter = system.ActorOf<GreetingActor>("greeter");
            //отправить сообщение актору
            greeter.Tell(new Greet("World"));

            //контейнер для актеров для системы авторизации
            var systemActor = ActorSystem.Create("AuthorizationSystem");
            var authorizer = systemActor.ActorOf<AuthorizationActor>();

            var transactionA = new Transaction(TransactionType.Credicard, 100, DateTime.UtcNow);
            var transactionB = new Transaction(TransactionType.Debit, 120, DateTime.UtcNow);
            var transactionC = new Transaction(TransactionType.Debit, 80, DateTime.UtcNow);

            authorizer.Tell(transactionA);
            authorizer.Tell(transactionB);
            authorizer.Tell(transactionC);

            Console.ReadLine();
        }
    }
}
