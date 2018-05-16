using UniRx;
using Network;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace LobbyScene
{
    public class UIManager : MonoBehaviour
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
                    gameManager.GetComponent<SceneManager>().LoadScene(SceneManager.GameScene, 3.0f, 3.0f);
                });
        }

        void Update()
        {

        }
    }
}