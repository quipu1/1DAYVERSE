using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL5 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.OpenURL("http://iogames.space/raid-land-io");
        }
    }
}
