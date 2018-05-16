using System;
using UnityEngine;
using System.Collections;

// using static UnityEngine.Debug;

namespace MainScene
{
    namespace HJU
    {
        [RequireComponent(typeof(CapsuleCollider))]
        public class ChessPiece : MonoBehaviour, IChessPiece // MainScene.HJU.ChessPiece
        {
            #region IChessPiece Properties
            public bool IsClicked { get; set; }
            public PhotonView Controller { get; set; }
            public Vector3 Position { get; set; }
            public Vector3 LerpedPosition { get; set; }
            public Team Team { get; set; }
            public PieceInfo PieceInfo { get; set; }
            #endregion

            #region Local Variables
            new private Transform transform;
            private LSJ.ChessPiece lsjPiece;
            #endregion

            void Awake()
            {
                transform = GetComponent<Transform>();
                // lsjPiece = new LSJ.ChessPiece();
            }

            void Start()
            {
                Debug.Log($"Spawned {name}.");
            }

            void Update()
            {
                transform.position = LerpedPosition;
            }

            public void OnMouseDown() { }

            public void OnMouseUp() { }

            public void InitializePieceInfo(Team team, PieceInfo info)
            {
                Team = team;
                PieceInfo = info;
            }
        }
    }
}