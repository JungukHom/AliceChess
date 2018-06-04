using UnityEngine;

public interface IChessPieceInfo
{
    /*
    bool IsClicked { get; set; }
    PhotonView Controller { get; set; }

    Vector3 Position { get; set; }
    Vector3 LerpedPosition { get; set; }

    Team Team { get; set; }
    PieceInfo PieceInfo { get; set; }
    */
   
    /*
    void OnMouseDown();
    void OnMouseUp();

    void InitializePieceInfo(Team team, PieceInfo info);
    */
}

public enum Team { WHITE, BLACK }
public enum Piece
{
    King, Queen,
    Rook_L, Rook_R,
    Knight_L, Knight_R,
    Bishop_L, Bishop_R,
    Pawn1, Pawn2, Pawn3, Pawn4,
    Pawn5, Pawn6, Pawn7, Pawn8
}