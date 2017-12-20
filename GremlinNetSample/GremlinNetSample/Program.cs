using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gremlin.Net;
using Gremlin.Net.Driver;

namespace GremlinNetSample
{
    class Program
    {
        private static string hostname = "your-gremlin-host.gremlin.cosmosdb.azure.com";
        private static int port = 443;
        private static string authKey = "your-secret-authentication-key";
        private static string database = "your-database-name";
        private static string collection = "your-collection-or-graph-name";

        static void Main(string[] args)
        {
            var gremlinServer = new GremlinServer(hostname, port, enableSsl: true, username: "/dbs/AsIsModel/colls/AsIsModel", password: authKey);
            var query = @"g.V()";

            using (var gremlinClient = new GremlinClient(gremlinServer))
            {
                var task = gremlinClient.SubmitAsync<dynamic>(query);
                task.Wait();
                var results = task.Result;
                foreach (var result in results)
                {
                    Console.WriteLine(result.toString());
                }
            }
        }
    }
}