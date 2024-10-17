using System;
using System.Linq.Expressions;
using System.Threading;

Random rand = new Random();

Console.WriteLine("Welcome to the best casino you will ever visit");
Console.WriteLine("But you look like a beginner");

while (true)
{
    Console.Write("Have you ever been to a casino before (yes/no): ");
    string answerFirstQ = Console.ReadLine().ToLower();

    if (answerFirstQ == "no")
    {
        Console.WriteLine("THEN GET OUT OF MY FACE!");
        return;
    }
    else if (answerFirstQ == "yes")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input. Please answer (yes / no).");
    }
}

Console.WriteLine("What game do you want to play?");
Console.WriteLine("1. Black Jack?");
Console.WriteLine("2. Poker?");
Console.WriteLine("3. Baccarat?");
Console.WriteLine("4. Roulette?");
Console.WriteLine("5. Quit the game");

while (true)
{
    Console.Write("Choose a number: ");
    string answerSecondQ = Console.ReadLine().ToLower();

    if (answerSecondQ == "1" || answerSecondQ == "2" || answerSecondQ == "3")
    {
        Console.WriteLine("We don't have that, sorry!");
    }
    else if (answerSecondQ == "5")
    {
        Console.WriteLine("You don't deserve to be here anyway. GET OUT!");
        return;
    }
    else if (answerSecondQ == "4")
    {
        Console.WriteLine("So you want to play roulette... ");
        Console.WriteLine("Do you know how to play? (yes/no):");
        string knowsRules = Console.ReadLine().ToLower();

        if (knowsRules == "no")
        {
            Console.WriteLine("Do you want me to explain the rules? (yes/no)");
            string explainRules = Console.ReadLine().ToLower();

            if (explainRules == "no")
            {
                Console.WriteLine("GET OUT THEN, I DON'T WANT TO SEE YOU HERE AGAIN");
                return;
            }
            else if (explainRules == "yes")
            {
                Console.WriteLine("Okay, here are the basic rules:");
                Console.WriteLine("1. Place your bets on the table.");
                Console.WriteLine("2. The dealer spins the wheel and releases a ball.");
                Console.WriteLine("3. The wheel has black, red, and green sections with numbers from 0 to 36.");
                Console.WriteLine("4. The green section contains the number 0.");
                Console.WriteLine("5. If the ball lands on your bet (color or number), you win.");
                Console.WriteLine("Do you understand the rules now? (yes/no)");

                string understandsNow = Console.ReadLine().ToLower();
                if (understandsNow == "no")
                {
                    Console.WriteLine("HOW DUMB CAN YOU BE, GET OUT OF MY FACE");
                    return;
                }
            }
        }
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice. Please choose an existing game.");
    }
}

Console.WriteLine("You made it to the roulette game!");

