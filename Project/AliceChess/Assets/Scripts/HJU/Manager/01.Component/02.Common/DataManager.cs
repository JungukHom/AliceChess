using UnityEngine;

namespace Utility
{
    public class DataManager
    {
        private DataManager() { }

        public static Team MyColor { get; set; } = Team.None;

        public struct Time
        {
            public static readonly float delayTime = 3.0f;
        }

        public struct Tag
        {
            public static readonly string ground = "Ground";
            public static readonly string chessPiece = "ChessPiece";
            public static readonly string positionParticle = "PositionParticle";
        }

        public struct ChessBoard
        {
            public static readonly Vector3 position = new Vector3(0.21f, ChessBoardInfo.startHeight, 0.21f);
            public static readonly Quaternion rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            public static readonly Vector3 scale = new Vector3(1, 1, 1);
        }

        public struct ChessBoardInfo
        {
            public static readonly int chessBoardMinimum = 0;
            public static readonly int chessBoardMaximum = 7;
            public static readonly float startHeight = 0.0f;
        }

        public struct ChessPieceInfo
        {
            public static readonly Quaternion whiteRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            public static readonly Quaternion blackRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            public static readonly Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
            public static readonly float distance = 0.06f;
        }

        public struct GameCamera
        {
            public static readonly Vector3 position = new Vector3(0.21f, 0.5f, 0.21f);
            public static readonly Quaternion whiteRotation = Quaternion.Euler(new Vector3(90, 0, 180));
            public static readonly Quaternion blackRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        }

        public enum Team { White, Black, None }

        public enum PieceName { King, Queen, Knight, Bishop, Rook, Pawn, None }

        public enum PieceDetail
        {
            LeftRook, LeftKnight, LeftBishop, King, Queen, RightBishop, RightKnight, RightRook,
            Pawn1, Pawn2, Pawn3, Pawn4, Pawn5, Pawn6, Pawn7, Pawn8
        }

        public static PieceName[] pieceNameArray =
        {
            PieceName.Rook,
            PieceName.Knight,
            PieceName.Bishop,
            PieceName.King,
            PieceName.Queen,
            PieceName.Bishop,
            PieceName.Knight,
            PieceName.Rook
        };

        public static PieceDetail[] WhitePiece =
        {
            PieceDetail.RightRook, PieceDetail.RightKnight, PieceDetail.RightBishop, PieceDetail.King,
            PieceDetail.Queen, PieceDetail.LeftBishop, PieceDetail.LeftKnight, PieceDetail.LeftRook,
            PieceDetail.Pawn8, PieceDetail.Pawn7, PieceDetail.Pawn6, PieceDetail.Pawn5,
            PieceDetail.Pawn4, PieceDetail.Pawn3, PieceDetail.Pawn2, PieceDetail.Pawn1
        };

        public static PieceDetail[] BlackPiece =
        {
            PieceDetail.Pawn1, PieceDetail.Pawn2, PieceDetail.Pawn3, PieceDetail.Pawn4,
            PieceDetail.Pawn5, PieceDetail.Pawn6, PieceDetail.Pawn7, PieceDetail.Pawn8,
            PieceDetail.LeftRook, PieceDetail.LeftKnight, PieceDetail.LeftBishop, PieceDetail.King,
            PieceDetail.Queen, PieceDetail.RightBishop, PieceDetail.RightKnight, PieceDetail.RightRook
        };
    }
}