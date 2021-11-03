using System;
using System.Collections.Generic;
using System.Linq;

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

		private Random rnd = new Random();
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
				int diceThrow = Dice6.DiceThrow() + Dice6.DiceThrow();
				ActivateCards(Human, AI, diceThrow, true);
				ActivateCards(AI, Human, diceThrow, false);
				HumanAction();

				//AI turn
				diceThrow = Dice6.DiceThrow() + Dice6.DiceThrow();
				ActivateCards(AI, Human, diceThrow, true);
				ActivateCards(Human, AI, diceThrow, false);
				AIAction();

				Console.WriteLine("\n ================================== \n");


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
							if (Player0 == Human) { Console.WriteLine($"Votre {c.Name} s'est activé"); }
							else { Console.WriteLine($"La {c.Name} de votre adversaire s'est activé"); }
							
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
							if (Player0 == AI) { Console.WriteLine($"La {c.Name} de votre adversaire s'est activé"); }
							else {Console.WriteLine($"Votre {c.Name} s'est activé"); }
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
			Console.WriteLine("Voici les cartes de l'IA: ");
			foreach (Card c in AI.Cards)
			{
				Console.WriteLine(c);
			}
			List<Card> cardsAvailable = new List<Card> { };
			foreach (Card c in Deck.Cards)
			{
				if (c.CardsLeft > 0 && c.CardCost <= AI.Money)
				{
					cardsAvailable.Add(c);
				}
			}

			if (cardsAvailable.Count > 0 || rnd.Next(0,10) < 3)
            {
				List<int> cardsWeights = new List<int>();

				foreach (Card c in cardsAvailable)
				{
					int expertFact = 1;
					if (ExpertMode && !AI.Cards.Contains(c)) { expertFact = 5; }

					cardsWeights.Add((1 +  2 * c.ValReceive + 3 * c.ValTaken - c.CardCost) * expertFact);
				}

				int chosenWeight = rnd.Next(0, cardsWeights.Sum() + 1);
				int weightSum = 0;
				for (int i = 0; i < cardsWeights.Count; i++)
                {
					weightSum += cardsWeights[i];
					if (weightSum >= chosenWeight)
					{
						DrawCard(AI, cardsAvailable[i], Deck);
						Console.WriteLine($"L'IA a choisi d'achter un.une {cardsAvailable[i].Name}");
						break;
                    }
                }
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

		private void EndGame(bool HumanWins, bool AIWins)
        {
			if (HumanWins && AIWins)
            {
				Console.WriteLine("Égalité");
            }
			else if (AIWins)
            {
				Console.WriteLine("L'ordinateur a gagné");
            }
            else
			{
				Console.WriteLine("Vous avez gagné");
			}
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

