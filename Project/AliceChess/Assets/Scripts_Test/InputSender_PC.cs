using UnityEngine;

using Manager;

public class InputSender_PC : MonoBehaviour
{
    public InputManager_PC inputManager_PC;

    private void OnMouseDown()
    {
        inputManager_PC.SetCurrentObject(gameObject);
    }

    private void OnMouseUp()
    {

    }
}
