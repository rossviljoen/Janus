//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using QuickGraph.Graphviz;
//using QuickGraph.Graphviz.Dot;

//namespace Janus
//{
//    class GraphvizEngine : IDotEngine
//    {

//        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
//        {
//            string executable = @".\external\dot.exe";
//            string output = @".\external\tempgraph";
//            File.WriteAllText(output, dot);

//            System.Diagnostics.Process process = new System.Diagnostics.Process();

//            // Stop the process from opening a new window
//            process.StartInfo.RedirectStandardOutput = true;
//            process.StartInfo.UseShellExecute = false;
//            process.StartInfo.CreateNoWindow = true;

//            // Setup executable and parameters
//            process.StartInfo.FileName = executable;
//            process.StartInfo.Arguments = string.Format(@"{0} -Tjpg -O", output);

//            // Go
//            process.Start();
//            // and wait dot.exe to complete and exit
//            process.WaitForExit();
//            Bitmap bitmap = null; ;
//            using (Stream bmpStream = System.IO.File.Open(output + ".jpg", System.IO.FileMode.Open))
//            {
//                Image image = Image.FromStream(bmpStream);
//                bitmap = new Bitmap(image);
//            }
//            File.Delete(output);
//            File.Delete(output + ".jpg");
//            return bitmap;
//        }
//}
