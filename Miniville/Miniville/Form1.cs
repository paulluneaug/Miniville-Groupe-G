using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MiniVille
{
    public partial class Form1 : Form
    {
        //Declare Components

        //Game Components
        private Player Human = new Player(); 
        private Player IntArt = new Player();
        private Pile MainDeck = new Pile();
        private StartMenu SM = new StartMenu();
        private Utils utils = new Utils();

        //In Game Variables
        private int MoneyToWin;
        private bool ExpertMode;
        private bool IsPlayerTurn;

        //Dice Components
        private Dice dice1 = new Dice(6);
        private Dice dice2 = new Dice(6);
        private DiceManager DManager = new DiceManager();

        //Position des Cartes
        Point carteGrandePos;
        Size carteGrandeTaille = new Size(233, 366);
        Point cartePetitePos;
        Size cartePetiteTaille = new Size(95, 150);
        PictureBox cardIsUp;
        enum PosCarte
        {
            Mouvement,
            Grande,
            Petite
        }
        PosCarte carte1State = PosCarte.Petite;
        //Fin Declaration Components

        public Form1()
        {
            //Screen Initialization
            this.Size = new Size(1360, 700);
            this.MaximumSize = new Size(1360, 700);
            this.MinimumSize = new Size(1360, 700);
            this.BackColor = Color.Black;
            
            //Initialize Components
            InitializeComponent();
            TextMessage.Text = ""; //DiceText
            TextMessage.ForeColor = Color.White;
            Debugger.ForeColor = Color.White;
            carteGrandePos = new Point((this.Width - carteGrandeTaille.Width) / 2,
                (this.Height - carteGrandeTaille.Height) / 2);

            # region Initialize Card Images
            Carte1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\WheatField.png");
            IACarte1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\WheatField.png");
            Carte2.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Bakery.png");
            IACarte2.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Bakery.png");
            Carte3.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Farm.png");
            IACarte3.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Farm.png");
            Carte4.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\CofeeShop.png");
            IACarte4.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\CofeeShop.png");
            Carte5.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Supermarket.png");
            IACarte5.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Supermarket.png");
            Carte6.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Forest.png");
            IACarte6.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Forest.png");
            Carte7.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Stadium.png");
            IACarte7.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Stadium.png");
            Carte8.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\CheeseFactory.png");
            IACarte8.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\CheeseFactory.png");
            Carte9.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\FurnitureFactory.png");
            IACarte9.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\FurnitureFactory.png");
            Carte10.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Restaurant.png");
            IACarte10.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Restaurant.png");
            Carte11.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Grove.png");
            IACarte11.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\Grove.png");
            Carte12.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\FruitMarket.png");
            IACarte12.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Cartes\FruitMarket.png");
            #endregion

            #region Rotation des cartes de l'IA
            IACarte1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte3.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte4.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte5.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte6.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte7.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte8.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte9.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte10.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte11.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            IACarte12.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            #endregion

            SM.UnableEverything(NameGiven, AskName, Submit, CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName, Expert, Normal, StartBttn);
            SM.MenuOptions(StartScreen, WelcomeText, NameGiven, AskName, Submit);
        }

        private async void Dice_Click(object sender, EventArgs e)
        {
            //Throw the dices
            int DiceThrow = 0;
            Dice.Visible = false;
            int i = 0;
            while (i < 20)
            {
                int dice1Throw = dice1.DiceThrow();
                int dice2Throw = dice2.DiceThrow();
                DiceThrow = dice1Throw + dice2Throw;
                PictureDice1.Image = DManager.ChooseImage(dice1Throw);
                PictureDice2.Image = DManager.ChooseImage(dice2Throw);
                TextMessage.Text = (DiceThrow).ToString();
                await Task.Delay(10);
                i++;
            }

            utils.ActivateCards(Human, IntArt, DiceThrow, IsPlayerTurn);
            utils.ActivateCards(IntArt, Human, DiceThrow, !IsPlayerTurn);

            UpdateCoins();
            if(IsPlayerTurn)
            {
                ChangePlusButtonVisibility(true);
                FinirTour.Visible = true;
            }
            IsPlayerTurn = !IsPlayerTurn;
        }

        private void MoveCard(PictureBox SelectedCard, PosCarte CardState, bool IACard)
        {
            //Move tha card to the middle of the board or back to its place
            bool canClick = true;
            int x = SelectedCard.Location.X;
            int y = SelectedCard.Location.Y;
            int Tx = SelectedCard.Size.Width;
            int Ty = SelectedCard.Size.Height;
            if (CardState == PosCarte.Petite && canClick)
            {
                SelectedCard.BringToFront();
                canClick = false;
                CardState = PosCarte.Mouvement;
                cartePetitePos = SelectedCard.Location;
                cardIsUp = SelectedCard;
                PictureDice1.Visible = false;
                PictureDice2.Visible = false;
                Dice.Visible = false;
                TextMessage.Visible = false;
                while (CardState != PosCarte.Grande)
                {
                    if (SelectedCard.Location != carteGrandePos)
                    {
                        if (y != carteGrandePos.Y)
                        {
                            y += (carteGrandePos.Y - y) / Math.Abs(carteGrandePos.Y - y);
                        }
                        else if (x != carteGrandePos.X)
                        {
                            x += (carteGrandePos.X - x) / Math.Abs(carteGrandePos.X - x);
                            if (IACard)
                            {
                                SelectedCard.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                IACard = false;
                            }
                        }
                        SelectedCard.Location = new Point(x, y);
                    }
                    else if (SelectedCard.Size != carteGrandeTaille)
                    {
                        if (Tx < carteGrandeTaille.Width)
                        {
                            Tx++;
                        }
                        if (Ty < carteGrandeTaille.Height)
                        {
                            Ty++;
                        }
                        SelectedCard.Size = new Size(Tx, Ty);
                    }
                    else if (SelectedCard.Location == carteGrandePos && SelectedCard.Size == carteGrandeTaille)
                    {
                        CardState = PosCarte.Grande;
                        carte1State = CardState;
                        break;
                    }
                    SelectedCard.Refresh();
                }

            }
            else if (CardState == PosCarte.Grande && canClick && SelectedCard == cardIsUp)
            {
                canClick = false;
                CardState = PosCarte.Mouvement;
                while (CardState != PosCarte.Petite)
                {
                    if (SelectedCard.Size != cartePetiteTaille)
                    {
                        if (Tx > cartePetiteTaille.Width)
                        {
                            Tx--;
                        }
                        if (Ty > cartePetiteTaille.Height)
                        {
                            Ty--;
                        }
                        SelectedCard.Size = new Size(Tx, Ty);
                    }
                    else if (SelectedCard.Location != cartePetitePos)
                    {
                        if (x != cartePetitePos.X)
                        {
                            x -= (x - cartePetitePos.X) / Math.Abs(x - cartePetitePos.X); ;
                            if (IACard)
                            {
                                SelectedCard.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                IACard = false;
                            }
                        }
                        else if (y != cartePetitePos.Y)
                        {
                            y -= (y - cartePetitePos.Y) / Math.Abs(y - cartePetitePos.Y); ;
                        }
                        SelectedCard.Location = new Point(x, y);
                    }
                    else if (SelectedCard.Location == cartePetitePos && SelectedCard.Size == cartePetiteTaille)
                    {
                        CardState = PosCarte.Petite;
                        carte1State = CardState;
                        PictureDice1.Visible = true;
                        PictureDice2.Visible = true;
                        Dice.Visible = true;
                        TextMessage.Visible = true;
                        break;
                    }
                    SelectedCard.Refresh();
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            if(NameGiven.Text != "")
            {
                string var;
                var = NameGiven.Text;
                Human.SetPlayer(var);
                SM.UnableEverything(NameGiven, AskName, Submit, 
                    CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName, 
                    Expert, Normal, StartBttn);
                AskName.Text = "Quelle longueur de partie choisissez vous ?";
                SM.SelectLenght(CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef);
            }
        }

        #region Game Lenght Buttons Clicks
        private void CourtButton_Click(object sender, EventArgs e)
        {
            MoneyToWin = 10;
            SM.UnableEverything(NameGiven, AskName, Submit,
    CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName,
    Expert, Normal, StartBttn);
            AskName.Text = "Voulez vous jouer en mode expert ?";
            SM.SelectDifficulty(AskName, Expert, Normal);
        }

        private void MidButton_Click(object sender, EventArgs e)
        {
            MoneyToWin = 20;
            SM.UnableEverything(NameGiven, AskName, Submit,
    CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName,
    Expert, Normal, StartBttn);
            AskName.Text = "Voulez vous jouer en mode expert ?";
            SM.SelectDifficulty(AskName, Expert, Normal);
        }

        private void LongButton_Click(object sender, EventArgs e)
        {
            MoneyToWin = 30;
            SM.UnableEverything(NameGiven, AskName, Submit,
    CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName,
    Expert, Normal, StartBttn);
            AskName.Text = "Voulez vous jouer en mode expert ?";
            SM.SelectDifficulty(AskName, Expert, Normal);
        }
        #endregion

        private void Normal_Click(object sender, EventArgs e)
        {
            //Select the normal difficulty
            ExpertMode = false;
            SM.UnableEverything(NameGiven, AskName, Submit,
    CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName,
    Expert, Normal, StartBttn);
            StartBttn.Visible = true;
            StartBttn.BringToFront();
        }
        private void Expert_Click(object sender, EventArgs e)
        {
            //Select the expert difficulty
            ExpertMode = true;
            SM.UnableEverything(NameGiven, AskName, Submit,
    CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName,
    Expert, Normal, StartBttn);
            StartBttn.Visible = true;
            StartBttn.BringToFront();
        }

        private void StartBttn_Click(object sender, EventArgs e)
        {

            //Initialize parameters for player and IA
            IntArt.SetPlayer("AI");
            PlayerName.Text = Human.Name;
            UpdateCoins();

            bool StartGone = false;
            Size Little = new Size(380, 100);
            Size CurrSize = StartScreen.Size;
            Point CurrLocation = StartScreen.Location;
            SM.UnableEverything(NameGiven, AskName, Submit, CourtButton, CourtDef, MidButton, MidDef, LongButton, LongDef, AskName, Expert, Normal, StartBttn);
            WelcomeText.Visible = false;
            while (!StartGone)
            {
                if(StartScreen.Size.Height <= Little.Height && StartScreen.Size.Width <= Little.Width)
                {
                    StartGone = true;
                    break;
                }
                CurrSize.Width -= 2;
                CurrSize.Height -= 2;
                CurrLocation.X += 1;
                CurrLocation.Y += 1;

                StartScreen.Location = CurrLocation;
                StartScreen.Size = CurrSize;
            }
            StartGone = false;
            while(!StartGone)
            {
                if(StartScreen.Location.X < -400)
                {
                    StartGone = true;
                    break;
                }
                CurrLocation.X -= 1;
                StartScreen.Location = CurrLocation;
            }

            utils.InitializeDeck(MainDeck);
            utils.InitializePlayerDeck(Human.Cards);
            utils.InitializePlayerDeck(IntArt.Cards);

            StartScreen.Visible = false;
            RefreshCardCount(true);
            RefreshCardCount(false);
            IsPlayerTurn = true;
        }

        private bool PlayerWins(Player p)
        {
            //Check if player p wins the game
            if (this.ExpertMode)
            {
                //If playing in expert mode, check if Player p has every card type in their deck
                foreach (Card c in p.Cards)
                {
                    if (c.CardsLeft == 0)
                    {
                        return false;
                    }
                }
            }
            // If that part is reached, it means that either the expert mode is not active, or that Player p has every type of card in their deck
            return p.Money >= this.MoneyToWin;
        }

        private void UpdateCoins()
        {
            //Displays the money of each player
            CoinsPlayer.Text = Human.Money.ToString();
            CoinsIA.Text = IntArt.Money.ToString();

            bool HumanWins = PlayerWins(Human), AIWins = PlayerWins(IntArt);

            if(HumanWins || AIWins)
            {
                EndGame(HumanWins, AIWins);
            }
        }
        private void EndGame(bool HumanWins, bool AIWins)
        {
            //Ends tha game and displays who won
            foreach (Control c in new Control[] { Carte1, Carte2, Carte3, Carte4, Carte5, Carte6, Carte7, Carte8, Carte9, Carte10, Carte11, Carte12, IACarte1,
                                                  IACarte2, IACarte3, IACarte4, IACarte5, IACarte6, IACarte7, IACarte8, IACarte9, IACarte10, IACarte11, IACarte12, Dice})
            {
                c.Enabled = false;
            }

            foreach (Control c in new Control[] { PlusCarte1, PlusCarte2, PlusCarte3, PlusCarte4, PlusCarte5, PlusCarte6,
                                                  PlusCarte7, PlusCarte8, PlusCarte9, PlusCarte10, PlusCarte11, PlusCarte12 })
            {
                c.Visible = false;
                c.Enabled = false;
                c.Dispose();
            }

            if (HumanWins && AIWins)
            {
                this.EndGameLab.Text = "Égalité";
            }
            else if (AIWins)
            {
                this.EndGameLab.Text =  "L'IA a gagné";
            }
            else
            {
                this.EndGameLab.Text = "Vous avez gagné";
            }
            this.EndGameLab.Visible = true;
        }

        public void RefreshCardCount(bool IsPlayer)
        {
            //Refresh the numbers below or above the cards
            if (IsPlayer)
            {
                QttCard1.Text = Human.Cards[0].CardsLeft.ToString();
                QttCard2.Text = Human.Cards[1].CardsLeft.ToString();
                QttCard3.Text = Human.Cards[2].CardsLeft.ToString();
                QttCard4.Text = Human.Cards[3].CardsLeft.ToString();
                QttCard5.Text = Human.Cards[4].CardsLeft.ToString();
                QttCard6.Text = Human.Cards[5].CardsLeft.ToString();
                QttCard7.Text = Human.Cards[6].CardsLeft.ToString();
                QttCard8.Text = Human.Cards[7].CardsLeft.ToString();
                QttCard9.Text = Human.Cards[8].CardsLeft.ToString();
                QttCard10.Text = Human.Cards[9].CardsLeft.ToString();
                QttCard11.Text = Human.Cards[10].CardsLeft.ToString();
                QttCard12.Text = Human.Cards[11].CardsLeft.ToString();
            }
            else
            {
                IAQttCard1.Text = IntArt.Cards[0].CardsLeft.ToString();
                IAQttCard2.Text = IntArt.Cards[1].CardsLeft.ToString();
                IAQttCard3.Text = IntArt.Cards[2].CardsLeft.ToString();
                IAQttCard4.Text = IntArt.Cards[3].CardsLeft.ToString();
                IAQttCard5.Text = IntArt.Cards[4].CardsLeft.ToString();
                IAQttCard6.Text = IntArt.Cards[5].CardsLeft.ToString();
                IAQttCard7.Text = IntArt.Cards[6].CardsLeft.ToString();
                IAQttCard8.Text = IntArt.Cards[7].CardsLeft.ToString();
                IAQttCard9.Text = IntArt.Cards[8].CardsLeft.ToString();
                IAQttCard10.Text = IntArt.Cards[9].CardsLeft.ToString();
                IAQttCard11.Text = IntArt.Cards[10].CardsLeft.ToString();
                IAQttCard12.Text = IntArt.Cards[11].CardsLeft.ToString();
            }
        }

        private void ChangePlusButtonVisibility(bool IsActive)
        {
            //Checks if there are cards available and changes their visibility
            if(MainDeck.Cards[0].CardsLeft > 0 && Human.Money >= MainDeck.Cards[0].CardCost)
            {
                PlusCarte1.Visible = IsActive;
            }
            if (MainDeck.Cards[1].CardsLeft > 0 && Human.Money >= MainDeck.Cards[1].CardCost)
            {
                PlusCarte2.Visible = IsActive;
            }
            if (MainDeck.Cards[2].CardsLeft > 0 && Human.Money >= MainDeck.Cards[2].CardCost)
            {
                PlusCarte3.Visible = IsActive;
            }
            if (MainDeck.Cards[3].CardsLeft > 0 && Human.Money >= MainDeck.Cards[3].CardCost)
            {
                PlusCarte4.Visible = IsActive;
            }
            if (MainDeck.Cards[4].CardsLeft > 0 && Human.Money >= MainDeck.Cards[4].CardCost)
            {
                PlusCarte5.Visible = IsActive;
            }
            if (MainDeck.Cards[5].CardsLeft > 0 && Human.Money >= MainDeck.Cards[5].CardCost)
            {
                PlusCarte6.Visible = IsActive;
            }
            if (MainDeck.Cards[6].CardsLeft > 0 && Human.Money >= MainDeck.Cards[6].CardCost)
            {
                PlusCarte7.Visible = IsActive;
            }
            if (MainDeck.Cards[7].CardsLeft > 0 && Human.Money >= MainDeck.Cards[7].CardCost)
            {
                PlusCarte8.Visible = IsActive;
            }
            if (MainDeck.Cards[8].CardsLeft > 0 && Human.Money >= MainDeck.Cards[8].CardCost)
            {
                PlusCarte9.Visible = IsActive;
            }
            if (MainDeck.Cards[9].CardsLeft > 0 && Human.Money >= MainDeck.Cards[9].CardCost)
            {
                PlusCarte10.Visible = IsActive;
            }
            if (MainDeck.Cards[10].CardsLeft > 0 && Human.Money >= MainDeck.Cards[10].CardCost)
            {
                PlusCarte11.Visible = IsActive;
            }
            if (MainDeck.Cards[11].CardsLeft > 0 && Human.Money >= MainDeck.Cards[11].CardCost)
            {
                PlusCarte12.Visible = IsActive;
            }
        }

        #region Cards Clicks
        private void Carte1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1");
            MoveCard(Carte1, carte1State, false);
        }

        private void Carte2_Click(object sender, EventArgs e)
        {
            MoveCard(Carte2, carte1State, false);
        }
        private void Carte3_Click(object sender, EventArgs e)
        {
            MoveCard(Carte3, carte1State, false);
        }

        private void Carte4_Click(object sender, EventArgs e)
        {
            MoveCard(Carte4, carte1State, false);
        }
        private void Carte5_Click(object sender, EventArgs e)
        {
            MoveCard(Carte5, carte1State, false);
        }

        private void Carte6_Click(object sender, EventArgs e)
        {
            MoveCard(Carte6, carte1State, false);
        }
        private void Carte7_Click(object sender, EventArgs e)
        {
            MoveCard(Carte7, carte1State, false);
        }

        private void Carte8_Click(object sender, EventArgs e)
        {
            MoveCard(Carte8, carte1State, false);
        }
        private void Carte9_Click(object sender, EventArgs e)
        {
            MoveCard(Carte9, carte1State, false);
        }

        private void Carte10_Click(object sender, EventArgs e)
        {
            MoveCard(Carte10, carte1State, false);
        }
        private void Carte11_Click(object sender, EventArgs e)
        {
            MoveCard(Carte11, carte1State, false);
        }

        private void Carte12_Click(object sender, EventArgs e)
        {
            MoveCard(Carte12, carte1State, false);
        }

        private void IACarte1_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte1, carte1State, true);
        }
        private void IACarte2_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte2, carte1State, true);
        }
        private void IACarte3_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte3, carte1State, true);
        }
        private void IACarte4_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte4, carte1State, true);
        }
        private void IACarte5_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte5, carte1State, true);
        }
        private void IACarte6_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte6, carte1State, true);
        }
        private void IACarte7_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte7, carte1State, true);
        }
        private void IACarte8_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte8, carte1State, true);
        }
        private void IACarte9_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte9, carte1State, true);
        }
        private void IACarte10_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte10, carte1State, true);
        }
        private void IACarte11_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte11, carte1State, true);
        }
        private void IACarte12_Click(object sender, EventArgs e)
        {
            MoveCard(IACarte12, carte1State, true);
        }

        #endregion

        #region Plus Cards Clicks
        private void PlusCarte1_Click(object sender, EventArgs e)
        {
            if(carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[0], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte2_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[1], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte3_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[2], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte4_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[3], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte5_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[4], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte6_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[5], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte7_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[6], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte8_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[7], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte9_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[8], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte10_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[9], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte11_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[10], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        private void PlusCarte12_Click(object sender, EventArgs e)
        {
            if (carte1State == PosCarte.Grande)
            {
                MoveCard(cardIsUp, carte1State, false);
            }
            ChangePlusButtonVisibility(false);
            utils.DrawCard(Human, MainDeck.Cards[11], MainDeck);
            UpdateCoins();
            RefreshCardCount(true);
            FinirTour.Visible = true;
        }
        #endregion

        private async void FinirTour_Click(object sender, EventArgs e)
        {
            ChangePlusButtonVisibility(false);
            Dice_Click(sender, e);
            FinirTour.Visible = false;
            await Task.Delay(600);
            utils.AIAction(IntArt, MainDeck, ExpertMode);
            RefreshCardCount(false);
            Dice.Visible = true;
        }
    }
}