using System.Drawing;

internal class Program
{
    public static void Main(string[] args)
    {
        Program menu = new Program();
        menu.Menu();
    }

    private void PrintMenu()
    {
        Console.WriteLine("\n1. Заполнение двумерных массивов");
        Console.WriteLine("2. Школьники с баллом >= 4.5");
        Console.WriteLine("3. Матричное выражение");
        Console.WriteLine("4. Количество квадратов нечетных чисел среди компонент файла");
        Console.WriteLine("5. Самая дорогая игрушка");
        Console.WriteLine("6. В файле найти среднее арифметическое максимального и минимального элементов");
        Console.WriteLine("7. Вычислить произведение чётных элементов");
        Console.WriteLine("8. Переписать в другой файл строки, в которых нет латинских букв");
        Console.WriteLine("0. Выход");
    }

    private void Menu()
    {
        Validator validator = new Validator();
        Program menu = new Program();
        int num = -1;
        while (num != 0)
        {
            PrintMenu();
            num = validator.ReadIntInterval("Выберите пункт:", 0, 8);
            switch (num)
            {
                case 1:
                    {
                        Random rnd = new Random();
                        int n = validator.ReadIntInterval("Введите размер n от 2 до 10:", 2, 10);
                        int m = validator.ReadIntInterval("Введите размер m от 2 до 10:", 2, 10);

                        Matrix m1 = new Matrix(n, m, validator);
                        Console.WriteLine("Массив из конструктора 1:");
                        Console.WriteLine(m1.ToString());

                        Matrix m2 = new Matrix(n, rnd);
                        Console.WriteLine("Массив из конструктора 2 (случайный с возрастающими столбцами):");
                        Console.WriteLine(m2.ToString());

                        Matrix m3 = new Matrix(n);
                        Console.WriteLine("Массив из конструктора 3:");
                        Console.WriteLine(m3.ToString());
                        break;
                    }
                case 2:
                    {
                        Matrix.GradesFind(validator);
                        break;
                    }
                case 3:
                    {
                        Random rnd = new Random();
                        int n = validator.ReadIntInterval("Введите размер n для квадратных матриц (от 2 до 10):", 2, 10);
                        Matrix matrixA = new Matrix(n, rnd);
                        Console.WriteLine("Матрица A:");
                        Console.WriteLine(matrixA);
                        Matrix matrixB = new Matrix(n, rnd);
                        Console.WriteLine("Матрица B:");
                        Console.WriteLine(matrixB);
                        Matrix matrixC = new Matrix(n, rnd);
                        Console.WriteLine("Матрица C:");
                        Console.WriteLine(matrixC);

                        Matrix result = Matrix.Transpose(matrixA) - Matrix.Transpose(matrixB) + 2 * matrixC;
                        Console.WriteLine("Результат выражения A^T - B^T + 2*C:");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case 4:
                    {
                        string path = "numbers.bin";
                        Files.FileInput4(path, validator);
                        Files.Bin4(path);
                        break;
                    }
                case 5:
                    {
                        string path = "toys.xml";
                        Files.FileInput5(path, validator);
                        Files.Toys(path);
                        break;
                    }
                case 6:
                    {
                        string path = "numbers_one.txt";
                        Files.FileInput6(path, validator);
                        Files.Calc6(path);
                        break;
                    }
                case 7:
                    {
                        string path = "numbers_multi.txt";
                        Files.FileInput7(path, validator);
                        Files.Calc7(path);
                        break;
                    }
                case 8:
                    {
                        string pathInput = "src.txt";
                        string pathOutput = "dest.txt";
                        Files.FileInput8(pathInput, validator);
                        Files.TextRewrite(pathInput, pathOutput);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
