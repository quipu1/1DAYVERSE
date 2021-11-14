using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class UserNameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView playerPV;

    [SerializeField] TMP_Text text;

    void Start()
    {   
        if(playerPV.IsMine)
        {
            gameObject.SetActive(false);
        }
        text.text = playerPV.Owner.NickName;

    }


}
