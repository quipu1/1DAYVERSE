using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPick : MonoBehaviour
{
    string onScreen = "start";
    public Button StopBtn;
    public Button GoBtn;
    // Start is called before the first frame update
    void Start()
    {
        StopBtn.onClick.AddListener(StopBtnClick);
        GoBtn.onClick.AddListener(GoBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);
                Debug.Log("onscreen" + onScreen);
                if (onScreen != hit.transform.gameObject.name)
                {
                    if (onScreen != "start") {
                        GameObject.Find("OnePick").transform.Find($"{onScreen}").gameObject.SetActive(false);
                    }
                    
                    GameObject.Find("OnePick").transform.Find($"{hit.transform.gameObject.name}").gameObject.SetActive(true);
                    onScreen = hit.transform.gameObject.name;
                }
               
            }
        }
    }

    private void StopBtnClick()
    {
        if (onScreen != "start")
        {
            GameObject.Find("OnePick").transform.Find($"{onScreen}").gameObject.SetActive(false);
        }               
        GameObject.Find("ShowMyInfo").transform.Find("MyInfoCanvas").gameObject.SetActive(true);
        GameObject.Find("CharacterChange").transform.Find("CharacterCanvas").gameObject.SetActive(false);
        GameObject.Find("CharacterChange").transform.Find("ControlCharacters").gameObject.SetActive(false);
    }

    private void GoBtnClick()
    {
        if (onScreen != "start")
        {
            GameObject.Find("OnePick").transform.Find($"{onScreen}").gameObject.SetActive(false);
        }
        GameObject.Find("ShowMyInfo").transform.Find("MyInfoCanvas").gameObject.SetActive(true);
        GameObject.Find("CharacterChange").transform.Find("CharacterCanvas").gameObject.SetActive(false);
        GameObject.Find("CharacterChange").transform.Find("ControlCharacters").gameObject.SetActive(false);
    }
}
