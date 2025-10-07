using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class Menu
{
    internal static void ShowMenu(string? name, DateTime date)
    {
        GameEngine engine = new GameEngine();

        Console.Clear();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"Hello {name}, It's {date}. This is your math's game. That's great that your're working on improving yourself.\n");
        Console.WriteLine("\n");

        bool isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
V - Game History
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
            Console.WriteLine("--------------------------------------------------------");
            var result = Console.ReadLine();

            switch (result.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    engine.AdditionGame("Addition game.", ShowGameDifficulty());
                    break;
                case "s":
                    engine.SubtractionGame("Subtraction game.", ShowGameDifficulty());
                    break;
                case "m":
                    engine.MultiplicationGame("Multiplication game.", ShowGameDifficulty());
                    break;
                case "d":
                    engine.DivisionGame("Division game.", ShowGameDifficulty());
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        } while (isGameOn);
    }

    internal static GameDifficulty ShowGameDifficulty()
    {
        GameDifficulty difficulty = default;
        bool validInput = false;

        do
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(@"Select difficulty of the game.
E - Easy
M - Medium
H - Hard");

            var result = Console.ReadLine();

            switch (result.Trim().ToLower())
            {
                case "e":
                    difficulty = GameDifficulty.Easy;
                    validInput = true;
                    break;
                case "m":
                    difficulty = GameDifficulty.Medium;
                    validInput = true;
                    break;
                case "h":
                    difficulty = GameDifficulty.Hard;
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

        } while (!validInput);

        Console.WriteLine("--------------------------------------------------------");
        return difficulty;
    }
}
