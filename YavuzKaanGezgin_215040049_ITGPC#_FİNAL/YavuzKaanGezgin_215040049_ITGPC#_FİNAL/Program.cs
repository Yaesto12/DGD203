using System;

class Program
{
    static string playerName;
    static int playerX, playerY;
    static bool hasFoundPicture = false;
    static int wrongAnswerCount = 0;

    static void Main()
    {
        Console.WriteLine("Welcome to the Game!");
        Console.Write("What would be the name of your traveller?: ");
        playerName = Console.ReadLine();

        while (true)
        {
            InitializeGame();

            while (true)
            {
                DisplayMap();
                DisplayOptions();

                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "north":
                        Move("north");
                        break;
                    case "south":
                        Move("south");
                        break;
                    case "west":
                        Move("west");
                        break;
                    case "east":
                        Move("east");
                        break;
                    case "pick":
                        TryPick();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter north, south, west, east, or pick.");
                        break;
                }

                if (playerX == 2 && playerY == 3 && !hasFoundPicture)
                {
                    Console.WriteLine("There is a picture here!");
                }
                else if (playerX == 4 && playerY == 1)
                {
                    Console.WriteLine("You have reached an NPC.");

                    {
                        Console.WriteLine("Riddler: Solve this riddle to win the game.");
                        AskRiddle();
                        break; // Exit the inner loop when the game ends
                    }
                }
            }

            Console.WriteLine("Game Over! Restart by pressing 'R' or any other key to exit.");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key != ConsoleKey.R)
            {
                break; // Exit the outer loop if the player chooses not to restart
            }
        }
    }

    static void InitializeGame()
    {
        playerX = 0;
        playerY = 0;
        hasFoundPicture = false;
        wrongAnswerCount = 0;
    }

    static void DisplayMap()
    {
        Console.WriteLine("Current Position: ({0}, {1})", playerX, playerY);
        Console.WriteLine("---------------");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == playerY && j == playerX)
                    Console.Write(" P ");
                else
                    Console.Write(" - ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("---------------");
    }

    static void DisplayOptions()
    {
        Console.WriteLine("Options: north, south, west, east, pick");
        if (hasFoundPicture)
        {
            Console.Write("Enter your move: ");
        }
        else
        {
            Console.Write("Enter your move (except 'e'): ");
        }
    }

    static void Move(string direction)
    {
        switch (direction)
        {
            case "north":
                if (playerY > 0)
                    playerY--;
                else
                    Console.WriteLine("You can't go north.");
                break;
            case "south":
                if (playerY < 4)
                    playerY++;
                else
                    Console.WriteLine("You can't go south.");
                break;
            case "west":
                if (playerX > 0)
                    playerX--;
                else
                    Console.WriteLine("You can't go west.");
                break;
            case "east":
                if (playerX < 4)
                    playerX++;
                else
                    Console.WriteLine("You can't go east.");
                break;
        }
    }

    static void TryPick()
    {
        if (playerX == 2 && playerY == 3 && !hasFoundPicture)
        {
            Console.WriteLine("You picked up the picture!");
            Console.WriteLine("In this picture, there is a crawling baby, a walking adult, and an old man with a walking stick.");
            hasFoundPicture = true;
        }
        else
        {
            Console.WriteLine("There is nothing to pick here.");
        }
    }

    static void AskRiddle()
    {
        Console.WriteLine("Riddle: It starts the journey with 4 legs and continues with 2 legs, at the end of the journey it has 3 legs. What is it?");
        Console.WriteLine("a) Frog");
        Console.WriteLine("b) House");
        Console.WriteLine("c) Guitar");
        Console.WriteLine("d) Tree");
        if (hasFoundPicture)
        {
            Console.WriteLine("e) Human");
        }

        string answer;
        do
        {
            Console.Write("Your answer (a, b, c, d, e): ");
            answer = Console.ReadLine().ToLower();
            if (answer == "e" && hasFoundPicture)
            {
                Console.WriteLine("Correct! You solved the riddle!");
                hasFoundPicture = true;
            }
            else
            {
                Console.WriteLine("Incorrect. Try again!");
                wrongAnswerCount++;

                if (wrongAnswerCount == 2)
                {
                    Console.WriteLine("You gave the wrong answer twice. Npc kill you.");
                    break; // Exit the inner loop when the game ends
                }
            }
        } while (answer != "e" || !hasFoundPicture);
    }
}
