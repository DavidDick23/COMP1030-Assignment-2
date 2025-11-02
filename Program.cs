#region Program Info
/*
 * The original code was create by Shy and refactored by Dave
 * to make it more modular. The original and refactored code 
 * works exactly the same.
 */
#endregion

using System;

#region Refactored Code - By Dave
namespace Assigntment2
{
    internal class Program
    {
        #region Variables
        //game settings variables
        static readonly int _low = 1;
        static readonly int _high = 100;

        //game state variables
        static int targetNumber;
        static int attempts = 0;
        static bool isRunning = true;
        #endregion

        #region Native Functions
        /// <summary>
        /// The main function called on startup
        /// </summary>
        static void Main()
        {
            InitializeGame();
            RunGameLoop();     
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes random number and display startup message
        /// </summary>
        static void InitializeGame()
        {
            //set random number
            Random randomNumber = new Random();
            targetNumber = randomNumber.Next(_low, _high + 1); //<- high needs to be plus one other wise it will only reach 99

            //display StartUp message
            Console.WriteLine("Welcome to the Numbers Guessing Game!");
            Console.WriteLine($"Try to guess the correct number I'm thinking of between {_low} and {_high}.");
            Console.WriteLine($"You can guess until you're correct. Best of luck!");
        }
        #endregion

        #region Game Logic
        /// <summary>
        /// The main loop for game logic to run
        /// </summary>
        static void RunGameLoop()
        {
            //loop will run until the player guesses the correct number
            while (isRunning)
            {
                //get the user input and increase attempts when it's a valid int
                int guess = GetPlayerGuess();
                attempts++;

                //give a hint to the the player based on their input
                if (guess < targetNumber)
                    Console.WriteLine("Too low!");
                else if (guess > targetNumber)
                    Console.WriteLine("Too high!");
                //end the game if the player guessed correctly
                else
                {
                    Console.WriteLine($"Correct! You guessed it in {attempts} attempts.");
                    isRunning = false;
                }
            }
        }

        /// <summary>
        /// Get the user input and return it as an int if it's valid
        /// </summary>
        static int GetPlayerGuess()
        {
            //wait for the user input within a loop
            while (true)
            {
                //ask the user for input and read input in the console
                Console.Write($"\nAttempt {attempts + 1}: Enter your guess: ");
                string input = Console.ReadLine();

                //if the input is a valid int 
                if (int.TryParse(input, out int guess))
                {
                    //and the input is within the given range (1-100)
                    if (guess >= _low && guess <= _high)
                        return guess; //return the input as an int (end current loop)

                    //otherwise the number was out of range, write to console
                    Console.WriteLine($"Please enter a number between {_low} and {_high}.");
                }
                //if the input was invalid (eg a letter)
                else
                {
                    //write to the console
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                }
            }
        }
        #endregion
    }
}
#endregion

#region Orginal Code - By ShyAnne
/*
using System;

namespace Assigntment2
{
    internal class Program
    {
        static void Main()
        {
            //Declarations of variables
            int low = 1;
            int high = 100;
            int attempts = 0;

            //Use Random class to generate a secret number between 1–100.
            Random rand = new Random();
            int targetNumber = rand.Next(low, high + 1);

            //Prints welcome message
            Console.WriteLine("Welcome to the Numbers Guessing Game!");
            Console.WriteLine($"Try to guess the correct number I'm thinking of between {low} and {high}.");
            Console.WriteLine($"You can guess until you're correct. Best of luck!");//- Ask the user to guess until correct.

            //Guessing Game Loop
            while (true)
            {
                Console.Write($"Attempt {attempts + 1}: Enter your guess: ");//- Display the number of attempts taken.
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int playerGuess))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                    continue;//Skip incrementing if invalid input
                }

                attempts++;

                //compare guess for hints 
                //- Give hints like “Too high!” or “Too low!”.
                //- Use if, else, while, and functions.

                if (playerGuess < targetNumber)
                {
                    Console.WriteLine("Too Low!");
                }
                else if (playerGuess > targetNumber)//if player guess is higher than target number
                {
                    Console.WriteLine(" Too High!");//print message too high
                }
                else
                {
                    Console.WriteLine($"Correct! You guessed the right number in {attempts} attempts!");//Correct number message
                    break;
                }
            }
        }
    }
}
*/
#endregion