using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class MyPageData : MonoBehaviour
{
    private TextMeshProUGUI userName;
    private TextMeshProUGUI userBirthday;
    private TextMeshProUGUI phoneNumber;
    private TextMeshProUGUI lectureName;
    private TextMeshProUGUI lecturePassword;


    public class JsonData
    {
        public string userName;
        public string userBirthday;
        public string phoneNumber;
        public string lectureName;
        public string lecturePassword;
    }

    // Start is called before the first frame update
    void Start()
    {
        userName = GameObject.Find("name").GetComponent<TMPro.TextMeshProUGUI>();
        SetText();
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
            userName.text = fromJson.userName;
        }

    }
}