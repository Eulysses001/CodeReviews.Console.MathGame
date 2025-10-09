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
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("-------------------------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: Score = {game.Score} - Time Taken: {game.GameTime.ToString(@"m\:ss\.fff")}");
        }
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty difficulty, TimeSpan time)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Difficulty = difficulty,
            GameTime = time
        });
    }

    internal static int[] GetNumbers(GameType type, int lowestNumber, int highestNumber)
    {
        var random = new Random();
        var firstNumber = random.Next(0, 99);
        var secondNumber = random.Next(0, 99);
        var result = new int[2];

        if (type == GameType.Division)
        {

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(lowestNumber, highestNumber);
                secondNumber = random.Next(lowestNumber, highestNumber);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;
        }
        else
        {
            result[0] = random.Next(lowestNumber, highestNumber);
            result[1] = random.Next(lowestNumber, highestNumber);
        }

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

    internal static GameType RandomizeGame()
    {
        var random = new Random();
        return (GameType)random.Next(0, 3);
    }

    internal static string GetGameMessage(GameType gameType)
    {
        return gameType switch
        {
            GameType.Addition => "Addition game.",
            GameType.Subtraction => "Subtraction game.",
            GameType.Multiplication => "Multiplication game.",
            GameType.Division => "Division Game"
        };
    }

    internal static GameDifficulty GetDifficulty()
    {
        var random = new Random();
        return (GameDifficulty)random.Next(1, 3);
    }
}
