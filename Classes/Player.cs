using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Classes
{
    public class Player
    {
        public string name;
        public char symbol;
        public int wins;


        public Player(string Name, char Symbol)
        {
            name = Name;
            symbol = Symbol;
            wins = 0;
        }

        public void PlayerTurn(List<string> cells)
        {
            Console.WriteLine($"{name}, which cell would you like to play?");

            string input = String.Empty;
            input = Console.ReadLine();
            bool inputIsInt = int.TryParse(input, out int inputInt);
            while (string.IsNullOrEmpty(input) || !cells.Contains(input) || !inputIsInt)
            {
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nYour chosen cell cannot be null or empty, please type in the number of an available cell:");
                }
                else if (!inputIsInt)
                {
                    Console.WriteLine("\nPlease play a playable whole number between 1-9:");
                }
                else if (!cells.Contains(input))
                {
                    Console.WriteLine($"\n{input} has already been played or does not exist. Please try again:");
                }
                input = Console.ReadLine();
                inputIsInt = int.TryParse(input, out inputInt);
            }

            cells[inputInt - 1] = symbol.ToString();
        }
    }
}
