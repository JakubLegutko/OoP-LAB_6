using System;
using System.Collections.Generic;
using System.Text;

namespace OoP_LAB_6
{
    class Game
    {
        public static void Run()
        {
            int rounds = 30; // how many rounds
            int score1 = 10; // both players cooperate
            int score2 = 15; // one player betrays - winner
            int score3 = -10; // one player betrays - loser
            int score4 = 0; // both players betray
                            // note: it can be shown mathematically that this game is non-trivial if: 
                            // 1) score2 > score1 > score4 > score3, AND
                            // 2) 2*score1 > score2 + score3

            int globalP1 = 0;
            int globalP2 = 0;
            List<IStrategy> StrategyList = new List<IStrategy>();
            StrategyList.Add(new StrategyBetrayal());
            StrategyList.Add(new StrategyEverySecondBetrayInv());
            StrategyList.Add(new StrategyEverySecondBetray());
            StrategyList.Add(new StrategyAlwaysTrue());
            StrategyList.Add(new StrategyBetrayIf());
            for (int listLength = 0; listLength < StrategyList.Count; listLength++)
            {
                for (int strategyCount = 0; strategyCount < StrategyList.Count; strategyCount++)
                {

                    Player p1 = new Player(StrategyList[listLength]);
                    Player p2 = new Player(StrategyList[strategyCount]);
                    for (int i = 0; i < rounds; i++)
                    {
                        bool move1 = p1.GetNextMove();
                        bool move2 = p2.GetNextMove();

                        if (move1 && move2) // both players cooperated
                        {
                            // update score
                            p1.Score += score1;
                            p2.Score += score1;
                            // update players' knowledge about their partner
                            p1.PartnerMoves.Add(true);
                            p2.PartnerMoves.Add(true);
                        }
                        else if (move1) // player2 betrayed player1
                        {
                            p1.Score += score3;
                            p2.Score += score2;
                            p1.PartnerMoves.Add(false);
                            p2.PartnerMoves.Add(true);
                        }
                        else if (move2) // player1 betrayed player2
                        {
                            p1.Score += score2;
                            p2.Score += score3;
                            p1.PartnerMoves.Add(true);
                            p2.PartnerMoves.Add(false);
                        }
                        else // both players betrayed
                        {
                            p1.Score += score4;
                            p2.Score += score4;
                            p1.PartnerMoves.Add(false);
                            p2.PartnerMoves.Add(false);
                        }
                    }

                    globalP1 += p1.Score;
                    globalP2 += p2.Score;
                    Console.WriteLine("Player1 score: " + p1.Score);
                    Console.WriteLine("Player2 score: " + p2.Score);
                }

                Console.WriteLine("Player1 score globally: " + globalP1);
                Console.WriteLine("Player2 score globally: " + globalP2);
            }

        }
    }
}