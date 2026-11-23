using System;
using System.Collections.Generic;
using System.Globalization;

class Box<T> { public T Value = default!; }
class Storage<T> {
    public T Data = default!;
    public void SetData(T value) => Data = value;
    public void ShowData() => Console.WriteLine(Data);
}
class Pair<T,U> { public T First = default!; public U Second = default!; }
class NumberBox<T> where T : struct { public T Number; }

class Program {
    static void Show<T>(T value) => Console.WriteLine(value);
    static DateTime ReadDate(string label) {
        Console.Write(label);
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            throw new FormatException("Күнді dd.MM.yyyy түрінде енгізіңіз.");
        return date;
    }
    static int ReadInt(string label) { Console.Write(label); return int.Parse(Console.ReadLine()!); }
    static void Main(string[] args) {
        string task = args.Length == 0 ? "G1" : args[0].ToUpperInvariant();
        switch (task) {
            case "G1": var b1 = new Box<int> { Value = 42 }; Console.WriteLine(b1.Value); break;
            case "G2": var b2 = new Box<string> { Value = "Әділхан" }; Console.WriteLine(b2.Value); break;
            case "G3":
                var s1 = new Storage<int> { Data = 17 };
                var s2 = new Storage<string> { Data = "Astana" };
                var s3 = new Storage<double> { Data = 3.75 };
                Console.WriteLine($"{s1.Data}; {s2.Data}; {s3.Data}"); break;
            case "G4": Show<int>(2026); Show<string>("Generic әдіс"); Show<double>(2.5); break;
            case "G5":
                var pair = new Pair<string,int> { First = "AITU College", Second = 2503 };
                Console.WriteLine($"{pair.First}; {pair.Second}"); break;
            case "G6":
                var n1 = new NumberBox<int> { Number = 10 };
                var n2 = new NumberBox<double> { Number = 4.5 };
                Console.WriteLine($"{n1.Number}; {n2.Number}"); break;
            case "G7":
                var list = new List<int> { 4, 7, 12, 15, 22 }; int sum = 0;
                foreach (int n in list) { Console.WriteLine(n); sum += n; }
                Console.WriteLine($"Саны: {list.Count}; қосындысы: {sum}"); break;
            case "G8":
                var name = new Storage<string>(); name.SetData("Әділхан");
                var age = new Storage<int>(); age.SetData(17);
                var grade = new Storage<double>(); grade.SetData(4.2);
                Console.Write("Аты: "); name.ShowData();
                Console.Write("Жасы: "); age.ShowData();
                Console.Write("Орташа бағасы: "); grade.ShowData(); break;
            case "D1": Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")); break;
            case "D2":
                try {
                    DateTime birth = ReadDate("Туған күн: "), today = DateTime.Today;
                    if (birth > today) { Console.WriteLine("Болашақ күн жарамсыз."); break; }
                    int years = today.Year - birth.Year;
                    if (birth > today.AddYears(-years)) years--;
                    Console.WriteLine($"Жасы: {years}");
                } catch (FormatException e) { Console.WriteLine(e.Message); } break;
            case "D3":
                try { var a = ReadDate("Бірінші күн: "); var b = ReadDate("Екінші күн: ");
                    Console.WriteLine($"Айырмасы: {Math.Abs((b-a).Days)} күн"); }
                catch (FormatException e) { Console.WriteLine(e.Message); } break;
            case "D4":
                var now = DateTime.Now;
                Console.WriteLine($"Қазір: {now:dd.MM.yyyy}");
                Console.WriteLine($"7 күннен кейін: {now.AddDays(7):dd.MM.yyyy}");
                Console.WriteLine($"2 айдан кейін: {now.AddMonths(2):dd.MM.yyyy}"); break;
            case "D5":
                try { Console.WriteLine($"Апта күні: {ReadDate("Күн: ").DayOfWeek}"); }
                catch (FormatException e) { Console.WriteLine(e.Message); } break;
            case "E6":
                try { Console.WriteLine($"Сан: {ReadInt("Бүтін сан: ")}"); }
                catch (FormatException) { Console.WriteLine("Қате: бүтін сан енгізіңіз."); } break;
            case "E7":
                try { int a = ReadInt("Бірінші сан: "), b = ReadInt("Екінші сан: ");
                    Console.WriteLine($"Нәтиже: {a/b}"); }
                catch (DivideByZeroException) { Console.WriteLine("Нөлге бөлуге болмайды."); }
                catch (FormatException) { Console.WriteLine("Бүтін сан енгізіңіз."); } break;
            case "E8":
                try { int a = ReadInt("Бірінші сан: "), b = ReadInt("Екінші сан: ");
                    Console.WriteLine($"Нәтиже: {a/b}"); }
                catch (FormatException) { Console.WriteLine("FormatException: сан дұрыс емес."); }
                catch (DivideByZeroException) { Console.WriteLine("DivideByZeroException: нөлге бөлу."); } break;
            case "E9":
                int[] array = { 10, 20, 30, 40, 50 };
                try { Console.WriteLine($"Элемент: {array[ReadInt("Индекс: ")]}"); }
                catch (IndexOutOfRangeException) { Console.WriteLine("Индекс массив шегінен тыс."); }
                catch (FormatException) { Console.WriteLine("Индекс бүтін сан болуы керек."); } break;
            case "E10":
                try { Console.Write("Сан: ");
                    double x = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    Console.WriteLine(x < 0 ? "Теріс санның нақты түбірі жоқ."
                        : $"Квадрат түбірі: {Math.Sqrt(x):F3}"); }
                catch (FormatException) { Console.WriteLine("FormatException: сан дұрыс емес."); }
                finally { Console.WriteLine("Бағдарлама жұмысы аяқталды"); } break;
            default: Console.WriteLine("Белгісіз тапсырма."); break;
        }
    }
}
