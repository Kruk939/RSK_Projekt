using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Node
    {
        bool isCentral; // is central department
        public String name; //name of department
        List<Node> neighbours; //list of neighbours of the node
        List<Route> routing; //static routing table
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
                for(int i = 0; i < routing.Count; i ++)
                {
                    Route route = routing[i];
                    if(route.to == packet.to)
                    {
                        Console.WriteLine(String.Format("[{3}][{0}] Sending packet to: {1} via {2}", this.name, route.to.name, route.via.name, packet.ID));
                        route.SendPacket(packet);
                        break;
                    }
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
        public List<Node> GetRoute(Node to, List<Node> nodes = null)
        {
            if (nodes == null) nodes = new List<Node>();
            if (to == this)
            {
                nodes.Add(this);
                return nodes;
            }
            for(int i = 0; i < routing.Count; i++)
            {
                Route route = routing[i];
                if(route.to == to)
                {
                    nodes.Add(this);
                    route.via.GetRoute(to, nodes);
                    break;
                }
            }
            return nodes;
        }
        public void Print()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(String.Format("{0} - {1}", this.id, this.name));
            for(int i = 0; i < routing.Count; i++)
            {
                Route route = routing[i];
                Console.WriteLine(String.Format("[{0}] {1}", this.name, route.ToString()));
                List<Node> r = this.GetRoute(route.to);
                for (int j = 0; j < r.Count; j++)
                {
                    if(j == 0)
                    {
                        Console.Write(r[j].name);
                    } else
                    {
                        Console.Write(" - " + r[j].name);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------");
        }
    }
}
