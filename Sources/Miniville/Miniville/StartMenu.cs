using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniVille
{
	public class StartMenu
	{
		public StartMenu()
		{
			
		}
		public async void MenuOptions(PictureBox ScreenImage, Label WelcomeText,
			TextBox Name, Label AskName, Button SubmitName)
        {
			ScreenImage.Size = new Size(1350, 665);
			ScreenImage.Location = new Point(0, 0);
			//Bring ScreenMenu to the front
			ScreenImage.Visible = true;
			//Bring Text To the front
			WelcomeText.BringToFront();
			WelcomeText.Visible = true;
			//Wait a little bit

			await Task.Delay(100);
			//Name text box appear, ask for name and sumbit button appear
			Name.Visible = true;
			Name.BringToFront();
			AskName.Visible = true;
			AskName.BringToFront();
			SubmitName.Visible = true;
			SubmitName.BringToFront();

			//Make a function to disapear TXT bx, Name Label and Submit bttn (so it can be called from 
			//the click action

			//Make Buttons with difficulty appear as well as a method that chooses the difficulty 
			//based on the button pressed and disapears the difficulty options

			//Make a start button appear

			//Method to disapear all the "Start Menu" elements when button is pressed
        }

		public void SelectLenght(Button CourtButton, Label CourtDefinition,
			Button MidButton, Label MidDefinition,
			Button LongButton, Label LongDeff)
        {
			CourtButton.Visible = true;
			CourtButton.BringToFront();
			CourtDefinition.Visible = true;
			CourtDefinition.BringToFront();
			MidButton.Visible = true;
			MidButton.BringToFront();
			MidDefinition.Visible = true;
			MidDefinition.BringToFront();
			LongButton.Visible = true;
			LongButton.BringToFront();
			LongDeff.Visible = true;
			LongDeff.BringToFront();
		}

		public void SelectDifficulty(Label Mode, Button Expert, Button Normal)
        {
			Mode.Visible = true;
			Mode.BringToFront();
			Expert.Visible = true;
			Expert.BringToFront();
			Normal.Visible = true;
			Normal.BringToFront();
        }



		public void UnableEverything(TextBox Name, Label AskName, Button SubmitName,
			Button CourtButton, Label CourtDefinition,
			Button MidButton, Label MidDefinition,
			Button LongButton, Label LongDeff,
			Label Mode, Button Expert, Button Normal,
			Button StartButton)
		{
			Name.Visible = false;
			AskName.Visible = false;
			SubmitName.Visible = false;
			CourtButton.Visible = false;
			CourtDefinition.Visible = false;
			MidButton.Visible = false;
			MidDefinition.Visible = false;
			LongButton.Visible = false;
			LongDeff.Visible = false;
			Mode.Visible = false;
			Expert.Visible = false;
			Normal.Visible = false;
			StartButton.Visible = false;
		}
	}
}

