using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Rotate();
        // transform.position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, (target.position + offset), .25f);
        transform.LookAt(target.position);
    }

    void Rotate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4, Vector3.up)* offset;
    }
}
