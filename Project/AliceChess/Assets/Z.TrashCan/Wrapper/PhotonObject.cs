using UnityEngine;
using System.Collections;

namespace Network
{
    public class PhotonObject
    {
        private PhotonObject() { }
        private static PhotonObject instance = null;
        public static PhotonObject GetInstance() => (instance ?? (instance = new PhotonObject()));

        public GameObject Instantiate(string prefabName, byte group)
        {
            return PhotonNetwork.Instantiate(prefabName, Vector3.zero, Quaternion.identity, group);
        }

        public GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation, byte group)
        {
            return PhotonNetwork.Instantiate(prefabName, position, rotation, group);
        }
    }
}