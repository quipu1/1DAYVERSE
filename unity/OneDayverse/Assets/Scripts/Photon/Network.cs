using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.InteropServices;

public class Network : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern string GetUsername();

    GameObject Player;
    string currentUsername;
    GameObject LobbyTarget;

    private void Start()
    {
        currentUsername = GetUsername();
        // currentUsername = "oxoxo";
        Player = GameObject.Find(currentUsername);
        LobbyTarget = GameObject.Find("LobbySpawnpoint");
    }
    public void ToLobby()
    {
        Player.transform.position = LobbyTarget.transform.position;

    }
    public void ToCate()
    {
        
        PhotonNetwork.LoadLevel(1);
        PhotonNetwork.LeaveRoom();
    }
}
