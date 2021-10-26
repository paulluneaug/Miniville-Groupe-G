using System;
using System.Collections.Generic;

namespace Miniville
{
	public class Player
	{
		public int Money;
		public List<Card> Cards = new List<Card>() { };
		public Player()
		{
			Money = 3;
		}
	}
}
