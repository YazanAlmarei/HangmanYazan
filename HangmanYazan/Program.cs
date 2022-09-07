using System;
using System.Collections.Generic;

namespace HangmanYazan
{
    class Program
    {
        private static int print(List<char> lettersGuessed, String randomWord) //a function that prints the word and updates the counter of right letters and lines _
        {
            int rightL = 0;

            foreach (char c in randomWord)
            {
                if (lettersGuessed.Contains(c))
                {
                    Console.Write(c + " ");
                    rightL = rightL + 1;
                }

                else
                {
                    Console.Write("_ ");
                }
            }
            return rightL;

        }
        static void Main(string[] args)
        {
            //The game asks the player about the name and to play

            Console.WriteLine("Hello, welcome to hangman, whats your name?");
            string name = Console.ReadLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Hello " + name + ", lets play!");

            Random random = new Random();
            List<string> randomWords = new List<string>
            {
                "car",
                "fish",
                "banana",
                "forest",
            };

            //The program chooses a random word
            int temp = random.Next(randomWords.Count);
            String randomWord = randomWords[temp];

            //for each letter in the random word, the program does a line _
            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWord = randomWord.Length;
            int timesWrong = 0;
            int lettersRight = 0;
            List<char> lettersGuessed = new List<char>(); //a list for the letters guessed if repeated

            while (timesWrong != 6 && lettersRight != lengthOfWord)
            {
                //printing the list of letters guessed
                Console.Write("\nLetters guessed: ");
                foreach (char c in lettersGuessed)
                {
                    Console.Write(c + " ");
                }

                //asking the player to type a letter
                Console.Write("\nTake a guess: ");
                char guessedLetter = char.Parse (Console.ReadLine());
                Console.Write("\n");

                //if the player repeats a letter, it updates the list and says....
                if (lettersGuessed.Contains(guessedLetter))
                {
                    Console.Write("\nAlready Guessed");
                    lettersRight = print(lettersGuessed, randomWord);
                }

                //if the letter is not in the letters guessed list
                else
                {
                    bool right = false;

                    //checking if the letter is in the word
                    for (int i = 0; i < randomWord.Length; i++) 
                    {
                        if (guessedLetter == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    //if we are correct, we print the word and show the letter
                    if (right)
                    {
                        lettersGuessed.Add(guessedLetter);
                        lettersRight = print(lettersGuessed, randomWord);

                    }

                    //if its wrong, we lose a life, update the letters list
                    else
                    {
                        timesWrong++;
                        lettersGuessed.Add(guessedLetter);
                        lettersRight = print(lettersGuessed, randomWord);
                        Console.Write("\nWrong guess\n");
                    }
                }

            }

            //after losing all lives
            if (timesWrong == 6)
            {
                Console.WriteLine("OMEGALUL you lost!");
            }
            
            //when completing the word
            else
            {
                Console.WriteLine("You got it right! Thanks for playing");
            }

        }
    }
}
