using ArbeidskravModul1.Graphs;
using ArbeidskravModul1.Graphs.Task4_BFS;
using ArbeidskravModul1.Graphs.Task5_DFS;
using ArbeidskravModul1.Shared;
using ArbeidskravModul1.Task1_Searching;
using ArbeidskravModul1.Task2_DataStructure;
using ArbeidskravModul1.Task3_Sorting;

Graph graph = CreateTransportGraph();
bool isRunning = true;

while (isRunning)
{
    ShowMenu();
    Console.Write("Velg oppgave: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            SearchDemo.Run();
            break;
        case "2":
            DataStructureDemo.Run();
            break;
        case "3":
            SortingDemo.Run();
            break;
        case "4":
            BfsDemo.Run(graph);
            break;
        case "5":
            DfsDemo.Run(graph);
            break;
        case "0":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Ugyldig valg. Velg et tall fra menyen.");
            break;
    }
}

Console.WriteLine("Programmet er avsluttet.");

// Viser oppgavene som kan kjøres fra konsollen.
static void ShowMenu()
{
    ConsoleHelper.PrintSection("Arbeidskrav 1 - Algoritmer");
    Console.WriteLine("1. Oppgave 1 - Lineært søk og binærsøk");
    Console.WriteLine("2. Oppgave 2 - Egen stakk");
    Console.WriteLine("3. Oppgave 3 - MergeSort");
    Console.WriteLine("4. Oppgave 4 - Graf og BFS");
    Console.WriteLine("5. Oppgave 5 - DFS");
    Console.WriteLine("0. Avslutt");
}

// Bygger testgrafen og legger til en ekstra kant som lager en sykel.
static Graph CreateTransportGraph()
{
    Graph graph = new Graph();

    graph.AddConnection("Majorstuen", "Nationaltheatret");
    graph.AddConnection("Nationaltheatret", "Stortinget");
    graph.AddConnection("Stortinget", "Jernbanetorget");
    graph.AddConnection("Jernbanetorget", "Grønland");
    graph.AddConnection("Grønland", "Tøyen");
    graph.AddConnection("Majorstuen", "Blindern");
    graph.AddConnection("Blindern", "Forskningsparken");
    graph.AddConnection("Forskningsparken", "Ullevål stadion");

    // Ekstrakanten lager en sykel uten å endre korteste rute til Grønland.
    graph.AddConnection("Nationaltheatret", "Blindern");
    graph.AddStation("Lysaker");

    return graph;
}
