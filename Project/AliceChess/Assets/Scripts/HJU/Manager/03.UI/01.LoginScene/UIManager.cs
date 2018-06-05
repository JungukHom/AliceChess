using UnityEngine;
using UnityEngine.UI;

using UniRx;
using Utility;
using Network;

namespace Manager.LoginScene
{
    public class UIManager : UIBehaviour
    {
        private InputField playerName;
        private Button playButton;
        private Toggle playOnVR;

        private void Start()
        {
            FindObjects();
            SetOnClick();
        }

        private void FindObjects()
        {
            playerName = FindComponent<InputField>("PlayerNameField");
            playButton = FindComponent<Button>("JoinLobbyButton");
            playOnVR = FindComponent<Toggle>("PlayOnVR");
        }

        private void SetOnClick()
        {
            playButton.onClick
                .AsObservable()
                .Subscribe(x =>
                {
                    SavePlayerName();
                    gameManager.GetComponent<NetworkManager>().JoinLobby();
                    LoadScene(playOnVR.isOn);
                });
        }

        private void SavePlayerName()
        {
            DataManager.playerName = playerName.text;
        }

        private void LoadScene(bool isVR)
        {
            DataManager.isVR = isVR;
            LoadScene(DataManager.SceneName.lobbyScene);
        }
    }
}