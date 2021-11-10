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
    public string currentUsername1;
    public string currentUsername2;


    public class JsonData
    {
        public string username;
        public string birth_day;
        public string phone_number;
        public string character;
 
    }

    // Start is called before the first frame update
    void Start()
    {
        username = GameObject.Find("name").GetComponent<TMPro.TextMeshProUGUI>();
        birth_day = GameObject.Find("birthday").GetComponent<TMPro.TextMeshProUGUI>();
        phone_number = GameObject.Find("phonenumber").GetComponent<TMPro.TextMeshProUGUI>();
        //currentUsername1 = GetUserData.currentUsername;
        currentUsername2 = gameObject.GetComponent<GetUserData>().currentUsername;
        StartCoroutine(GetInfo());     
        
    }

  
    public IEnumerator GetInfo()
    {
        UnityWebRequest request;
        using (request = UnityWebRequest.Get("https://k5c202.p.ssafy.io/od/unitys/profile/" + currentUsername2 + "/"))
        {
            yield return request.SendWebRequest();
            Debug.Log("¿©±â" + request.downloadHandler.text);
           
            JsonData fromJson = JsonUtility.FromJson<JsonData>(request.downloadHandler.text);
            username.text = fromJson.username;
            birth_day.text = fromJson.birth_day;
            phone_number.text = fromJson.phone_number;

        }

    }
}