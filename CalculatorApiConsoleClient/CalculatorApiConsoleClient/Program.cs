// See https://aka.ms/new-console-template for more information
using CalculatorApiConsoleClient;
using System.Diagnostics.Metrics;

Console.WriteLine("Hello, World!");
Console.WriteLine("Which operation you want to calculate?: ");
string methodName = Console.ReadLine();

Console.WriteLine("Enter two numbers: ");
double num1 = 0;
double num2 = 0;
bool num1Parsed = false;
bool num2Parsed = false;

int counter = 0;
Console.WriteLine("Please enter the first number");
while (!num1Parsed && counter < 5)
{
    counter++;
    num1Parsed = double.TryParse(Console.ReadLine(), out num1);
    if (!num1Parsed)
    {
        Console.WriteLine("Invalid, enter 1th number:");
    }
    else
    {
        Console.WriteLine("Number1:" + num1);
        Console.WriteLine("Please enter the second number");
    }

}
counter = 0;
while (!num2Parsed && counter < 5)
{
    counter++;
    num2Parsed = double.TryParse(Console.ReadLine(), out num2);
    if (!num2Parsed)
    {
        Console.WriteLine("Invalid, enter 2th number:");
    }
    else
    {
        Console.WriteLine($"Number2: {num2}");
    }

}
await CalculatorApiHttpClient.CalculatorApiPostRequest(methodName, num1, num2);
Console.ReadLine();