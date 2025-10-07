using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class Helpers
{
    static List<Game> games = new List<Game>();

    internal static string GetName()
    {
        Console.WriteLine("Please write your name.");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty.");
            name = Console.ReadLine();
        }

        return name;
    }
    internal static void PrintGames()
    {
        var gamesToPrint = games.Where(x => x.Type == GameType.Division);

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("-------------------------------------------");
        foreach (var game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: Score = {game.Score}");
        }
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty difficulty)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Difficulty = difficulty
        });
    }

    internal static int[] GetDivisionNumber()
    {
        var random = new Random();
        var firstNumber = random.Next(0, 99);
        var secondNumber = random.Next(0, 99);
        var result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(0, 99);
            secondNumber = random.Next(0, 99);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again");
            result = Console.ReadLine();
        }

        return result;
    }
}
