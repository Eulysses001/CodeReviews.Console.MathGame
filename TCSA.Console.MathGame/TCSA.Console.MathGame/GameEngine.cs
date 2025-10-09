using System.Diagnostics;
using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class GameEngine
{
    internal void StartGame(GameType type, GameDifficulty difficulty)
    {
        var message = Helpers.GetGameMessage(type);
        int score = 0;
        int firstNumber;
        int secondNumber;
        var timer = new Stopwatch();
        var operation = type switch
        {
            GameType.Addition => "+",
            GameType.Subtraction => "-",
            GameType.Multiplication => "*",
            GameType.Division => "/"
        };

        if (difficulty == GameDifficulty.None)
        {
            difficulty = Menu.ShowGameDifficulty();
        }

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var lowestNumber = 0;
            var highestNumber = 0;

            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    lowestNumber = 1;
                    highestNumber = 9;
                    break;
                case GameDifficulty.Medium:
                    lowestNumber = 10;
                    highestNumber = 99;
                    break;
                case GameDifficulty.Hard:
                    lowestNumber = 100;
                    highestNumber = 999;
                    break;
            }

            timer.Start();
            var numbers = Helpers.GetNumbers(type, lowestNumber, highestNumber);
            firstNumber = numbers[0];
            secondNumber = numbers[1];

            Console.WriteLine($"{firstNumber} {operation} {secondNumber}");
            var result = Helpers.ValidateResult(Console.ReadLine());
            var operationResult = type switch
            {
                GameType.Addition => int.Parse(result) == firstNumber + secondNumber,
                GameType.Subtraction => int.Parse(result) == firstNumber - secondNumber,
                GameType.Multiplication => int.Parse(result) == firstNumber * secondNumber,
                GameType.Division => int.Parse(result) == firstNumber / secondNumber
            };

            if (operationResult)
            {
                Console.WriteLine("Your answer is correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer is wrong. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game Over. Your final score is {score}. Time Taken: {timer.Elapsed.ToString(@"m\:ss\.fff")} Press any key to go back to the main menu.");
                timer.Stop();
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, type, difficulty, timer.Elapsed);
    }
}
