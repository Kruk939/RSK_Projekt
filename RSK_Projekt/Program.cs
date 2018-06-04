using System;
using System.Collections.Generic;

namespace RSK_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();
            int oddzial_oddzial = 2589;
            int oddzial_centrala = 13334;
            int centrala_oddzial = 5178;


            Node Opole = new Node(100, "Opole", true);
            Node Nysa = new Node(200, "Nysa");
            Node Walbrzych = new Node(300, "Walbrzych");
            Node Legnica = new Node(400, "Legnica");
            Node Wroclaw = new Node(500, "Wroclaw");
            Node Kluczbork = new Node(600, "Kluczbork");

            Opole.AddNeighbour(Nysa);
            Opole.AddNeighbour(Legnica);
            Opole.AddNeighbour(Kluczbork);
            Nysa.AddNeighbour(Walbrzych);
            Nysa.AddNeighbour(Opole);
            Walbrzych.AddNeighbour(Legnica);
            Walbrzych.AddNeighbour(Nysa);
            Legnica.AddNeighbour(Wroclaw);
            Legnica.AddNeighbour(Opole);
            Legnica.AddNeighbour(Walbrzych);
            Wroclaw.AddNeighbour(Kluczbork);
            Wroclaw.AddNeighbour(Legnica);
            Kluczbork.AddNeighbour(Opole);
            Kluczbork.AddNeighbour(Wroclaw);

            
            Opole.AddRoute(new Route(Nysa, Nysa));
            Opole.AddRoute(new Route(Walbrzych, Nysa));
            Opole.AddRoute(new Route(Legnica, Legnica));
            Opole.AddRoute(new Route(Wroclaw, Legnica));
            Opole.AddRoute(new Route(Kluczbork, Kluczbork));

            Nysa.AddRoute(new Route(Opole, Opole));
            Nysa.AddRoute(new Route(Walbrzych, Walbrzych));
            Nysa.AddRoute(new Route(Legnica, Walbrzych));
            Nysa.AddRoute(new Route(Wroclaw, Walbrzych));
            Nysa.AddRoute(new Route(Kluczbork, Opole));

            Walbrzych.AddRoute(new Route(Opole, Nysa));
            Walbrzych.AddRoute(new Route(Nysa, Nysa));
            Walbrzych.AddRoute(new Route(Legnica, Legnica));
            Walbrzych.AddRoute(new Route(Wroclaw, Legnica));
            Walbrzych.AddRoute(new Route(Kluczbork, Nysa));

            Legnica.AddRoute(new Route(Opole, Opole));
            Legnica.AddRoute(new Route(Nysa, Walbrzych));
            Legnica.AddRoute(new Route(Walbrzych, Walbrzych));
            Legnica.AddRoute(new Route(Wroclaw, Wroclaw));
            Legnica.AddRoute(new Route(Kluczbork, Wroclaw));

            Wroclaw.AddRoute(new Route(Opole, Kluczbork));
            Wroclaw.AddRoute(new Route(Nysa, Legnica));
            Wroclaw.AddRoute(new Route(Walbrzych, Legnica));
            Wroclaw.AddRoute(new Route(Legnica, Legnica));
            Wroclaw.AddRoute(new Route(Kluczbork, Kluczbork));

            Kluczbork.AddRoute(new Route(Opole, Opole));
            Kluczbork.AddRoute(new Route(Nysa, Opole));
            Kluczbork.AddRoute(new Route(Walbrzych, Opole));
            Kluczbork.AddRoute(new Route(Legnica, Wroclaw));
            Kluczbork.AddRoute(new Route(Wroclaw, Wroclaw));


            nodes.Add(Opole);
            nodes.Add(Nysa);
            nodes.Add(Walbrzych);
            nodes.Add(Legnica);
            nodes.Add(Wroclaw);
            nodes.Add(Kluczbork);

            Opole.Broadcast(nodes, oddzial_oddzial);
            Nysa.Broadcast(nodes, oddzial_oddzial);
            Walbrzych.Broadcast(nodes, oddzial_oddzial);
            Legnica.Broadcast(nodes, oddzial_oddzial);
            Wroclaw.Broadcast(nodes, oddzial_oddzial);
            Kluczbork.Broadcast(nodes, oddzial_oddzial);
            Opole.Broadcast(nodes, centrala_oddzial);

            for(int i = 0; i < nodes.Count; i++)
            {
                Node node = nodes[i];
                node.SendPacket(Opole, oddzial_centrala);
            }
            Console.WriteLine();
            Console.WriteLine("------------- SUMMARY -------------");

            for (int i = 0; i < nodes.Count; i++)
            {

                Node node = nodes[i];
                node.Print();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
