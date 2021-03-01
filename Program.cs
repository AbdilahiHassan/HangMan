using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            HangMan();
        

            }
           static void HangMan()
            {
            //Random object it is making random of this program
            Random random = new Random();
            //String Array it is contain A sectret latter
            string[] Hangman = { "Hang", "Man", "Game", "Test", "Win", "lose", "or", "Nothing else" };
            // Declaration of gues latter and Array length ramdom next 
            //is taking next latter from forn the user
            string Guess = Hangman[random.Next(0, Hangman.Length)];
            string wordToGues = Guess.ToUpper();
            //StringBuilder is a object, and Building userinput latter
            System.Text.StringBuilder displayToPlayer = new StringBuilder(Guess.Length);
            for (int i = 0; i < Guess.Length; i++)
                //Append it is a method and it is insert the word
                displayToPlayer.Append('_');
            //Char array contains CorrectGues/incorrectG
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            //Number of attempts
            int AttemptNr = 10;
            //Bool win or not
            bool win = false;
            int Revealed = 0;

            string input;
            char guess;
            //While loop if user get the number or not
            while (!win && AttemptNr > 0)
            {
                Console.Write("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                try
                {
                    guess = input[0];
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message + "Try again");
                }

                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGues.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < Guess.Length; i++)
                    {
                        if (wordToGues[i] == guess)
                        {
                            displayToPlayer[i] = Guess[i];
                            Revealed++;
                        }
                    }

                    if (Revealed == Guess.Length)
                        win = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Sorry, there's no '{0}' in it!", guess);
                    AttemptNr--;
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (win)
                Console.WriteLine("You win!");
            else
                Console.WriteLine("You lost! It was '{0}'", Guess);

            Console.Write("Press enter if you want exit...");
            Console.ReadLine();
            //char[] letters = words[random].ToCharArr

            Console.Write("----------------------");
            Console.ReadLine();
            }
        }
    }

