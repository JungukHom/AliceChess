using Utility;
using UnityEngine;

namespace Manager
{
    public class PositionManager : Manager
    {
        private float distance;
        private float halfDistance;

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// Only for this project
        /// </summary>
        public void Initialize()
        {
            distance = 0.06f;
            halfDistance = distance / 2;
        }

        public void Initialize(float xStart, float yStart, float xLength, float yLength, float distance, float yPos)
        {
            this.distance = distance;
            this.halfDistance = distance / 2;
        }

        public Vector3 GetPosition(float x, float y, float z)
        {
            return new Vector3(GetX(x), DataManager.ChessBoardInfo.startHeight, GetZ(z));
        }

        public Vector3 ToRealPosition(float x, float z)
        {
            float distance = DataManager.ChessPieceInfo.distance;
            return new Vector3(x * distance, DataManager.ChessBoardInfo.startHeight, z * distance);
        }

        public Vector3 ToNormalPosition(float x, float y, float z)
        {
            float distance = DataManager.ChessPieceInfo.distance;
            return new Vector3(x / distance, DataManager.ChessBoardInfo.startHeight, z / distance);
        }

        private float GetX(float position)
        {
            float result = 0;
            int quotient = (int)(position / distance);
            float remainder = position % distance;

            if (remainder < halfDistance)
            {
                result = distance * quotient;
            }
            else if (remainder >= halfDistance)
            {
                result = distance * (quotient + 1);
            }
            else
            {
                Debug.Log($"error on GetX(); remainder : {remainder}");
            }

            return result;
        }

        private float GetZ(float position)
        {
            float result = 0;
            int quotient = (int)(position / distance);
            float remainder = position % distance;

            if (remainder < halfDistance)
            {
                result = distance * quotient;
            }
            else if (remainder >= halfDistance)
            {
                result = distance * (quotient + 1);
            }
            else
            {
                Debug.Log($"error on GetY(); remainder : {remainder}");
            }
            return result;
        }
    }
}