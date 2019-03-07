using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DjikstraTest
{
    class Util
    {
        public static double Distance(Location a, Location b) // Standard distance formula
        {
            if (a.Equals(b))
            {
                return 0;
            }
            double xtotal = b.X - a.X;
            double ytotal = b.Y - a.Y;
            return Math.Sqrt(Math.Pow(xtotal, 2) + Math.Pow(ytotal, 2));
        }
        public static string ArrayToString(object[] arr) // returns a long string that's every array element put together
        {
            string run = "";
            foreach (object obj in arr)
            {
                run += obj.ToString();
                run += " ";
            }
            return run;
        }
        public static int GetNodeAtLoc(List<Node> nodes, Location loc) // finds the index of the node in the list of nodes that is at a certain position. assume all nodes are unique.
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i].Point == loc)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
