using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Node
    {
        public bool isCentral; // is central department
        public String name; //name of department
        List<Node> neighbours; //list of neighbours of the node
        public List<Route> routing; //static routing table
        int id; //id of the department
        public Node(int id, String name, bool central = false)
        {
            this.id = id;
            this.name = name;
            this.isCentral = central;
            this.neighbours = new List<Node>();
            this.routing = new List<Route>();
        }
        public void AddNeighbour(Node node)
        {
            neighbours.Add(node);
        }
        public void AddRoute(Route route)
        {
            routing.Add(route);
        }
        private Route GetRoute(Node node)
        {
            Route route = null;
            for (int i = 0; i < routing.Count; i++)
            {
                if (routing[i].to.Contains(node))
                {
                    route = routing[i];
                    break;
                }
            }
            return route;
        }
        public void SendPacket(Node to, int bits)
        {
            this.ReceivePacket(new Packet(this, to, bits));
        }
        public void ReceivePacket(Packet packet)
        {
            if (packet.to == this)
            {
                Console.WriteLine(String.Format("[{2}][{0}] Received packet from: {1}", this.name, packet.from.name, packet.ID));
            } else
            {
                Route route = GetRoute(packet.to);
                if(route != null)
                {
                    Console.WriteLine(String.Format("[{3}][{0}] Sending packet to: {1} via {2}", this.name, packet.to.name, route.via.name, packet.ID));
                    route.SendPacket(packet);
                }
            }
        }
        public void Broadcast(List<Node> nodes, int bits)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                Node node = nodes[i];
                if(node != this) this.SendPacket(node, bits);
            }
        }
        public List<Node> RouteTo(Node to, List<Node> nodes = null)
        {
            if (nodes == null) nodes = new List<Node>();
            if (to == this)
            {
                nodes.Add(this);
                return nodes;
            }
            Route route = GetRoute(to);
            if (route != null)
            {
                nodes.Add(this);
                route.via.RouteTo(to, nodes);
            }
            return nodes;
        }
        public void Print()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(String.Format("{0} - {1}", this.id, this.name));
            Console.WriteLine("Neighbours:");
            for (int i = 0; i < neighbours.Count; i ++)
            {
                Node node = neighbours[i];
                Console.WriteLine(String.Format("{0} - {1}: {2} b/s", this.name, node.name, GetRoute(node).bits));
            }


            Console.WriteLine("Routes:");
            for (int i = 0; i < routing.Count; i++)
            {
                Route route = routing[i];
                for(int j = 0; j < route.to.Count; j++)
                {
                    List<Node> r = this.RouteTo(route.to[j]);
                    for (int k = 0; k < r.Count; k++)
                    {
                        if (k == 0)
                        {
                            Console.Write(r[k].name);
                        }
                        else
                        {
                            Console.Write(" - " + r[k].name);
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("--------------------");
        }
    }
}
