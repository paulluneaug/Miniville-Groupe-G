using System;

namespace Miniville
{
	public class Dice
	{
		private Random random;
		public Dice()
		{
			random = new Random();
		}

		public int DiceThrow()
		{
			return random.Next();

		}
	}
}
