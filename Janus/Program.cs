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
            dbConn = new ConnectionClass();
        }
    }
}
