using UnityEngine;

namespace Network
{
    public class RPC
    {
        private static RPC instance = null;
        private RPC() { }

        /// <summary>
        /// Get instance of RPC class.
        /// </summary>
        /// <returns></returns>
        public static RPC GetInstance() => (instance ?? new RPC());

        /// <summary>
        /// Internal to send an RPC on given PhotonView.
        /// </summary>
        /// <param name="view">photonView</param>
        /// <param name="methodName">string methodName</param>
        /// <param name="target">PhotonTargets.?</param>
        /// <param name="encrypt">encrypt</param>
        /// <param name="parameters">params</param>
        public void Send(PhotonView view, string methodName, PhotonTargets target, bool encrypt, params object[] parameters)
        {
            if (view == null)
            {
                Debug.Log($"Can't send RPC to {target.ToString()} players because photonView is null");
                return;
            }
            view.RPC(methodName, target, encrypt, parameters);
        }

        [PunRPC]
        public void RPCTestMessage(string message)
        {
            Debug.Log($"message : {message}");
        }

        /*
        [PunRPC]
        public void StartGame()
        {
            Debug.Log("Game Start!");
        }
        */
    }
}