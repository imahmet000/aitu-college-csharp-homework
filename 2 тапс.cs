using System;

enum ProgrammingLanguage { CSharp, Python, Java, JavaScript }
enum Color { Red, Green, Blue, Yellow }
enum OrderStatus { New, Processing, Shipped, Delivered, Cancelled }
enum Grade { Excellent, Good, Satisfactory, Poor }
enum StudentStatus { Active, Graduated, Expelled }
enum EmployeeStatus { Intern, Junior, Middle, Senior, Manager }
struct Student {
    public string Name;
    public int Age;
    public string Group;
    public StudentStatus Status;
}
struct Book { public string Title, Author; public int Year; }
struct Product { public string Name; public decimal Price; public int Quantity; }
struct Order { public int Number; public string ProductName; public OrderStatus Status; }
struct Employee { public string FullName; public int Years; public EmployeeStatus Status; }

class Program {
    static void Main(string[] args) {
        var task = args.Length == 0 ? "T1" : args[0].ToUpperInvariant();
        switch (task) {
            case "T1":
                ProgrammingLanguage language = ProgrammingLanguage.CSharp;
                Console.WriteLine($"Бағдарламалау тілі: {language}"); break;
            case "T2":
                Color color = Color.Green;
                Console.WriteLine($"Түс: {color}"); break;
            case "T3":
                OrderStatus orderStatus = OrderStatus.Processing;
                switch (orderStatus) {
                    case OrderStatus.New: Console.WriteLine("Жаңа тапсырыс"); break;
                    case OrderStatus.Processing: Console.WriteLine("Тапсырыс өңделуде"); break;
                    case OrderStatus.Shipped: Console.WriteLine("Тапсырыс жіберілді"); break;
                    case OrderStatus.Delivered: Console.WriteLine("Тапсырыс жеткізілді"); break;
                    case OrderStatus.Cancelled: Console.WriteLine("Тапсырыс жойылды"); break;
                } break;
            case "T4":
                Grade grade = Grade.Good;
                switch (grade) {
                    case Grade.Excellent: Console.WriteLine("Өте жақсы"); break;
                    case Grade.Good: Console.WriteLine("Жақсы"); break;
                    case Grade.Satisfactory: Console.WriteLine("Қанағаттанарлық"); break;
                    case Grade.Poor: Console.WriteLine("Нашар"); break;
                } break;
            case "T5":
                var student = new Student { Name = "Әділхан", Age = 17, Group = "БҚ-2503" };
                Console.WriteLine($"{student.Name}, {student.Age} жас, {student.Group}"); break;
            case "T6":
                Book[] books = {
                    new Book { Title = "Абай жолы", Author = "Мұхтар Әуезов", Year = 1942 },
                    new Book { Title = "Қан мен тер", Author = "Әбдіжәміл Нұрпейісов", Year = 1961 }
                };
                foreach (Book book in books)
                    Console.WriteLine($"{book.Title} — {book.Author}, {book.Year}"); break;
            case "T7":
                Product[] products = {
                    new Product { Name = "Дәптер", Price = 250, Quantity = 3 },
                    new Product { Name = "Қалам", Price = 150, Quantity = 5 },
                    new Product { Name = "Кітап", Price = 2800, Quantity = 2 }
                };
                decimal total = 0;
                foreach (Product p in products) {
                    decimal cost = p.Price * p.Quantity; total += cost;
                    Console.WriteLine($"{p.Name}: {p.Price} × {p.Quantity} = {cost} ₸");
                }
                Console.WriteLine($"Барлығы: {total} ₸"); break;
            case "T8":
                var learner = new Student { Name = "Әділхан", Age = 17, Status = StudentStatus.Active };
                string status = learner.Status switch {
                    StudentStatus.Active => "оқуын жалғастыруда",
                    StudentStatus.Graduated => "оқуын аяқтады",
                    StudentStatus.Expelled => "оқудан шығарылды",
                    _ => "белгісіз"
                };
                Console.WriteLine($"{learner.Name}, {learner.Age} жас — {status}"); break;
            case "T9":
                Order[] orders = {
                    new Order { Number = 101, ProductName = "Ноутбук", Status = OrderStatus.New },
                    new Order { Number = 102, ProductName = "Тышқан", Status = OrderStatus.Shipped },
                    new Order { Number = 103, ProductName = "Пернетақта", Status = OrderStatus.Delivered }
                };
                foreach (Order o in orders) {
                    string message = o.Status switch {
                        OrderStatus.New => "қабылданды",
                        OrderStatus.Processing => "өңделуде",
                        OrderStatus.Shipped => "жолда",
                        OrderStatus.Delivered => "жеткізілді",
                        OrderStatus.Cancelled => "жойылды",
                        _ => "белгісіз"
                    };
                    Console.WriteLine($"№{o.Number}: {o.ProductName}, {o.Status} — {message}");
                } break;
            case "T10":
                Employee[] employees = {
                    new Employee { FullName = "Аружан", Years = 1, Status = EmployeeStatus.Junior },
                    new Employee { FullName = "Ерлан", Years = 6, Status = EmployeeStatus.Senior },
                    new Employee { FullName = "Айжан", Years = 9, Status = EmployeeStatus.Manager }
                };
                foreach (Employee e in employees) {
                    string description = e.Status switch {
                        EmployeeStatus.Intern => "тәжірибеден өтуші",
                        EmployeeStatus.Junior => "бастапқы маман",
                        EmployeeStatus.Middle => "тәжірибелі маман",
                        EmployeeStatus.Senior => "аға маман",
                        EmployeeStatus.Manager => "басшы",
                        _ => "белгісіз"
                    };
                    Console.WriteLine($"{e.FullName}: {e.Years} жыл, {e.Status} — {description}");
                }
                Console.WriteLine("5 жылдан астам тәжірибесі барлар:");
                foreach (Employee e in employees)
                    if (e.Years > 5) Console.WriteLine(e.FullName);
                break;
            default: Console.WriteLine("Белгісіз тапсырма"); break;
        }
    }
}
