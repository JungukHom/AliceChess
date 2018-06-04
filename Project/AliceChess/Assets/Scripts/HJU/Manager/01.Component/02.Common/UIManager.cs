using UniRx;
using Network;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.LobbyScene
{
    public class UIManager : Manager
    {
        private GameObject gameManager;
        private Button joinButton;

        void Start()
        {
            FindObjects();
        }

        private void FindObjects()
        {
            gameManager = GameObject.Find("GameManager");
            joinButton = GameObject.Find("JoinButton").GetComponent<Button>();

            SetOnClick();
        }

        private void SetOnClick()
        {
            joinButton.onClick
                .AsObservable()
                .Subscribe(x =>
                {
                    gameManager.GetComponent<NetworkManager>().JoinRoom();
                    gameManager.GetComponent<SceneManager>().LoadScene(SceneManager.SceneName.gameScene);
                });
        }

        void Update()
        {

        }
    }
}