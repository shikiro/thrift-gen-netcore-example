using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace Shikiro.LearnThrift.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            HelloWorldServer.Run(tokenSource.Token, loggerFactory);

            var mres = new ManualResetEventSlim();
            mres.Wait();
        }
    }
}
