using System.Security.AccessControl;
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
R - Random Game
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
            Console.WriteLine("--------------------------------------------------------");
            var result = Console.ReadLine();

            GameType gameType = default;
            GameDifficulty gameDifficulty = default;

            switch (result.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    continue;
                case "r":
                    gameType = Helpers.RandomizeGame();
                    gameDifficulty = Helpers.GetDifficulty();
                    break;
                case "a":
                    gameType = GameType.Addition;
                    break;
                case "s":
                    gameType = GameType.Subtraction;
                    break;
                case "m":
                    gameType = GameType.Multiplication;
                    break;
                case "d":
                    gameType = GameType.Division;
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    continue;
                default:
                    Console.WriteLine("Invalid Input");
                    continue;
            }

            engine.StartGame(gameType, gameDifficulty);

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
