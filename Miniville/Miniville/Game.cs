using System;
using System.Collections.Generic;

namespace Miniville
{
	public class Game
	{
		private Player Human;// { get; private set; }
		private Player AI;// { get; private set; }

		private Pile Deck;// { get; private set; }

		private Dice Dice6 = new Dice(6);

		private int nbTurns = 0;
		private int MoneyToWin;
		private bool ExpertMode;
		private bool PlayInConsole = true;
		public Game()
		{
			Console.WriteLine("Quel est votre nom ?");
			this.Human = new Player(Console.ReadLine());

			this.AI = new Player("AI");

			this.Deck = new Pile();

			if (PlayInConsole)
			{
				//Ask the player how long the game should last
				Console.WriteLine("Quelle longueur de partie choisissez vous ? ");
				Console.WriteLine("1 - Courte, il faut au moins 10 pièces pour gagner");
				Console.WriteLine("2 - Standard, il faut au moins 20 pièces pour gagner");
				Console.WriteLine("3 - Longue, il faut au moins 30 pièces pour gagner");
				while (true)
				{
					try
					{
						int inp = Int32.Parse(Console.ReadLine());
						if (1 <= inp && inp <= 3)
						{
							this.MoneyToWin = inp * 10;
							break;
						}
					}
					catch
					{
						Console.WriteLine("Veuillez entrer un nombre valide");
					}
				}
				Console.WriteLine("Voulez vous jouer en mode expert ? (O/N)");
				this.ExpertMode = Console.ReadLine().ToLower() == "o";

			}
		}

		public void Run()
		{
			bool HumanWins = PlayerWins(Human), AIWins = PlayerWins(AI);
			while (!(HumanWins || AIWins))
            {
				//Human turn
				int diceThrow = Dice6.DiceThrow();
				ActivateCards(Human, AI, diceThrow, true);
				ActivateCards(AI, Human, diceThrow, false);
				HumanAction();

				//AI turn
				diceThrow = Dice6.DiceThrow();
				ActivateCards(AI, Human, diceThrow, true);
				ActivateCards(Human, AI, diceThrow, false);
				AIAction();


				HumanWins = PlayerWins(Human);
				AIWins = PlayerWins(AI);
			}
			EndGame(HumanWins, AIWins);

		}

		private void ActivateCards(Player Player0, Player otherPlayer, int diceThrow, bool isPlayer0Turn)
		{
			foreach (Card c in Player0.Cards)
			{
				if (isPlayer0Turn)
				{
					if (c.CardColor == Utils.CardColor.Red || c.CardColor == Utils.CardColor.Blue)
					{
						if (c.NbsActivation.Contains(diceThrow))
						{
							c.Effect(Player0, otherPlayer);
						}
					}
				}
                else
				{
					if (c.CardColor == Utils.CardColor.Green || c.CardColor == Utils.CardColor.Blue)
					{
						if (c.NbsActivation.Contains(diceThrow))
						{
							c.Effect(Player0, otherPlayer);
						}
					}
				}
			}
		}

		private void HumanAction()
		{

		}
		private void AIAction()
		{

		}

		private void EndGame(bool HumanWins, bool AIWins)
        {

        }

		private void ConsoleDisplay()
		{

		}

		private bool PlayerWins(Player p)
		{
			if (this.ExpertMode)
			{
				//If playing in expert mode, check if Player p has every card type in their deck
				foreach (Utils.CardName name in Enum.GetValues(typeof(Utils.CardName)))
				{
					bool nameInDeck = false;
					foreach (Card c in p.Cards)
					{
						nameInDeck = nameInDeck || c.Name == name;
						if (nameInDeck)
                        {
							break;
                        }
					}
					if (!nameInDeck)
                    {
						return false;
                    }
				}
			}
			// If that part is reached, it means that either the expert mode is not active, or that Player p has every type of card in their deck
			return p.Money >= this.MoneyToWin;
		}
	}
}

