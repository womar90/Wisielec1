using System;
using System.Diagnostics;
using System.IO;
namespace Wisielec1
{
    internal class Program
    {
        static void WrongGuess(int x)
        {

            switch (x)
            {
                case 0:
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |  " +
                    "        |\n\t\t\t\t\t\t\t |       " +
                    "    \n\t\t\t\t\t\t\t |              \n\t\t\t\t\t\t\t |       " +
                    "       \n\t\t\t\t\t\t\t/ \\");
                    break;
                case 2:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |    " +
                    "      |\n\t\t\t\t\t\t\t |       " +
                    "   O\n\t\t\t\t\t\t\t |              \n\t\t\t\t\t\t\t |      " +
                    "        \n\t\t\t\t\t\t\t/ \\");
                    break;
                case 3:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |      " +
                    "    |\n\t\t\t\t\t\t\t |       " +
                    "   O\n\t\t\t\t\t\t\t |         ( )\n\t\t\t\t\t\t\t |      " +
                    "        \n\t\t\t\t\t\t\t/ \\");
                    break;
                case 4:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |    " +
                    "      |\n\t\t\t\t\t\t\t |       " +
                    "   O\n\t\t\t\t\t\t\t |        /( )\n\t\t\t\t\t\t\t |      " +
                    "        \n\t\t\t\t\t\t\t/ \\");
                    break;
                case 5:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |    " +
                    "      |\n\t\t\t\t\t\t\t |       " +
                    "   O\n\t\t\t\t\t\t\t |        /( )\\\n\t\t\t\t\t\t\t |       " +
                    "       \n\t\t\t\t\t\t\t/ \\");
                    break;
                case 6:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |   " +
                    "       |\n\t\t\t\t\t\t\t |" +
                    "          O\n\t\t\t\t\t\t\t |        /( )\\\n\t\t\t\t\t\t\t |     " +
                    "      \\ \n\t\t\t\t\t\t\t/ \\");
                    break;
                case 7:
                    Console.WriteLine("\t\t\t\t\t\t\t _ _ _ _ _ _  \n\t\t\t\t\t\t\t |     " +
                    "     |\n\t\t\t\t\t\t\t |" +
                    "          O\n\t\t\t\t\t\t\t |        /( )\\\n\t\t\t\t\t\t\t | " +
                    "        / \\ \n\t\t\t\t\t\t\t/ \\");
                    break;
            }
        }
        static void Main(string[] args)
        {
            // You have to change a paths for files. 
            var document = File.ReadAllLines(@"C:\Marcin\programowanie\materialy\dane_wisielec.csv");

            Console.WriteLine("\t\t\t\t---------- HANGMAN ----------");
            Console.WriteLine();
            Console.WriteLine("Welcome in Hangman game!");
            Console.WriteLine("Computer will pick a random COUNTRY name. " +
                              "Try to guess it as fast as You can.");
            Console.WriteLine("You have 7 lifes - every wrong guess equals 1 life.");
            Console.WriteLine("At 7th wrong guess you loose");
            Console.WriteLine("Every turn You can try to guess the whole word.");
            Console.WriteLine("You loose life only if You won't " +
                              "guess a letter not an entire word. ");
            Console.WriteLine();
            Console.WriteLine();

            bool playAgainBool = true;

            try
            {
                while (playAgainBool)

                {
                    List<string> WordsList = new List<string>();

                    WordsList = document.ToList();

                    int FirstIndex = 0;
                    int LastIndex = WordsList.Count - 1;
                    Random randomIndex = new Random();

                    int randomWordIndex = randomIndex.Next(FirstIndex, LastIndex);
                    string randomWord = WordsList[randomWordIndex].ToLower();
                    string maskedRandomWord = "";

                    List<string> guessesContainerList = new List<string>();
                    List<string> randomWordList = new List<string>();
                    char[] randomWordArray = randomWord.ToCharArray();
                    foreach (char c in randomWordArray)
                    {
                        string letter = c.ToString();
                        if (letter == " ")
                        {
                            randomWordList.Add(letter);
                            guessesContainerList.Add(" ");
                            maskedRandomWord = maskedRandomWord + " ";
                        }
                        else
                        {
                            randomWordList.Add(letter);
                            guessesContainerList.Add("_");
                            maskedRandomWord = maskedRandomWord + "_ ";
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("The random word : " + maskedRandomWord);
                    Console.WriteLine();
                    Console.WriteLine();
                    int goodGuessesNumber = 0;
                    int wrongGuessesNumber = 0;
                    string playerInputWord = "";
                    string playerInputLetter = "";
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (wrongGuessesNumber < 7 && playerInputWord != randomWord)
                    {
                        Console.Write("Try to guess a letter in this word: ");
                        playerInputLetter = Console.ReadLine().ToLower();

                        if (guessesContainerList.Contains(playerInputLetter))
                        {
                            Console.WriteLine("You already tried this letter.");
                        }
                        else if (randomWordList.Contains(playerInputLetter))
                        {
                            Console.WriteLine("Good Guess!");
                            goodGuessesNumber++;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Guess!");
                            wrongGuessesNumber++;
                            Console.WriteLine("Wrong guesses: " + wrongGuessesNumber);
                        }
                        WrongGuess(wrongGuessesNumber);

                        for (int i = 0; i < randomWordList.Count; i++)
                        {
                            if (randomWordList[i] == playerInputLetter)
                            {
                                guessesContainerList[i] = playerInputLetter;
                            }
                        }
                        foreach (string i in guessesContainerList)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        if (wrongGuessesNumber < 7)
                        {
                            Console.WriteLine("Try to guess the word (press \"enter\" to skip)");
                        }
                        playerInputWord = Console.ReadLine().ToLower();
                        if (playerInputWord != randomWord && playerInputWord != "")
                        {
                            Console.WriteLine("Wrong guess.");
                        }
                    }
                    if (wrongGuessesNumber >= 7)
                    {
                        Console.WriteLine("The random word: " + randomWord);
                        Console.WriteLine("\nYOU LOOSE!!!");
                    }
                    else
                    {
                        double numberToDefineScore;
                        if (wrongGuessesNumber == 0)
                        {
                            numberToDefineScore = 0.5;
                        }
                        else
                        {
                            numberToDefineScore = wrongGuessesNumber;
                        }
                        double score = ((randomWordList.Count) / (numberToDefineScore));
                        stopwatch.Stop();
                        Console.WriteLine("CONGRATULATIONS! YOU WIN!!!");
                        Console.WriteLine("Your time: " + (stopwatch.Elapsed));
                        Console.WriteLine("Your's score: " + (score));
                        Console.WriteLine($"Correct guesses:  {goodGuessesNumber}");
                        Console.WriteLine($"Wrong guesses:    {wrongGuessesNumber}");
                        Console.WriteLine($"The lenght of the random word:  {randomWordList.Count} symbols");
                        Console.WriteLine("Please enter your nickname to scoreboard: ");
                        string nickname = Console.ReadLine();
                        while (nickname == "")
                        {
                            Console.WriteLine("Please enter your nickname");
                            nickname = Console.ReadLine();
                        }
                        string scoreToFile = (nickname + ": " + score + "points " + " \ttime: " + stopwatch.Elapsed);
                        if (File.Exists($"C:/Marcin/programowanie/materialy/CwiczeniaDoZrobienia/Hangman/HangmanScores.txt"))
                        {
                            var files = Directory.GetFiles($"C:/Marcin/programowanie/materialy/CwiczeniaDoZrobienia/Hangman/", "*HangmanScores.txt", SearchOption.AllDirectories);
                            foreach (string file in files)
                            {
                                File.AppendAllText(file, scoreToFile + "\n");
                            }
                        }
                        else
                        {
                            File.WriteAllText($"C:/Marcin/programowanie/materialy/CwiczeniaDoZrobienia/Hangman/HangmanScores.txt", scoreToFile + "\n");
                        }
                        Console.WriteLine("\t\t\t\t\t---------SCORE BOARD---------");
                        Console.WriteLine();
                        var scoreFile = File.ReadAllText(@"C:/Marcin/programowanie/materialy/CwiczeniaDoZrobienia/Hangman/HangmanScores.txt");
                        Console.WriteLine(scoreFile);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would You like to play again? Yes(Y)/any other if No");
                    string playAgainChoise = Console.ReadLine().ToUpper();
                    if (playAgainChoise == "Y")
                    {
                        playAgainBool = true;
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing. Take care!");

                        break;
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please try to input everything in correct format");
            }
            catch (Exception e)
            {
                Console.WriteLine("Please try again and focus what You input");

            }
            Console.ReadLine();
        }
    }
}