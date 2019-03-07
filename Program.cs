using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DjikstraTest
{
    class Program
    {
        static void GetShortestPath(List<Node> nodes, Node start, Node goal)
        {
            nodes.Sort();
            if(start.Point == goal.Point)
            {
                Console.WriteLine("Start and goal are equal!");
                return;
            }
            Node current = nodes[0]; //assume the start node is always nodes[0]
            //Console.WriteLine($"Currently at {nodes[0].Point}.");
            while (!current.Visited && current.Point != goal.Point)
            {
                for(int i = 0; i < current.Attached.Length; i++)
                {
                    int p = Util.GetNodeAtLoc(nodes, current.Attached[i]);
                    double distance = Util.Distance(current.Point, current.Attached[i]);
                    if (nodes[p].Cost > (current.Cost + distance) && !nodes[p].Visited)
                    {
                        nodes[p].Cost = (current.Cost + distance);
                        nodes[p].Path.Clear();
                        foreach(Location loc in current.Path)
                        {
                            //Console.WriteLine($"Adding a point at {loc}!");
                            nodes[p].Path.Add(loc);
                        }
                        nodes[p].Path.Add(current.Point);
                        //Console.WriteLine($"The node at location {nodes[p].Point} now has a cost of {nodes[p].Cost}.");
                    }
                }
                current.Visited = true;
                nodes[Util.GetNodeAtLoc(nodes, current.Point)] = current;
                nodes.Sort();
                current = nodes[0];
                int count = 0;
                if (current.Visited)
                {
                    while (current.Visited)
                    {
                        count++;
                        current = nodes[count];
                    }
                }
                //Console.WriteLine($"Now considering {current.Point}, with a current cost of {current.Cost}.");
            }
            Console.WriteLine("The optimal path is:");
            foreach(Location loc in nodes[Util.GetNodeAtLoc(nodes, goal.Point)].Path)
            {
                Console.WriteLine(loc);
            }
            Console.WriteLine(goal.Point);
        }
        static void Main(string[] args)
        {
            Location start = new Location(3, 2);
            Location goal = new Location(9, 6);
            Location a = new Location(1, 5);
            Location b = new Location(4, 5);
            Location c = new Location(6, 2);
            Location d = new Location(8, 3);
            Location e = new Location(7, 9);
            Location[] sv = { a, b };
            Location[] gv = { d, e };
            Location[] av = { start, b };
            Location[] bv = { start, a, c, d, e };
            Location[] cv = { start, b, d };
            Location[] dv = { b, c, goal };
            Location[] ev = { b, goal };
            double dmv = double.MaxValue;
            Node nodeStart = new Node(start, sv, 0);
            Node nodeGoal = new Node(goal, gv, dmv);
            Node nodeA = new Node(a, av, dmv);
            Node nodeB = new Node(b, bv, dmv);
            Node nodeC = new Node(c, cv, dmv);
            Node nodeD = new Node(d, dv, dmv);
            Node nodeE = new Node(e, ev, dmv);
            List<Node> nodes = new List<Node>();
            nodes.Add(nodeGoal);
            nodes.Add(nodeStart);
            nodes.Add(nodeA);
            nodes.Add(nodeB);
            nodes.Add(nodeC);
            nodes.Add(nodeD);
            nodes.Add(nodeE);
            GetShortestPath(nodes, nodeStart, nodeGoal);
        }
    }
}
