using Utility;
using UnityEngine;

public class ChessPieceState : MonoBehaviour // , IPunObservable
{
    public Vector3 Position { get; set; }
    public DataManager.Team Team { get; set; }
    public DataManager.PieceName PieceName { get; set; }
    public DataManager.PieceDetail PieceDetail { get; set; }

    private ChessPieceState() { }

    public void Initialize(Vector3 position, DataManager.Team team, DataManager.PieceName pieceName, DataManager.PieceDetail pieceDetail)
    {
        Position = position;
        Team = team;
        PieceName = pieceName;
        PieceDetail = pieceDetail;
    }
}