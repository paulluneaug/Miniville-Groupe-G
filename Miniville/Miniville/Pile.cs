using System;
using System.Collections.Generic;



namespace MiniVille
{
	public class Pile
	{
		public List<Card> Cards { get; private set; }
		public Pile()
		{
			this.Cards = new List<Card>();
		}
		public void BuildDeck()
		{
			foreach (Utils.CardName cName in Enum.GetValues(typeof(Utils.CardName)))
			{
				this.Cards.Add(new Card(cName, 6));
			}
		}
	}
}

