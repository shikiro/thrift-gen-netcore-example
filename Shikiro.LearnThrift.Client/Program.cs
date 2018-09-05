using System;
using System.Threading;

namespace Shikiro.LearnThrift.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            HelloWorldTest.Run(10, tokenSource.Token);

            Console.ReadKey();
        }
    }
}
