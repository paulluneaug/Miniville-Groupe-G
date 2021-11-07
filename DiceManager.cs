using System;
using System.Drawing;
using System.IO;

namespace MiniVille
{
	public class DiceManager
	{
		Image Ione = Image.FromFile(Directory.GetCurrentDirectory() + @"\Dices\dice_one.png");
		Image Itwo = Image.FromFile(Directory.GetCurrentDirectory() + @"\Dices\dice_two.png");
		Image Ithree = Image.FromFile(Directory.GetCurrentDirectory() + @"\Dices\dice_three.png");
		Image Ifour = Image.FromFile(Directory.GetCurrentDirectory() + @"\Dices\dice_four.png");
		Image Ifive = Image.FromFile(Directory.GetCurrentDirectory() + @"\Dices\dice_five.png");
		Image Isix = Image.FromFile(Directory.GetCurrentDirectory() + @"\Dices\dice_six.png");
		public struct Dice
		{
			public Image image;
		}

		public Image ChooseImage(int num)
        {
			Image temp = Ione;
			switch (num)
				{
				case 1:
					temp = Ione;
					break;
				case 2:
					temp = Itwo;
					break;
				case 3:
					temp = Ithree;
					break;
				case 4:
					temp = Ifour;
					break;
				case 5:
					temp = Ifive;
					break;
				case 6:
					temp = Isix;
					break;
			}
			return temp;

        }
	}
}
