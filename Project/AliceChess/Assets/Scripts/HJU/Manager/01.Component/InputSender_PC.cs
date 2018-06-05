using UnityEngine;

using Manager;

public class InputSender_PC : MonoBehaviour
{
    private InputManager_PC inputManager_PC;

    private void Start()
    {
        inputManager_PC = GameObject.Find("GameManager").GetComponent<InputManager_PC>();
    }

    private void OnMouseDown()
    {
        inputManager_PC.SetCurrentObject(gameObject);
    }

    private void OnMouseUp()
    {

    }
}