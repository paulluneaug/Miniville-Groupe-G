using System;
using System.Collections.Generic;

namespace Miniville
{
	public class Player
	{
		public int money;
		public List<Card> cartes = new List<Card> { };
		public Player()
		{
			money = 3;
		}
	}
}
