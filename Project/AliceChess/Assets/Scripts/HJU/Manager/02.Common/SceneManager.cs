using UnityEngine;

namespace Manager
{
    public class SceneManager : Manager
    {
        public static readonly string LoginScene = "01.Login";
        public static readonly string LobbyScene = "02.Lobby";
        public static readonly string GameScene = "03.Game";

        public void LoadScene(string sceneName, float fadeOutTime, float fadeInTime)
        {
            /*
            CanvasManager manager = GetOrCreateManager<CanvasManager>();
            manager.FadeOut(fadeOutTime, (callback) =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            });
            manager.FadeIn(fadeInTime);
            */
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}