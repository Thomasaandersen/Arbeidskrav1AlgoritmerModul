using System.Collections.Generic;

namespace ArbeidskravModul1.Graphs;

// Lagrer stasjoner og forbindelsene mellom dem som en naboliste.
public class Graph
{
    private readonly Dictionary<string, List<string>> adjacencyList = new();

    // Legger til en stasjon hvis den ikke finnes fra før.
    public void AddStation(string station)
    {
        if (!adjacencyList.ContainsKey(station))
        {
            adjacencyList.Add(station, new List<string>());
        }
    }

    // Legger til samme forbindelse fra begge stasjonene.
    public void AddConnection(string firstStation, string secondStation)
    {
        AddStation(firstStation);
        AddStation(secondStation);

        if (!adjacencyList[firstStation].Contains(secondStation))
        {
            adjacencyList[firstStation].Add(secondStation);
        }

        if (!adjacencyList[secondStation].Contains(firstStation))
        {
            adjacencyList[secondStation].Add(firstStation);
        }
    }

    // Sjekker om stasjonen er registrert i grafen.
    public bool ContainsStation(string station)
    {
        return adjacencyList.ContainsKey(station);
    }

    // Henter naboene, eller en tom liste hvis stasjonen ikke finnes.
    public IReadOnlyList<string> GetNeighbors(string station)
    {
        if (adjacencyList.TryGetValue(station, out List<string>? neighbors))
        {
            return neighbors;
        }

        return new List<string>();
    }
}
