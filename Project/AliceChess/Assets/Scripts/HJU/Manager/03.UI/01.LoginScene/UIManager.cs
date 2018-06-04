using UniRx;
using Network;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.LoginScene
{
    public class UIManager : Manager
    {
        private GameObject gameManager;
        private InputField playerName;
        private Button playButton;

        public string GetPlayerName() => (playerName.text ?? $"User:{Random.Range(0, 9999)}");

        private void Start()
        {
            FindObjects();
        }

        private void FindObjects()
        {
            gameManager = GameObject.Find("GameManager");
            playerName = GameObject.Find("PlayerName")?.GetComponent<InputField>();
            playButton = GameObject.Find("PlayButton")?.GetComponent<Button>();

            SetOnClick();
        }

        private void SetOnClick()
        {
            playButton.onClick
                .AsObservable()
                .Subscribe(x =>
                {
                    gameManager.GetComponent<NetworkManager>().JoinLobby();
                    gameManager.GetComponent<SceneManager>().LoadScene(SceneManager.SceneName.lobbyScene);
                });
        }
    }
}