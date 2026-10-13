using System.Collections.Generic;

namespace ArbeidskravModul1.Graphs.Task4_BFS;

public static class BreadthFirstSearch
{
    // Besøker alle nåbare stasjoner nivå for nivå ved hjelp av en kø.
    public static List<string> Traverse(Graph graph, string start)
    {
        List<string> traversalOrder = new();

        if (!graph.ContainsStation(start))
        {
            return traversalOrder;
        }

        Queue<string> stationQueue = new();
        HashSet<string> visitedStations = new();

        stationQueue.Enqueue(start);
        visitedStations.Add(start);

        while (stationQueue.Count > 0)
        {
            string currentStation = stationQueue.Dequeue();
            traversalOrder.Add(currentStation);

            foreach (string neighbor in graph.GetNeighbors(currentStation))
            {
                if (!visitedStations.Contains(neighbor))
                {
                    visitedStations.Add(neighbor);
                    stationQueue.Enqueue(neighbor);
                }
            }
        }

        return traversalOrder;
    }

    // Finner korteste rute målt i antall forbindelser mellom to stasjoner.
    public static int ShortestDistance(Graph graph, string start, string destination)
    {
        if (!graph.ContainsStation(start) || !graph.ContainsStation(destination))
        {
            return -1;
        }

        Queue<string> stationQueue = new();
        Dictionary<string, int> distances = new();

        stationQueue.Enqueue(start);
        distances.Add(start, 0);

        while (stationQueue.Count > 0)
        {
            string currentStation = stationQueue.Dequeue();

            if (currentStation == destination)
            {
                return distances[currentStation];
            }

            foreach (string neighbor in graph.GetNeighbors(currentStation))
            {
                if (!distances.ContainsKey(neighbor))
                {
                    distances.Add(neighbor, distances[currentStation] + 1);
                    stationQueue.Enqueue(neighbor);
                }
            }
        }

        return -1;
    }
}
