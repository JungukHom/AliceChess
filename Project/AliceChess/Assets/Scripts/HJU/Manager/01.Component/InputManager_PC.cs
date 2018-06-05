using UnityEngine;
using System.Collections.Generic;

using Utility;

namespace Manager
{
    public class InputManager_PC : Manager
    {
        public GameObject particle;

        private Ray ray;
        private RaycastHit hit;
        private GameObject currentObject = null;

        private AlgorithmManager algorithmManager;
        private PositionManager positionManager;

        private List<GameObject> particles = new List<GameObject>();

        private void Start()
        {
            algorithmManager = GetOrCreateManager<AlgorithmManager>();
            positionManager = GetOrCreateManager<PositionManager>();
        }

        public void SetCurrentObject(GameObject currentObject)
        {
            if (currentObject.CompareTag(DataManager.Tag.chessPiece))
            {
                if (this.currentObject?.name != currentObject.name)
                {
                    RemoveAllPositions();
                    this.currentObject = currentObject;

                    ChessPieceState pieceState = currentObject.GetComponent<ChessPieceState>();
                    List<Vector2> availablePosition = algorithmManager.GetList(pieceState, DataManager.MyTeam);
                    

                    ShowAvailablePositions(availablePosition);
                }
            }
            else if (currentObject.CompareTag(DataManager.Tag.positionParticle))
            {
                Debug.Log(currentObject.transform.position);
                RemoveAllPositions();
                this.currentObject = null;
            }
            else
            {
                RemoveAllPositions();
                this.currentObject = null;
            }
        }

        private void ShowAvailablePositions(List<Vector2> positions)
        {
            // 갈 수 있는 위치를 받아와 파티클을 생성
            Vector3 curPos = currentObject.transform.position;
            for (int i = 0; i < positions.Count; i++)
            {
                Vector3 myPosition = positionManager.ToRealPosition(positions[i].x, positions[i].y);

                Quaternion rotation;
                if (DataManager.MyTeam == DataManager.Team.Black)
                {
                    rotation = DataManager.ChessPieceInfo.blackRotation;
                }
                else
                {
                    rotation = DataManager.ChessPieceInfo.whiteRotation;
                }
                GameObject particle = Instantiate(this.particle, myPosition, rotation);

                particle.AddComponent<InputSender_PC>();
                particles.Add(particle);
            }
        }

        private void RemoveAllPositions()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                Destroy(particles[i]);
            }
            particles.Clear();
        }

        private void MouseUp()
        {
        }

        private GameObject OnCurrentObjectNull()
        {
            GameObject result = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag(DataManager.Tag.chessPiece))
                {
                    result = hit.collider.gameObject;
                }
            }

            return result;
        }
    }
}