using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_gui.POCSO
{
    class MancalaBoard
    {
        public int[,] GameBoard = new int[2, 6];
        public int P1Mancala;
        public int P2Mancala;
        public MancalaBoard()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    GameBoard[i, j] = 8;
                }
            }
            P1Mancala = 0;
            P2Mancala = 0;
        }

        // RIGHT NOW, this is assuming players 1, 2 and cups 1-6
        public bool UpdateBoard(int player, int cup)
        {
            int piecesRemaining = GameBoard[player - 1, cup - 1];
            GameBoard[player - 1, cup - 1] = 0;
            int lastPieceSideIndex = -1, lastPieceCupIndex = - 1;
            bool loopAround = false; // Have we gone around the board?
            while (piecesRemaining > 0)
            {
                int playerCupIndex = loopAround ? 0 : cup;
                loopAround = true;
                int playerSideIndex = player == 1 ? 0 : 1;
                while(playerCupIndex < 6 && piecesRemaining > 0)
                {
                    GameBoard[playerSideIndex, playerCupIndex]++;
                    lastPieceSideIndex = playerSideIndex;
                    lastPieceCupIndex = playerCupIndex;
                    piecesRemaining--;
                    playerCupIndex++;
                }
                if(piecesRemaining > 0 && player == 1)
                {
                    P1Mancala++;
                    piecesRemaining--;
                    lastPieceSideIndex = playerSideIndex;
                    lastPieceCupIndex = 6;
                }
                else if (piecesRemaining > 0 && player == 2)
                {
                    P2Mancala++;
                    piecesRemaining--;
                    lastPieceSideIndex = playerSideIndex;
                    lastPieceCupIndex = 6;
                }
                int opponentCupIndex = 0;
                int opponentSideIndex = player == 1 ? 1 : 0;
                while (opponentCupIndex < 6 && piecesRemaining > 0)
                {
                    GameBoard[opponentSideIndex, opponentCupIndex]++;
                    lastPieceSideIndex = opponentSideIndex;
                    lastPieceCupIndex = opponentCupIndex;
                    piecesRemaining--;
                    opponentCupIndex++;
                }
            }
            // Special Cases -------------------------------------------------
            int oppositeSide = player - 1 == 0 ? 1 : 0;
            if(lastPieceSideIndex == player - 1 
                && lastPieceCupIndex != 6 
                && GameBoard[lastPieceSideIndex, lastPieceCupIndex] == 1 
                && GameBoard[oppositeSide, 5 - lastPieceCupIndex] > 0) // Capture opponent
            {
                if(player == 1)
                {
                    int total = GameBoard[0, lastPieceCupIndex] + GameBoard[1, 5 - lastPieceCupIndex];
                    GameBoard[0, lastPieceCupIndex] = 0;
                    GameBoard[1, 5 - lastPieceCupIndex] = 0;
                    P1Mancala += total;
                }
                else
                {
                    int total = GameBoard[1, lastPieceCupIndex] + GameBoard[0, 5 - lastPieceCupIndex];
                    GameBoard[1, lastPieceCupIndex] = 0;
                    GameBoard[0, 5 - lastPieceCupIndex] = 0;
                    P2Mancala += total;
                }
                return false;
            }
            else if (lastPieceSideIndex == player - 1 && lastPieceCupIndex == 6) // Go again (landed in mancala)
            {
                return true;
            }
            else // No Special cases
            {
                return false;
            }
        }

        public bool PlayerHasWon()
        {
            int total1  = 0;
            for(int i = 0; i < 6; i++)
            {
                total1 += GameBoard[0, i];
            }

            int total2 = 0;
            for (int i = 0; i < 6; i++)
            {
                total2 += GameBoard[1, i];
            }

            return (total1 == 0 || total2 == 0);
        }
    }
}
