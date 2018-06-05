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

        private List<GameObject> particles = new List<GameObject>();

        public void SetCurrentObject(GameObject currentObject)
        {
            Debug.Log($"SetCurrentObject : {currentObject.name}");
            if (currentObject.CompareTag(Utility.DataManager.Tag.chessPiece))
            {
                if (this.currentObject?.name != currentObject.name)
                {
                    RemoveAllPositions();
                    this.currentObject = currentObject;
                    ShowAvailablePositions();
                }
            }
            else if (currentObject.CompareTag(Utility.DataManager.Tag.positionParticle))
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

        private void ShowAvailablePositions()
        {
            // 갈 수 있는 위치를 받아와 파티클을 생성
            Vector3 curPos = currentObject.transform.position;
            for (int i = 1; i < 4; i++)
            {
                // throw new System.NotImplementedException();
                GameObject particle = Instantiate(this.particle, new Vector3(curPos.x, curPos.y, curPos.z + -i * 0.06f), Quaternion.identity);
                particle.AddComponent<InputSender_PC>();
                // GameObject particle = Instantiate(this.particle, new Vector3(curPos.x, 0, curPos.y + i * 1.5f), Quaternion.identity);
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
                if (hit.collider.gameObject.CompareTag("ChessPiece"))
                {
                    result = hit.collider.gameObject;
                }
            }

            return result;
        }
    }
}