using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace Janus
{
    class GraphBuilder
    {
        public static  AdjacencyGraph<DWTable, SEquatableEdge<DWTable>> CreateGraph()
        {
            var spList = QueryHelper.GetSPs();
            var newGraph = new AdjacencyGraph<DWTable, SEquatableEdge<DWTable>>();
            foreach(var sp in spList)
            {
                newGraph.AddVertex(sp);
            }
            foreach(var sp in spList)
            {
                var depList = QueryHelper.GetSpDependencies(sp);
                foreach(string dep in depList)
                {
                    newGraph.AddVerticesAndEdge(new SEquatableEdge<DWTable>(new DWTable(dep), sp));
                }
            }
            return newGraph;
        }

        //private Dictionary<DWTable, SEquatableEdge<DWTable>[]> CreateDictionary()
        //{
        //    var spList = QueryHelper.GetSPs();
        //    var spDic = new Dictionary<DWTable, SEquatableEdge<DWTable>[]>();
        //    foreach (var sp in spList)
        //    {
        //        var depList = QueryHelper.GetSpDependencies(sp);

        //    }
        //}
    }
}
