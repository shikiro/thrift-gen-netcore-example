using Shikiro.LearnThrift.Service.Interface.HelloWorld;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports.Client;
using System.Net.Sockets;
using System.Threading;

namespace Shikiro.LearnThrift.Client
{
    class HelloWorldTest
    {
        public static void Run(int times, CancellationToken cancellationToken)
        {
            Parallel.For(0, times, i =>
            {
                using (var socket = new TcpClient("localhost", 8005))
                {
                    using (var transport = new TSocketClientTransport(socket))
                    {
                        using (TProtocol protocol = new TCompactProtocol(transport))
                        {
                            using (var client = new IHelloWorldService.Client(protocol))
                            {
                                transport.OpenAsync().Wait();
                                client.HelloWorldAsync(cancellationToken).Wait();
                            }
                        }
                    }
                }
            });
        }
    }
}
