namespace ArbeidskravModul1.Task2_DataStructure;

public class CustomStack<T>
{
    // Hver node peker videre til elementet som ligger under i stakken.
    private sealed class Node
    {
        public T Value { get; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node? top;

    public int Count { get; private set; }

    public bool IsEmpty => top is null;

    // Legger et nytt element øverst i stakken.
    public void Push(T value)
    {
        Node newNode = new Node(value)
        {
            Next = top
        };

        top = newNode;
        Count++;
    }

    // Fjerner og returnerer elementet som ligger øverst.
    public T Pop()
    {
        if (top is null)
        {
            throw new InvalidOperationException("Stakken er tom.");
        }

        T value = top.Value;
        top = top.Next;
        Count--;
        return value;
    }

    // Leser elementet øverst uten å fjerne det.
    public T Peek()
    {
        if (top is null)
        {
            throw new InvalidOperationException("Stakken er tom.");
        }

        return top.Value;
    }
}
