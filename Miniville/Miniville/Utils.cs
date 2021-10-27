using System;
using System.Collections.Generic;

namespace Miniville
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
			Restraurant,
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
							  0) //Value Taken
			},
			{Utils.CardName.Bakery,
				new Card(Utils.CardName.Bakery, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 2, 3 }, //Values Activation
							  3, //Cost
							  2, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.CofeeShop,
				new Card(Utils.CardName.CofeeShop, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 3 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  1) //Value Taken
			},
			{Utils.CardName.SuperMarket,
				new Card(Utils.CardName.SuperMarket, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 4 }, //Values Activation
							  3, //Cost
							  3, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Forest,
				new Card(Utils.CardName.Forest, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 5 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Stadium,
				new Card(Utils.CardName.Stadium, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 6 }, //Values Activation
							  6, //Cost
							  3, //Value Received
							  3) //Value Taken
			},
			{Utils.CardName.CheeseFactory,
				new Card(Utils.CardName.CheeseFactory, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 7 }, //Values Activation
							  5, //Cost
							  3, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.FurnitureFactory,
				new Card(Utils.CardName.FurnitureFactory, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 8 }, //Values Activation
							  6, //Cost
							  4, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Restraurant,
				new Card(Utils.CardName.Restraurant, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 9, 10 }, //Values Activation
							  4, //Cost
							  2, //Value Received
							  2) //Value Taken
			},
			{Utils.CardName.Grove,
				new Card(Utils.CardName.Grove, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 10 }, //Values Activation
							  3, //Cost
							  3, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.FruitMarket,
				new Card(Utils.CardName.FruitMarket, // Name / Type								  
							  Utils.CardColor.Green, // Color
							  new List<int>() { 11, 12 }, //Values Activation
							  6, //Cost
							  5, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.WheatField,
				new Card(Utils.CardName.WheatField, // Name / Type								  
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 1 }, //Values Activation
							  1, //Cost
							  1, //Value Received
							  0) //Value Taken
			}
		};
	}
}

