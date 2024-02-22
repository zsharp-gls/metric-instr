using System;
using System.Diagnostics.Metrics;
using System.Threading;

namespace metric_instr
{
    internal class Program
    {
        static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
        static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hats-sold");

        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Press any key to exit");
            while (!Console.KeyAvailable)
            {
                //// Simulate hat selling transactions.
                Thread.Sleep(rand.Next(100, 2500));
                s_hatsSold.Add(rand.Next(0, 1000));
            }
        }
    }
}
