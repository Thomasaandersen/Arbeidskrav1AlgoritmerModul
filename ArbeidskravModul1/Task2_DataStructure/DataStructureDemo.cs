using ArbeidskravModul1.Shared;

namespace ArbeidskravModul1.Task2_DataStructure;

public static class DataStructureDemo
{
    // Viser at stakken følger LIFO og kontrollerer de viktigste operasjonene.
    public static void Run()
    {
        ConsoleHelper.PrintSection("Oppgave 2 - Egen generisk stakk");

        CustomStack<int> stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("Stakken fylles med 10, 20 og 30.");
        Console.WriteLine($"Peek viser øverste verdi: {stack.Peek()}");
        int firstPopped = stack.Pop();
        int secondPopped = stack.Pop();
        int thirdPopped = stack.Pop();
        Console.WriteLine($"Verdier fjernes i denne rekkefølgen: {firstPopped}, {secondPopped}, {thirdPopped}");

        ConsoleHelper.PrintCheck("Count blir null etter at alle elementene er fjernet", stack.Count == 0);

        CustomStack<int> countStack = new CustomStack<int>();
        countStack.Push(10);
        countStack.Push(20);
        countStack.Push(30);
        ConsoleHelper.PrintCheck("Count øker når elementer legges til", countStack.Count == 3);

        CustomStack<int> peekStack = new CustomStack<int>();
        peekStack.Push(10);
        peekStack.Push(20);
        bool peekIsCorrect = peekStack.Peek() == 20 && peekStack.Count == 2;
        ConsoleHelper.PrintCheck("Peek viser øverste element uten å fjerne det", peekIsCorrect);

        CustomStack<int> popStack = new CustomStack<int>();
        popStack.Push(10);
        popStack.Push(20);
        popStack.Push(30);
        int firstValue = popStack.Pop();
        int secondValue = popStack.Pop();
        int thirdValue = popStack.Pop();
        bool popIsLifo = firstValue == 30 && secondValue == 20 && thirdValue == 10;
        ConsoleHelper.PrintCheck("Pop følger LIFO-rekkefølgen", popIsLifo);
        ConsoleHelper.PrintCheck("Stakken er tom etter at alle elementene er fjernet", popStack.IsEmpty && popStack.Count == 0);

        CustomStack<int> emptyStack = new CustomStack<int>();
        ConsoleHelper.PrintCheck("Tom stakk rapporteres med IsEmpty", emptyStack.IsEmpty);

        bool popOnEmptyThrows = false;
        try
        {
            emptyStack.Pop();
        }
        catch (InvalidOperationException)
        {
            popOnEmptyThrows = true;
        }

        ConsoleHelper.PrintCheck("Pop på tom stakk gir InvalidOperationException", popOnEmptyThrows);

        bool peekOnEmptyThrows = false;
        try
        {
            emptyStack.Peek();
        }
        catch (InvalidOperationException)
        {
            peekOnEmptyThrows = true;
        }

        ConsoleHelper.PrintCheck("Peek på tom stakk gir InvalidOperationException", peekOnEmptyThrows);

        CustomStack<string> wordStack = new CustomStack<string>();
        wordStack.Push("først");
        wordStack.Push("sist");
        ConsoleHelper.PrintCheck("Den generiske stakken kan også brukes med tekst", wordStack.Pop() == "sist");
    }
}
