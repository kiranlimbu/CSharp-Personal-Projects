using System;

namespace NumGuessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set app vars
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Kiran Limbu";

            // Change text color
            Console.ForegroundColor = ConsoleColor.Green;

            // Write app info
            Console.WriteLine($"{appName}: Version {appVersion} by {appAuthor}");

            // Reset Text color
            Console.ResetColor();

            // Get player name
            Console.Write("Enter your name: ");
            string inputName = Console.ReadLine();

            Console.WriteLine("\n\n\nHello {0}, lets play a number guessing game...", inputName);

            // Lets PLAY
            bool gameOn = true;

            while (gameOn)
            {

                // Set correct number. Make it random
                Random random = new Random(); // constructor
                int correctNumber = random.Next(1, 20); // stores a random value between 1 to 10

                // Int guess var
                int guess = 0;

                // Ask user for number
                Console.WriteLine("\nBetween 1-20, a number is stored in this []");
                Console.Write("Guess the number: ");

                // check the input
                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out guess))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid Entry!");
                        Console.ResetColor();
                        Console.Write("Enter a number: ");
                        continue;  // this line restarts the while process skipping codes below this line and therefore avoiding error
                    }

                    guess = int.Parse(input);

                    if (guess != correctNumber)
                    {
                        Console.WriteLine("\nIncorrect number! Guess again. ");
                        if (guess > correctNumber)
                        {
                            Console.WriteLine("Hint! go smaller...");
                        }
                        else
                        {
                            Console.WriteLine("Hint! go bigger...");
                        }
                    }

                }

                if (guess == correctNumber)
                {
                    Console.Write("\nCongratulation! you guessed it correct!\n\n\n");
                }

                Console.Write("Play again? Y/N: ");
                string answer = Console.ReadLine().ToLower();

                if (answer != "y")
                {
                    gameOn = false;
                }
            }
        }
    }
}
