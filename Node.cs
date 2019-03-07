using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DjikstraTest
{
    class Node: IComparable<Node>
    {
        public Node(Location p, Location[] a, double c)
        {
            Point = p;
            Attached = a;
            Cost = c;
            Visited = false;
        }
        public Location Point { get; set; } // the node's static point. like, where it is.
        public Location[] Attached { get; set; } // every point the node can go to
        public double Cost { get; set; } // the cost, or distance, or fitness, whatever you wanna call it
        public bool Visited { get; set; } // marked false by default, true when all other nodes have been visited
        public HashSet<Location> Path = new HashSet<Location>(); // a running list of what path to take to get to this node in the shortest distance
        public override string ToString()
        {
            return $"A node at point {Point} that can go to nodes {Util.ArrayToString(Attached)} with a current cost of {Cost}.";
        }
        public int CompareTo(Node otherNode) // used to sort nodes by cost
        {
            if(otherNode == null)
            {
                return 1;
            }
            else
            {
                return this.Cost.CompareTo(otherNode.Cost);
            }
        }
    }
}
