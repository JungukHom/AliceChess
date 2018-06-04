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

        // components
        private ChessPieceState currentObject = null;

        private void Start()
        {
            MyColor = DataManager.MyColor;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(OnDown());
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnUp();
            }
        }

        private GameObject OnDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, rayLength))
            {
                if (rayHit.collider.gameObject.tag == DataManager.Tag.chessPiece)
                {
                    currentObject = rayHit.collider.gameObject.GetComponent<ChessPieceState>();
                }

                if (rayHit.collider.gameObject.tag == DataManager.Tag.ground)
                {
                    Debug.Log("ground");
                }

                return rayHit.transform.gameObject;
            }
            else
            {
                return null;
                // do nothing
            }
        }

        private void OnUp()
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
                GetOrCreateManager<ParticleManager>().ReSet();
                GetOrCreateManager<ParticleManager>().Show(GetOrCreateManager<AlgorithmManager>().GetList(currentObject, MyColor));
            }
            else
            {
                GetOrCreateManager<ParticleManager>().ReSet();
            }
        }

        
    }

}