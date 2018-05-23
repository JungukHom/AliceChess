using System;
using Utility;
using UnityEngine;
using System.Collections.Generic;

namespace Manager
{
    public class PhotonInstantiateManager : Manager
    {
        private BoardStateManager boardStateManager;
        private Vector3 scale;
        private Quaternion blackRotation;
        private Quaternion whiteRotation;
        private ChessPieceManager[,] board;

        #region CharacterNames
        private readonly string blackKing = "King";
        private readonly string blackQueen = "Queen";
        private readonly string blackRook = "Rook";
        private readonly string blackBishop = "Bishop";
        private readonly string blackKnight = "Knight";
        private readonly string blackPawn = "Pawn";

        private readonly string whiteKing = "King";
        private readonly string whiteQueen = "Queen";
        private readonly string whiteRook = "Rook";
        private readonly string whiteBishop = "Bishop";
        private readonly string whiteKnight = "Knight";
        private readonly string whitePawn = "Pawn";
        #endregion

        private readonly float chessBoardStartHeight = DataManager.ChessBoardInfo.startHeight;
        // private readonly Vector3 chessBoardPosition = DataManager.ChessBoardPosition;

        private static PhotonInstantiateManager instance = null;

        private PhotonInstantiateManager()
        {
            boardStateManager = BoardStateManager.GetInstance();
            // boardStateManager = GetOrCreateManager<BoardStateManager>();
            board = boardStateManager.GetBoard();

            scale = DataManager.ChessPieceInfo.scale;
            // todo : blackRotation, whiteRotation change
            blackRotation = Quaternion.identity;
            whiteRotation = Quaternion.identity;
        }

        public static PhotonInstantiateManager GetInstance() => (instance ?? (instance = new PhotonInstantiateManager()));

        public void InstantiateBoard(bool onNetwork = false)
        {
            Debug.Log($"InstantiateBoard; onNetwork : {onNetwork}");
            GameObject myChessBoard;
            Transform boardTr;
            if (onNetwork)
            {
                if (PhotonNetwork.isMasterClient)
                {
                    myChessBoard = PhotonNetwork.Instantiate("ChessBoard", Vector3.zero, Quaternion.identity, 0);
                }
                else
                {
                    Debug.Log("Don't instantiate board cause you are not masterclient.");
                    return;
                }
            }
            else
            {
                myChessBoard = Instantiate(Resources.Load("ChessBoard")) as GameObject;
                myChessBoard.GetPhotonView().ObservedComponents = null;
            }
            boardTr = myChessBoard.GetComponent<Transform>();
            boardTr.position = DataManager.ChessBoard.position;
            boardTr.rotation = DataManager.ChessBoard.rotation;
            boardTr.localScale = DataManager.ChessBoard.scale;
        }

        public List<GameObject> InstantiateWhite()
        {
            List<GameObject> myPieces = new List<GameObject>();
            try
            {
                int i = 0;
                for (int z = 7; z > 5; z--)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        float distance = DataManager.ChessPieceInfo.distance;
                        Quaternion rot = DataManager.ChessPieceInfo.whiteRotation;
                        DataManager.Team team = board[x, z].Team;
                        DataManager.PieceName pieceName = board[x, z].PieceName;
                        GameObject obj = PhotonNetwork.Instantiate
                        (
                            FindObjectNameByEnum(team, pieceName),
                            new Vector3(x * distance, chessBoardStartHeight, z * distance),
                            rot,
                            (byte)0
                        );
                        // obj.GetComponent<Transform>().localScale = scale;
                        obj.name = board[x, z].PieceName.ToString();
                        // obj.AddComponent<ObjectDragger>();
                        // Transform tr = obj.GetComponent<Transform>();
                        ChessPieceState state = obj.GetComponent<ChessPieceState>();
                        // tr.LookAt(tr.position + new Vector3(0, 0, 1));
                        state.Initialize(new Vector3(x * distance, 0, z * distance), team, pieceName, DataManager.WhitePiece[i++]);
                        myPieces.Add(obj);
                    }
                }
            }
            catch (ArgumentException) { /* do nothing */ }
            return myPieces;
        }

        public List<GameObject> InstantiateBlack()
        {
            List<GameObject> myPieces = new List<GameObject>();
            try
            {
                int i = 0;
                for (int z = 0; z < 2; z++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        float distance = DataManager.ChessPieceInfo.distance;
                        Quaternion rot = DataManager.ChessPieceInfo.blackRotation;
                        DataManager.Team team = board[x, z].Team;
                        DataManager.PieceName pieceName = board[x, z].PieceName;
                        GameObject obj = PhotonNetwork.Instantiate
                        (
                            FindObjectNameByEnum(team, pieceName),
                            new Vector3(0.06f * x, chessBoardStartHeight, 0.06f * z),
                            rot,
                            (byte)0
                        );
                        // obj.GetComponent<Transform>().localScale = scale;
                        obj.name = board[x, z].PieceName.ToString();
                        // obj.AddComponent<ObjectDragger>();
                        // Transform tr = obj.GetComponent<Transform>();
                        ChessPieceState state = obj.GetComponent<ChessPieceState>();
                        // tr.LookAt(tr.position + new Vector3(0, 0, -1));
                        state.Initialize(new Vector3(x * distance, 0, z * distance), team, pieceName, DataManager.BlackPiece[i++]);
                        myPieces.Add(obj);
                    }
                }

            }
            catch (ArgumentException) { /* do nothing */ }
            return myPieces;
        }

        private string FindObjectNameByEnum(DataManager.Team team, DataManager.PieceName pieceName)
        {
            string result = "";
            switch (team)
            {
                case DataManager.Team.White:
                    result = FindWhiteObjectNameByPieceName(pieceName);
                    break;
                case DataManager.Team.Black:
                    result = FindBlackObjectNameByPieceName(pieceName);
                    break;
                case DataManager.Team.None:
                    throw new Exception("Can't return gameobject witch has NONE tag");
            }
            return result;
        }

        private string FindWhiteObjectNameByPieceName(DataManager.PieceName pieceName)
        {
            string result = "";
            switch (pieceName)
            {
                case DataManager.PieceName.King:
                    result = whiteKing;
                    break;
                case DataManager.PieceName.Queen:
                    result = whiteQueen;
                    break;
                case DataManager.PieceName.Rook:
                    result = whiteRook;
                    break;
                case DataManager.PieceName.Knight:
                    result = whiteKnight;
                    break;
                case DataManager.PieceName.Bishop:
                    result = whiteBishop;
                    break;
                case DataManager.PieceName.Pawn:
                    result = whitePawn;
                    break;
            }
            return result;
        }

        private string FindBlackObjectNameByPieceName(DataManager.PieceName pieceName)
        {
            string result = "";
            switch (pieceName)
            {
                case DataManager.PieceName.King:
                    result = blackKing;
                    break;
                case DataManager.PieceName.Queen:
                    result = blackQueen;
                    break;
                case DataManager.PieceName.Rook:
                    result = blackRook;
                    break;
                case DataManager.PieceName.Knight:
                    result = blackKnight;
                    break;
                case DataManager.PieceName.Bishop:
                    result = blackBishop;
                    break;
                case DataManager.PieceName.Pawn:
                    result = blackPawn;
                    break;
            }
            return result;
        }
    }
}