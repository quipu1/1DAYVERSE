using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Network : MonoBehaviour
{
    public void ToCate()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
