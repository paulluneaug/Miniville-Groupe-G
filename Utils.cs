using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace MiniVille
{
	public class Utils
	{
		public enum CardName
		{
			Farm,
			Bakery,
			CofeeShop,
			SuperMarket,
			Forest,
			Stadium,
			CheeseFactory,
			FurnitureFactory,
			Restaurant,
			Grove,
			FruitMarket,
			WheatField
		}
		public enum CardColor
		{
			Red,
			Green,
			Blue
		}

		public static readonly Dictionary<Utils.CardName, Utils.CardName> CardsNeeds = new Dictionary<Utils.CardName, Utils.CardName>()
		{
			{Utils.CardName.CheeseFactory, Utils.CardName.Farm},
			{Utils.CardName.FurnitureFactory, Utils.CardName.Forest},
			{Utils.CardName.FruitMarket, Utils.CardName.Grove}
		};

		public static readonly Dictionary<Utils.CardName, Card> CardsStats = new Dictionary<Utils.CardName, Card>()
		{
			{Utils.CardName.Farm,
				new Card(Utils.CardName.Farm, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 2 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Farm.png")
							)
			},
			{Utils.CardName.Bakery,
				new Card(Utils.CardName.Bakery, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 2, 3 }, //Values Activation
							  3, //Cost
							  2, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Bakery.png")
							)
			},
			{Utils.CardName.CofeeShop,
				new Card(Utils.CardName.CofeeShop, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 3 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  1, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\CofeeShop.png")
							)
			},
			{Utils.CardName.SuperMarket,
				new Card(Utils.CardName.SuperMarket, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 4 }, //Values Activation
							  3, //Cost
							  3, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Supermarket.png")
							)
			},
			{Utils.CardName.Forest,
				new Card(Utils.CardName.Forest, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 5 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Forest.png")
							)
			},
			{Utils.CardName.Stadium,
				new Card(Utils.CardName.Stadium, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 6 }, //Values Activation
							  6, //Cost
							  3, //Value Received
							  3, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Stadium.png")
							)
			},
			{Utils.CardName.CheeseFactory,
				new Card(Utils.CardName.CheeseFactory, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 7 }, //Values Activation
							  5, //Cost
							  3, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\CheeseFactory.png")
							)
			},
			{Utils.CardName.FurnitureFactory,
				new Card(Utils.CardName.FurnitureFactory, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 8 }, //Values Activation
							  6, //Cost
							  4, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\FurnitureFactory.png")
							)
			},
			{Utils.CardName.Restaurant,
				new Card(Utils.CardName.Restaurant, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 9, 10 }, //Values Activation
							  4, //Cost
							  2, //Value Received
							  2, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Restaurant.png")
							)
			},
			{Utils.CardName.Grove,
				new Card(Utils.CardName.Grove, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 10 }, //Values Activation
							  3, //Cost
							  3, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Grove.png")
							)
			},
			{Utils.CardName.FruitMarket,
				new Card(Utils.CardName.FruitMarket, // Name / Type								  
							  Utils.CardColor.Green, // Color
							  new List<int>() { 11, 12 }, //Values Activation
							  6, //Cost
							  5, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\FruitMarket.png")
							)
			},
			{Utils.CardName.WheatField,
				new Card(Utils.CardName.WheatField, // Name / Type								  
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 12 }, //Values Activation
							  1, //Cost
							  1, //Value Received
							  0, //Value Taken
							  Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\WheatField.png")
							)
			}
		};

		public void DrawCard(Player p, Card chosenCard, Pile cardDeck)
		{
			foreach (Card c in p.Cards)
			{
				if (chosenCard.Name == c.Name)
				{
					c.CardsLeft++;
				}
			}
			p.Money -= chosenCard.CardCost;
			foreach (Card c in cardDeck.Cards)
			{
				if (chosenCard.Name == c.Name)
				{
					c.CardsLeft--;
				}
			}
		}

		public void InitializeDeck(Pile Deck)
        {
			Deck.Cards.Add(new Card(CardName.WheatField, 6));
			Deck.Cards.Add(new Card(CardName.Bakery, 6));
			Deck.Cards.Add(new Card(CardName.Farm, 6));
			Deck.Cards.Add(new Card(CardName.CofeeShop, 6));
			Deck.Cards.Add(new Card(CardName.SuperMarket, 6));
			Deck.Cards.Add(new Card(CardName.Forest, 6));
			Deck.Cards.Add(new Card(CardName.Stadium, 6));
			Deck.Cards.Add(new Card(CardName.CheeseFactory, 6));
			Deck.Cards.Add(new Card(CardName.FurnitureFactory, 6));
			Deck.Cards.Add(new Card(CardName.Restaurant, 6));
			Deck.Cards.Add(new Card(CardName.Grove, 6));
			Deck.Cards.Add(new Card(CardName.FruitMarket, 6));
		}

		public void InitializePlayerDeck(List<Card> Deck)
        {
			Deck.Add(new Card(CardName.WheatField, 1));
			Deck.Add(new Card(CardName.Bakery, 1));
			Deck.Add(new Card(CardName.Farm, 0));
			Deck.Add(new Card(CardName.CofeeShop, 0));
			Deck.Add(new Card(CardName.SuperMarket, 0));
			Deck.Add(new Card(CardName.Forest, 0));
			Deck.Add(new Card(CardName.Stadium, 0));
			Deck.Add(new Card(CardName.CheeseFactory, 0));
			Deck.Add(new Card(CardName.FurnitureFactory, 0));
			Deck.Add(new Card(CardName.Restaurant, 0));
			Deck.Add(new Card(CardName.Grove, 0));
			Deck.Add(new Card(CardName.FruitMarket, 0));
		}

		public void ActivateCards(Player Player0, Player otherPlayer, int diceThrow, bool isPlayer0Turn)
		{
			foreach (Card c in Player0.Cards)
			{
				if (isPlayer0Turn)
				{
					if (c.CardColor == Utils.CardColor.Green || c.CardColor == Utils.CardColor.Blue)
					{
						if (c.NbsActivation.Contains(diceThrow) && c.CardsLeft > 0)
						{
							c.Effect(Player0, otherPlayer);
						}
					}
				}
				else
				{
					if (c.CardColor == Utils.CardColor.Red || c.CardColor == Utils.CardColor.Blue)
					{
						if (c.NbsActivation.Contains(diceThrow) && c.CardsLeft > 0)
						{
							c.Effect(Player0, otherPlayer);
						}
					}
				}
			}
		}
		public void AIAction(Player AI, Pile Deck, bool ExpertMode)
		{
			Random rnd = new Random();

			

			List<Card> cardsAvailable = new List<Card> { };
			foreach (Card c in Deck.Cards)
			{
				if (c.CardsLeft > 0 && c.CardCost <= AI.Money)
				{
					cardsAvailable.Add(c);
				}
			}

			bool allCardsInAIDeck = ExpertMode;
			if (ExpertMode)
            {
				foreach (Card c in AI.Cards)
                {
					allCardsInAIDeck = allCardsInAIDeck && c.CardsLeft != 0;
                }
            }
			if (!allCardsInAIDeck) 
			{
				if ((cardsAvailable.Count > 0 || rnd.Next(0, 10) < 3))
				{
					List<int> cardsWeights = new List<int>();

					foreach (Card c in cardsAvailable)
					{
						int expertFact = (ExpertMode && !AI.Cards.Contains(c)) ? 10 : 1;

						cardsWeights.Add((1 + 2 * c.ValReceive + 3 * c.ValTaken - c.CardCost) * expertFact);
					}

					int chosenWeight = rnd.Next(0, cardsWeights.Sum() + 1);
					int weightSum = 0;
					for (int i = 0; i < cardsWeights.Count; i++)
					{
						weightSum += cardsWeights[i];
						if (weightSum >= chosenWeight)
						{
							DrawCard(AI, cardsAvailable[i], Deck);
							break;
						}
					}
				}
			}
			
		}
	}
}

