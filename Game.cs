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
        public Game()
        {
            InitializeComponent();
        }

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

    }
}
