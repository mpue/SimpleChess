using SimpleChess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleChess.ChessGame;

namespace ChessGUI.SimpleChessLib
{
    class Evaluation
    {
        public static Move savedMove = null;
        public static readonly int MAXDEPTH = 3;

        public static float miniMax(Board board,int player, in int depth)
        {
            Piece.Color color = Piece.Color.BLACK;
            if (player == 1)
            {
                color = Piece.Color.BLACK;
            }
            else
            {
                color = Piece.Color.WHITE;
            }

            if (depth == 0 || board.GetPossibleMoves(color).Count == 0)
            {
                return -board.Eval(color);
            }
            float maxValue = float.MinValue;
            List<Move> moves = board.GetPossibleMoves(color);

            int moveCount = 0;

            while (moves.Count > 0)
            {
                // Move m = new Move(moves[0],board);
                board.history.Push(moves[0]);
                moves[0].Execute();

                float value = -miniMax(board, -player, depth - 1);
                board.history.Pop().Undo();

                if (value > maxValue)
                {
                    maxValue = value;
                    if (depth == MAXDEPTH)
                    {
                        savedMove = new Move(moves[0], board);
                    }
                }
                moves.RemoveAt(0);
                moveCount++;
            }

            return maxValue;
        }

        public static float miniMaxAlphaBeta(Board board, int player, int depth, float alpha, float beta)
        {
            Piece.Color color = Piece.Color.BLACK;
            if (player == 1)
            {
                color = Piece.Color.BLACK;
            }
            else
            {
                color = Piece.Color.WHITE;
            }

            List<Move> possibleMoves = board.GetPossibleMoves(color);

            if (depth == 0 || possibleMoves.Count == 0)
            {
                return board.Eval(color);
            }

            float maxValue = alpha;
            int moveCount = 0;

            PresortMoves(possibleMoves, board);

            foreach (Move move in possibleMoves)
            {
                float value = 0;

                if (move.Execute())
                {

                    board.history.Push(move);
                    value = -miniMaxAlphaBeta(board, -player, depth - 1, -beta, -maxValue) + board.Pieces[move.x2, move.y2].GetSquareTable()[move.x2, move.y2];
                    board.history.Pop().Undo();
                    if (value > maxValue)
                    {
                        maxValue = value;
                        if (depth == MAXDEPTH)
                        {
                            savedMove = move;
                        }
                        if (maxValue >= beta)
                        {
                            break;
                        }
                    }

                }
                else
                {
                    continue;
                }
                moveCount++;

            }

            return maxValue;
        }
        public static float miniMaxAlphaBetaPV(Board board, int depth, float alpha, float beta)
        {
            if (depth == 0)
            {
                return board.Eval();
            }

            bool pvfound = false;
            float best = float.NegativeInfinity;

            List<Move> possibleMoves = board.GetPossibleMoves();


            int moveCount = 0;

            PresortMoves(possibleMoves, board);

            foreach (Move move in possibleMoves)
            {
                

                float value = 0;

                if (move.Execute())
                {
                    board.history.Push(move);
                    if (pvfound)
                    {
                        value = -miniMaxAlphaBetaPV(board, depth - 1, -alpha - 1, -alpha) + board.Pieces[move.x2, move.y2].GetSquareTable()[move.x2, move.y2];

                        if (value > alpha && value < beta)
                            value = -miniMaxAlphaBetaPV(board,depth - 1, -beta, -value);

                    }
                    else
                    {
                        value = -miniMaxAlphaBetaPV(board, depth - 1, -beta, -alpha);

                    }


                    board.history.Pop().Undo();
                    if (value > best)
                    {
                        if (value >= beta)
                        {
                            return value;
                        }
                        best = value;
                        if (value > alpha)
                        {
                            alpha = value;
                            pvfound = true;
                        }
                    }

                }
                else
                {
                    continue;
                }
                moveCount++;

            }

            return best;
        }

        private static void PresortMoves(List<Move> moves, Board board)
        {
            moves.Sort(new MoveComparer(board));
        }

        private class MoveComparer : IComparer<Move>
        {
            public MoveComparer(Board board)
            {
                Board = board;
            }

            public Board Board { get; }

            public int Compare(Move m1, Move m2)
            {
                int val_m1 = 0;
                int val_m2 = 0;

                foreach (Piece p in Board.Pieces)
                {
                    if ((p.position.col == m1.x2 && p.position.row == m1.y2))
                    {
                        val_m1 = (int)p.type;
                    }
                    if (p.position.col == m2.x2 && p.position.row == m2.y2)
                    {
                        val_m2 = (int)p.type;
                    }
                    return val_m1.CompareTo(val_m2);
                }

                return 0;
            }
        }

    }
}
