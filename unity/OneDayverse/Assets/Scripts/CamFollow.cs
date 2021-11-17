using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CamFollow : MonoBehaviour
{

    GameObject target;
    Transform traget_transform;
    public Vector3 offset;
    string currentUsername;

    [DllImport("__Internal")]
    private static extern string GetUsername();

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        currentUsername = "oxoxo";
        target = GameObject.Find(currentUsername);

        if (target != null)
        {
            traget_transform = target.transform;
            // transform.position = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, (traget_transform.position + offset), .25f);
            transform.LookAt(new Vector3(traget_transform.position.x, traget_transform.position.y+1.5f, traget_transform.position.z));

        }
    }

    void Rotate()
    {
        // offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4, Vector3.up)* offset;
    }
}
