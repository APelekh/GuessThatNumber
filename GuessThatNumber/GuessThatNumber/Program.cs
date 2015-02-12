using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        
        static Random rng = new Random();
        static int NumberToGuess = 0;
      
       
        static void Main(string[] args)
        {

            SetNumberToGuess(NumberToGuess);


            string test = "I want to output my text very slowly...";
            for (int i = 0; i < test.Length; i++)
            {
                Console.Write(test[i]);
                System.Threading.Thread.Sleep(100);
            }

            Console.ReadKey();
        }
        
        /// <summary>
        /// Checks if the input value is an integer or not
        /// </summary>
        /// <param name="userInput">Input value to be checked</param>
        /// <returns>Returns true if the input was an integer and false if not</returns>
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.

            //creating varialbe for TryParse
            int result = 0;
            //checking if the input is an integer
            if (int.TryParse(userInput, out result))
            {
                //checking if the integer is within the range of 1 to 100
                if (int.Parse(userInput) <= 100 && int.Parse(userInput) >= 1)
                {
                    //returns true if both conditions are yes
                    return true;
                }
            }
            return false;
        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;
            
            //getting random number that needs to be guessed
            NumberToGuess = rng.Next(1, 101);
            //creating a variable to store the number of tries. Must start at 1 for correct calculation
            int numberOfTries = 1;
            //Asking the user to enter the number
            Console.WriteLine("Welcome to GUESS THAT NUMBER!!!");
            Console.WriteLine("Guess the number between 1 and 100 and get a free cookie!");
            //reading the input from user
            string userInputString = Console.ReadLine();
            //creating a list with funny messages. Need to work on it later
            List<string> slowPokeMessages = new List<string>() { "Is it too hard?", "I'm not going to do it for you.", "Are you still there?", "Com'n! Use your brain,!", "You're hopeless..." };
            
            //most likely will never happen, but need to check if the first input number is matching the number to be guessed
            //this part executes if the first input number is matching the number to be guessed
            if (ValidateInput(userInputString) && NumberToGuess == Convert.ToInt32(userInputString))
            {
                //if it matches then program skips all code and continues with printing the results
               
            }
            
            //this part executes if the first input was invalid
            //checking if the input is invalid
            else if (!ValidateInput(userInputString))
            {
                //using do while loop because I need to execute this part at least once
                do
                {
                    //printing out the message that number is invalid, and asks user to enter it again
                    Console.WriteLine("Input is invalid. Number must be between 1 and 100.");
                    //reading the input
                    userInputString = Console.ReadLine();
                    
                    //part for funny messages. Needs to be fixed
                    //int i = 0;

                    //looping as long as the input is valid and is not equal to guess number
                    while (ValidateInput(userInputString) && NumberToGuess != Convert.ToInt32(userInputString))
                    {
                        //checking if number is higher or lower and prints out the result
                        IsGuessTooHigh(Convert.ToInt32(userInputString));
                        IsGuessTooLow(Convert.ToInt32(userInputString));

                        //needs to be fixed
                        //if (i > 4)
                        //{
                        //    Console.WriteLine(slowPokeMessages[i]);
                        //    i++;
                        //}
                        //else
                        //{
                        //    Console.WriteLine("....");
                        //}
                        
                        //getting new input from user
                        userInputString = Console.ReadLine();
                        //incrementing the amount of tries
                        numberOfTries++;

                    }
                    //incrementing the amount of tries
                    numberOfTries++;
                //looping as long as input is invalid
                } while (!ValidateInput(userInputString));

             }

            //this part executes if first input was an integer
            //checking if the input was an integer and if the integer is not matching the number to be guessed
            else if (ValidateInput(userInputString) && NumberToGuess != Convert.ToInt32(userInputString))
            {
                //checking if number is higher or lower and prints out the result
                IsGuessTooHigh(Convert.ToInt32(userInputString));
                IsGuessTooLow(Convert.ToInt32(userInputString));
                //getting new input from user
                userInputString = Console.ReadLine();

               
                //using do while loop because I need to execute this part at least once
                do
                {
                    //checking if the input was invalid
                    if (!ValidateInput(userInputString))
                    {
                        Console.WriteLine("Input is invalid. Number must be between 1 and 100.");
                        //getting new input from user
                        userInputString = Console.ReadLine();
                    }

                    //part for funny messages. Needs to be fixed
                    //int i = 0;
                    //looping as long as the input is valid and is not equal to guess number
                    while (ValidateInput(userInputString) && NumberToGuess != Convert.ToInt32(userInputString))
                    {
                        //checking if number is higher or lower and prints out the result
                        IsGuessTooHigh(Convert.ToInt32(userInputString));
                        IsGuessTooLow(Convert.ToInt32(userInputString));

                        //needs to be fixed
                        //if (i > 4)
                        //{
                        //    Console.WriteLine(slowPokeMessages[i]);
                        //    i++;
                        //}
                        //else
                        //{
                        //    Console.WriteLine("....");
                        //}

                        //getting new input from user
                        userInputString = Console.ReadLine();
                        //incrementing the amount of tries
                        numberOfTries++;
                    }
                //looping as long as input is invalid
                } while (!ValidateInput(userInputString));

            }
            
            //printing out results
            if (numberOfTries > 7)
            {
                Console.WriteLine("This game is too hard for you...Try with basic math first..");
                Console.WriteLine("It took {0} tries for you to guess it.", numberOfTries);
            }
            else
            {
                Console.WriteLine("YES! You got it!");
                Console.WriteLine("It took {0} tries for you to guess it.", numberOfTries);
            }



            //int userInputInt = 0;
            //while (userInputInt != numberToGuess)
            //{
            //    //1. get input from user
            //    if (ValidateInput(userInputString))
            //    {
            //        userInputInt = int.Parse(userInputString);
            //    }
            //    //2. check if its too high/low/correct
            //    if (IsGuessTooHigh(1)){
            //        Console.WriteLine("too high");
            //    }
            //    else if (IsGuessTooLow(1))
            //    {
            //        Console.WriteLine("toolow");
            //    }
            //    else
            //    {
            //        Console.WriteLine("yay, you won");
            //    }
            //}
                   
                
        }

        /// <summary>
        /// Checks if the input number is higher than the number to be guessed
        /// </summary>
        /// <param name="userGuess">Number to be checked</param>
        /// <returns>Returns true if the input was higher, and false if not</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high

            //checking if the input is higher than the number to be guessed
            if (userGuess > NumberToGuess)
            {
                Console.WriteLine("Number is too high!");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the input number is lower than the number to be guessed
        /// </summary>
        /// <param name="userGuess">Number to be checked</param>
        /// <returns>Returns true if the input was lower, and false if not</returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low

            //checking if the input is lower than the number to be guessed
            if (userGuess < NumberToGuess)
            {
                Console.WriteLine("Number is too low!");
                return true;
            }
            return false;
        }
    }
}
