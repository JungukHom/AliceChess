using Utility;
using UnityEngine;

public class ChessPieceState : MonoBehaviour // , IPunObservable
{
    public Vector3 Position { get; set; }
    public DataManager.Team Team { get; set; }
    public DataManager.PieceName PieceName { get; set; }
    public DataManager.PieceDetail PieceDetail { get; set; }

    // for debug
    [SerializeField] private string information;
    // for debug

    private ChessPieceState() { }

    public void Initialize(Vector3 position, DataManager.Team team, DataManager.PieceName pieceName, DataManager.PieceDetail pieceDetail)
    {
        Position = position;
        Team = team;
        PieceName = pieceName;
        PieceDetail = pieceDetail;

        information = $"PieceDetail : {PieceDetail}, Team : {Team}, PieceName : {PieceName}";
    }

    /*
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(Position);
            stream.SendNext(Team);
            stream.SendNext(PieceName);
        }
        else
        {
            Position = (Vector3)stream.ReceiveNext();
            Team = (DataManager.Team)stream.ReceiveNext();
            PieceName = (DataManager.PieceName)stream.ReceiveNext();
        }
    }
    */
}