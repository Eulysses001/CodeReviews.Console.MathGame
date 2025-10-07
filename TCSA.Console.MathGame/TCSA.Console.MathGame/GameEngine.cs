using TCSA.MathGame.Models;

namespace TCSA.MathGame;

internal class GameEngine
{
    internal void AdditionGame(string message, GameDifficulty difficulty)
    {
        var random = new Random();
        int score = 0;
        int firstNumber;
        int secondNumber;

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

            firstNumber = random.Next(lowestNumber, highestNumber);
            secondNumber = random.Next(lowestNumber, highestNumber);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(result) == firstNumber + secondNumber)
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
                Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division, difficulty);
    }

    internal void SubtractionGame(string message, GameDifficulty difficulty)
    {
        var random = new Random();
        int score = 0;
        int firstNumber;
        int secondNumber;

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

            firstNumber = random.Next(lowestNumber, highestNumber);
            secondNumber = random.Next(lowestNumber, highestNumber);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(result) == firstNumber - secondNumber)
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
                Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division, difficulty);
    }

    internal void MultiplicationGame(string message, GameDifficulty difficulty)
    {
        var random = new Random();
        int score = 0;
        int firstNumber;
        int secondNumber;

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

            firstNumber = random.Next(lowestNumber, highestNumber);
            secondNumber = random.Next(lowestNumber, highestNumber);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(result) == firstNumber * secondNumber)
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
                Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division, difficulty);
    }

    internal void DivisionGame(string message, GameDifficulty difficulty)
    {
        int score = 0;

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

            var divisionNumber = Helpers.GetDivisionNumber();
            var firstNumber = divisionNumber[0];
            var secondNumber = divisionNumber[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(result) == firstNumber / secondNumber)
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
                Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division, difficulty);
    }
}
