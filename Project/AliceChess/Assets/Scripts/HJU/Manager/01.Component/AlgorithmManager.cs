using System;
using Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class AlgorithmManager : Manager
    {
        private ChessPieceState pieceState;
        private BoardStateManager boardManager;
        private readonly float distance = DataManager.ChessPieceInfo.distance;

        private readonly int min = DataManager.ChessBoardInfo.chessBoardMinimum;
        private readonly int max = DataManager.ChessBoardInfo.chessBoardMaximum;

        private DataManager.Team currentTeam;

        private void Start()
        {
            boardManager = GetManager<BoardStateManager>();
        }

        public List<Vector2> GetList(ChessPieceState state, DataManager.Team team)
        {
            this.currentTeam = team;
            this.pieceState = state;
            DataManager.PieceName name = pieceState.PieceName;
            Vector3 position = pieceState.Position;
            int x = (int)(position.x / distance);
            int z = (int)(position.z / distance);

            if (position.x % distance >= 0.03f)
            {
                x++;
            }
            if (position.z % distance >= 0.03f)
            {
                z++;
            }

            List<Vector2> result = new List<Vector2>();
            switch (name)
            {
                case DataManager.PieceName.King:
                    result = King(x, z);
                    break;
                case DataManager.PieceName.Queen:
                    result = Queen(x, z);
                    break;
                case DataManager.PieceName.Rook:
                    result = Rook(x, z);
                    break;
                case DataManager.PieceName.Bishop:
                    result = Bishop(x, z);
                    break;
                case DataManager.PieceName.Knight:
                    result = Knight(x, z);
                    break;
                case DataManager.PieceName.Pawn:
                    result = Pawn(x, z);
                    break;
            }
            #region debugging codes
            /*
            if (result.Count != 0)
                Debug.Log("Exist");
            else
                Debug.Log("GetList : No Place available");
            int i = 0;
            foreach (Vector2 elem in result)
            {
                Debug.Log($"{++i} : x = {elem.x}, z = {elem.y}");
            }
            */
            #endregion
            return result;
        }

        private List<Vector2> King(int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            #region King
            ChessPieceInformation[,] board = boardManager.GetBoard();

            // 위
            try
            {
                for (int i = xPos - 1; i <= xPos + 1; i++)
                {
                    ChessPieceInformation manager = board[i, zPos + 1];
                    Vector2 tempResult = new Vector2(i, zPos + 1);
                    if (manager.PieceName == DataManager.PieceName.None)
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }

            // 중간
            try
            {
                for (int i = xPos - 1; i <= xPos + 1; i++)
                {
                    ChessPieceInformation manager = board[i, zPos];
                    Vector2 tempResult = new Vector2(i, zPos);
                    if (i == xPos)
                    {
                        continue;
                    }

                    if (manager.PieceName == DataManager.PieceName.None)
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }

            // 아래
            try
            {
                for (int i = xPos - 1; i <= xPos + 1; i++)
                {
                    ChessPieceInformation manager = board[i, zPos - 1];
                    Vector2 tempResult = new Vector2(i, zPos - 1);
                    if (manager.PieceName == DataManager.PieceName.None)
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }
            #endregion
            return result;
        }

        private List<Vector2> Queen(int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            #region Queen
            ChessPieceInformation[,] board = boardManager.GetBoard();
            // 상
            if (zPos != 7)
            {
                try
                {
                    for (int i = zPos + 1; i <= max; i++)
                    {
                        ChessPieceInformation manager = board[xPos, i];
                        Vector2 tempResult = new Vector2(xPos, i);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */ }
            }

            // 하
            if (zPos != 0)
            {
                try
                {
                    for (int i = zPos - 1; i <= max; i--)
                    {
                        ChessPieceInformation manager = board[xPos, i];
                        Vector2 tempResult = new Vector2(xPos, i);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */}
            }

            // 좌
            if (xPos != 0)
            {
                try
                {
                    for (int i = xPos - 1; i >= min; i--)
                    {
                        ChessPieceInformation manager = board[i, zPos];
                        Vector2 tempResult = new Vector2(i, zPos);
                        if (manager.PieceName == DataManager.PieceName.None)
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */ }
            }

            // 우
            if (xPos != 7)
            {
                try
                {
                    for (int i = xPos + 1; i <= max; i++)
                    {
                        ChessPieceInformation manager = board[i, zPos];
                        Vector2 tempResult = new Vector2(i, zPos);
                        if (manager.PieceName == DataManager.PieceName.None)
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */ }

                // 좌상
                int lu_x = xPos;
                int lu_z = zPos;
                while (true)
                {
                    try
                    {
                        int x = --lu_x;
                        int z = ++lu_z;
                        ChessPieceInformation manager = board[x, z];
                        Vector2 tempResult = new Vector2(x, z);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }

                // 우상
                int ru_x = xPos;
                int ru_z = zPos;
                while (true)
                {
                    try
                    {
                        int x = ++ru_x;
                        int z = ++ru_z;
                        ChessPieceInformation manager = board[x, z];
                        Vector2 tempResult = new Vector2(x, z);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }

                // 우하
                int rd_x = xPos;
                int rd_z = zPos;
                while (true)
                {
                    try
                    {
                        int x = ++rd_x;
                        int z = --rd_z;
                        ChessPieceInformation manager = board[x, z];
                        Vector2 tempResult = new Vector2(x, z);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }

                // 좌하
                int ld_x = xPos;
                int ld_z = zPos;
                while (true)
                {
                    try
                    {
                        int x = --ld_x;
                        int z = --ld_z;
                        ChessPieceInformation manager = board[x, z];
                        Vector2 tempResult = new Vector2(x, z);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
            }
            #endregion
            return result;
        }

        private List<Vector2> Rook(int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            #region Rook
            ChessPieceInformation[,] board = boardManager.GetBoard();
            // 상
            if (zPos != 7)
            {
                try
                {
                    for (int i = zPos + 1; i <= max; i++)
                    {
                        ChessPieceInformation manager = board[xPos, i];
                        Vector2 tempResult = new Vector2(xPos, i);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */ }
            }

            // 하
            if (zPos != 0)
            {
                try
                {
                    for (int i = zPos - 1; i <= max; i--)
                    {
                        Debug.Log($"rook//down// xPos : {xPos}, i : {i}");
                        ChessPieceInformation manager = board[xPos, i];
                        Vector2 tempResult = new Vector2(xPos, i);
                        if (manager.PieceName.Equals(DataManager.PieceName.None))
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */}
            }

            // 좌
            if (xPos != 0)
            {
                try
                {
                    for (int i = xPos - 1; i >= min; i--)
                    {
                        ChessPieceInformation manager = board[i, zPos];
                        Vector2 tempResult = new Vector2(i, zPos);
                        if (manager.PieceName == DataManager.PieceName.None)
                        {
                            result.Add(tempResult);
                        }
                        else
                        {
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */ }
            }

            // 우
            if (xPos != 7)
            {
                try
                {
                    for (int i = xPos + 1; i <= max; i++)
                    {
                        ChessPieceInformation manager = board[i, zPos];
                        Vector2 tempResult = new Vector2(i, zPos);
                        if (manager.PieceName == DataManager.PieceName.None)
                        {
                            result.Add(tempResult);
                            Debug.Log($"// rook, right // first if");
                        }
                        else
                        {
                            Debug.Log($"// rook, right // first else");
                            if (currentTeam != manager.Team)
                            {
                                result.Add(tempResult);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException) { /* do nothing */ }
            }
            #endregion
            return result;
        }

        private List<Vector2> Bishop(int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            #region Bishop
            ChessPieceInformation[,] board = boardManager.GetBoard();

            // 좌상
            int lu_x = xPos;
            int lu_z = zPos;
            while (true)
            {
                try
                {
                    int x = --lu_x;
                    int z = ++lu_z;
                    ChessPieceInformation manager = board[x, z];
                    Vector2 tempResult = new Vector2(x, z);
                    if (manager.PieceName.Equals(DataManager.PieceName.None))
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            // 우상
            int ru_x = xPos;
            int ru_z = zPos;
            while (true)
            {
                try
                {
                    int x = ++ru_x;
                    int z = ++ru_z;
                    ChessPieceInformation manager = board[x, z];
                    Vector2 tempResult = new Vector2(x, z);
                    if (manager.PieceName.Equals(DataManager.PieceName.None))
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            // 우하
            int rd_x = xPos;
            int rd_z = zPos;
            while (true)
            {
                try
                {
                    int x = ++rd_x;
                    int z = --rd_z;
                    ChessPieceInformation manager = board[x, z];
                    Vector2 tempResult = new Vector2(x, z);
                    if (manager.PieceName.Equals(DataManager.PieceName.None))
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            // 좌하
            int ld_x = xPos;
            int ld_z = zPos;
            while (true)
            {
                try
                {
                    int x = --ld_x;
                    int z = --ld_z;
                    ChessPieceInformation manager = board[x, z];
                    Vector2 tempResult = new Vector2(x, z);
                    if (manager.PieceName.Equals(DataManager.PieceName.None))
                    {
                        result.Add(tempResult);
                    }
                    else
                    {
                        if (currentTeam != manager.Team)
                        {
                            result.Add(tempResult);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            #endregion
            return result;
        }

        private List<Vector2> Knight(int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            #region Knight

            ChessPieceInformation[,] board = boardManager.GetBoard();

            List<Vector2> positionList = new List<Vector2>();
            // 상
            positionList.Add(new Vector2(xPos - 1, zPos + 2));
            positionList.Add(new Vector2(xPos + 1, zPos + 2));

            // 하
            positionList.Add(new Vector2(xPos - 1, zPos - 2));
            positionList.Add(new Vector2(xPos + 1, zPos - 2));

            // 좌
            positionList.Add(new Vector2(xPos - 2, zPos - 1));
            positionList.Add(new Vector2(xPos - 2, zPos + 1));

            // 우
            positionList.Add(new Vector2(xPos + 2, zPos - 1));
            positionList.Add(new Vector2(xPos + 2, zPos + 1));

            foreach (Vector2 elem in positionList)
            {
                int x = (int)elem.x;
                int z = (int)elem.y;
                if (x > 7 || x < 0 || z > 7 || z < 0)
                {
                    continue;
                }
                ChessPieceInformation manager = board[x, z];
                Vector2 tempReuslt = new Vector2(x, z);
                if (manager.PieceName.Equals(DataManager.PieceName.None))
                {
                    result.Add(tempReuslt);
                }
                else
                {
                    if (currentTeam != manager.Team && manager.Team != DataManager.Team.None)
                    {
                        result.Add(tempReuslt);
                        continue;
                    }
                }
            }
            #region backup
            /*
            ChessPieceManager[,] board = boardManager.GetBoard();

            // z + 2 일 때 
            try
            {
                for (int i = xPos - 1; i < xPos + 1; i++)
                {
                    if (i == xPos)
                    {
                        continue;
                    }
                    if (board[i, zPos + 2].PieceName == DataManager.PieceName.NONE)
                    {
                        result.Add(new Vector2(i, zPos + 2));
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }

            // z - 2 일 때
            try
            {
                for (int i = xPos - 1; i < xPos + 1; i++)
                {
                    if (i == xPos)
                    {
                        continue;
                    }
                    if (board[i, zPos - 2].PieceName == DataManager.PieceName.NONE)
                    {
                        result.Add(new Vector2(i, zPos - 2));
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }

            // x + 2 일 때
            try
            {
                for (int i = zPos - 1; i < zPos + 1; i++)
                {
                    if (i == zPos)
                    {
                        continue;
                    }
                    if (board[xPos + 2, i].PieceName == DataManager.PieceName.NONE)
                    {
                        result.Add(new Vector2(xPos + 2, i));
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }

            try
            {
                for (int i = zPos - 1; i < zPos + 1; i++)
                {
                    if (i == zPos)
                    {
                        continue;
                    }
                    if (board[xPos - 2, i].PieceName == DataManager.PieceName.NONE)
                    {
                        result.Add(new Vector2(xPos + 2, i));
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
            */
            #endregion
            #endregion
            return result;
        }

        private List<Vector2> Pawn(int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            #region Pawn
            ChessPieceInformation[,] board = boardManager.GetBoard();
            switch (pieceState.Team)
            {
                case DataManager.Team.Black:
                    result = BlackPawn(board, xPos, zPos);
                    break;
                case DataManager.Team.White:
                    result = WhitePawn(board, xPos, zPos);
                    break;
                default:
                    break;
            }
            #endregion
            return result;
        }

        private List<Vector2> BlackPawn(ChessPieceInformation[,] board, int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            try
            {
                if (board[xPos, zPos + 1].PieceName == DataManager.PieceName.None) // xPos -> zPos
                {
                    result.Add(new Vector2(xPos, zPos + 1));
                }

                if (zPos == 1 && board[xPos, zPos + 2].PieceName == DataManager.PieceName.None)
                {
                    result.Add(new Vector2(xPos, zPos + 2));
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log($"PawnIOBException // {e.ToString()}");
            }

            try
            {
                if (board[xPos - 1, zPos + 1].Team == DataManager.Team.White)
                {
                    result.Add(new Vector2(xPos - 1, zPos + 1));
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }

            try
            {
                if (board[xPos + 1, zPos + 1].Team == DataManager.Team.White)
                {
                    result.Add(new Vector2(xPos + 1, zPos + 1));
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }
            return result;
        }

        private List<Vector2> WhitePawn(ChessPieceInformation[,] board, int xPos, int zPos)
        {
            List<Vector2> result = new List<Vector2>();
            try
            {
                if (board[zPos, zPos - 1].PieceName == DataManager.PieceName.None)
                {
                    result.Add(new Vector2(xPos, zPos - 1));
                }

                if (zPos == 6 && board[xPos, zPos - 2].PieceName == DataManager.PieceName.None)
                {
                    result.Add(new Vector2(xPos, zPos - 2));
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log($"PawnIOBException // {e.ToString()}");
            }

            try
            {
                if (board[xPos - 1, zPos - 1].Team == DataManager.Team.Black)
                {
                    result.Add(new Vector2(xPos - 1, zPos - 1));
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }

            try
            {
                if (board[xPos + 1, zPos - 1].Team == DataManager.Team.Black)
                {
                    result.Add(new Vector2(xPos + 1, zPos - 1));
                }
            }
            catch (IndexOutOfRangeException) { /* do nothing */ }
            return result;
        }
    }
}