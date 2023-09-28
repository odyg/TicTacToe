using System;
using System.ComponentModel.Design;

namespace TicTacToe
{
    internal class Program
    {
        static bool checkWin(string symbol, string[,]b)
        {
            for (int i = 0;i<3; i++)
            {
                if (symbol == b[i,0] && symbol == b[i, 1] && symbol == b[i,2])
                {
                    return true;
                }
                if (symbol == b[0, i] && symbol == b[1, i] && symbol == b[2, i])
                {
                    return true;
                }
            }

            if (symbol == b[0, 0] && symbol == b[1, 1] && symbol == b[2, 2])
            {
                return true;
            }

            if (symbol == b[2, 0] && symbol == b[1, 1] && symbol == b[0, 2])
            {
                return true;
            }

            return false;
        }
        static void Display(string [,] b) 
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"|{b[i, j],3}  ");
                }
                Console.Write($"|");
                Console.WriteLine();
            }
       
        }

        static void help()
        {
            Console.WriteLine("To play type \" place row col\"");
            Console.WriteLine("To exit type \"exit\"");
        }
        static void PlayGame(string[,] b, string player1, string player2)
        {
          
            string statementmove = "Please enter a command: ";
            string input;
            string[] command;

            for (int i = 0;i < 9;) //9 because there's a maximum of 9 in this 3X3 tictactoe
            { 
                Display(b);
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{statementmove} {player1}");
                }
                else
                {
                    Console.WriteLine($"{statementmove} {player2}");
                }

                input = Console.ReadLine();
                command = input.Split(' ');

                switch(command[0])
                {
                    case "initialize":
                        for(int x=0; x<3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                                b[x, y] = "";
                        }
                        break;

                    case "place":
                        int r = int.Parse(command[1]);
                        int c = int.Parse(command[2]);
                        if (b[r,c] == "")
                        {
                            if (i % 2 == 0)
                            {
                                b[r, c] = "X";
                            }
                            else
                            {
                                b[r, c] = "O";
                            }

                            if(checkWin("X", b) == true)
                            {
                                Console.WriteLine($"Congrats {player1}");
                                Console.WriteLine("Do you want to play again? (Y/N)");
                                input = Console.ReadLine();
                                if (input == "y" || input == "Y")
                                {
                                    goto case "initialize";
                                }
                                else
                                {
                                    goto case "exit";
                                }
                            }
                            else if (checkWin("O", b) == true)
                            {
                                Console.WriteLine($"Congrats {player2}");
                                Console.WriteLine("Do you want to play again? (Y/N)");
                                input = Console.ReadLine();
                                if (input == "y" || input == "Y")
                                {
                                    goto case "initialize";
                                }
                                else
                                {
                                    goto case "exit";
                                }
                            }

                            i++;
                            if (i == 9)
                            {
                                Console.WriteLine("DRAW!");
                                Console.WriteLine("Do you want to play again? (Y/N)");
                                input = Console.ReadLine();
                                if (input == "y" ||  input == "Y")
                                {
                                    goto case "initialize";
                                }
                                else
                                {
                                    goto case "exit";
                                }
                            }
                        }
                      
                        break;

                    case "help":
                        help();
                        Console.ReadKey();
                        break;

                    case "exit":
                        return;
                        default: Console.WriteLine("Command invalid");
                        Console.ReadKey();
                        break;

                }
            }

        }


        static void Main(string[] args)
        {
            string[,] board = new string[,] {{ "", "", "" },{ "", "", ""},{ "", "", ""}};

            Console.WriteLine("Enter player 1");
            string player1 = Console.ReadLine();
            Console.WriteLine("Enter player 2");
            string player2 = Console.ReadLine();

            PlayGame(board, player1, player2);
        }
    }
}
