using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DontDestroyObject : MonoBehaviour
{
    public static DontDestroyObject instance;
    public static string prevScene;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
           
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
           
    }      

    public void ShowMyPageBtnClick()
    {
        prevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MyPage");
    }

}
