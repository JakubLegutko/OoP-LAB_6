using System;
using System.Collections.Generic;
using System.Text;

namespace OoP_LAB_6
{
    class StrategyBetrayIf : IStrategy
    {
        public bool GetNextMove(List<bool> knownMoves)
        {
            int length = knownMoves.Count;
            if (length < 5)
            {
                return true;
            }
            else
                {
                    if (knownMoves[length -1] == false && knownMoves[length -2] == true) return false;
                    else return true;
                }
        }
    }
}
