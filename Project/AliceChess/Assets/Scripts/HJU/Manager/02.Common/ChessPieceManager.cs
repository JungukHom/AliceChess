using Utility;

namespace Manager
{
    public class ChessPieceManager
    {
        public DataManager.Team Team { get; set; }
        public DataManager.PieceName PieceName { get; set; }

        public ChessPieceManager(DataManager.Team team, DataManager.PieceName pieceName)
        {
            Team = team;
            PieceName = pieceName;
        }
    }
}