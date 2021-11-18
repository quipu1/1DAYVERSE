using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class PhotonCreate : MonoBehaviourPunCallbacks
{   
    public static PhotonCreate Instance;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject PlayerListItemPrefab;
    [SerializeField] GameObject startGameButton;
    
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
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
        Debug.Log("로비에 입장");
        PhotonNetwork.NickName = "Player " + Random.Range(0,1000).ToString("0000");
    }

    // Update is called once per frame
    public void CreateRoom()
    {   
        // if (string.IsNullOrEmpty(roomNameInputField.text)) // 안 써놓으면 룸 네임이 랜덤으로 생성
        // {
        //     return;
        // }
        PhotonNetwork.CreateRoom("Exercise"); 
        // MenuManager.Instance.OpenMenu("loading");
    }
    public override void OnJoinedRoom()
    {
        // MenuManager.Instance.OpenMenu("room");
        // roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        // Player[] players = PhotonNetwork.PlayerList;
        // foreach (Transform child in playerListContent)
        // {
        //     Destroy(child.gameObject);
        // }
        // for (int i = 0; i < players.Length; i++)
        // {   

        //     Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);

        // } 
        // startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        // base.OnMasterClientSwitched(newMasterClient);
        // startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {   
        // errorText.text = "방 만들기 실패" + message;
        // MenuManager.Instance.OpenMenu("error");
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        // MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {   
        // RoomOptions RO = new RoomOptions ();
        // RO.MaxPlayers = byte.Parse("5");
        // PhotonNetwork.JoinOrCreateRoom("k", RO,TypedLobby.Default);

        PhotonNetwork.JoinRoom(info.Name);
        // MenuManager.Instance.OpenMenu("loading");
    }
    public override void OnLeftRoom()
    {
        // MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {   
        // foreach(Transform trans in roomListContent)
        // {
        //     Destroy(trans.gameObject);
        // }
        // for (int i = 0; i < roomList.Count; i++)
        // {
        //     if(roomList[i].RemovedFromList)
        //         continue;
        //     Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        // }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    public void CreateExerciseRoom()
    {   
        RoomOptions ros = new RoomOptions();
        ros.MaxPlayers = 15;

        PhotonNetwork.CreateRoom("Exercise", ros);
    }

    public void StartExerciseRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
    public void CreateArtRoom()
    {        RoomOptions ros = new RoomOptions();
        ros.MaxPlayers = 15;
        PhotonNetwork.CreateRoom("Art", ros);
    }

    public void StartArtRoom()
    {
        PhotonNetwork.LoadLevel(3);
    }
    public void CreateLanguageRoom()
    {
        RoomOptions ros = new RoomOptions();
        ros.MaxPlayers = 15;
        PhotonNetwork.CreateRoom("Language", ros);
    }

    public void StartLanguageRoom()
    {
        PhotonNetwork.LoadLevel(4);
    }

    public void CreateLoungeRoom()
    {
        RoomOptions ros = new RoomOptions();
        ros.MaxPlayers = 30;
        PhotonNetwork.CreateRoom("Lounge", ros);
    }

    public void StartLoungeRoom()
    {
        PhotonNetwork.LoadLevel(6);
    }
    
}
