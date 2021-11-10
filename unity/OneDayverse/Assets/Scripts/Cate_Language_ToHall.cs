using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cate_Language_ToHall : MonoBehaviour
{
    public GameObject Player;
    public Button CateButton;

    public void Start()
    {
        CateButton.onClick.AddListener(Move);
    }

    public void Move()
    {
        Player.transform.position = new Vector3(0, 0, 0);
    }
}
