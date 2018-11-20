using QuickGraph;
using QuickGraph.Graphviz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janus
{
    class GraphvizGenerator
    {
        IEdgeListGraph<DWTable, SEquatableEdge<DWTable>> graph;
        string filePath = @"C:\dev\Janus\Janus\outputfile.dot";

        public GraphvizGenerator(IEdgeListGraph<DWTable, SEquatableEdge<DWTable>> graph)
        {
            this.graph = graph;
        }

        public void Run()
        {
            GraphvizAlgorithm<DWTable, SEquatableEdge<DWTable>> graphviz = new GraphvizAlgorithm<DWTable, SEquatableEdge<DWTable>>(graph);
            graphviz.FormatVertex += (sender, args) => args.VertexFormatter.Label = args.Vertex.StrProc;
//           graphviz.FormatEdge += (sender, args) => { args.EdgeFormatter.Label.Value = args.Edge.Label; };

            graphviz.Generate(new FileDotEngine(), filePath);
        }
    }
}
