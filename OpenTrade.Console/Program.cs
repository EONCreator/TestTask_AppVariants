using OpenTrade.Console.Handlers;
using OpenTrade.Console.Handlers.Grpc;

while (true) {
    System.Console.Write("Даное приложение определяет два предыдущих члена " +
        "последовательности Фибоначчи по введенному числу.\n" +
        "Выберите способ использования логики: \n" +
        "1 - Консоль\n" +
        "2 - ASP.NET Core\n" +
        "3 - gRPC.\n" +
        "4 - Выйти\n" +
        "Введите вариант: ");

    int variant;
    while (!int.TryParse(Console.ReadLine(), out variant) || variant < 1 || variant > 4)
    {
        Console.WriteLine("Некорректный ввод. Попробуйте снова:");
    }

    if (variant == 4)
    {
        break;
    }

    IHandler handler = variant switch
    {
        1 => new ConsoleHandler(),
        2 => new AspNetCoreHandler(),
        3 => new GrpcHandler(),
        _ => throw new ArgumentException("Нет такого варианта")
    };

    System.Console.Write("Введите число: ");
    int n = int.Parse(Console.ReadLine());
    var result = await handler.GetPreviousFibonacci(n);
    Console.WriteLine($"{result}\n");
}