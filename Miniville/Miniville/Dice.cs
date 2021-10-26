using System;

namespace Miniville
{
	public class Dice
	{
		private Random random;
		public int NbFaces { get; private set; }
		public Dice()
		{
			random = new Random();
			this.NbFaces = 6;
		}

		public Dice(int nbFaces) : this ()
        {
			this.NbFaces = nbFaces;
		}

		public int DiceThrow()
		{
			return random.Next(1,NbFaces+1);
		}
	}
}
