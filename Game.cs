using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using game_gui.POCSO;
using game_gui.Controllers;

namespace game_gui
{
    public partial class Game : Form
    {
        private MancalaBoard GameBoard;
        private string P1Type = "";
        private string P2Type = "";
        private string P1Path = "";
        private string P2Path = "";
        private int Turn = 0;
        private int TimeoutInMilliseconds = 15000;
        bool GameInProgress = false;

        // CTOR
        public Game()
        {
            InitializeComponent();
            ResetBoard();
        }

        // PLAYER 1 Selection ----------------------------------------------
        private void Player1Cup1_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human") && GameBoard.GameBoard[0, 0] > 0)
            {
                Player1ButtonSelect(1, 1);
            }
            else
            {
                InvalidSelection(1, 1);
            }
        }

        private void Player1Cup2_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human") && GameBoard.GameBoard[0, 1] > 0)
            {
                Player1ButtonSelect(1, 2);
            }
            else
            {
                InvalidSelection(1, 2);
            }
        }

        private void Player1Cup3_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human") && GameBoard.GameBoard[0, 2] > 0)
            {
                Player1ButtonSelect(1, 3);
            }
            else
            {
                InvalidSelection(1, 3);
            }
        }

        private void Player1Cup4_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human") && GameBoard.GameBoard[0, 3] > 0)
            {
                Player1ButtonSelect(1, 4);
            }
            else
            {
                InvalidSelection(1, 4);
            }
        }

        private void Player1Cup5_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human") && GameBoard.GameBoard[0, 4] > 0)
            {
                Player1ButtonSelect(1, 5);
            }
            else
            {
                InvalidSelection(1, 5);
            }
        }

        private void Player1Cup6_Click(object sender, EventArgs e)
        {
            if(Turn == 1 && P1Type.Equals("Human") && GameBoard.GameBoard[0, 5] > 0)
            {
                Player1ButtonSelect(1, 6);
            }
            else
            {
                InvalidSelection(1, 6);
            }
        }

        private void Player1ButtonSelect(int playerIndex, int cupIndex)
        {
            bool canGoAgain = UpdateBoard(playerIndex, cupIndex);
            bool P1SideEmpty = GameBoard.PlayerHasWon();
            if (!canGoAgain && !P1SideEmpty && P2Type.Equals("Human"))
            {
                Console.WriteLine("\tChanging Turns! It is now Player 2's turn");
                Turn = 2;
                turnIndicator.BackColor = Color.YellowGreen; 
            }
            else if (!canGoAgain && !P1SideEmpty && P2Type.Equals("Computer"))
            {
                Console.WriteLine("\tChanging Turns! It is now Player 2's turn");
                Turn = 0;
                turnIndicator.BackColor = Color.YellowGreen;
                bool compSideEmpty = false, compCanGoAgain;
                do
                {
                    Task.Delay(1500);
                    string move = AIController.GetMove(GameBoard, 2, P2Path, TimeoutInMilliseconds);
                    if (move.Equals("timeout"))
                    {
                        Console.WriteLine("\tAI has exceeded time limit. Skipping turn...");
                        break;
                    }
                    var lines = move.Split(',');
                    int playerNum = 0;
                    int cupNum = 0;
                    try
                    {
                        playerNum = Int32.Parse(lines[0]);
                        cupNum = Int32.Parse(lines[1]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\tERROR: Error Parsing move from executatable. Exiting Application....");
                        Environment.Exit(1);
                    }
                    compCanGoAgain = UpdateBoard(playerNum, cupNum);
                    compSideEmpty = GameBoard.PlayerHasWon();
                    if (compCanGoAgain)
                    {
                        Console.WriteLine("\tPlayer gets another turn!");
                    }
                } while (!compSideEmpty && compCanGoAgain);

                if (compSideEmpty)
                {
                    GameOver();
                }
                else
                {
                    Console.WriteLine("\tChanging Turns! It is now Player 1's turn");
                    Turn = 1;
                    turnIndicator.BackColor = Color.MediumTurquoise;
                }
            }
            else if (P1SideEmpty)
            {
                GameOver();
            }
            // NEW - only give the go again notification if the player's side isn't empty
            if (canGoAgain && !P1SideEmpty)
            {
                Console.WriteLine("\tPlayer gets another turn!");
                string message = "You get another turn!";
                string caption = "Additional Turn";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // PLAYER 2 Selection ----------------------------------------------
        private void Player2Cup1_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human") && GameBoard.GameBoard[1, 0] > 0)
            {
                Player2ButtonSelect(2, 1);
            }
            else
            {
                InvalidSelection(2, 1);
            }
        }

        private void Player2Cup2_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human") && GameBoard.GameBoard[1, 1] > 0)
            {
                Player2ButtonSelect(2, 2);
            }
            else
            {
                InvalidSelection(2, 2);
            }
        }

        private void Player2Cup3_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human") && GameBoard.GameBoard[1, 2] > 0)
            {
                Player2ButtonSelect(2, 3);
            }
            else
            {
                InvalidSelection(2, 3);
            }
        }

        private void Player2Cup4_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human") && GameBoard.GameBoard[1, 3] > 0)
            {
                Player2ButtonSelect(2, 4);
            }
            else
            {
                InvalidSelection(2, 4);
            }
        }

        private void Player2Cup5_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human") && GameBoard.GameBoard[1, 4] > 0)
            {
                Player2ButtonSelect(2, 5);
            }
            else
            {
                InvalidSelection(2, 5);
            }
        }

        private void Player2Cup6_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human") && GameBoard.GameBoard[1, 5] > 0)
            {
                Player2ButtonSelect(2, 6);
            }
            else
            {
                InvalidSelection(2, 6);
            }
        }

        private void Player2ButtonSelect(int playerIndex, int cupIndex)
        {
            bool canGoAgain = UpdateBoard(playerIndex, cupIndex);
            bool P2SideEmpty = GameBoard.PlayerHasWon();
            if (!canGoAgain && !P2SideEmpty && P1Type.Equals("Human"))
            {
                Console.WriteLine("\tChanging Turns! It is now Player 1's turn");
                Turn = 1; 
                turnIndicator.BackColor = Color.MediumTurquoise;
            }
            else if (!canGoAgain && !P2SideEmpty && P1Type.Equals("Computer"))
            {
                Console.WriteLine("\tChanging Turns! It is now Player 1's turn");
                Turn = 0;
                turnIndicator.BackColor = Color.MediumTurquoise;
                bool compSideEmpty = false, compCanGoAgain;
                do
                {
                    Task.Delay(1500);
                    string move = AIController.GetMove(GameBoard, 1, P1Path, TimeoutInMilliseconds);
                    if (move.Equals("timeout"))
                    {
                        Console.WriteLine("\tAI has exceeded time limit. Skipping turn...");
                        break;
                    }
                    var lines = move.Split(',');
                    int playerNum = 0;
                    int cupNum = 0;
                    try
                    {
                        playerNum = Int32.Parse(lines[0]);
                        cupNum = Int32.Parse(lines[1]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\tERROR: Error Parsing move from executatable. Exiting Application....");
                        Environment.Exit(1);
                    }
                    compCanGoAgain = UpdateBoard(playerNum, cupNum);
                    compSideEmpty = GameBoard.PlayerHasWon();
                    if (compCanGoAgain)
                    {
                        Console.WriteLine("\tPlayer gets another turn!");
                    }
                } while (!compSideEmpty && compCanGoAgain);

                if (compSideEmpty)
                {
                    GameOver();
                }
                else
                {
                    Console.WriteLine("\tChanging Turns! It is now Player 2's turn");
                    Turn = 2;
                    turnIndicator.BackColor = Color.YellowGreen;
                }
            }
            else if (P2SideEmpty)
            {
                GameOver();
            }
            // NEW - only give the go again notification if the player's side isn't empty
            if (canGoAgain && !P2SideEmpty)
            {
                Console.WriteLine("\tPlayer gets another turn!");
                string message = "You get another turn!";
                string caption = "Additional Turn";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Set Human / Computer ----------------------------------------------
        private void P1HumanButton_Click(object sender, EventArgs e)
        {
            p1HumanButton.BackColor = Color.LightGreen;
            p1ComputerButton.BackColor = Color.White;
            P1Type = "Human";
            p1ComputerPathLabel.Text = "";
            Console.WriteLine("Player 1 set as: Human");
        }

        private void P1ComputerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Executables (*.exe) | *.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                P1Path = openFileDialog.FileName;
                p1ComputerPathLabel.Text = P1Path;
                p1HumanButton.BackColor = Color.White;
                p1ComputerButton.BackColor = Color.LightGreen;
                P1Type = "Computer";
                Console.WriteLine("Player 1 set as AI: " + P1Path);
            }
        }

        private void p2HumanButton_Click(object sender, EventArgs e)
        {
            p2HumanButton.BackColor = Color.LightGreen;
            p2ComputerButton.BackColor = Color.White;
            P2Type = "Human";
            p2ComputerPathLabel.Text = "";
            Console.WriteLine("Player 2 set as: Human");
        }

        private void p2ComputerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Executables (*.exe) | *.exe";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                P2Path = openFileDialog.FileName;
                p2ComputerPathLabel.Text = P2Path;
                p2HumanButton.BackColor = Color.White;
                p2ComputerButton.BackColor = Color.LightGreen;
                P2Type = "Computer";
                Console.WriteLine("Player 2 set as AI: " + P2Path);
            }
        }

        // General Game Control ----------------------------------------------
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (GameInProgress)
            {
                string message = "A game is already in progress. Reset the game if you would like to start a new one.";
                string caption = "Game Already in Progress";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("----------------------------- GAME STARTED! -----------------------------");
            if(P1Type.Equals("Computer") && P2Type.Equals("Computer"))
            {
                if(!P1Path.Contains(".exe") || !P2Path.Contains(".exe"))
                {
                    SelectExeError();
                    return;
                }
                GameInProgress = true;
                startGameButton.BackColor = Color.LightGreen;
                Turn = 0;
                bool anAiHasWon;
                do
                {
                    Console.WriteLine("\tIt is now Player 1's turn");
                    anAiHasWon = AI1Turn();
                    Task.Delay(400);
                    if (!anAiHasWon)
                    {
                        Console.WriteLine("\tIt is now Player 2's turn");
                        anAiHasWon = AI2Turn();
                    }
                    Task.Delay(400);
                } while (!anAiHasWon);
            }
            else if (P1Type.Equals("Computer") && P2Type.Equals("Human"))
            {
                if (!P1Path.Contains(".exe"))
                {
                    SelectExeError();
                    return;
                }
                GameInProgress = true;
                startGameButton.BackColor = Color.LightGreen;
                Console.WriteLine("\tIt is now Player 1's turn");
                Turn = 0;
                turnIndicator.BackColor = Color.MediumTurquoise;
                bool compCanGoAgain;
                do
                {
                    Task.Delay(1500);
                    string move = AIController.GetMove(GameBoard, 1, P1Path, TimeoutInMilliseconds);
                    if (move.Equals("timeout"))
                    {
                        Console.WriteLine("\tAI has exceeded time limit. Skipping turn...");
                        break;
                    }
                    var lines = move.Split(',');
                    int playerNum = 0;
                    int cupNum = 0;
                    try
                    {
                        playerNum = Int32.Parse(lines[0]);
                        cupNum = Int32.Parse(lines[1]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\tERROR: Error Parsing move from executatable. Exiting Application....");
                        Environment.Exit(1);
                    }
                    compCanGoAgain = UpdateBoard(playerNum, cupNum);
                    if (compCanGoAgain)
                    {
                        Console.WriteLine("\tPlayer gets another turn!");
                    }
                } while (compCanGoAgain);

                Console.WriteLine("\tChanging Turns! It is now Player 2's turn");
                Turn = 2;
                turnIndicator.BackColor = Color.YellowGreen;
            }
            else if (P1Type.Equals("Human") && P2Type.Equals("Computer"))
            {
                if (!P2Path.Contains(".exe"))
                {
                    SelectExeError();
                    return;
                }
                GameInProgress = true;
                startGameButton.BackColor = Color.LightGreen;
                Console.WriteLine("\tIt is now Player 1's turn");
                Turn = 1;
            }
            else
            {
                GameInProgress = true;
                startGameButton.BackColor = Color.LightGreen;
                Console.WriteLine("\tIt is now Player 1's turn");
                Turn = 1;
            }
        }

        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Resetting game board...");
            ResetBoard();
        }


        // Time Limit Control ----------------------------------------------
        private void TimeLimitSelect5_Click(object sender, EventArgs e)
        {
            DeselectTimings();
            TimeoutInMilliseconds = 5000;
            timeLimitSelect5.Checked = true;
            Console.WriteLine("5s time limit for AI set");
        }

        private void TimeLimitSelect10_Click(object sender, EventArgs e)
        {
            DeselectTimings();
            TimeoutInMilliseconds = 10000;
            timeLimitSelect10.Checked = true;
            Console.WriteLine("10s time limit for AI set");
        }

        private void TimeLimitSelect15_Click(object sender, EventArgs e)
        {
            DeselectTimings();
            TimeoutInMilliseconds = 15000;
            timeLimitSelect15.Checked = true;
            Console.WriteLine("15s time limit for AI set");
        }

        private void TimeLimitSelect20_Click(object sender, EventArgs e)
        {
            DeselectTimings();
            TimeoutInMilliseconds = 20000;
            timeLimitSelect20.Checked = true;
            Console.WriteLine("20s time limit for AI set");
        }

        private void TimeLimitSelectNone_Click(object sender, EventArgs e)
        {
            DeselectTimings();
            TimeoutInMilliseconds = -1;
            timeLimitSelectNone.Checked = true;
            Console.WriteLine("Unlimited time limit for AI set");
        }

        private void ResetBoard()
        {
            // Reset board
            GameBoard = new MancalaBoard();

            // Reset player types
            P1Type = "Human";
            P2Type = "Human";

            // Reset GUI
            UpdateGUI();

            Turn = 0;
            GameInProgress = false;
            startGameButton.BackColor = Color.White;
            turnIndicator.BackColor = Color.MediumTurquoise;

            p1HumanButton.BackColor = Color.LightGreen;
            p1ComputerButton.BackColor = Color.White;
            p1ComputerPathLabel.Text = "";
            p2HumanButton.BackColor = Color.LightGreen;
            p2ComputerButton.BackColor = Color.White;
            p2ComputerPathLabel.Text = "";

            Console.WriteLine("Fresh game board initialized!");
            Console.WriteLine("Player 1 set as: Human");
            Console.WriteLine("Player 2 set as: Human");
        }

        private bool UpdateBoard(int player, int cupNum)
        {
            Console.WriteLine("\t\tPlayer has chosen cup: " + cupNum);
            Console.WriteLine("\tUpdating board...");
            bool result = GameBoard.UpdateBoard(player, cupNum);
            UpdateGUI();

            return result;
        }

        private void UpdateGUI()
        {
            Console.WriteLine("Updating GUI values...");
            player1Cup1.BackgroundImage = GetImageFile(1, 1);
            player1Cup2.BackgroundImage = GetImageFile(1, 2);
            player1Cup3.BackgroundImage = GetImageFile(1, 3);
            player1Cup4.BackgroundImage = GetImageFile(1, 4);
            player1Cup5.BackgroundImage = GetImageFile(1, 5);
            player1Cup6.BackgroundImage = GetImageFile(1, 6);
            player1Mancala.BackgroundImage = GetImageFile(1, 7);
            player2Cup1.BackgroundImage = GetImageFile(2, 1);
            player2Cup2.BackgroundImage = GetImageFile(2, 2);
            player2Cup3.BackgroundImage = GetImageFile(2, 3);
            player2Cup4.BackgroundImage = GetImageFile(2, 4);
            player2Cup5.BackgroundImage = GetImageFile(2, 5);
            player2Cup6.BackgroundImage = GetImageFile(2, 6);
            player2Mancala.BackgroundImage = GetImageFile(2, 7);

            player1Cup1Count.Text = GameBoard.GameBoard[0, 0].ToString();
            player1Cup2Count.Text = GameBoard.GameBoard[0, 1].ToString();
            player1Cup3Count.Text = GameBoard.GameBoard[0, 2].ToString();
            player1Cup4Count.Text = GameBoard.GameBoard[0, 3].ToString();
            player1Cup5Count.Text = GameBoard.GameBoard[0, 4].ToString();
            player1Cup6Count.Text = GameBoard.GameBoard[0, 5].ToString();
            player1MancalaCount.Text = GameBoard.P1Mancala.ToString();

            player2Cup1Count.Text = GameBoard.GameBoard[1, 0].ToString();
            player2Cup2Count.Text = GameBoard.GameBoard[1, 1].ToString();
            player2Cup3Count.Text = GameBoard.GameBoard[1, 2].ToString();
            player2Cup4Count.Text = GameBoard.GameBoard[1, 3].ToString();
            player2Cup5Count.Text = GameBoard.GameBoard[1, 4].ToString();
            player2Cup6Count.Text = GameBoard.GameBoard[1, 5].ToString();
            player2MancalaCount.Text = GameBoard.P2Mancala.ToString();
        }

        private Image GetImageFile(int player, int cup)
        {
            if(cup > 6)
            {
                int numItems = player == 1 ? GameBoard.P1Mancala : GameBoard.P2Mancala;
                switch (numItems)
                {
                    case 0:
                        return Properties.Resources.e0;
                    case 1:
                        return Properties.Resources.e1;
                    case 2:
                        return Properties.Resources.e2;
                    case 3:
                        return Properties.Resources.e3;
                    case 4:
                        return Properties.Resources.e4;
                    case 5:
                        return Properties.Resources.e5;
                    default:
                        return Properties.Resources.e6;
                }
            }
            else
            {
                int numItems = GameBoard.GameBoard[player - 1, cup - 1];
                switch (numItems)
                {
                    case 0:
                        return Properties.Resources.p0;
                    case 1:
                        return Properties.Resources.p1;
                    case 2:
                        return Properties.Resources.p2;
                    case 3:
                        return Properties.Resources.p3;
                    case 4:
                        return Properties.Resources.p4;
                    case 5:
                        return Properties.Resources.p5;
                    default:
                        return Properties.Resources.p6;
                }
            }
        }

        private void DeselectTimings()
        {
            timeLimitSelect5.Checked = false;
            timeLimitSelect10.Checked = false;
            timeLimitSelect15.Checked = false;
            timeLimitSelect20.Checked = false;
            timeLimitSelectNone.Checked = false;
        }

        private void InvalidSelection(int player, int cup)
        {
            string message = "Invalid Selection! Please click your own boxes on your turn.";
            string caption = "ERROR";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine("\tInvalid selection. User tried to select cup: " + player + ", " + cup);
        }

        private void SelectExeError()
        {
            string message = "Please make sure an exe is selected for all computer players";
            string caption = "ERROR";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine("ERROR: Game cannot play without an AI selected");
        }

        private bool AI1Turn()
        {
            Console.WriteLine("\tChanging Turns! It is now Player 1's turn");
            turnIndicator.BackColor = Color.MediumTurquoise;
            bool compSideEmpty = false, compCanGoAgain;
            do
            {
                Task.Delay(150);
                string move = AIController.GetMove(GameBoard, 1, P1Path, TimeoutInMilliseconds);
                if(move.Equals("timeout"))
                {
                    Console.WriteLine("\tAI has exceeded time limit. Skipping turn...");
                    break;
                }
                var lines = move.Split(',');
                int playerNum = 0;
                int cupNum = 0;
                try
                {
                    playerNum = Int32.Parse(lines[0]);
                    cupNum = Int32.Parse(lines[1]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tERROR: Error Parsing move from executatable. Exiting Application....");
                    Environment.Exit(1);
                }
                compCanGoAgain = UpdateBoard(playerNum, cupNum);
                compSideEmpty = GameBoard.PlayerHasWon();
                if (compCanGoAgain)
                {
                    Console.WriteLine("\tPlayer gets another turn!");
                }
            } while (!compSideEmpty && compCanGoAgain);

            if (compSideEmpty)
            {
                GameOver();
                return true;
            }
            else
            {
                Console.WriteLine("\tChanging Turns! It is now Player 2's turn");
                turnIndicator.BackColor = Color.YellowGreen;
                return false;
            }
        }

        private bool AI2Turn()
        {
            Console.WriteLine("\tChanging Turns! It is now Player 2's turn");
            turnIndicator.BackColor = Color.YellowGreen;
            bool compSideEmpty = false, compCanGoAgain;
            do
            {
                Task.Delay(150);
                string move = AIController.GetMove(GameBoard, 2, P2Path, TimeoutInMilliseconds);
                if (move.Equals("timeout"))
                {
                    Console.WriteLine("\tAI has exceeded time limit. Skipping turn...");
                    break;
                }
                var lines = move.Split(',');
                int playerNum = 0;
                int cupNum = 0;
                try
                {
                    playerNum = Int32.Parse(lines[0]);
                    cupNum = Int32.Parse(lines[1]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\tERROR: Error Parsing move from executatable. Exiting Application....");
                    Environment.Exit(1);
                }
                compCanGoAgain = UpdateBoard(playerNum, cupNum);
                compSideEmpty = GameBoard.PlayerHasWon();
                if (compCanGoAgain)
                {
                    Console.WriteLine("\tPlayer gets another turn!");
                }
            } while (!compSideEmpty && compCanGoAgain);

            if (compSideEmpty)
            {
                GameOver();
                return true;
            }
            else
            {
                Console.WriteLine("\tChanging Turns! It is now Player 1's turn");
                turnIndicator.BackColor = Color.MediumTurquoise;
                return false;
            }
        }

        // NEW - Checks to see who had the most rocks in their Mancala and prints the winner
        private void GameOver()
        {
            string message;
            if (GameBoard.P1Mancala > GameBoard.P2Mancala) { message = "Player 1 has won!"; }
            else if (GameBoard.P2Mancala > GameBoard.P1Mancala) { message = "Player 2 has won!"; }
            else { message = "It's a tie!"; }
            Console.WriteLine(message);
            string caption = "WINNER";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Turn = 0;
        }
    }
}