using Utility;
using Network;
using UnityEngine;
using System.Collections.Generic;

namespace Manager
{
    public class ParticleManager : Manager
    {
        // private ParticleManager() { }
        // private static ParticleManager instance = null;
        // public static ParticleManager GetInstance() => (instance ?? (instance = new ParticleManager()));

        GameObject particle;
        private GameObject[,] particles = new GameObject[8, 8];

        private float distance = DataManager.ChessPieceInfo.distance;
        private float chessBoardStartHeight = DataManager.ChessBoardInfo.startHeight;

        public void SetParticle(GameObject particle)
        {
            this.particle = particle;
        }

        public void InstantiateParticles()
        {
            Vector3 position;
            Quaternion rotation = Quaternion.identity;
            GameObject parent = new GameObject("Particles");
            for (int z = 0; z < 8; z++)
            {
                for (int x = 0; x < 8; x++)
                {
                    position = new Vector3(x * distance, chessBoardStartHeight, z * distance);
                    GameObject particle = Instantiate(this.particle, position, rotation, parent.transform); // (GameObject)Resources.Load("Prefab")
                    particle.SetActive(false);
                    particles[x, z] = particle;
                    // particles[x, z].Stop();
                }
            }
        }

        // todo : object pool 방식으로 최적화하기
        public void ReSet()
        {
            for (int z = 0; z < 8; z++)
            {
                for (int x = 0; x < 8; x++)
                {
                    particles[x, z].SetActive(false);
                }
            }
        }

        public void Show(List<Vector2> positions)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                Vector2 pos = positions[i];
                int x = (int)pos.x;
                int z = (int)pos.y;
                particles[x, z].SetActive(true);
            }
        }
    }
}