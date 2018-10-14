using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Janus
{
    struct DWTable
    {
        public String tableName;
        public String strProc;
        public DWTable(string name, string strProc)
        {
            this.tableName = name;
            this.strProc = strProc;
        }

        public DWTable(string strProc)
        {
            this.tableName = Regex.Replace(strProc, "(update_)", "");
            this.strProc = strProc;
        }

        public override bool Equals(object obj)
        {
            return (obj is DWTable) && ((DWTable)obj).tableName == tableName;
        }
    }
}
