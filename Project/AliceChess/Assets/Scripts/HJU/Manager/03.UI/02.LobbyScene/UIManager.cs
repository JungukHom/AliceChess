using UnityEngine;
using UnityEngine.UI;

using UniRx;
using Network;
using Utility;

namespace Manager.LobbyScene
{
    public class UIManager : UIBehaviour
    {
        private Text lobbyName;
        private Text nickName;

        // 방 목록, 방 정보 구현

        private Button backToLoginButton;
        private Button createButton;
        private Button joinButton;

        private Canvas createRoomCanvas;
        // CreateRoomCanvas
        private InputField newRoomField;
        private Button createAndJoinButton;
        private Button cancelButton;

        private NetworkManager networkManager;

        void Start()
        {
            networkManager = gameManager.GetComponent<NetworkManager>();

            FindObjects();
            SetOnClick();

            lobbyName.text = "DefaultLobby";
            nickName.text = DataManager.playerName;
            createRoomCanvas.enabled = false;
        }

        private void FindObjects()
        {
            lobbyName = FindComponent<Text>("LobbyName");
            nickName = FindComponent<Text>("NickName");

            // 방 목록, 방 정보 찾기

            backToLoginButton = FindComponent<Button>("BackToLoginButton");
            createButton = FindComponent<Button>("CreateRoomButton");
            joinButton = FindComponent<Button>("JoinRoomButton");

            createRoomCanvas = FindComponent<Canvas>("CreateRoomCanvas");

            newRoomField = FindComponent<InputField>("NewRoomField");
            createAndJoinButton = FindComponent<Button>("CreateAndJoinButton");
            cancelButton = FindComponent<Button>("CancelButton");
        }

        private void SetOnClick()
        {
            backToLoginButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    throw new System.NotImplementedException();
                    // LoadScene(DataManager.SceneName.loginScene);
                });

            createButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    createRoomCanvas.enabled = true;
                });

            createAndJoinButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    string roomName = newRoomField.text;
                    LoadScene();
                    networkManager.CreateRoom(roomName);
                });

            joinButton.onClick
                .AsObservable()
                .Subscribe(x =>
                {
                    throw new System.NotImplementedException();
                    // LoadScene();
                    // networkManager.JoinRoom("abc"); 클릭된 리스트로 방 Join
                });

            cancelButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    createRoomCanvas.enabled = false;
                });
        }

        private void LoadScene()
        {
            bool isVR = DataManager.isVR;
            if (isVR)
            {
                LoadScene(DataManager.SceneName.gameScene_VR);
            }
            else
            {
                LoadScene(DataManager.SceneName.gameScene_PC);
            }
            
        }
    }
}