using System.ComponentModel.DataAnnotations;
using System.Text;

internal class Matrix
{
    private int[,] _matrix;

    // Задание 1. Конструктор 1: размер n x m, заполнение с клавиатуры по столбцам снизу вверх
    public Matrix(int n, int m, Validator validator)
    {
        _matrix = new int[n, m];
        Console.WriteLine($"Введите элементы массива {n}x{m} по столбцам (снизу вверх):");
        for (int j = 0; j < m; j++)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                _matrix[i, j] = validator.ReadInt($"Элемент [{i}, {j}]:");
            }
        }
    }

    // Задание 1. Конструктор 2: размер n x n, заполнение случайными числами (возрастающие столбцы)
    public Matrix(int n, Random rnd)
    {
        _matrix = new int[n, n];
        for (int j = 0; j < n; j++)
        {
            int a = rnd.Next(-10, 5);
            for (int i = 0; i < n; i++)
            {
                a += rnd.Next(1, 5);
                _matrix[i, j] = a;
            }
        }
    }

    // Задание 1. Конструктор 3: заполнение для произвольного n (например, узор)
    public Matrix(int n)
    {
        _matrix = new int[n, n];
        int count = 0;
        int cur = 2;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                while (true)
                {
                    bool flag = true;
                    for (int d = 2; d <= Math.Sqrt(cur); d++)
                    {
                        if (cur % d == 0)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        _matrix[i, j] = cur;
                        cur++;
                        break;
                    }
                    cur++;
                }
            }
        }
    }

    public Matrix(int[,] Matrix)
    {
        _matrix = Matrix;
    }

    public int[,] MatrixD
    {
        get { return _matrix; }
        set { _matrix = value; }
    }

    public static void GradesFind(Validator validator)
    {
        int n = validator.ReadIntNatural("Введите количество школьников (n):");
        int m = validator.ReadIntNatural("Введите количество оценок / предметов (m):");

        int[,] grades = new int[n, m];
        Console.WriteLine("Введите оценки школьников (от 2 до 5):");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Школьник {i + 1}:");
            for (int j = 0; j < m; j++)
            {
                grades[i, j] = validator.ReadIntInterval($"  Оценка по предмету {j + 1}:", 2, 5);
            }
        }

        Console.WriteLine("Школьники со средней оценкой выше 4.5:");
        bool found = false;

        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < m; j++)
            {
                sum += grades[i, j];
            }

            double average = sum / m;
            if (average > 4.5)
            {
                Console.WriteLine($"Школьник {i + 1} (средний балл: {average:F2})");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Таких школьников нет.");
        }
    }

    public static Matrix Transpose(Matrix m)
    {
        int rows = m._matrix.GetLength(0);
        int cols = m._matrix.GetLength(1);
        int[,] result = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = m._matrix[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        int rows = m1._matrix.GetLength(0);
        int cols = m1._matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m1._matrix[i, j] - m2._matrix[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator *(int scalar, Matrix m)
    {
        int rows = m._matrix.GetLength(0);
        int cols = m._matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = scalar * m._matrix[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        int rows = m1._matrix.GetLength(0);
        int cols = m1._matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m1._matrix[i, j] + m2._matrix[i, j];
            }
        }

        return new Matrix(result);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int rows = _matrix.GetLength(0);
        int cols = _matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sb.Append(_matrix[i, j].ToString().PadLeft(5));
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}