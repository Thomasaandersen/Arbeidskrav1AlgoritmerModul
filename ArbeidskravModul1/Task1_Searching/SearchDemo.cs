using ArbeidskravModul1.Shared;

namespace ArbeidskravModul1.Task1_Searching;

public static class SearchDemo
{
    // Viser søkene på oppgitte eksempler og noen viktige grenseverdier.
    public static void Run()
    {
        ConsoleHelper.PrintSection("Oppgave 1 - Lineært søk og binærsøk");

        int[] unsortedNumbers = { 8, 3, 11, 7, 2, 9, 5 };
        int linearIndex = LinearSearchAlgorithm.LinearSearch(unsortedNumbers, 7, out int linearComparisons);
        ShowSearch("Lineært søk etter 7", unsortedNumbers, linearIndex, linearComparisons);
        ConsoleHelper.PrintCheck("Lineært søk finner 7 på indeks 3", linearIndex == 3 && linearComparisons == 4);

        int missingLinearIndex = LinearSearchAlgorithm.LinearSearch(unsortedNumbers, 42, out int missingLinearComparisons);
        ShowSearch("Lineært søk etter en verdi som mangler", unsortedNumbers, missingLinearIndex, missingLinearComparisons);
        ConsoleHelper.PrintCheck("Lineært søk undersøker hele arrayet når verdien mangler", missingLinearIndex == -1 && missingLinearComparisons == 7);

        int[] sortedNumbers = { 2, 5, 7, 9, 11, 13, 17 };
        int binaryIndex = BinarySearchAlgorithm.BinarySearch(sortedNumbers, 13, out int binaryComparisons);
        ShowSearch("Binærsøk etter 13", sortedNumbers, binaryIndex, binaryComparisons);
        ConsoleHelper.PrintCheck("Binærsøk finner 13 på indeks 5", binaryIndex == 5 && binaryComparisons == 5);

        int missingBinaryIndex = BinarySearchAlgorithm.BinarySearch(sortedNumbers, 4, out int missingBinaryComparisons);
        ShowSearch("Binærsøk etter en verdi som mangler", sortedNumbers, missingBinaryIndex, missingBinaryComparisons);
        ConsoleHelper.PrintCheck("Binærsøk returnerer -1 når verdien mangler", missingBinaryIndex == -1);

        int[] emptyNumbers = Array.Empty<int>();
        int emptyLinearIndex = LinearSearchAlgorithm.LinearSearch(emptyNumbers, 5, out int emptyLinearComparisons);
        ShowSearch("Lineært søk i et tomt array", emptyNumbers, emptyLinearIndex, emptyLinearComparisons);
        ConsoleHelper.PrintCheck("Lineært søk i et tomt array gir -1 uten sammenligninger", emptyLinearIndex == -1 && emptyLinearComparisons == 0);

        int emptyBinaryIndex = BinarySearchAlgorithm.BinarySearch(emptyNumbers, 5, out int emptyBinaryComparisons);
        ShowSearch("Binærsøk i et tomt array", emptyNumbers, emptyBinaryIndex, emptyBinaryComparisons);
        ConsoleHelper.PrintCheck("Binærsøk i et tomt array gir -1 uten sammenligninger", emptyBinaryIndex == -1 && emptyBinaryComparisons == 0);

        int[] oneNumber = { 6 };
        int oneLinearIndex = LinearSearchAlgorithm.LinearSearch(oneNumber, 6, out int oneLinearComparisons);
        ShowSearch("Lineært søk i et array med ett element", oneNumber, oneLinearIndex, oneLinearComparisons);
        ConsoleHelper.PrintCheck("Lineært søk fungerer med ett element", oneLinearIndex == 0 && oneLinearComparisons == 1);

        int oneBinaryIndex = BinarySearchAlgorithm.BinarySearch(oneNumber, 6, out int oneBinaryComparisons);
        ShowSearch("Binærsøk i et array med ett element", oneNumber, oneBinaryIndex, oneBinaryComparisons);
        ConsoleHelper.PrintCheck("Binærsøk fungerer med ett element", oneBinaryIndex == 0 && oneBinaryComparisons == 1);

        int[] duplicateNumbers = { 1, 2, 2, 2, 3 };
        int linearDuplicateIndex = LinearSearchAlgorithm.LinearSearch(duplicateNumbers, 2, out int linearDuplicateComparisons);
        ShowSearch("Lineært søk etter 2 med duplikater", duplicateNumbers, linearDuplicateIndex, linearDuplicateComparisons);
        ConsoleHelper.PrintCheck("Lineært søk returnerer første forekomst av en duplikatverdi", linearDuplicateIndex == 1);

        int duplicateIndex = BinarySearchAlgorithm.BinarySearch(duplicateNumbers, 2, out int duplicateComparisons);
        ShowSearch("Binærsøk etter 2 med duplikater", duplicateNumbers, duplicateIndex, duplicateComparisons);
        ConsoleHelper.PrintCheck("Binærsøk returnerer første forekomst av en duplikatverdi", duplicateIndex == 1);

        int outsideLinearIndex = LinearSearchAlgorithm.LinearSearch(sortedNumbers, 100, out int outsideLinearComparisons);
        ShowSearch("Lineært søk etter en verdi over området", sortedNumbers, outsideLinearIndex, outsideLinearComparisons);
        ConsoleHelper.PrintCheck("Lineært søk håndterer en verdi utenfor området", outsideLinearIndex == -1);

        int outsideBinaryIndex = BinarySearchAlgorithm.BinarySearch(sortedNumbers, 100, out int outsideBinaryComparisons);
        ShowSearch("Binærsøk etter en verdi over området", sortedNumbers, outsideBinaryIndex, outsideBinaryComparisons);
        ConsoleHelper.PrintCheck("Binærsøk håndterer en verdi utenfor området", outsideBinaryIndex == -1);

        int sortedRequiredResult = BinarySearchAlgorithm.BinarySearch(unsortedNumbers, 8, out int unsortedBinaryComparisons);
        ShowSearch("Binærsøk på usorterte data", unsortedNumbers, sortedRequiredResult, unsortedBinaryComparisons);
        int linearUnsortedResult = LinearSearchAlgorithm.LinearSearch(unsortedNumbers, 8, out int unsortedLinearComparisons);
        ShowSearch("Lineært søk på de samme usorterte dataene", unsortedNumbers, linearUnsortedResult, unsortedLinearComparisons);
        Console.WriteLine("Binærsøk krever et sortert array. Resultatet for usorterte verdier er derfor ikke pålitelig.");
        ConsoleHelper.PrintCheck("Lineært søk kan finne 8 i et usortert array", linearUnsortedResult == 0);
        Console.WriteLine($"Binærsøk ga {sortedRequiredResult} på det samme usorterte arrayet.");
    }

    // Skriver ut data, resultatindeks og antall sammenligninger.
    private static void ShowSearch(string title, int[] array, int index, int comparisons)
    {
        Console.WriteLine(title);
        Console.Write("Array: ");
        PrintArray(array);
        Console.WriteLine($"Indeks: {index}");
        Console.WriteLine($"Sammenligninger: {comparisons}");
    }

    // Skriver ut et array på en lettlest måte.
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
