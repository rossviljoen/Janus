using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janus
{
    class Program
    {
        public static ConnectionClass dbConn;

        static void Main(string[] args)
        {
            using (dbConn = new ConnectionClass())
            {
                var dwGraph = GraphBuilder.CreateGraph();
            }
        }
    }
}
