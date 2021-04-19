using System;
using System.Collections.Generic;
using System.Text;

namespace OoP_LAB_6
{
    class StrategyBestStrat : IStrategy
    {
        public bool GetNextMove(List<bool> knownMoves)
        {
            int length = knownMoves.Count;
            if (length < 2)
            {
                return true;
            }
            else
            {
                if (knownMoves[length - 1] == false) return false;
                else return true;
            }
        }
    }
}
