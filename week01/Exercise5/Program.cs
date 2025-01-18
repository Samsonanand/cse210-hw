using System;

class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message
        DisplayWelcome();

        // Prompt for the user's name
        string userName = PromptUserName();

        // Prompt for the user's favorite number
        int favoriteNumber = PromptUserNumber();

        // Calculate the square of the number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Display the final result
        DisplayResult(userName, favoriteNumber, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userResponse = Console.ReadLine();
        return userResponse;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string userResponse = Console.ReadLine();
        int favoriteNumber = int.Parse(userResponse); // Convert input to integer
        return favoriteNumber;
    }

    static int SquareNumber(int number)
    {
        return number * number; // Square the number
    }

    static void DisplayResult(string name, int number, int squaredNumber)
    {
        Console.WriteLine($"Hello {name}, your favorite number is {number}, and its square is {squaredNumber}.");
    }
}
