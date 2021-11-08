using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CharacterPick : MonoBehaviour
{
    string onScreen = "start";
    public Button StopBtn;
    public Button GoBtn;

    public class User
    {
        public string username;
        public string character;
    }
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

    public IEnumerator SendInfo(string json)
    {
        UnityWebRequest request;
        using (request = UnityWebRequest.Post("https://jsonplaceholder.typicode.com/todos/1", json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            Debug.Log("¿©±â" + request.downloadHandler.text);

        }

    }

    private void GoBtnClick()
    {
        if (onScreen != "start")
        {
            GameObject.Find("OnePick").transform.Find($"{onScreen}").gameObject.SetActive(false);
        }
        Debug.Log(onScreen);

        User userInfo = new User
        {
            username = "idididid2",
            character = onScreen,
        };

        string json = JsonUtility.ToJson(userInfo);
        StartCoroutine(SendInfo(json));

        GameObject.Find("ShowMyInfo").transform.Find("MyInfoCanvas").gameObject.SetActive(true);
        GameObject.Find("CharacterChange").transform.Find("CharacterCanvas").gameObject.SetActive(false);
        GameObject.Find("CharacterChange").transform.Find("ControlCharacters").gameObject.SetActive(false);
      
    }
}
