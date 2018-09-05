using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shikiro.LearnThrift.Service.Interface.HelloWorld;

namespace Shikiro.LearnThrift.Service.Implementation
{
    public class HelloWorldService : IHelloWorldService.IAsync
    {
        public Task HelloWorldAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Hello World");
            });
        }
    }
}
