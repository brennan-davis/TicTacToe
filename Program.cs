namespace TicTacToe
{
    internal class Program
    {
            static int turnCount = 0;
            static int playerTurn;

            static void Main(string[] args)
            {
                Console.Clear();

                Player playerOne = createPlayer("1");
                Player playerTwo = createPlayer("2");

                bool newGame = true;

                while (newGame)
                {
                    List<string> cells = initializGame();
                    playerTurn = new Random().Next(1, 3);
                    bool continueGame = true;

                    while (continueGame && turnCount < 9)
                    {
                        drawBoard(cells, playerOne, playerTwo);

                        if (playerTurn == 1)
                        {
                            playerOne.PlayerTurn(cells);
                            continueGame = CheckWin(playerOne, cells, 2);
                            if (!continueGame)
                            {
                                playerOne.wins++;
                                drawBoard(cells, playerOne, playerTwo);
                                Console.WriteLine($"{playerOne.name} Wins!");
                            }
                        }
                        else
                        {
                            playerTwo.PlayerTurn(cells);
                            continueGame = CheckWin(playerOne, cells, 1);
                            if (!continueGame)
                            {
                                playerTwo.wins++;
                                drawBoard(cells, playerOne, playerTwo);
                                Console.WriteLine($"{playerTwo.name} Wins!");
                            }
                        }

                    }

                    if (turnCount > 8)
                    {
                        Console.WriteLine("Ran out of turns!");
                    }

                    Console.WriteLine("Would you like to play a another game? (y/n)");
                    if (Console.ReadLine() != "y")
                    {
                        newGame = false;
                    }
                }

            }

            static Player createPlayer(string playerNum)
            {
                Console.WriteLine($"Player {playerNum}, what is your name?");
                string name = string.Empty;
                while (string.IsNullOrEmpty(name))
                {
                    name = Console.ReadLine();
                };
                Console.WriteLine($"{name}, what symbol would you like to use for play? (Ex. 'X' or '$')");
                bool isChar = char.TryParse(Console.ReadLine(), out char playerSymbol);
                while (!isChar)
                {
                    isChar = char.TryParse(Console.ReadLine(), out playerSymbol);
                }

                return new Player(name, playerSymbol);
            }

            static List<string> initializGame()
            {
                turnCount = 0;

                List<string> cellsArray = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                return cellsArray;
            }

            static void drawBoard(List<string> cells, Player playerOne, Player playerTwo)
            {
                Console.Clear();

                Console.WriteLine($"     |     |     \n  {cells[0]}  |  {cells[1]}  |  {cells[2]}  \n     |     |     \n-----------------\n     |     |       SCORE:\n  {cells[3]}  |  {cells[4]}  |  {cells[5]}    {playerOne.name}({playerOne.symbol}): {playerOne.wins}\n     |     |       {playerTwo.name}({playerTwo.symbol}): {playerTwo.wins}\n-----------------\n     |     |     \n  {cells[6]}  |  {cells[7]}  |  {cells[8]}  \n     |     |     \n");

            }

        class Player
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
                while (string.IsNullOrEmpty(input) || !cells.Contains(input) && !inputIsInt)
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Your chosen cell cannot be null or empty, please type in the number of an available cell:");
                    }
                    else if (!cells.Contains(input))
                    {
                        Console.WriteLine($"{input} has already been played or does not exist. Please try again:");
                    }
                    input = Console.ReadLine();
                    inputIsInt = int.TryParse(input, out inputInt);
                }

                cells[inputInt - 1] = symbol.ToString();
            }
        }

        static bool CheckWin(Player player, List<string> cells, int PlayerTurn)
        {
            turnCount++;
            playerTurn = PlayerTurn;

            if (cells[0] == cells[1] && cells[0] == cells[2] || cells[3] == cells[4] && cells[3] == cells[5] || cells[6] == cells[7] && cells[6] == cells[8] || cells[0] == cells[3] && cells[0] == cells[6] || cells[1] == cells[4] && cells[1] == cells[7] || cells[2] == cells[5] && cells[2] == cells[8] || cells[0] == cells[4] && cells[0] == cells[8] || cells[6] == cells[4] && cells[6] == cells[2])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}