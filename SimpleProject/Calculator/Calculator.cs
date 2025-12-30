using System;

int a=0,b=0,num;

Console.WriteLine("Hello!\nInput the first number:");
string Input1=Console.ReadLine();

// Checks whether the input integer is valid
if (int.TryParse(Input1, out num))
{
    a = num;
}  
else
{
    Console.WriteLine("Invalid Input");
    ExitApp();
}

Console.WriteLine("Input the second number:");
string Input2 = Console.ReadLine();

if (int.TryParse(Input2, out num))
{
    b = num;
}
else
{
    Console.WriteLine("Invalid Input");
    ExitApp();
}

//Displays the operations available to perform
Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");
string userChoice = Console.ReadLine();

//Do calculation based on the option selected
switch (userChoice.ToLower())
{
    case "a":
        Console.WriteLine(a + "+" + b + "=" + (a + b));
        break;
    case "s":
        Console.WriteLine(a + "-" + b + "=" + (a - b));
        break;
    case "m":
        Console.WriteLine(a + "*" + b + "=" + (a * b));
        break;
    default:
        Console.WriteLine("Invalid option");
        break;
}
ExitApp();

void ExitApp()
{
    Console.WriteLine("Press any key to close");
    Console.ReadKey();
    Environment.Exit(0);
}


