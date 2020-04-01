using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Controllers Folder: For general game control and getting data from users
        // POCSO (plain old C# objects): If you need a general object, place it here, but I suspect we will have our "board" array just in GameController

        // CTOR
        public Game()
        {
            InitializeComponent();
        }

        // PLAYER 1 Selection ----------------------------------------------
        private void Player1Cup1_Click(object sender, EventArgs e)
        {

        }

        private void Player1Cup2_Click(object sender, EventArgs e)
        {

        }

        private void Player1Cup3_Click(object sender, EventArgs e)
        {

        }

        private void Player1Cup4_Click(object sender, EventArgs e)
        {

        }

        private void Player1Cup5_Click(object sender, EventArgs e)
        {

        }

        private void Player1Cup6_Click(object sender, EventArgs e)
        {

        }

        // PLAYER 2 Selection ----------------------------------------------
        private void Player2Cup1_Click(object sender, EventArgs e)
        {

        }

        private void Player2Cup2_Click(object sender, EventArgs e)
        {

        }

        private void Player2Cup3_Click(object sender, EventArgs e)
        {

        }

        private void Player2Cup4_Click(object sender, EventArgs e)
        {

        }

        private void Player2Cup5_Click(object sender, EventArgs e)
        {

        }

        private void Player2Cup6_Click(object sender, EventArgs e)
        {

        }

        // Set Human / Computer ----------------------------------------------
        private void P1HumanButton_Click(object sender, EventArgs e)
        {

        }

        private void P1ComputerButton_Click(object sender, EventArgs e)
        {

        }

        private void p2HumanButton_Click(object sender, EventArgs e)
        {

        }

        private void p2ComputerButton_Click(object sender, EventArgs e)
        {

        }

        // General Game Control ----------------------------------------------
        private void StartGameButton_Click(object sender, EventArgs e)
        {

        }

        private void ResetGameButton_Click(object sender, EventArgs e)
        {

        }

        // Console show / hide ----------------------------------------------
        private void P1ShowConsoleCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void P2ShowConsoleCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Time Limit Control ----------------------------------------------
        private void TimeLimitSelect5_Click(object sender, EventArgs e)
        {

        }

        private void TimeLimitSelect10_Click(object sender, EventArgs e)
        {

        }

        private void TimeLimitSelect15_Click(object sender, EventArgs e)
        {

        }

        private void TimeLimitSelect20_Click(object sender, EventArgs e)
        {

        }

        private void TimeLimitSelectNone_Click(object sender, EventArgs e)
        {

        }
    }
}
