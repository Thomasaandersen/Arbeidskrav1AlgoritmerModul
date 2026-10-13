using ArbeidskravModul1.Shared;

namespace ArbeidskravModul1.Task3_Sorting;

public static class SortingDemo
{
    public static void Run()
    {
        ConsoleHelper.PrintSection("Oppgave 3 - MergeSort");

        RunExample(
            "Oppgitt datasett",
            new int[] { 64, 34, 25, 12, 22, 11, 90 },
            new int[] { 11, 12, 22, 25, 34, 64, 90 });

        RunExample(
            "Allerede sortert",
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 });

        RunExample(
            "Sortert i motsatt rekkefølge",
            new int[] { 9, 8, 7, 6, 5 },
            new int[] { 5, 6, 7, 8, 9 });

        RunExample(
            "Duplikater",
            new int[] { 4, 2, 4, 1, 2 },
            new int[] { 1, 2, 2, 4, 4 });

        RunExample("Tomt array", Array.Empty<int>(), Array.Empty<int>());
        RunExample("Ett element", new int[] { 42 }, new int[] { 42 });
    }

    // Viser resultatet og kontrollerer det mot forventet sortering.
    private static void RunExample(string name, int[] array, int[] expectedArray)
    {
        MergeSortAlgorithm algorithm = new MergeSortAlgorithm();

        Console.WriteLine($"Test: {name}");
        Console.Write("Før sortering: ");
        PrintArray(array);

        algorithm.Sort(array);

        Console.Write("Etter sortering: ");
        PrintArray(array);
        Console.WriteLine($"Sammenligninger: {algorithm.ComparisonCount}");
        Console.WriteLine($"Sammenslåinger: {algorithm.MergeCount}");
        ConsoleHelper.PrintCheck($"{name} er sortert riktig", ArraysMatch(array, expectedArray));
        Console.WriteLine();
    }

    // Sammenligner to arrayer uten å bruke ekstra biblioteker.
    private static bool ArraysMatch(int[] firstArray, int[] secondArray)
    {
        if (firstArray.Length != secondArray.Length)
        {
            return false;
        }

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                return false;
            }
        }

        return true;
    }

    // Skriver ut verdiene i arrayet med hakeparenteser.
    private static void PrintArray(int[] array)
    {
        Console.Write("[");

        for (int i = 0; i < array.Length; i++)
        {
            if (i > 0)
            {
                Console.Write(", ");
            }

            Console.Write(array[i]);
        }

        Console.WriteLine("]");
    }
}
