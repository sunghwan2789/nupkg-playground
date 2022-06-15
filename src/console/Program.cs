using wrapper;

using var handler = new Handler();

Console.WriteLine(handler.Name);
Console.WriteLine(handler.Name = "awer");
Console.WriteLine(handler.Invoke());

