using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int Number = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != Number)
        {
            Console.Write("Guess the number? ");
            guess = int.Parse(Console.ReadLine());

            if (Number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (Number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it correctly!");
            }

        }                    
    }
}