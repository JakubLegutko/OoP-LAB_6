using System;
using System.Collections.Generic;
using System.Text;

namespace OoP_LAB_6
{
    class StrategyEverySecondBetrayInv :IStrategy
    {
        public bool GetNextMove(List<bool> knownMoves)
        {
            int length = knownMoves.Count;
            if (length % 2 != 0 || length != 0)
            {
                return true;
            }
            else return false;
        }
    }
}
