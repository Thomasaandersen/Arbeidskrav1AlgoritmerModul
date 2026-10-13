using System;
using System.Collections.Generic;
using ArbeidskravModul1.Shared;

namespace ArbeidskravModul1.Graphs.Task4_BFS;

public static class BfsDemo
{
    // Viser BFS-rekkefølgen og kontrollerer ruteavstander fra testgrafen.
    public static void Run(Graph graph)
    {
        ConsoleHelper.PrintSection("Oppgave 4 - Bredde-først-søk (BFS)");

        string startStation = "Majorstuen";
        List<string> traversalOrder = BreadthFirstSearch.Traverse(graph, startStation);
        List<string> expectedOrder = new()
        {
            "Majorstuen",
            "Nationaltheatret",
            "Blindern",
            "Stortinget",
            "Forskningsparken",
            "Jernbanetorget",
            "Ullevål stadion",
            "Grønland",
            "Tøyen"
        };

        Console.WriteLine($"BFS fra {startStation}:");
        Console.WriteLine(string.Join(" -> ", traversalOrder));
        ConsoleHelper.PrintCheck("BFS besøker stasjonene i forventet nivårekkefølge.",
            ListsMatch(traversalOrder, expectedOrder));

        int distanceToGreenland = BreadthFirstSearch.ShortestDistance(graph, startStation, "Grønland");
        Console.WriteLine($"Korteste avstand fra {startStation} til Grønland: {distanceToGreenland} forbindelser");
        ConsoleHelper.PrintCheck("Korteste avstand til Grønland er 4 forbindelser.", distanceToGreenland == 4);

        int distanceAcrossCycle = BreadthFirstSearch.ShortestDistance(graph, "Ullevål stadion", "Tøyen");
        Console.WriteLine($"Korteste avstand fra Ullevål stadion til Tøyen: {distanceAcrossCycle} forbindelser");
        ConsoleHelper.PrintCheck("Ekstrakanten gir en rute på 7 forbindelser til Tøyen.", distanceAcrossCycle == 7);

        List<string> isolatedStationOrder = BreadthFirstSearch.Traverse(graph, "Lysaker");
        Console.WriteLine("BFS fra den isolerte stasjonen Lysaker:");
        Console.WriteLine(string.Join(" -> ", isolatedStationOrder));
        ConsoleHelper.PrintCheck("BFS fra Lysaker besøker bare Lysaker.",
            ListsMatch(isolatedStationOrder, new List<string> { "Lysaker" }));
        ConsoleHelper.PrintCheck("Det finnes ingen rute fra Lysaker til Majorstuen.",
            BreadthFirstSearch.ShortestDistance(graph, "Lysaker", startStation) == -1);

        ConsoleHelper.PrintCheck("BFS fra en stasjon som mangler gir en tom rekkefølge.",
            BreadthFirstSearch.Traverse(graph, "Ukjent stasjon").Count == 0);
        ConsoleHelper.PrintCheck("Avstand med en startstasjon som mangler er -1.",
            BreadthFirstSearch.ShortestDistance(graph, "Ukjent stasjon", startStation) == -1);
        ConsoleHelper.PrintCheck("Avstand til en stasjon som mangler er -1.",
            BreadthFirstSearch.ShortestDistance(graph, startStation, "Ukjent stasjon") == -1);

        Graph emptyGraph = new Graph();
        ConsoleHelper.PrintCheck("BFS i en tom graf gir en tom rekkefølge.",
            BreadthFirstSearch.Traverse(emptyGraph, "Start").Count == 0);

        Graph oneStationGraph = new Graph();
        oneStationGraph.AddStation("Solo");
        ConsoleHelper.PrintCheck("BFS i en graf med én stasjon besøker startstasjonen.",
            ListsMatch(BreadthFirstSearch.Traverse(oneStationGraph, "Solo"), new List<string> { "Solo" }));
        ConsoleHelper.PrintCheck("Korteste avstand fra en stasjon til seg selv er 0.",
            BreadthFirstSearch.ShortestDistance(oneStationGraph, "Solo", "Solo") == 0);
    }

    // Sammenligner to stasjonslister i samme rekkefølge.
    private static bool ListsMatch(List<string> firstList, List<string> secondList)
    {
        if (firstList.Count != secondList.Count)
        {
            return false;
        }

        for (int index = 0; index < firstList.Count; index++)
        {
            if (firstList[index] != secondList[index])
            {
                return false;
            }
        }

        return true;
    }
}
