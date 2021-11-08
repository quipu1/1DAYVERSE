using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cate_PasswordModal : MonoBehaviour
{
    public GameObject Panel;
    public GameObject WrongPanel;
    public GameObject Player;

    public Button checkButton;
    public InputField PasswordInput;

    public GameObject SmallClassTarget;
    public GameObject MidClassTarget;
    public GameObject LargeClassTarget;
    public GameObject LoungeTarget;
    GameObject Target;

    public string className;
    public string answer;

    public void OnMouseDown()
    {
        bool isActive = Panel.activeSelf;
        className = transform.parent.name;
        Target = new GameObject("new GameObject=");
        checkButton.onClick.AddListener(UpdateCheckedClass);

        if (!isActive)
        {
            Panel.SetActive(!isActive);
        }
    }

    public void UpdateCheckedClass()
    {
        if (className == "class door_1")
        {
            answer = "123";
            CheckPassword();
        }
        else if (className == "class door_2")
        {
            answer = "456";
            CheckPassword();
        }
        else if (className == "class door_3")
        {
            answer = "789";
            CheckPassword();
        }
        else if (className == "lounge")
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
        print("¿Ãµø");
        print(Target);
        Player.transform.position = Target.transform.position;
    }
}
