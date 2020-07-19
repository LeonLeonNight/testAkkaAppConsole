using Akka.Event;
using Akka.Util;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace testAkkaAppConsole.Actors
{
    public class PingActor : Akka.Actor.ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public PingActor()
        {
            Receive<Ping>(p => 
            {
                _log.Info("Received {0}",p);

                //reply back at a random, short inerval
                var replyTime = TimeSpan.FromSeconds(
                    ThreadLocalRandom.Current.Next(1,5));

                Context.System.Scheduler.ScheduleTellOnce(
                    replyTime,
                    Sender,
                    p.Site,
                    Self);
            });
        }
    }
}
