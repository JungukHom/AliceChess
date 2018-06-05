using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class UIBehaviour : Manager
    {
        protected void ShowPopUP(string message)
        {
            throw new System.NotImplementedException();
        }

        protected void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
