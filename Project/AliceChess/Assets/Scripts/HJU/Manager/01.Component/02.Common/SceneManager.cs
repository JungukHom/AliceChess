using UnityEngine;

namespace Manager
{
    public class SceneManager : Manager
    {
        public struct SceneName
        {
            public static readonly string loginScene = "01.Login";
            public static readonly string lobbyScene = "02.Lobby";
            public static readonly string gameScene = "03.Game";
        }

        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}