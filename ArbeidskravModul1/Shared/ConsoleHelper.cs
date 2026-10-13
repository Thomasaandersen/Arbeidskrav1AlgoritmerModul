namespace ArbeidskravModul1.Shared;

public static class ConsoleHelper
{
    // Skriver en tydelig overskrift for en del av programmet.
    public static void PrintSection(string title)
    {
        Console.WriteLine();
        Console.WriteLine($"=== {title} ===");
        Console.WriteLine();
    }

    // Viser om en enkel kontroll bestod.
    public static void PrintCheck(string description, bool passed)
    {
        string result = passed ? "PASS" : "FAIL";
        Console.WriteLine($"{result}: {description}");
    }
}
