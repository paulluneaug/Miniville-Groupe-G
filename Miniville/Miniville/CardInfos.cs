using System;
using System.Collections.Generic;

namespace Miniville
{
	public class CardInfos
	{
		public Utils.CardName Name { get; private set; }
		public Utils.CardColor CardColor { get; private set; }
		public List<int> NbsActivation { get; private set; }
		public int CardCost { get; private set; }
		public int ValReceive { get; private set; }
		public int ValTaken { get; private set; }

		public CardInfos(Utils.CardName name, Utils.CardColor cardColor, List<int> nbsActivation, int cardCost, int valReceive, int valTaken)
		{
			this.Name = name;
			this.CardColor = cardColor;
			this.CardCost = cardCost;

			this.NbsActivation = nbsActivation;

			this.ValReceive = valReceive;
			this.ValTaken = valTaken;

		}
	}
}
