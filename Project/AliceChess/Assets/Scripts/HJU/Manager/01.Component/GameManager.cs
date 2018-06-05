using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : Manager
    {
        private void Start()
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
    }
}