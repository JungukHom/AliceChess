using Photon;
using Utility;
using Manager;
using UnityEngine;
using System.Collections;

namespace Network
{
    public class NetworkManager : PunBehaviour
    {
        public string PlayerName { get; set; }

        private static readonly string VERSION = "v1.0";

        private TypedLobby defaultLobby;
        private PhotonObject photonObject;
        private PhotonInstantiateManager photonInstantiateManager;
        private ParticleManager particleManager;

        private void Awake()
        {
            DontDestroyOnLoad(GetComponent<Transform>().gameObject);

            PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = true;

            photonObject = PhotonObject.GetInstance();
            photonInstantiateManager = GetComponent<PhotonInstantiateManager>();
            particleManager = GetComponent<ParticleManager>();
        }

        private void Start()
        {
            PhotonNetwork.sendRate = 50;
            PhotonNetwork.sendRateOnSerialize = 50;
            PhotonNetwork.EnableLobbyStatistics = true;
            PhotonNetwork.ConnectUsingSettings(VERSION);

            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            while (true)
            {
                Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
                yield return new WaitForSeconds(0.5f);
            }
        }

        public override void OnConnectedToMaster()
        {
            defaultLobby = new TypedLobby("LobbyName", LobbyType.Default);
        }

        public override void OnJoinedLobby()
        {
            // 룸 정보 보여주기
        }

        public override void OnJoinedRoom()
        {
            GameObject camera = Instantiate((GameObject)Resources.Load("Camera"));
            Transform cameraTransform = camera.GetComponent<Transform>();
            cameraTransform.position = DataManager.GameCamera.position;

            SendRPC("InstantiateCommonObjects", PhotonTargets.All);

            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("Client : MasterClient");
                DataManager.MyColor = DataManager.Team.White;

                photonInstantiateManager.InstantiateWhite();
                cameraTransform.rotation = DataManager.GameCamera.whiteRotation;
            }
            else
            {
                Debug.Log("Client : GuestClient");
                DataManager.MyColor = DataManager.Team.Black;

                photonInstantiateManager.InstantiateBlack();
                cameraTransform.rotation = DataManager.GameCamera.blackRotation;

                // send rpc startGame
                SendRPC("StartGame", PhotonTargets.All);
            }

            gameObject.AddComponent<InputManager>();
        }

        public void JoinLobby()
        {
            PlayerName = GameObject.Find("UIManager").GetComponent<LoginScene.UIManager>().GetPlayerName();
            PhotonNetwork.playerName = PlayerName;
            PhotonNetwork.JoinLobby(defaultLobby);
        }

        public void JoinRoom()
        {
            RoomOptions roomOptions = new RoomOptions()
            {
                IsVisible = true,
                MaxPlayers = 10
            };
            PhotonNetwork.JoinOrCreateRoom("TestRoomName", roomOptions, defaultLobby);
        }

        public void GetRoomList()
        {
            RoomInfo[] infos = PhotonNetwork.GetRoomList();
            foreach (RoomInfo info in infos)
            {
                Debug.Log($"info.Name : {info.Name}");
                Debug.Log($"info.PlayerCount : {info.PlayerCount}");
                Debug.Log($"info.MaxPlayers : {info.MaxPlayers}");
                Debug.Log($"info.IsVisible : {info.IsVisible}");
                Debug.Log($"info.IsOpen : {info.IsOpen}");
            }
        }

        /// <summary>
        /// Internal to send an RPC on given PhotonView.
        /// </summary>
        /// <param name="view">photonView</param>
        /// <param name="methodName">string methodName</param>
        /// <param name="target">PhotonTargets.?</param>
        /// <param name="encrypt">encrypt</param>
        /// <param name="parameters">params</param>
        public void SendRPC(string methodName, PhotonTargets target, params object[] parameters)
        {
            if (!photonView)
            {
                Debug.Log($"Can't send RPC to {target.ToString()} players because photonView is null");
                return;
            }
            photonView.RPC(methodName, target, parameters);
        }

        [PunRPC]
        public IEnumerator StartGame()
        {
            yield return new WaitForSeconds(DataManager.Time.delayTime);
            Debug.Log("Game Start!");
        }

        [PunRPC]
        public void InstantiateCommonObjects()
        {
            particleManager.InstantiateParticles();
            photonInstantiateManager.InstantiateBoard(true);
        }
    }
}