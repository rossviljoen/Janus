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
        public String TableName { get; }
        public String StrProc { get; }
        public DWTable(string name, string strProc)
        {
            this.TableName = name;
            this.StrProc = strProc;
        }

        public DWTable(string strProc)
        {
            this.TableName = Regex.Replace(strProc, "(update_)", "");
            this.StrProc = strProc;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return (obj is DWTable) && ((DWTable)obj).TableName == TableName;
        }

        public override int GetHashCode()
        {
            return -28095652 + EqualityComparer<string>.Default.GetHashCode(TableName);
        }

    }
}