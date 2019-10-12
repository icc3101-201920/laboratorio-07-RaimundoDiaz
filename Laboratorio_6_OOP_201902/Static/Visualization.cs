using Laboratorio_6_OOP_201902.Cards;
using Laboratorio_6_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_6_OOP_201902.Static
{
    public static class Visualization
    {
        public static void ShowHand(Hand hand)
        {
            CombatCard combatCard;
            Console.WriteLine("Hand: ");
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i] is CombatCard)
                {
                    combatCard = hand.Cards[i] as CombatCard;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"|({i}) {combatCard.Name} ({combatCard.Type}): {combatCard.AttackPoints} |");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"|({i}) {hand.Cards[i].Name} ({hand.Cards[i].Type}) |");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        public static void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select one Deck:");
            for (int i = 0; i < decks.Count; i++)
            {
                Console.WriteLine($"({i}) Deck {i + 1}");
            }
        }
        public static void ShowCaptains(List<SpecialCard> captains)
        {
            Console.WriteLine("Select one captain:");
            for (int i = 0; i < captains.Count; i++)
            {
                Console.WriteLine($"({i}) {captains[i].Name}: {captains[i].Effect}");
            }
        }
        public static int GetUserInput(int maxInput, bool stopper = false)
        {
            bool valid = false;
            int value;
            int minInput = stopper ? -1 : 0;
            while (!valid)
            {

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minInput && value <= maxInput)
                    {
                        return value;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The option ({value}) is not valid, try again");
                        Console.ResetColor();
                    }
                }
                else
                {
                    ConsoleError($"Input must be a number, try again");
                }
            }
            return -1;
        }
        public static void ConsoleError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowListOptions(List<string> options, string message = null)
        {
            if (message != null) Console.WriteLine($"{message}");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"({i}) {options[i]}");
            }
        }
        public static void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }

        public static void ShowBoard(Board board, int player, int[] lifePoints, int[] attackPoints)
        {
            int opponent;

            if (player == 0)
            {
                opponent = 0;
            }

            else
            {
                opponent = 1;
            }

            List<Card> cardList0 = board.PlayerCards[opponent][EnumType.longRange];
            string melee0 = "";
            foreach (Card card in cardList0)
            {
                CombatCard String = (CombatCard)card;
                melee0 += $"|{String.AttackPoints}| ";
            }

            List<Card> cardList1 = board.PlayerCards[opponent][EnumType.longRange];
            string range0 = "";
            foreach (Card card in cardList1)
            {
                CombatCard String = (CombatCard)card;
                range0 += $"|{String.AttackPoints}| ";
            }

            List<Card> cardList10 = board.PlayerCards[opponent][EnumType.longRange];
            string lRange0 = "";
            foreach (Card card in cardList10)
            {
                CombatCard String = (CombatCard)card;
                lRange0 += $"|{String.AttackPoints}| ";
            }

            List<SpecialCard> weatherCardsList = board.WeatherCards;
            string weatherCards = "";
            foreach (SpecialCard specialCard in weatherCardsList)
            {
                weatherCards += $"|{specialCard.Name}|  ";
            }

            List<Card> cardList11 = board.PlayerCards[player][EnumType.longRange];
            string melee1 = "";
            foreach (Card card in cardList11)
            {
                CombatCard String = (CombatCard)card;
                melee1 += $"|{String.AttackPoints}| ";
            }

            List<Card> cardList100 = board.PlayerCards[player][EnumType.longRange];
            string range1 = "";
            foreach (Card card in cardList100)
            {
                CombatCard String = (CombatCard)card;
                range1 += $"|{String.AttackPoints}| ";
            }

            List<Card> cardList101 = board.PlayerCards[player][EnumType.longRange];
            string lRange1 = "";
            foreach (Card card in cardList101)
            {
                CombatCard String = (CombatCard)card;
                lRange1 += $"|{String.AttackPoints}| ";
            }

            Console.WriteLine("Board:");
            Console.WriteLine("");
            Console.WriteLine($"Opponent - LifePoints: {lifePoints[opponent]} - AttackPoints: { attackPoints[opponent]}");
            Console.WriteLine($"(Long Range) [{board.GetAttackPoints(EnumType.longRange)[opponent]}]: {lRange0}");
            Console.WriteLine($"(Range) [{board.GetAttackPoints(EnumType.range)[opponent]}]: {range0}");
            Console.WriteLine($"(Melee) [{board.GetAttackPoints(EnumType.longRange)[opponent]}]: {melee0}");
            Console.WriteLine("");
            Console.WriteLine($"Weather Cards: {weatherCards}");
            Console.WriteLine($"Opponent - LifePoints: {lifePoints[player]} - AttackPoints: {attackPoints[player]}");
            Console.WriteLine("");
            Console.WriteLine($"(Long Range) [{board.GetAttackPoints(EnumType.longRange)[player]}]: {lRange1}");
            Console.WriteLine($"(Range) [{board.GetAttackPoints(EnumType.range)[player]}]: {range1}");
            Console.WriteLine($"(Melee) [{board.GetAttackPoints(EnumType.longRange)[player]}]: {melee1}");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
