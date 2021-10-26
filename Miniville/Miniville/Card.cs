using System;
using System.Collections.Generic;

namespace Miniville {
	public class Card
	{
		
		public Utils.CardName Name { get; private set; }
		public Utils.CardColor CardColor { get; private set; }
		public List<int> NbsActivation { get; private set; }
		public int CardCost { get; private set; }
		public int ValReceive { get; private set; }
		public int ValTaken { get; private set; }
		public int CardsLeft { get; set; }

		public Card(Utils.CardName cardName, int cardsLeft)
		{
			CardInfos cardInf = Utils.CardsStats[cardName];
			this.Name = cardInf.Name;
			this.CardColor = cardInf.CardColor;
			this.CardCost = cardInf.CardCost;

			this.NbsActivation = cardInf.NbsActivation;

			this.ValReceive = cardInf.ValReceive;
			this.ValTaken = cardInf.ValTaken;

			this.CardsLeft = cardsLeft;


		}

		public void Effect(Player receiver, Player giver)
		{
			receiver.Money += ValReceive;
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
