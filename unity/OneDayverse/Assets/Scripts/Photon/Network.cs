using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Network : MonoBehaviour
{   
    public void ToLobby()
    {
        transform.position = SpawnManager.Instance.GetSpawnpoint(4).position;

    }
    public void ToCate()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
