using Utility;
using Network;
using UnityEngine;

namespace Manager
{
    public class BoardStateManager : Manager
    {
        private int boardWidthHeight = 8;
        private ChessPieceManager[,] board = new ChessPieceManager[8, 8];

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            // 아래팀
            for (int i = 0; i < boardWidthHeight; i++)
            {
                board[i, 0] = new ChessPieceManager(DataManager.Team.Black, DataManager.pieceNameArray[i]);
            }

            // 아래팀 폰
            for (int i = 0; i < boardWidthHeight; i++)
            {
                board[i, 1] = new ChessPieceManager(DataManager.Team.Black, DataManager.PieceName.Pawn);
            }

            // 중간
            for (int i = 2; i <= 5; i++)
            {
                for (int j = 0; j < boardWidthHeight; j++)
                {
                    board[j, i] = new ChessPieceManager(DataManager.Team.None, DataManager.PieceName.None);
                }
            }

            // 위팀 폰
            for (int i = 0; i < boardWidthHeight; i++)
            {
                board[i, 6] = new ChessPieceManager(DataManager.Team.White, DataManager.PieceName.Pawn);
            }

            // 위팀
            for (int i = 0; i < boardWidthHeight; i++)
            {
                board[i, 7] = new ChessPieceManager(DataManager.Team.White, DataManager.pieceNameArray[i]);
            }
        }

        public ChessPieceManager[,] GetBoard()
        {
            return this.board;
        }

        public void ChangeState(Vector3 firstPosition, Vector3 lastPositon)
        {
            float distance = DataManager.ChessPieceInfo.distance;

            // 첫번째
            int first_xOffset = (int)(firstPosition.x / distance);
            int first_zOffset = (int)(firstPosition.z / distance);

            #region catch bugs
            float remain_x = firstPosition.x % distance;
            float remain_z = firstPosition.z % distance;
            if (remain_x >= 0.03f)
            {
                first_xOffset++;
            }
            if (remain_z >= 0.03f)
            {
                first_zOffset++;
            }
            #endregion

            ChessPieceManager firstState = board[first_xOffset, first_zOffset];

            DataManager.Team first_team = firstState.Team;
            DataManager.PieceName first_pieceName = firstState.PieceName;

            // 두번째
            int last_xOffset = (int)(lastPositon.x / distance);
            int last_zOffset = (int)(lastPositon.z / distance);

            #region catch bugs 2
            float re_x = lastPositon.x % distance;
            float re_z = lastPositon.z % distance;
            if (re_x >= 0.03f)
            {
                last_xOffset++;
            }
            if (re_z >= 0.03f)
            {
                last_zOffset++;
            }
            #endregion

            ChessPieceManager lastState = board[last_xOffset, last_zOffset];

            DataManager.Team last_team = lastState.Team;
            DataManager.PieceName last_pieceName = lastState.PieceName;

            if (firstState.Team != lastState.Team && lastState.Team != DataManager.Team.None)
            {
                // kill piece
                // GameObject.FindGameObjectWithTag("GameManager").GetComponent<NetworkManager>().SetActiveFalseObject(last_team, last_pieceName, last_xOffset, last_zOffset);
                // GetOrCreateManager<NetworkManager>().
                board[first_xOffset, first_zOffset] = new ChessPieceManager(DataManager.Team.None, DataManager.PieceName.None);
                board[last_xOffset, last_zOffset] = firstState;
            }
            else
            {
                // switching
                board[first_xOffset, first_zOffset] = lastState;
                board[last_xOffset, last_zOffset] = firstState;
            }
        }

        public ChessPieceManager GetChessPieceState(Vector2 position)
        {
            float x = position.x;
            float z = position.y;
            return board[(int)x, (int)z];
        }

        [PunRPC]
        public void SetActiveFalse()
        {

        }
    }
}