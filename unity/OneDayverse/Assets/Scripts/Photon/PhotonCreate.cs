using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonCreate : MonoBehaviourPunCallbacks
{      


    public static PhotonCreate Instance;
    void Awake()
    {
        Instance = this;
    }
    void Start()

    {
        Debug.Log("서버에 접속 중");
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {   
        Debug.Log("서버에 접속 성공");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {   
        // MenuManager.Instance.OpenMenu("title");
        PhotonNetwork.NickName = "Player " + Random.Range(0,1000).ToString("0000");
        Debug.Log("로비에 입장" + PhotonNetwork.NickName);
    }
}
