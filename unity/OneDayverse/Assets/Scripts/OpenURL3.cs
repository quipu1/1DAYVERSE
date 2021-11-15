using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL3 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.OpenURL("http://iogames.space/slither-io");
        }
    }
}
