using UniRx;
using Network;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace LoginScene
{
    public class UIManager : Manager.Manager
    {
        private GameObject gameManager;
        private InputField playerName;
        private Button playButton;

        public string GetPlayerName() => (playerName.text ?? $"NoName{Random.Range(0, 9999)}");

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
                    gameManager.GetComponent<SceneManager>().LoadScene(SceneManager.LobbyScene, 3.0f, 3.0f);
                });
        }
    }
}