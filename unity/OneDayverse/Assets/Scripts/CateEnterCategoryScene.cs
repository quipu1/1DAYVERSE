using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CateEnterCategoryScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RoomOptions RO = new RoomOptions();
            RO.MaxPlayers = 30;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "Category1")
                {
                    // SceneManager.LoadScene("CateExercise");

                    // PhotonNetwork.JoinOrCreateRoom("Exercise", RO, TypedLobby.Default);
                    // PhotonNetwork.LoadLevel(2);
                    PhotonNetwork.JoinRoom("Exercise");

                    // PhotonNetwork.JoinOrCreateRoom("Exercise", RO, TypedLobby.Default);
                    // PhotonNetwork.LoadLevel(2);
                } else if (hit.transform.gameObject.name == "Category2")
                {
                    // SceneManager.LoadScene("CateArt");
                    // PhotonNetwork.JoinOrCreateRoom("Exercise", RO, TypedLobby.Default);
                    PhotonNetwork.JoinRoom("Art");
                    // PhotonNetwork.JoinOrCreateRoom("Art", RO, TypedLobby.Default);
                    // PhotonNetwork.LoadLevel(3);
                    // PhotonNetwork.JoinRoom("Art");
                }
                else if (hit.transform.gameObject.name == "Category3")
                {
                    // SceneManager.LoadScene("CateLanguage");

                    // PhotonNetwork.JoinOrCreateRoom("Language", RO, TypedLobby.Default);
                    // PhotonNetwork.JoinOrCreateRoom("Language", RO, TypedLobby.Default);
                    // PhotonNetwork.LoadLevel(4);
                    PhotonNetwork.JoinRoom("Language");

                }               
                else if (hit.transform.gameObject.name=="Fountain")
                {   
                    
                    // PhotonNetwork.JoinOrCreateRoom("Lounge", RO, TypedLobby.Default);
                    PhotonNetwork.JoinOrCreateRoom("Lounge", RO, TypedLobby.Default);
                    // PhotonNetwork.JoinRoom("Lounge");

                    PhotonNetwork.LoadLevel(6);

                }

            }
        }
    }
}
