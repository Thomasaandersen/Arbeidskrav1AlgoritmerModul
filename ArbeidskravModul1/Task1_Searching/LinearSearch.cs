namespace ArbeidskravModul1.Task1_Searching;

public static class LinearSearchAlgorithm
{
    // Søker fra starten av arrayet og gir tilbake indeksen til første treff.
    public static int LinearSearch(int[] array, int target)
    {
        return LinearSearch(array, target, out int comparisons);
    }

    // Søker lineært og teller verdiene som sammenlignes med målet.
    public static int LinearSearch(int[] array, int target, out int comparisons)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        comparisons = 0;

        for (int i = 0; i < array.Length; i++)
        {
            comparisons++;

            if (array[i] == target)
            {
                return i;
            }
        }

        return -1;
    }
}
