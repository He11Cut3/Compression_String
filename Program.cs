using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Сжать строку");
            Console.WriteLine("2. Декомпрессировать строку");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CompressMenu();
                    break;
                case "2":
                    DecompressMenu();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
    static void CompressMenu()
    {
        Console.Write("\nВведите строку для сжатия: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Ошибка: Введена пустая строка.");
            return;
        }
        if (!input.All(c => c >= 'a' && c <= 'z'))
        {
            Console.WriteLine("Ошибка: Строка должна содержать только строчные латинские буквы (a-z).");
            return;
        }
        try
        {
            string compressed = Compress_inm(input);
            Console.WriteLine($"Сжатая строка: {compressed}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сжатии: {ex.Message}");
        }
    }

    static void DecompressMenu()
    {
        Console.Write("\nВведите строку для декомпрессии: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Ошибка: Введена пустая строка.");
            return;
        }
        try
        {
            string decompressed = Decompress_inm(input);
            Console.WriteLine($"Декомпрессированная строка: {decompressed}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Некорректный формат сжатой строки. Число повторений должно быть целым положительным числом.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при декомпрессии: {ex.Message}");
        }
    }

    public static string Compress_inm(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("Строка не может быть пустой");

        Dictionary<char, int> directory = new Dictionary<char, int>();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (char num in s)
        {
            if (directory.ContainsKey(num))
            {
                directory[num]++;
            }
            else
            {
                directory.Add(num, 1);
            }
        }
        foreach (var ent in directory)
        {
            stringBuilder.Append(ent.Key);
            if (ent.Value > 1)
            {
                stringBuilder.Append(ent.Value);
            }
        }
        return stringBuilder.ToString();
    }

    public static string Decompress_inm(string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("Строка не может быть пустой");
        StringBuilder stringBuilder = new StringBuilder();
        int i = 0;

        while (i < s.Length)
        {
            if (!char.IsLetter(s[i]))
                throw new FormatException($"Ожидалась буква в позиции {i + 1}, но найдено '{s[i]}'");

            char currentChar = s[i];
            i++;
            string numStr = string.Empty;
            while (i < s.Length && char.IsDigit(s[i]))
            {
                numStr += s[i];
                i++;
            }
            int count;
            if (numStr.Length > 0)
            {
                if (!int.TryParse(numStr, out count) || count <= 0)
                    throw new FormatException($"Некорректное число повторений '{numStr}' для символа '{currentChar}'");
            }
            else
            {
                count = 1;
            }
            stringBuilder.Append(currentChar, count);
        }

        return stringBuilder.ToString();
    }
}