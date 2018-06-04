using System;
using System.Collections.Generic;
using System.Text;

namespace RSK_Projekt
{
    class Project
    {
        List<Node> nodes;
        int oddzial_oddzial = 2589;
        int oddzial_centrala = 13334;
        int centrala_oddzial = 5178;
        public Project() {
            nodes = new List<Node>();
        }
        public void AddNode(Node node)
        {
            nodes.Add(node);
        }
        private Node GetCentral()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].isCentral) return nodes[i];
            }
            return null;
        }
        public void Simulate()
        {
            Node central = GetCentral();
            for (int i = 0; i < nodes.Count; i++)
            {
                Node node = nodes[i];
                node.Broadcast(nodes, oddzial_oddzial); //rozglaszanie do wszystkich wezlow
                if (node != central) node.SendPacket(central, oddzial_centrala); //rozglaszanie wezla do centrali
            }
            central.Broadcast(nodes, centrala_oddzial); //rozglaszanie centrali do wszystkich wezlow
        }
        public void Print()
        {
            for (int i = 0; i < nodes.Count; i++)
            {

                Node node = nodes[i];
                node.Print();
                Console.WriteLine();
            }
            double time = GetAverageTime(2.0);
            Console.WriteLine(String.Format("Time: {0}s", time));
        }
        private double GetAverageTime(double multiplayer)
        {
            List<Route> routes = GetAllRoutes();
            double time = 0;
            int packets = 0;
            double fi = 0;
            for(int i = 0; i < routes.Count; i++)
            {
                Route route = routes[i];
                packets += route.GetPackets();
                fi += (double)route.bits/((double)route.GetBandwidth(multiplayer) - (double)route.bits);
            }
            time = (1 / (double)packets) * fi;
            return time;
        }
        private List<Route> GetAllRoutes()
        {
            List<Route> routes = new List<Route>();
            for(int i = 0; i < nodes.Count; i++)
            {
                routes.AddRange(nodes[i].routing);
            }
            return routes;
        }
    }
}
