using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL2 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.OpenURL("https://iogames.space/squid-game-io");
        }
    }
}
