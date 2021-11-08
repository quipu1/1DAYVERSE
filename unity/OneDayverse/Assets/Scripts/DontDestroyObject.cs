using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DontDestroyObject : MonoBehaviour
{
    public static string prevScene;
   
    void Start()
    { 
        var obj = FindObjectsOfType<DontDestroyObject>(); 
        if (obj.Length == 1) 
        { 
            DontDestroyOnLoad(gameObject); 
        } 
        else 
        { 
            Destroy(gameObject); 
        }
        
    }

    public void ShowMyPageBtnClick()
    {
        prevScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
    }
}
