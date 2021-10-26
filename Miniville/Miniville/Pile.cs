using System;
using System.Collections.Generic;



namespace Miniville
{
	public class Pile
	{

		public List<Card> Cards { get; private set; }
		public Pile()
		{
			this.Cards = new List<Card>();

			BuildDeck(Cards);
		}
		private void BuildDeck(List<Card> p)
		{
			p.Add(new Card(Utils.CardName.WheatField, // Name / Type
								 Utils.CardColor.Blue, // Color
								 new List<int>() { 1 }, //Values Activation
								 1, //Cost
								 1, //Value Recieved
								 0, //Value Taken
								 6)); // Cards Left

			p.Add(new Card(Utils.CardName.Farm, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 1 }, //Values Activation
							  2, //Cost
							  1, //Value Recieved
							  0, //Value Taken
							  6)); // Cards Left

			p.Add(new Card(Utils.CardName.Bakery, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 1, 2 }, //Values Activation
							  1, //Cost
							  2, //Value Recieved
							  0, //Value Taken
							  6)); // Cards Left

			p.Add(new Card(Utils.CardName.CofeeShop, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 3 }, //Values Activation
							  2, //Cost
							  1, //Value Recieved
							  1, //Value Taken
							  6)); // Cards Left

			p.Add(new Card(Utils.CardName.SuperMarket, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 4 }, //Values Activation
							  2, //Cost
							  3, //Value Recieved
							  0, //Value Taken
							  6)); // Cards Left

			p.Add(new Card(Utils.CardName.Forest, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 5 }, //Values Activation
							  2, //Cost
							  1, //Value Recieved
							  0, //Value Taken
							  6)); // Cards Left

			p.Add(new Card(Utils.CardName.Restraurant, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 5 }, //Values Activation
							  4, //Cost
							  2, //Value Recieved
							  2, //Value Taken
							  6)); // Cards Left

			p.Add(new Card(Utils.CardName.Stadium, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 6 }, //Values Activation
							  6, //Cost
							  4, //Value Recieved
							  0, //Value Taken
							  6)); // Cards Left
		}
	}
}

