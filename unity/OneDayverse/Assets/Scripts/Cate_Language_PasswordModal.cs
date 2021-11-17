using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
public class Cate_Language_PasswordModal : MonoBehaviourPunCallbacks
{   

    public GameObject Panel;
    public GameObject LoungePanel;
    public GameObject WrongPanel;
    public GameObject Player;

    public Button checkButton;
    public Button LoungeButton;
    public InputField PasswordInput;

    public GameObject SmallClassTarget;
    public GameObject MidClassTarget;
    public GameObject LargeClassTarget;
    public GameObject LoungeTarget;
    GameObject Target;
    PhotonView PV;
    PlayerManager playerManager;

    PlayerController playerController;

    void Awake()
    {
        // playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
        // PV = GetComponent<PhotonView>();
        // playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();


    }
    private void Start()
    {   
        playerController = GetComponent<PlayerController>();

        GameObject Target = new GameObject("new GameObject");
    }

    public string className;
    public string answer;

    public void OnMouseDown()
    {
        className = transform.parent.name;

        if (className == "lounge")
        {
            bool isActive = LoungePanel.activeSelf;

            Panel.GetComponentsInChildren<Text>()[0].text = "Lounge";
            Panel.GetComponentsInChildren<Text>()[1].text = "";

            if (!isActive)
            {
                LoungePanel.SetActive(!isActive);
            }

            LoungeButton.onClick.AddListener(UpdateCheckedClass);
        }
        else
        {
            bool isActive = Panel.activeSelf;

            if (className == "class door_1")
            {
                Panel.GetComponentsInChildren<Text>()[0].text = className;
                Panel.GetComponentsInChildren<Text>()[1].text = className + "tutor";
            }
            else if (className == "class door_2")
            {
                Panel.GetComponentsInChildren<Text>()[0].text = className;
                Panel.GetComponentsInChildren<Text>()[1].text = className + "tutor";
            }
            else if (className == "class door_3")
            {
                Panel.GetComponentsInChildren<Text>()[0].text = className;
                Panel.GetComponentsInChildren<Text>()[1].text = className + "tutor";
            }
        
            checkButton.onClick.AddListener(UpdateCheckedClass);

            if (!isActive)
            {
                Panel.SetActive(!isActive);
            }
        }
    }

    public void UpdateCheckedClass()
    {
        if (className == "class door_1")
        {
            answer = "123";
        }
        else if (className == "class door_2")
        {
            answer = "456";
        }
        else if (className == "class door_3")
        {
            answer = "789";
        }

        if (PasswordInput.text != answer)
        {
            WrongPanel.SetActive(true);
        }
        else
        {
            WrongPanel.SetActive(false);
            CheckPassword();
        }

        if (className == "lounge")
        {
            Target = LoungeTarget;
            playMove();
        }
    }

    void CheckPassword()

    {
        if (PasswordInput.text != answer)
        {
            WrongPanel.SetActive(true);
        }

        else 
        {
            if (className == "class door_1")
            {   
                // playerController.moveToLargeClass();
                // playMove();
                
                // Transform spawnpoint =SpawnManager.Instance.GetSpawnpoint(2);
                // Debug.Log(PV.ViewID);

                // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"),spawnpoint.position,spawnpoint.rotation,0, new object[] {PV.ViewID});
                
                // transform.position = spawnpoint.position;
                // playerController.moveToLargeClass();
                // GameObject.Find("PlayerManager").GetComponent<PlayerManager>().goToLargeClass();
                // playerManager.Die();
 
                playerController = GetComponent<PlayerController>();
            }
            else if (className == "class door_2")
            {
                // playerManager.Die();
                Transform spawnpoint =SpawnManager.Instance.GetSpawnpoint(1);
                Vector3 move =  spawnpoint.position;
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position,  spawnpoint.rotation, 0, new object[] {PV.ViewID});
            }
            else if (className == "class door_3")
            {
                // playerManager.Die();    
                Transform spawnpoint =SpawnManager.Instance.GetSpawnpoint(0);
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position,  spawnpoint.rotation, 0, new object[] {PV.ViewID});

            }
        }
    }

    public void playMove()
    {   

        Player.transform.position = Target.transform.position;
    }
}
