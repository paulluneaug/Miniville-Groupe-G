using System;

namespace MiniVille
{
	public class Dice
	{
		private Random random;
		public int NbFaces { get; private set; } // Number of faces of the dice
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
