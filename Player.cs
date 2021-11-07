using System;
using System.Collections.Generic;

namespace MiniVille
{
	public class Player
	{
		public int Money;
		public string Name { get; private set; }
		public List<Card> Cards = new List<Card>() { };
		public void SetPlayer(string name)
		{
			Money = 3;
			this.Name = name;
		}
	}
}
