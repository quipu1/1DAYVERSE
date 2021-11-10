using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyPageSceneControl : MonoBehaviour
{
  
    public Button ShowCharacterBtn;
    public Button ShowPrevSceneBtn;
    public static string prevSceneName = DontDestroyObject.prevScene;


    // Start is called before the first frame update
    void Start()
    {
        ShowCharacterBtn.onClick.AddListener(ShowCharacterBtnClick);
        ShowPrevSceneBtn.onClick.AddListener(ShowPrevSceneBtnClick);
    }

    public void ShowPrevSceneBtnClick()
    {
        Debug.Log("preSceneName" + prevSceneName);
        SceneManager.LoadScene($"{prevSceneName}");
    }

    // Update is called once per frame
    private void ShowCharacterBtnClick()
    {
        GameObject.Find("ShowMyInfo").transform.Find("MyInfoCanvas").gameObject.SetActive(false);
        GameObject.Find("CharacterChange").transform.Find("CharacterCanvas").gameObject.SetActive(true);
        GameObject.Find("CharacterChange").transform.Find("ControlCharacters").gameObject.SetActive(true);
    }

    

}
