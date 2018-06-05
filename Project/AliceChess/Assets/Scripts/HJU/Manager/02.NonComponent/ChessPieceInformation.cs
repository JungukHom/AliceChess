using Utility;

namespace Manager
{
    public class ChessPieceInformation
    {
        public DataManager.Team Team { get; set; }
        public DataManager.PieceName PieceName { get; set; }

        public ChessPieceInformation(DataManager.Team team, DataManager.PieceName pieceName)
        {
            Team = team;
            PieceName = pieceName;
        }
    }
}