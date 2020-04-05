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
        // This is where our event handlers will be for our form. Pass off game control functoinality to controllers

        // C# Conventions: https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md
        // Class Names: PascalCase
        // Constructors: PascalCase
        // Method Names: PascalCase
        // Constants: PascalCase
        // Class Variables: PacalCase
        // Local Variabls: camelCase
        // Method Params: camelCase

        private MancalaBoard GameBoard;
        private bool PlayerHasWon = false;
        private string P1Type = "";
        private string P2Type = "";
        private string P1Path = "";
        private string P2Path = "";
        private int Turn = 0;
        private int TimeoutInMilliseconds = 15000;

        // CTOR
        public Game()
        {
            InitializeComponent();
            ResetBoard();
        }

        // PLAYER 1 Selection ----------------------------------------------
        private void Player1Cup1_Click(object sender, EventArgs e)
        {
            //if (Turn == 1 && P1Type.Equals("Human"))
            //{
            //    // Take turn
            //    // Update Board and see if player goes again
            //    // Check for win
            //    // If player can go again
            //        // Don't switch turns
            //    // If no win, player does not go again, and p2 = comp... 
            //        // let computer go
            //        // Update board
            //        // Check for win
            //    // Else, the other player is a human and turn is over
            //        // Switch turns
            //}
            //else
            //{
            //    InvalidSelection(1, 1);
            //}
            GameBoard.UpdateBoard(2, 6);
            AIController.WriteBoardToFile(GameBoard, 1);
        }

        private void Player1Cup2_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(1, 2);
            }
        }

        private void Player1Cup3_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(1, 3);
            }
        }

        private void Player1Cup4_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(1, 4);
            }
        }

        private void Player1Cup5_Click(object sender, EventArgs e)
        {
            if (Turn == 1 && P1Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(1, 5);
            }
        }

        private void Player1Cup6_Click(object sender, EventArgs e)
        {
            if(Turn == 1 && P1Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(1, 6);
            }
        }

        // PLAYER 2 Selection ----------------------------------------------
        private void Player2Cup1_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(2, 1);
            }
        }

        private void Player2Cup2_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(2, 2);
            }
        }

        private void Player2Cup3_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(2, 3);
            }
        }

        private void Player2Cup4_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(2, 4);
            }
        }

        private void Player2Cup5_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(2, 5);
            }
        }

        private void Player2Cup6_Click(object sender, EventArgs e)
        {
            if (Turn == 2 && P2Type.Equals("Human"))
            {

            }
            else
            {
                InvalidSelection(2, 6);
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
            if(P1Type.Equals("Computer") && P2Type.Equals("Computer"))
            {
                if(!P1Path.Contains(".exe") || !P2Path.Contains(".exe"))
                {
                    SelectExeError();
                    return;
                }

                // Just do a while loop here since it isn't important that the GUI is active
                    // Make a computer play method that has a while loop (while can play again)
                // Add in delay so we can see what is happening
            }
            else if (P1Type.Equals("Computer") && P2Type.Equals("Human"))
            {
                if (!P1Path.Contains(".exe"))
                {
                    SelectExeError();
                    return;
                }
                // Let computer go, then switch to human's turn
            }
            else if (P1Type.Equals("Human") && P2Type.Equals("Computer"))
            {
                if (!P2Path.Contains(".exe"))
                {
                    SelectExeError();
                    return;
                }

            }
            else // Both humans
            {
                // nothing???
            }
        }

        private void ResetGameButton_Click(object sender, EventArgs e)
        {
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
            player1Cup1Count.Text = "4";
            player1Cup2Count.Text = "4";
            player1Cup3Count.Text = "4";
            player1Cup4Count.Text = "4";
            player1Cup5Count.Text = "4";
            player1Cup6Count.Text = "4";
            player1MancalaCount.Text = "0";

            player2Cup1Count.Text = "4";
            player2Cup2Count.Text = "4";
            player2Cup3Count.Text = "4";
            player2Cup4Count.Text = "4";
            player2Cup5Count.Text = "4";
            player2Cup6Count.Text = "4";
            player2MancalaCount.Text = "0";

            Turn = 0;
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
            // update board through MancalaBoard's method (true means player goes again)
            // Update GUI board to reflect changes

            return false;
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
    }
}