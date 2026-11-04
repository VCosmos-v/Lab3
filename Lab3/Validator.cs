internal class Validator
{
    public int ReadInt(string prompt)
    {
        Console.WriteLine(prompt);
        string? s = Console.ReadLine();
        int x = 0;
        while (!int.TryParse(s, out x))
        {
            Console.WriteLine("Ошибка!");
            Console.WriteLine(prompt);
            s = Console.ReadLine();
        }
        return x;
    }

    public int ReadIntInterval(string prompt, int min, int max)
    {
        Console.WriteLine(prompt);
        string? s = Console.ReadLine();
        int x = 0;
        while (!int.TryParse(s, out x) || x < min || x > max)
        {
            Console.WriteLine("Ошибка!");
            Console.WriteLine(prompt);
            s = Console.ReadLine();
        }
        return x;
    }

    public int ReadIntNatural(string prompt)
    {
        Console.WriteLine(prompt);
        string? s = Console.ReadLine();
        int x = 0;
        while (!int.TryParse(s, out x) || x < 0)
        {
            Console.WriteLine("Ошибка!");
            Console.WriteLine(prompt);
            s = Console.ReadLine();
        }
        return x;
    }
}