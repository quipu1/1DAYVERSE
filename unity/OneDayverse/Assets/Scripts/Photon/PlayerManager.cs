 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{   

    PhotonView PV;

    GameObject controller;
    // Start is called before the first frame update
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }
    // Update is called once per frame
    void CreateController()
    {       
        // Debug.Log("플레이어 컨트롤러 생성");
        Transform spawnpoint =SpawnManager.Instance.GetSpawnpoint(2);
        // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position,  spawnpoint.rotation, 0, new object[] {PV.ViewID});

    }

    void CreateLargeClassController()
    {       
        // Debug.Log("플레이어 컨트롤러 생성");
        Transform spawnpoint =SpawnManager.Instance.GetSpawnpoint(4);
        // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position,  spawnpoint.rotation, 0, new object[] {PV.ViewID});

    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }

    public void goToLargeClass()
    {
        PhotonNetwork.Destroy(controller);
        CreateLargeClassController();
    }
}
