namespace ArbeidskravModul1.Task1_Searching;

public static class BinarySearchAlgorithm
{
    // Søker i et sortert array og returnerer den første forekomsten av målet.
    public static int BinarySearch(int[] array, int target)
    {
        return BinarySearch(array, target, out int comparisons);
    }

    // Teller sammenligninger mellom arrayverdier og målet under søket.
    public static int BinarySearch(int[] array, int target, out int comparisons)
    {
        ArgumentNullException.ThrowIfNull(array);

        comparisons = 0;
        int left = 0;
        int right = array.Length - 1;
        int foundIndex = -1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            comparisons++;

            if (array[middle] == target)
            {
                foundIndex = middle;

                // Fortsetter mot venstre for å finne første treff ved duplikater.
                right = middle - 1;
            }
            else
            {
                comparisons++;

                if (array[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
        }

        return foundIndex;
    }
}
