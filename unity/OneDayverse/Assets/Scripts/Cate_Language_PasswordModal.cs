using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
public class Cate_Language_PasswordModal : MonoBehaviourPunCallbacks
{
    [DllImport("__Internal")] private static extern void setLectureCate(string data);
    [DllImport("__Internal")] private static extern void setLectureId(string data);

    public GameObject Panel;
    public GameObject LoungePanel;
    public GameObject WrongPanel;
    GameObject Player;

    public Button checkButton;
    public Button LoungeButton;
    public InputField PasswordInput;

    GameObject SmallClassTarget;
    GameObject MidClassTarget;
    GameObject LargeClassTarget;
    GameObject LoungeTarget;

    string currentUsername;
    GameObject Target;
    PhotonView PV;
    PlayerManager playerManager;

    PlayerController playerController;
    Scene scene;

    [DllImport("__Internal")]
    private static extern string GetUsername();

    private void Start()
    {
        SmallClassTarget = GameObject.Find("SmallClassSpawnpoint");
        MidClassTarget = GameObject.Find("MediumClassSpawnpoint ");
        LargeClassTarget = GameObject.Find("LargeClassSpawnpoint");

        playerController = GetComponent<PlayerController>();

        GameObject Target = new GameObject("new GameObject");
        scene = SceneManager.GetActiveScene();
    }

    public string className;
    public string answer;

    public void OnMouseDown()
    {

        currentUsername = "oxoxo";
        Player = GameObject.Find(currentUsername);

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

                #if UNITY_WEBGL
                    setLectureCate(data: scene.name);
                    setLectureId(data: "101");
                #endif
            }
            else if (className == "class door_2")
            {
                Panel.GetComponentsInChildren<Text>()[0].text = className;
                Panel.GetComponentsInChildren<Text>()[1].text = className + "tutor";

                #if UNITY_WEBGL
                    setLectureCate(data: scene.name);
                    setLectureId(data: "102");
                #endif
            }
            else if (className == "class door_3")
            {
                Panel.GetComponentsInChildren<Text>()[0].text = className;
                Panel.GetComponentsInChildren<Text>()[1].text = className + "tutor";

                #if UNITY_WEBGL
                    setLectureCate(data: scene.name);
                    setLectureId(data: "103");
                #endif

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
                Target = LargeClassTarget;
                playMove();
            }
            else if (className == "class door_2")
            {
                Target = MidClassTarget;
                playMove();
            }
            else if (className == "class door_3")
            {
                Target = SmallClassTarget;
                playMove();
            }
        }
    }

    public void playMove()
    {
        print(Player);
        print(Target);
        Player.transform.position = Target.transform.position;
    }
}
