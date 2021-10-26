using System;

namespace Miniville
{
	public class Game
	{
		private Player Human;// { get; private set; }
		private Player AI;// { get; private set; }

		private Pile Deck;// { get; private set; }

		private int nbTurns = 0;
		private int MoneyToWin;
		private bool ExpertMode;
		private bool playInConsole = true;
		public Game()
		{
			this.Human = new Player();
			this.AI = new Player();
			this.Deck = new Pile();
			if (playInConsole)
			{
				//Ask the player how long the game should last
				Console.WriteLine("Quelle longueur de partie choisissez vous ? ");
				Console.WriteLine("1 - Courte, il faut au moins 10 pièces pour gagner");
				Console.WriteLine("2 - Standard, il faut au moins 20 pièces pour gagner");
				Console.WriteLine("3 - Longue, il faut au moins 30 pièces pour gagner");
				while (true)
				{
					try
					{
						int inp = Int32.Parse(Console.ReadLine());
						if (1 <= inp && inp <= 3)
						{
							this.MoneyToWin = inp * 10;
							break;
						}
					}
					catch
					{
						Console.WriteLine("Veuillez entrer un nombre valide");
					}
				}
				Console.WriteLine("Voulez vous jouer en mode expert ? (O/N)");
				this.ExpertMode = Console.ReadLine().ToLower() == "o";

			}
		}

		private void ConsoleDisplay()
		{

		}

		private bool EndGame()
		{
			bool expertCond = !ExpertMode;
			foreach (Player p in new Player[2] { Human, AI })
			{

				//foreach(Utils.CardName cName in Utils.CardName)
				//{

				//}
			}
			return Human.Money >= this.MoneyToWin || AI.Money >= this.MoneyToWin;
		}
	}
}

