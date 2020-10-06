using System;

namespace Guess
{
    class Program
    {
        public enum Difficulty
        {
            Easy = 20,
            Medium = 15,
            Hard = 7,
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1. Player guesses number\n2. Computer guesses number");
            int result = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (result)
            {
                case 1:
                    PvC();
                    break;
                case 2:
                    CvP();
                    break;
                default:
                    Console.WriteLine("Bad input");
                    break;
            }
        }

        public static void PvC()
        {
            Console.WriteLine("Choose your difficulty: Easy, Medium or Hard");
            string result = Console.ReadLine();
            Console.Clear();
            Random rng = new Random();
            int maxAttempts = 0;
            int answer = 0;
            switch (result.ToLower())
            {
                case "easy":
                    maxAttempts = (int)Difficulty.Easy;
                    answer = rng.Next(1, 100);
                    Console.WriteLine("Guess the number between 1-100.");
                    break;
                case "medium":
                    maxAttempts = (int)Difficulty.Medium;
                    answer = rng.Next(1, 500);
                    Console.WriteLine("Guess the number between 1-500.");
                    break;
                case "hard":
                    maxAttempts = (int)Difficulty.Hard;
                    answer = rng.Next(-1000, 1000);
                    Console.WriteLine("Guess the number between -1000 - +1000.");
                    break;
                default:
                    Console.WriteLine("Bad Difficulty!");
                    break;
            }
            Console.WriteLine("You have {0} attempts.", maxAttempts);

            int usersGuess = 0;
            int attempts = 1;
            while (usersGuess != answer)
            {
                if (maxAttempts == 0)
                    break;
                usersGuess = int.Parse(Console.ReadLine());
                if (usersGuess != answer)
                {
                    attempts++;
                    maxAttempts--;
                    if (usersGuess > answer)
                        Console.WriteLine("Too high! You have {0} attempts left.", maxAttempts);
                    else
                        Console.WriteLine("Too low! You have {0} attempts left.", maxAttempts);
                }

            }
            if (usersGuess == answer)
                Console.WriteLine("You have guessed the number! It was {0}. It took you {1} attempts!", answer, attempts);
            else
                Console.WriteLine("You failed. The correct number was {0}.", answer);
        }

        public static void CvP()
        {
            //This is going to be default to Easy.
            Random rng = new Random();
            int high = 100;
            int low = 1;
            int guess = 0;
            bool win = false;
            string answer = "";
            while (!win)
            {
                guess = rng.Next(low, high);
                Console.WriteLine("Computer guesses: {0}.\nHigh, Low or Correct?", guess);
                answer = Console.ReadLine();
                switch (answer.ToLower())
                {
                    case "high":
                        high = guess - 1; //If the number's too high, obviously it can't be that number or higher.
                        break;
                    case "low":
                        low = guess + 1; //Same goes for if it's too low.
                        break;
                    case "correct":
                        win = true;
                        Console.WriteLine("The computer has guessed your number, it was {0}", guess);
                        break;
                }
                if (win)
                    break;
            }
        }
    }
}
