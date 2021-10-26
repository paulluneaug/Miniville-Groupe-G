using System;
using System.Collections.Generic;

namespace Miniville
{
	public class Utils
	{
		public enum CardName
		{
			WheatField,
			Farm,
			Bakery,
			CofeeShop,
			SuperMarket,
			Forest,
			Restraurant,
			Stadium
		}
		public enum CardColor
		{
			Red,
			Green,
			Blue
		}
		public readonly static Dictionary<Utils.CardName, CardInfos> CardsStats = new Dictionary<Utils.CardName, CardInfos>()
		{
			{Utils.CardName.WheatField,
				new CardInfos(Utils.CardName.WheatField, // Name / Type								  
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 1 }, //Values Activation
							  1, //Cost
							  1, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Farm,
				new CardInfos(Utils.CardName.Farm, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 1 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Bakery,
				new CardInfos(Utils.CardName.Bakery, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 1, 2 }, //Values Activation
							  1, //Cost
							  2, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.CofeeShop,
				new CardInfos(Utils.CardName.CofeeShop, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 3 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  1) //Value Taken
			},
			{Utils.CardName.SuperMarket,
				new CardInfos(Utils.CardName.SuperMarket, // Name / Type
							  Utils.CardColor.Green, // Color
							  new List<int>() { 4 }, //Values Activation
							  2, //Cost
							  3, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Forest,
				new CardInfos(Utils.CardName.Forest, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 5 }, //Values Activation
							  2, //Cost
							  1, //Value Received
							  0) //Value Taken
			},
			{Utils.CardName.Restraurant,
				new CardInfos(Utils.CardName.Restraurant, // Name / Type
							  Utils.CardColor.Red, // Color
							  new List<int>() { 5 }, //Values Activation
							  4, //Cost
							  2, //Value Received
							  2) //Value Taken
			},
			{Utils.CardName.Stadium,
				new CardInfos(Utils.CardName.Stadium, // Name / Type
							  Utils.CardColor.Blue, // Color
							  new List<int>() { 6 }, //Values Activation
							  6, //Cost
							  4, //Value Received
							  0) //Value Taken
			}
		};
	}
}