while (true)
{
    Console.WriteLine("1. Play with bets");
    Console.WriteLine("2. Play without bets");
    Console.WriteLine("3. Leave the game");
    Console.Write("Choose an option: ");

    string gameModeChoice = Console.ReadLine().ToLower();

    if (gameModeChoice == "1")
    {
        Console.WriteLine("Welcome to the DEMON roulette!");


        int balance;
        while (true)
        {
            Console.Write("Enter the amount you want to charge: ");
            if (int.TryParse(Console.ReadLine(), out balance) && balance >= 50)
            {
                break;
            }
            Console.WriteLine("Please deposit $50 or more!");
        }

        while (true)
        {
            Console.WriteLine($"Your balance is ${balance}.");
            Console.WriteLine("Press 'Q' to quit and refund your money, ");
            Console.WriteLine("or type 'menu' to go back to the main menu.");
            Console.WriteLine("Or just press Enter to Continue");
            string inputExit = Console.ReadLine().ToLower();
            if (inputExit == "q")
            {
                Console.WriteLine("Hahaha, what a LOSER, BIITTCCCHHH");
                return;
            }
            else if (inputExit == "menu")
            {
                break;
            }


            Console.WriteLine("Choose a color to bet on:");
            Console.WriteLine("Red: Numbers 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36");
            Console.WriteLine("Black: Numbers 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35");
            Console.WriteLine("Green: Number 0");

            while (true)
            {
                Console.Write("Choose a color (red/black/green): ");
                string colorChoice = Console.ReadLine().ToLower();

                int[] redChoices = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
                int[] blackChoices = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
                int[] greenChoices = { 0 };

                if (colorChoice == "red" || colorChoice == "black" || colorChoice == "green")
                {
                    while (true)
                    {
                        Console.Write("Enter a number: ");
                        if (int.TryParse(Console.ReadLine(), out int numberChoice))
                        {
                            bool isValid = (colorChoice == "red" && Array.Exists(redChoices, num => num == numberChoice)) ||
                                           (colorChoice == "black" && Array.Exists(blackChoices, num => num == numberChoice)) ||
                                           (colorChoice == "green" && numberChoice == 0);

                            if (!isValid)
                            {
                                Console.WriteLine("Invalid number choice, try again.");
                                continue;
                            }

                            Console.Write("How much do you want to bet? ");
                            int betAmount;
                            while (!int.TryParse(Console.ReadLine(), out betAmount) || betAmount < 50)
                            {
                                Console.WriteLine("Invalid bet amount. Please enter $50 or more.");
                            }

                            if (betAmount > balance)
                            {
                                Console.WriteLine("You do not have enough balance. Try again.");
                                continue;
                            }


                            Console.Write("Spinning the wheel");
                            for (int i = 0; i < 5; i++)
                            {
                                Thread.Sleep(1000);
                                Console.Write(".");
                            }
                            Console.WriteLine();


                            int rouletteResult = rand.Next(0, 37);
                            string resultColor = rouletteResult == 0 ? "green" : (Array.Exists(redChoices, num => num == rouletteResult) ? "red" : "black");

                            Console.WriteLine($"The wheel stopped at {resultColor} {rouletteResult}.");

                            if (numberChoice == rouletteResult)
                            {
                                int winnings = betAmount * 35;
                                Console.WriteLine($"Congratulations! You hit the exact number and won ${winnings}!");
                                balance += winnings;
                            }
                            else if (colorChoice == resultColor)
                            {
                                int winnings = betAmount * 2;
                                Console.WriteLine($"You chose the right color! You won ${winnings}.");
                                balance += winnings;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, you lose.");
                                balance -= betAmount;
                            }

                            if (balance < 50)
                            {
                                Console.WriteLine("You ran out of money. Game over!");
                                return;
                            }

                            while (true)
                            {
                                Console.WriteLine("To go to the menu type (menu) or (no) to exit");
                                string continueChoice = Console.ReadLine().ToLower();

                                if (continueChoice == "menu")
                                {
                                    Console.WriteLine("Returning to the main menu...");
                                    goto MainMenu;
                                }
                                else if (continueChoice == "no")
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number choice. Try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid color choice. Try again.");
                }
            }

        MainMenu: continue;
        }
    }







    else if (gameModeChoice == "2")
    {
        Console.WriteLine("Welcome to the fun roulette!");
        Console.WriteLine("Play without spending your money");
        Console.WriteLine("Choose a color to bet on:");

        while (true)
        {
            Console.WriteLine("Red: Numbers 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36");
            Console.WriteLine("Black: Numbers 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35");
            Console.WriteLine("Green: Number 0");

            Console.Write("Choose a color (red/black/green) or type (menu) to go back to the main menu: ");
            string colorChoice = Console.ReadLine().ToLower();

            if (colorChoice == "menu")
            {
                break;
            }

            int[] redChoices = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            int[] blackChoices = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            int[] greenChoices = { 0 };

            if (colorChoice == "red" || colorChoice == "black" || colorChoice == "green")
            {
                Console.Write("Enter your number choice: ");
                if (int.TryParse(Console.ReadLine(), out int numberChoice))
                {
                    bool isValid = (colorChoice == "red" && Array.Exists(redChoices, num => num == numberChoice)) ||
                                   (colorChoice == "black" && Array.Exists(blackChoices, num => num == numberChoice)) ||
                                   (colorChoice == "green" && numberChoice == 0);

                    if (!isValid)
                    {
                        Console.WriteLine("Invalid number choice, try again.");
                        continue;
                    }

                    Console.Write("Spinning the wheel");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        Console.Write(".");
                    }
                    Console.WriteLine();

                    int rouletteResult = rand.Next(0, 37);
                    string resultColor = rouletteResult == 0 ? "green" : (Array.Exists(redChoices, num => num == rouletteResult) ? "red" : "black");

                    Console.WriteLine($"The wheel stopped at {resultColor} {rouletteResult}.");
                    Console.WriteLine("type (menu) to go back to the main menu or (no) to exit.");

                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "menu")
                    {
                        break;
                    }
                    else if (userInput == "no")
                    {
                        Console.WriteLine("thank you for playing");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number choice. Try again.");
                }
            }

        }
    }
    else if (gameModeChoice == "3")
    {
        Console.WriteLine("Why did you waste my time, BRRUUHHH");
        return;
    }
    else
    {
        Console.WriteLine("Choose from the menu please!");
    }
}