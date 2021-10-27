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
			Card cardInf = Utils.CardsStats[cardName];

			this.Name = cardInf.Name;
			this.CardColor = cardInf.CardColor;
			this.CardCost = cardInf.CardCost;

			this.NbsActivation = cardInf.NbsActivation;

			this.ValReceive = cardInf.ValReceive;
			this.ValTaken = cardInf.ValTaken;

			this.CardsLeft = cardsLeft;
		}
		public Card (Utils.CardName name, Utils.CardColor cardColor, List<int> nbsActivation, int cardCost, int valReceive, int valTaken)
		{
			this.Name = name;
			this.CardColor = cardColor;
			this.CardCost = cardCost;

			this.NbsActivation = nbsActivation;

			this.ValReceive = valReceive;
			this.ValTaken = valTaken;

		}

		public void Effect(Player receiver, Player giver)
		{
			if (Utils.CardsNeeds.ContainsKey(this.Name))
            {
				foreach(Card c in receiver.Cards)
                {
					if (Utils.CardsNeeds[this.Name] == c.Name)
					{
						receiver.Money += ValReceive;
						giver.Money += ValTaken;
						break;
					}
                }
            }
            else
			{
				receiver.Money += ValReceive;
				giver.Money += ValTaken;
			}
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

        public override string ToString()
		{
			string bank = "la banque", adversary = "votre adversaire";

			string activations = $"{this.NbsActivation[0]}";
			for (int act = 1; act < this.NbsActivation.Count; act++)
			{
				activations += $"ou { this.NbsActivation[act] } ";
			}
			return $"{this.Name} : {this.CardColor}  Vous recevez {this.ValReceive} pièces de {(this.ValReceive == 0 ? adversary : bank)} \n Cette carte s'active quand les dés tombent sur {activations} \n";
		}
    }
}
