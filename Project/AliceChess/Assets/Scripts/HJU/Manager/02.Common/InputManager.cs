using Network;
using Utility;
using UnityEngine;

namespace Manager
{
    public class InputManager : Manager
    {
        // properties
        public DataManager.Team MyColor { get; set; }
        // variables
        private float rayLength = 1.0f;
        private string chessPiece = "ChessPiece";

        // components
        private ChessPieceState currentObject = null;

        /*
        public static DataManager.Team Team { get; private set; }
        public static DataManager.PieceName PieceName { get; private set; }
        public static DataManager.PieceDetail PieceDetail { get; private set; }
        */

        private void Start()
        {
            MyColor = DataManager.MyColor;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, rayLength))
                {
                    
                    if (hit.collider.gameObject.tag == chessPiece)
                    {
                        currentObject = hit.collider.gameObject.GetComponent<ChessPieceState>();
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (currentObject)
                {
                    #region debug
                    Debug.Log($"PieceDetail : {currentObject.PieceDetail}");
                    Debug.Log($"PieceName : {currentObject.PieceName}");
                    Debug.Log($"Team : {currentObject.Team}");
                    #endregion
                    // todo : edit new List<Vector2>()
                    // GetOrCreateManager<ParticleManager>().Show(new List<Vector2>());
                    GetOrCreateManager<ParticleManager>().Show(GetOrCreateManager<AlgorithmManager>().GetList(currentObject, MyColor));
                }
                else
                {
                    Debug.Log($"currentObject null.");
                    GetOrCreateManager<ParticleManager>().ReSet();
                }
            }
        }
    }

}