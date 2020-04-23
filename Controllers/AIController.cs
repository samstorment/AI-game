using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using game_gui.POCSO;

namespace game_gui.Controllers
{
    static class AIController
    {
        public static string GetMove(MancalaBoard board, int playerNum, string exePath, int timeLimit)
        {
            WriteBoardToFile(board, playerNum);
            ProcessStartInfo info = new ProcessStartInfo();
            info.CreateNoWindow = true;
            info.FileName = exePath;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit(timeLimit);
            if (!p.HasExited)
            {
                if(p.Responding)
                {
                    p.CloseMainWindow();
                } 
                else
                {
                    p.Kill();
                }
                return "timeout";
            }
            string resp = System.IO.File.ReadAllLines("AIfile.txt")[0];
            return resp;
        }

        public static void WriteBoardToFile(MancalaBoard board, int playerNum)
        {
            Console.WriteLine("\tPrinting to Board File...");
            string[] lines = { "", "", "", "", "" };
            lines[0] = playerNum.ToString();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (j < 5)
                        lines[i + 1] += board.GameBoard[i, j].ToString() + ", ";
                    else
                        lines[i + 1] += board.GameBoard[i, j].ToString();
                }
            }
            lines[3] = board.P1Mancala.ToString();
            lines[4] = board.P2Mancala.ToString();

            System.IO.File.WriteAllLines("AIfile.txt", lines);
            Console.WriteLine("\tWrite to file complete.");
        }
    }
}
