using System;
using System.Collections.Generic;

namespace RSK_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Project project = new Project();

            Node Opole = new Node(100, "Opole", true);
            Node Nysa = new Node(200, "Nysa");
            Node Walbrzych = new Node(300, "Walbrzych");
            Node Legnica = new Node(400, "Legnica");
            Node Wroclaw = new Node(500, "Wroclaw");
            Node Kluczbork = new Node(600, "Kluczbork");

            //dodawanie sasiadow
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


            //Lista routingu dla Opola
            
            Opole.AddRoute(new Route(new List<Node>(new Node[] { Nysa, Walbrzych }), Nysa));
            Opole.AddRoute(new Route(new List<Node>(new Node[] { Legnica, Wroclaw }), Legnica));
            Opole.AddRoute(new Route(new List<Node>(new Node[] { Kluczbork }), Kluczbork));

            //Lista routingu dla Nysy
            Nysa.AddRoute(new Route(new List<Node>(new Node[] { Opole, Kluczbork }), Opole));
            Nysa.AddRoute(new Route(new List<Node>(new Node[] { Walbrzych, Legnica, Wroclaw }), Walbrzych));

            //Lista routingu dla Walbrzycha
            Walbrzych.AddRoute(new Route(new List<Node>(new Node[] { Opole, Nysa, Kluczbork }), Nysa));
            Walbrzych.AddRoute(new Route(new List<Node>(new Node[] { Legnica, Wroclaw, Legnica }), Legnica));

            //Lista routingu dla Legnicy
            Legnica.AddRoute(new Route(new List<Node>(new Node[] { Opole }), Opole));
            Legnica.AddRoute(new Route(new List<Node>(new Node[] { Nysa, Walbrzych }), Walbrzych));
            Legnica.AddRoute(new Route(new List<Node>(new Node[] { Wroclaw, Kluczbork }), Wroclaw));

            //Lista routingu dla Wroclawia
            Wroclaw.AddRoute(new Route(new List<Node>(new Node[] { Opole, Kluczbork }), Kluczbork));
            Wroclaw.AddRoute(new Route(new List<Node>(new Node[] { Nysa, Walbrzych, Legnica }), Legnica));

            //Lista routingu dla Kluczborka
            Kluczbork.AddRoute(new Route(new List<Node>(new Node[] { Opole, Nysa, Walbrzych }), Opole));
            Kluczbork.AddRoute(new Route(new List<Node>(new Node[] { Wroclaw, Legnica }), Wroclaw));

            //Przypisywanie do listy wszystkich wezlow
            project.AddNode(Opole);
            project.AddNode(Nysa);
            project.AddNode(Walbrzych);
            project.AddNode(Legnica);
            project.AddNode(Wroclaw);
            project.AddNode(Kluczbork);

            project.Simulate();

            Console.WriteLine();
            Console.WriteLine("------------- SUMMARY -------------");

            project.Print();

            Console.ReadKey();
        }
    }
}
