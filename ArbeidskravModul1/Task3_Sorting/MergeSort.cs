namespace ArbeidskravModul1.Task3_Sorting;

public class MergeSortAlgorithm
{
    public int ComparisonCount { get; private set; }
    public int MergeCount { get; private set; }

    // Starter sorteringen og nullstiller tellerne for det nye datasettet.
    public void Sort(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        ComparisonCount = 0;
        MergeCount = 0;

        if (array.Length > 1)
        {
            MergeSort(array, 0, array.Length - 1);
        }
    }

    // Deler arrayet i mindre deler helt til hver del har ett element.
    public void MergeSort(int[] array, int left, int right)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            if (left == 0 && right == -1)
            {
                return;
            }

            throw new ArgumentException("Området som skal sorteres er ugyldig.");
        }

        if (left < 0 || left >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(left));
        }

        if (right < 0 || right >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(right));
        }

        if (left > right)
        {
            throw new ArgumentException("Venstre indeks må være mindre enn eller lik høyre indeks.");
        }

        if (left == right)
        {
            return;
        }

        int middle = left + (right - left) / 2;

        MergeSort(array, left, middle);
        MergeSort(array, middle + 1, right);
        Merge(array, left, middle, right);
    }

    // Slår sammen to sorterte deler, og velger venstre verdi først ved likhet.
    public void Merge(int[] array, int left, int middle, int right)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (left < 0 || middle < left || middle >= right || right >= array.Length)
        {
            throw new ArgumentException("Området som skal slås sammen er ugyldig.");
        }

        MergeCount++;

        int leftLength = middle - left + 1;
        int rightLength = right - middle;
        int[] leftPart = new int[leftLength];
        int[] rightPart = new int[rightLength];

        for (int i = 0; i < leftLength; i++)
        {
            leftPart[i] = array[left + i];
        }

        for (int i = 0; i < rightLength; i++)
        {
            rightPart[i] = array[middle + 1 + i];
        }

        int leftIndex = 0;
        int rightIndex = 0;
        int arrayIndex = left;

        // Fletter delene ved å sammenligne de neste verdiene i hver del.
        while (leftIndex < leftLength && rightIndex < rightLength)
        {
            ComparisonCount++;

            if (leftPart[leftIndex] <= rightPart[rightIndex])
            {
                array[arrayIndex] = leftPart[leftIndex];
                leftIndex++;
            }
            else
            {
                array[arrayIndex] = rightPart[rightIndex];
                rightIndex++;
            }

            arrayIndex++;
        }

        while (leftIndex < leftLength)
        {
            array[arrayIndex] = leftPart[leftIndex];
            leftIndex++;
            arrayIndex++;
        }

        while (rightIndex < rightLength)
        {
            array[arrayIndex] = rightPart[rightIndex];
            rightIndex++;
            arrayIndex++;
        }
    }
}
