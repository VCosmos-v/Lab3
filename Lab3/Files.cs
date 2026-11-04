using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
public struct Toy
{
    public string _Name;
    public int _Price;
    public int _AgeMin;
    public int _AgeMax;

    public Toy(string name, int price, int ageMin, int ageMax)
    {
        _Name = name;
        _Price = price;
        _AgeMin = ageMin;
        _AgeMax = ageMax;
    }
}

internal static class Files
{
    public static void FileInput4(string path, Validator validator)
    {
        int count = validator.ReadIntNatural("Введите количество чисел для бинарного файла:");
        using BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
        for (int i = 0; i < count; i++)
        {
            int val = validator.ReadInt($"Введите число {i + 1}:");
            writer.Write(val);
        }
    }

    public static void Bin4(string path)
    {
        int countSquares = 0;
        using BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            int val = reader.ReadInt32();
            int sqrt = (int)Math.Sqrt(val);
            if (sqrt * sqrt == val && sqrt % 2 != 0)
            {
                countSquares++;
            }
        }
        Console.WriteLine($"Количество квадратов нечетных чисел в файле: {countSquares}");
    }

    public static void FileInput5(string path, Validator validator)
    {
        int count = validator.ReadIntNatural("Введите количество игрушек:");
        Toy[] toys = new Toy[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nВвод данных для игрушки №{i + 1}:");
            Console.WriteLine("Введите название игрушки:");
            string name = Console.ReadLine() ?? "Игрушка";
            int price = validator.ReadIntNatural("Введите стоимость в рублях:");
            int ageMin = validator.ReadIntInterval("Введите минимальный возраст ребенка:", 0, 18);
            int ageMax = validator.ReadIntInterval("Введите максимальный возраст ребенка:", ageMin, 18);

            toys[i] = new Toy(name, price, ageMin, ageMax);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
        using FileStream fs = new FileStream(path, FileMode.Create);
        serializer.Serialize(fs, toys);
    }

    public static void Toys(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
        Toy[] toys;
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            toys = (Toy[])serializer.Deserialize(fs);
        }

        string s = "Нет подходящих игрушек";
        int maxPrice = -1;

        for (int i = 0; i < toys.Length; i++)
        {
            if (toys[i]._AgeMax <= 4 && toys[i]._Price > maxPrice)
            {
                maxPrice = toys[i]._Price;
                s = toys[i]._Name;
            }
        }

        Console.WriteLine($"Самая дорогая игрушка для детей до 4 лет: {s} (Цена: {maxPrice} руб.)");
    }

    public static void FileInput6(string path, Validator validator)
    {
        int count = validator.ReadIntNatural("Введите количество чисел для текстового файла:");
        using StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
        for (int i = 0; i < count; i++)
        {
            int val = validator.ReadInt($"Введите целое число {i + 1}:");
            sw.WriteLine(val);
        }
    }

    public static void Calc6(string path)
    {
        using StreamReader sr = new StreamReader(path, Encoding.UTF8);
        string? line = sr.ReadLine();
        if (line == null)
        {
            return;
        }

        int min = int.Parse(line);
        int max = min;

        while ((line = sr.ReadLine()) != null)
        {
            int val = int.Parse(line);
            if (val < min)
            {
                min = val;
            }
            if (val > max)
            {
                max = val;
            }
        }

        double average = (min + max) / 2.0;
        Console.WriteLine($"Минимум: {min}, Максимум: {max}, Среднее арифметическое: {average}");
    }

    public static void FileInput7(string path, Validator validator)
    {
        int linesCount = validator.ReadIntNatural("Введите количество строк в файле:");
        using StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);

        for (int i = 0; i < linesCount; i++)
        {
            Console.WriteLine($"Введите целые числа для строки {i + 1}, разделяя их пробелами:");
            string? line = Console.ReadLine();
            sw.WriteLine(line ?? string.Empty);
        }
    }

    public static void Calc7(string path)
    {
        using StreamReader sr = new StreamReader(path, Encoding.UTF8);
        long product = 1;
        bool foundEven = false;
        string? line;

        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                int val = int.Parse(parts[i]);
                if (val != 0 && val % 2 == 0)
                {
                    product *= val;
                    foundEven = true;
                }
            }
        }

        if (foundEven)
        {
            Console.WriteLine($"Произведение четных элементов: {product}");
        }
        else
        {
            Console.WriteLine("Четных элементов не найдено.");
        }
    }

    public static void FileInput8(string path, Validator validator)
    {
        int linesCount = validator.ReadIntNatural("Введите количество строк текста для исходного файла:");
        using StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);

        for (int i = 0; i < linesCount; i++)
        {
            Console.WriteLine($"Введите текст строки {i + 1}:");
            string? line = Console.ReadLine();
            sw.WriteLine(line ?? string.Empty);
        }
    }

    public static void TextRewrite(string srcPath, string destPath)
    {
        using StreamReader sr = new StreamReader(srcPath, Encoding.UTF8);
        using StreamWriter sw = new StreamWriter(destPath, false, Encoding.UTF8);
        string? line;

        while ((line = sr.ReadLine()) != null)
        {
            bool hasLatin = false;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    hasLatin = true;
                    break;
                }
            }

            if (!hasLatin)
            {
                sw.WriteLine(line);
            }
        }

        Console.WriteLine("Строки без латинских букв успешно переписаны в новый файл.");
    }
}