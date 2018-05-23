using Utility;
using UnityEngine;

namespace Manager
{
    public class LatticeManager : Manager
    {
        private float distance;
        private float halfDistance;
        private float chessBoardStartHeight = 0f; // todo : change value

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