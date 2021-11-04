using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MyPageData : MonoBehaviour
{
    private Text myText;

    public class JsonData
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;
    }

    // Start is called before the first frame update
    void Start()
    {
        myText = GameObject.Find("TestText").GetComponent<Text>();
        SetText();
        // Debug.Log(myText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetText()
    {
        StartCoroutine(API_getInfo());

        //IEnumerator Info = API_getInfo();
        //while (Info.MoveNext())
        //{
        //    object result = Info.Current;
        //    Debug.Log("여기" + result);
        // }
    }

    public IEnumerator API_getInfo()
    {
        UnityWebRequest request;
        using (request = UnityWebRequest.Get("https://jsonplaceholder.typicode.com/todos/1"))
        {
            yield return request.SendWebRequest();
            // Debug.Log("여기" + request.downloadHandler.text);
            JsonData fromJson = JsonUtility.FromJson<JsonData>(request.downloadHandler.text);
            myText.text = fromJson.title;
        }

    }
}