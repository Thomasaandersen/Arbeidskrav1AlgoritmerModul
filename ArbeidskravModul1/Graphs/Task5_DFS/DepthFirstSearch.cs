using System.Collections.Generic;

namespace ArbeidskravModul1.Graphs.Task5_DFS;

public static class DepthFirstSearch
{
    // Går så langt som mulig langs én rute før neste nabo besøkes.
    public static List<string> RecursiveTraversal(Graph graph, string start)
    {
        List<string> traversalOrder = new();

        if (!graph.ContainsStation(start))
        {
            return traversalOrder;
        }

        HashSet<string> visitedStations = new();
        VisitRecursively(graph, start, visitedStations, traversalOrder);

        return traversalOrder;
    }

    // Bruker en stakk til å gå gjennom grafen uten rekursive metodekall.
    public static List<string> IterativeTraversal(Graph graph, string start)
    {
        List<string> traversalOrder = new();

        if (!graph.ContainsStation(start))
        {
            return traversalOrder;
        }

        Stack<string> stationStack = new();
        HashSet<string> visitedStations = new();
        stationStack.Push(start);
        visitedStations.Add(start);

        while (stationStack.Count > 0)
        {
            string currentStation = stationStack.Pop();
            traversalOrder.Add(currentStation);
            IReadOnlyList<string> neighbors = graph.GetNeighbors(currentStation);

            // Prøver naboene i motsatt rekkefølge, slik at første nabo behandles først.
            for (int index = neighbors.Count - 1; index >= 0; index--)
            {
                string neighbor = neighbors[index];

                if (visitedStations.Add(neighbor))
                {
                    stationStack.Push(neighbor);
                }
            }
        }

        return traversalOrder;
    }

    // Sjekker rekursivt om det finnes en rute mellom to stasjoner.
    public static bool HasPath(Graph graph, string start, string destination)
    {
        if (!graph.ContainsStation(start) || !graph.ContainsStation(destination))
        {
            return false;
        }

        HashSet<string> visitedStations = new();
        return FindPathRecursively(graph, start, destination, visitedStations);
    }

    // Besøker hver stasjon en gang under rekursiv traversering.
    private static void VisitRecursively(
        Graph graph,
        string currentStation,
        HashSet<string> visitedStations,
        List<string> traversalOrder)
    {
        visitedStations.Add(currentStation);
        traversalOrder.Add(currentStation);

        foreach (string neighbor in graph.GetNeighbors(currentStation))
        {
            if (!visitedStations.Contains(neighbor))
            {
                VisitRecursively(graph, neighbor, visitedStations, traversalOrder);
            }
        }
    }

    // Returnerer true når målet nås, og bruker besøkte stasjoner for å stoppe sykler.
    private static bool FindPathRecursively(
        Graph graph,
        string currentStation,
        string destination,
        HashSet<string> visitedStations)
    {
        if (currentStation == destination)
        {
            return true;
        }

        visitedStations.Add(currentStation);

        foreach (string neighbor in graph.GetNeighbors(currentStation))
        {
            if (!visitedStations.Contains(neighbor)
                && FindPathRecursively(graph, neighbor, destination, visitedStations))
            {
                return true;
            }
        }

        return false;
    }
}
