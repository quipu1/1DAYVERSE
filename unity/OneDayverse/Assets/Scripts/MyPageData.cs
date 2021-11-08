using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.Xml;

public class MyPageData : MonoBehaviour
{
    private TextMeshProUGUI username;
    private TextMeshProUGUI birth_day;
    private TextMeshProUGUI phone_number;
    private TextMeshProUGUI character;
    private TextMeshProUGUI lecturePassword;


    public class JsonData
    {
        public string title;
        public string id;
        public string phone_number;
        public string character;
        public string lecturePassword;
    }

    // Start is called before the first frame update
    void Start()
    {
        username = GameObject.Find("name").GetComponent<TMPro.TextMeshProUGUI>();
        birth_day = GameObject.Find("birthday").GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(GetInfo());
     
    }

  
    public IEnumerator GetInfo()
    {
        UnityWebRequest request;
        using (request = UnityWebRequest.Get("https://jsonplaceholder.typicode.com/todos/1"))
        {
            yield return request.SendWebRequest();
            Debug.Log("¿©±â" + request.downloadHandler.text);
           
            JsonData fromJson = JsonUtility.FromJson<JsonData>(request.downloadHandler.text);
            Debug.Log(fromJson.title);
            
        }

    }
}