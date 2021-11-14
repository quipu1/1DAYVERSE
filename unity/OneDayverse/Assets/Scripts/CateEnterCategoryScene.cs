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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "Category1")
                {
                    // SceneManager.LoadScene("CateExercise");

                    PhotonNetwork.JoinOrCreateRoom("Exercise", RO, TypedLobby.Default);
                    PhotonNetwork.LoadLevel(2);
                } else if (hit.transform.gameObject.name == "Category2")
                {
                    // SceneManager.LoadScene("CateArt");
                    PhotonNetwork.JoinOrCreateRoom("Exercise", RO, TypedLobby.Default);

                }
                else if (hit.transform.gameObject.name == "Category3")
                {
                    // SceneManager.LoadScene("CateLanguage");

                    PhotonNetwork.JoinOrCreateRoom("Exercise", RO, TypedLobby.Default);

                }               

            }
        }
    }
}
