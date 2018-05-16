using UnityEngine;
using Network;

public class RPCTest : Photon.MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"spacebar keydown");
            /*
            Network.RPC.GetInstance().Send
            (
                // GameObject.Find("GameManager").GetComponent<NetworkManager>().GetPhotonView(),
                photonView,
                "RPCTestMessage",
                PhotonTargets.All,
                false,
                "RPC test message."
            );
            */
            NetworkManager gm = GameObject.Find("GameManager").GetComponent<NetworkManager>();
            gm.SendRPC("RPCTestMessage", PhotonTargets.All, false, "RPC test message.");
        }
    }
}
