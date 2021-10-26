using System;
using System.Collections.Generic;

namespace Miniville {
	public class Card
	{
		
		public Utils.CardName Name { get; private set; }
		public Utils.CardColor CardColor { get; private set; }
		public List<int> NbsActivation { get; private set; }
		public int CardCost { get; private set; }
		public int ValRecieve { get; private set; }
		public int ValTaken { get; private set; }
		public int CardsLeft { get; set; }

		public Card(Utils.CardName name, Utils.CardColor cardColor, List<int> nbsActivation, int cardCost, int valRecieve, int valTaken, int cardsLeft)
		{
			this.Name = name;
			this.CardColor = cardColor;
			this.CardCost = cardCost;

			this.NbsActivation = nbsActivation;

			this.ValRecieve = valRecieve;
			this.ValTaken = valTaken;

			this.CardsLeft = cardsLeft;


		}

		public void Effect(Player reciever, Player giver)
		{
			reciever.Money += ValRecieve;
			giver.Money += ValTaken;
		}

        public override bool Equals(object obj)
		{
			//Check for null and compare run-time types.
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Card c = (Card) obj;
				return (this.Name == c.Name);
			}
		}
    }
}
