using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Classes
{
    public static class Game
    {
        static List<string> cellsArray = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        
        public static List<string> initializGame()
        {
            return cellsArray;
        }

        public static void drawBoard(List<string> cells, Player playerOne, Player playerTwo)
        {
            Console.Clear();

            Console.WriteLine($"     |     |     \n  {cells[0]}  |  {cells[1]}  |  {cells[2]}  \n     |     |     \n-----------------\n     |     |       SCORE:\n  {cells[3]}  |  {cells[4]}  |  {cells[5]}    {playerOne.name}({playerOne.symbol}): {playerOne.wins}\n     |     |       {playerTwo.name}({playerTwo.symbol}): {playerTwo.wins}\n-----------------\n     |     |     \n  {cells[6]}  |  {cells[7]}  |  {cells[8]}  \n     |     |     \n");

        }

        public static Player createPlayer(string playerNum)
        {
            Console.WriteLine($"Player {playerNum}, what is your name?");
            string name = string.Empty;
            while (string.IsNullOrEmpty(name))
            {
                name = Console.ReadLine();
            };
            Console.WriteLine($"\n{name}, what symbol would you like to use for play? (Ex. 'X' or '$')");
            bool isChar = char.TryParse(Console.ReadLine(), out char playerSymbol);
            while (!isChar)
            {
                isChar = char.TryParse(Console.ReadLine(), out playerSymbol);
            }

            Console.WriteLine();

            return new Player(name, playerSymbol);
        }

        public static bool CheckWin(Player player, List<string> cells)
        {
            return !(cells[0] == cells[1] && cells[0] == cells[2] || cells[3] == cells[4] && cells[3] == cells[5] || cells[6] == cells[7] && cells[6] == cells[8] || cells[0] == cells[3] && cells[0] == cells[6] || cells[1] == cells[4] && cells[1] == cells[7] || cells[2] == cells[5] && cells[2] == cells[8] || cells[0] == cells[4] && cells[0] == cells[8] || cells[6] == cells[4] && cells[6] == cells[2]);
        }
    }
}
