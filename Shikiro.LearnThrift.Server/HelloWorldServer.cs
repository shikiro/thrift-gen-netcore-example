using Shikiro.LearnThrift.Service.Implementation;
using Shikiro.LearnThrift.Service.Interface.HelloWorld;
using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Server;
using Thrift.Transports.Server;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Shikiro.LearnThrift.Server
{
    public class HelloWorldServer
    {
        public static void Run(CancellationToken cancellationToken, LoggerFactory loggerFactory)
        {
            TServerTransport serverTransport = new TServerSocketTransport(8005);

            ITProtocolFactory inputProtocolFactory = new TCompactProtocol.Factory();
            ITProtocolFactory outputProtocolFactory = new TCompactProtocol.Factory();

            var processor = new IHelloWorldService.AsyncProcessor(new HelloWorldService());

            var server = new AsyncBaseServer(processor, serverTransport, inputProtocolFactory, outputProtocolFactory, loggerFactory);

            server.ServeAsync(cancellationToken);
        }
    }
}
