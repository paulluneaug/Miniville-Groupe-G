using System;
using System.Collections.Generic;

namespace MiniVille
{
	public class Game
	{
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
				int diceThrow = ;
				ActivateCards(Human, AI, diceThrow, true);
				ActivateCards(AI, Human, diceThrow, false);
				HumanAction();

				//AI turn
				diceThrow = ;
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
			Console.WriteLine("Voici vos cartes : ");
			foreach (Card c in Human.Cards)
			{
				Console.WriteLine(c);
			}
			Console.WriteLine($"Vous avez {Human.Money} pièces");

			List<Card> cardsAvailable = new List<Card> { };
			foreach (Card c in Deck.Cards)
			{
				if (c.CardsLeft > 0 && c.CardCost <= Human.Money)
				{
					cardsAvailable.Add(c);
				}
			}

			if (cardsAvailable.Count != 0)
			{
				Console.WriteLine("Voulez vous achetez une carte?\n o - oui\n n - non");
				string rep1 = Console.ReadLine().ToLower();
				if (rep1 == "o")
				{

					int i = 1;
					Console.WriteLine("Choisissez une carte");
					foreach (Card c in cardsAvailable)
					{
						Console.WriteLine($"{i} - {c}");
						i++;
					}

					int rep2 = int.Parse(Console.ReadLine()) - 1;

					DrawCard(Human, cardsAvailable[rep2], Deck);

				}
			}
			else
			{
				Console.WriteLine("Vous n'avez pas assez d'argent pour acheter une nouvelle carte");
			}

		}
		private void AIAction()
		{
			List<Card> cardsAvailable = new List<Card> { };
			foreach (Card c in Deck.Cards)
			{
				if (c.CardsLeft > 0 && c.CardCost <= AI.Money)
				{
					cardsAvailable.Add(c);
				}
			}
			if (cardsAvailable.Count > 0)
			{
				Card cardChoice = cardsAvailable[0];
				foreach (Card c in cardsAvailable)
				{
					if (cardChoice.ValReceive < c.ValReceive)
					{
						cardChoice = c;
					}
					else if (cardChoice.ValReceive == c.ValReceive)
					{
						if (cardChoice.ValTaken < c.ValTaken)
						{
							cardChoice = c;
						}
						else if (cardChoice.ValTaken == c.ValTaken)
						{
							if (cardChoice.CardCost > cardChoice.CardCost)
							{
								cardChoice = c;
							}
						}
					}
				}

				DrawCard(AI, cardChoice, Deck);
			}
		}

		private void DrawCard(Player p, Card chosenCard, Pile cardDeck)
		{
			p.Cards.Add(new Card(chosenCard.Name, 1));
			p.Money -= chosenCard.CardCost;
			foreach (Card c in cardDeck.Cards)
			{
				if (chosenCard.Name == c.Name)
				{
					c.CardsLeft--;
				}
			}
		}



		
	}
}

