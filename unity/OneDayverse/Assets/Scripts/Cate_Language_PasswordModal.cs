using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cate_Language_PasswordModal : MonoBehaviour
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

    private void Start()
    {
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
                Target = SmallClassTarget;
                playMove();
            }
            else if (className == "class door_2")
            {
                Target = MidClassTarget;
                playMove();
            }
            else if (className == "class door_3")
            {
                Target = LargeClassTarget;
                playMove();
            }
        }
    }

    public void playMove()
    {
        Player.transform.position = Target.transform.position;
    }
}
