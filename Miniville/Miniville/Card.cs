using System;
using System.Collections.Generic;

namespace Miniville {
	public class Card 
	{
		
		public Utils.CardName Name { get; private set; } // Name of the card
		public Utils.CardColor CardColor { get; private set; } // Color of the card, representing the moment of the turn when it can be activated
		public List<int> NbsActivation { get; private set; } // 
		public int CardCost { get; private set; } // Value needed to buy this card
		public int ValReceive { get; private set; } // Value recieved when the card is activated
		public int ValTaken { get; private set; } // Value stolen from the opponent when the card is activated
		public int CardsLeft { get; set; } // Number of the same type of card in the deck

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
			if (Utils.CardsNeeds.ContainsKey(this.Name)) //Check if the card needs an other one to be activated
            {
				foreach(Card c in receiver.Cards) //If so, searches in the player's deck for the card needed for activation
                {
					if (Utils.CardsNeeds[this.Name] == c.Name)
					{
						receiver.Money += this.ValReceive;
						giver.Money -= this.ValTaken;
						break;
					}
                }
            }
            else
			{
				receiver.Money += this.ValReceive;
				giver.Money -= this.ValTaken;
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
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		public override string ToString()
		{
			string bank = "la banque", adversary = "votre adversaire";

			string activations = $"{this.NbsActivation[0]}";
			for (int act = 1; act < this.NbsActivation.Count; act++)
			{
				activations += $"ou { this.NbsActivation[act] } ";
			}
			return $"{this.Name} : {this.CardColor}  Vous recevez {this.ValReceive} pièces de {(this.ValTaken == 0 ? bank : adversary)} \n Cette carte s'active quand les dés tombent sur {activations} \n";
		}
    }
}
