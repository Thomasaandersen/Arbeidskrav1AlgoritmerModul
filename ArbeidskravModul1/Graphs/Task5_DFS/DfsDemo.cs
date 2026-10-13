using System;
using System.Collections.Generic;
using ArbeidskravModul1.Graphs.Task4_BFS;
using ArbeidskravModul1.Shared;

namespace ArbeidskravModul1.Graphs.Task5_DFS;

public static class DfsDemo
{
    // Viser BFS og begge DFS-variantene på samme testgraf.
    public static void Run(Graph graph)
    {
        ConsoleHelper.PrintSection("Oppgave 5 - Dybde-først-søk (DFS)");

        string startStation = "Majorstuen";
        List<string> breadthFirstOrder = BreadthFirstSearch.Traverse(graph, startStation);
        List<string> recursiveDepthFirstOrder = DepthFirstSearch.RecursiveTraversal(graph, startStation);
        List<string> iterativeDepthFirstOrder = DepthFirstSearch.IterativeTraversal(graph, startStation);

        Console.WriteLine($"BFS fra {startStation}:");
        Console.WriteLine(string.Join(" -> ", breadthFirstOrder));
        Console.WriteLine($"Rekursiv DFS fra {startStation}:");
        Console.WriteLine(string.Join(" -> ", recursiveDepthFirstOrder));
        Console.WriteLine($"Iterativ DFS fra {startStation}:");
        Console.WriteLine(string.Join(" -> ", iterativeDepthFirstOrder));

        HashSet<string> breadthFirstStations = new(breadthFirstOrder);
        ConsoleHelper.PrintCheck("Begge DFS-variantene finner de samme nåbare stasjonene som BFS.",
            breadthFirstStations.SetEquals(recursiveDepthFirstOrder)
            && breadthFirstStations.SetEquals(iterativeDepthFirstOrder));
        ConsoleHelper.PrintCheck("Rekursiv DFS besøker hver stasjon bare én gang.",
            recursiveDepthFirstOrder.Count == new HashSet<string>(recursiveDepthFirstOrder).Count);
        ConsoleHelper.PrintCheck("Iterativ DFS besøker hver stasjon bare én gang.",
            iterativeDepthFirstOrder.Count == new HashSet<string>(iterativeDepthFirstOrder).Count);

        ConsoleHelper.PrintCheck("Det finnes en rute fra Majorstuen til Tøyen.",
            DepthFirstSearch.HasPath(graph, "Majorstuen", "Tøyen"));
        ConsoleHelper.PrintCheck("Lysaker har ingen rute til Majorstuen.",
            !DepthFirstSearch.HasPath(graph, "Lysaker", "Majorstuen"));
        ConsoleHelper.PrintCheck("En stasjon har en rute til seg selv.",
            DepthFirstSearch.HasPath(graph, "Lysaker", "Lysaker"));

        List<string> recursiveLysakerOrder = DepthFirstSearch.RecursiveTraversal(graph, "Lysaker");
        List<string> iterativeLysakerOrder = DepthFirstSearch.IterativeTraversal(graph, "Lysaker");
        ConsoleHelper.PrintCheck("Rekursiv og iterativ DFS fra Lysaker besøker bare Lysaker.",
            recursiveLysakerOrder.Count == 1
            && recursiveLysakerOrder[0] == "Lysaker"
            && iterativeLysakerOrder.Count == 1
            && iterativeLysakerOrder[0] == "Lysaker");
        ConsoleHelper.PrintCheck("DFS fra en stasjon som mangler gir en tom rekkefølge.",
            DepthFirstSearch.RecursiveTraversal(graph, "Ukjent stasjon").Count == 0
            && DepthFirstSearch.IterativeTraversal(graph, "Ukjent stasjon").Count == 0);
        ConsoleHelper.PrintCheck("En stasjon som mangler kan ikke være del av en rute.",
            !DepthFirstSearch.HasPath(graph, "Majorstuen", "Ukjent stasjon"));

        Graph emptyGraph = new Graph();
        ConsoleHelper.PrintCheck("Begge DFS-variantene gir tom rekkefølge for en tom graf.",
            DepthFirstSearch.RecursiveTraversal(emptyGraph, "Start").Count == 0
            && DepthFirstSearch.IterativeTraversal(emptyGraph, "Start").Count == 0);

        Graph oneStationGraph = new Graph();
        oneStationGraph.AddStation("Solo");
        List<string> recursiveSoloOrder = DepthFirstSearch.RecursiveTraversal(oneStationGraph, "Solo");
        List<string> iterativeSoloOrder = DepthFirstSearch.IterativeTraversal(oneStationGraph, "Solo");
        ConsoleHelper.PrintCheck("Begge DFS-variantene besøker én stasjon i en graf med én stasjon.",
            recursiveSoloOrder.Count == 1 && recursiveSoloOrder[0] == "Solo"
            && iterativeSoloOrder.Count == 1 && iterativeSoloOrder[0] == "Solo");
    }
}
