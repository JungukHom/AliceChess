using System.Collections;

using static UnityEngine.Debug;

namespace MainScene.LSJ
{
    public class ChessPiece // MainScene.LSJ.ChessPiece
    {
        public ChessPiece() { }

        public IEnumerator Move()
        {
            Log($"Started Coroutine : LSJ.ChessPiece.Move()");
            yield return null;
        }
    }
}