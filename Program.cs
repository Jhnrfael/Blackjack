namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            //This code runs whenever you answer yes to "Would you like to play again?" and since the question hasn't been asked yet this will run without answer at the start.
            while (playAgain)
            {
                Console.WriteLine("Welcome to Blackjack!");
                int playerSum = 0;
                int dealerSum = 0;
                Random rand = new Random();
                bool dealerStops = false;

                while (true)
                {
                    Console.WriteLine("Hit or stay?");
                    string answer = Console.ReadLine();
                    if (answer == "stay")
                    {
                        Console.WriteLine($"You chose to stay with a total sum of {playerSum}, Dealer's total sum: {dealerSum}");
                        break;
                    }

                    int playerHit = rand.Next(1, 7);
                    playerSum += playerHit;

                    //This code tells the program what to write and when, in this case if dealerStops has not been set as true it will continue
                    //to write both players hits but when the dealer reaches 17 or more and stops, it will only write how much you hit.

                    if (!dealerStops)
                    {
                        int dealerhit = rand.Next(1, 7);
                        dealerSum += dealerhit;

                        Console.WriteLine("You hit: " + playerHit + " , Dealer hit: " + dealerhit);
                    }
                    else
                    {
                        Console.WriteLine("You hit: " + playerHit);
                    }

                    Console.WriteLine("Your points: " + playerSum + " , Dealer's points: " + dealerSum);

                    if (dealerSum >= 17)
                    {
                        dealerStops = true;
                        Console.WriteLine("The Dealer chose to stay with a total sum of: " + dealerSum);
                    }

                    if (playerSum > 21)
                    {
                        Console.WriteLine("You went over 21, you have unfortunately lost...");
                        break;
                    }

                    if (dealerSum > 21)
                    {
                        Console.WriteLine("The Dealer went over 21, you win!");
                        break;
                    }
                }

                //This line of code only runs if you ever choose to stay whilst the dealer is still less than 17 points.

                if (dealerSum < 17)
                {
                    Console.WriteLine("It's time for the reckoning... Dealer's turn to play...");
                    while (dealerSum < 17)
                    {
                        int dealerHit = rand.Next(1, 7);
                        dealerSum += dealerHit;
                        Console.WriteLine("The Dealer hits: " + dealerHit + " The Dealer's total points: " + dealerSum);

                        if (dealerSum > 21)
                        {
                            Console.WriteLine("The Dealer went over 21. You have won!");
                            break;
                        }
                    }
                }

                if (playerSum <= 21 && dealerSum <= 21)
                {
                    if (playerSum == dealerSum)
                    {
                        Console.WriteLine("The points were equal, rendering The Dealer as the winner!");
                    }
                    else if (playerSum > dealerSum)
                    {
                        Console.WriteLine("You were closer to 21 than The Dealer. You win!");
                    }
                    else
                    {
                        Console.WriteLine("The Dealer was closer to 21 than you were. You have lost...");
                    }
                }

                Console.WriteLine("Would you want to play again? ;) (yes/no)");
                string playAgainAnswer = Console.ReadLine();

                if (playAgainAnswer != "yes")
                {
                    playAgain = false;
                    Console.WriteLine("Thank you for playing!");
                }
            }
        }
    }
}
