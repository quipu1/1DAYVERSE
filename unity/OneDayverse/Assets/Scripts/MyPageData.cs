using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using TMPro;
using System.Runtime.InteropServices;
using System.Text;

public class MyPageData : MonoBehaviour
{
    private TextMeshProUGUI username;
    private TextMeshProUGUI birth_day;
    private TextMeshProUGUI phone_number;
    private TextMeshProUGUI character;
    private TextMeshProUGUI lecture_name;
    private TextMeshProUGUI lecture_tutor;
    private TextMeshProUGUI lecture_password;
    private string currentUsername;

    [DllImport("__Internal")]
    private static extern string GetUsername();


    public class JsonData
    {
        public string username;
        public string birth_day;
        public string phone_number;
        public string character;
    }

    public class JsonData2
    {
        public List<Lecture> lectures;
    }

    public class Lecture
    {
        public string id;
        public string name;
        public string title;
        public string description;       
        public string password;
        public string validation;
    }


    // Start is called before the first frame update
    void Start()
    {
        username = GameObject.Find("name").GetComponent<TMPro.TextMeshProUGUI>();
        birth_day = GameObject.Find("birthday").GetComponent<TMPro.TextMeshProUGUI>();
        phone_number = GameObject.Find("phonenumber").GetComponent<TMPro.TextMeshProUGUI>();
        lecture_name = GameObject.Find("lecturename").GetComponent<TMPro.TextMeshProUGUI>();
        lecture_tutor = GameObject.Find("lecturetutor").GetComponent<TMPro.TextMeshProUGUI>();
        lecture_password = GameObject.Find("lecturepassword").GetComponent<TMPro.TextMeshProUGUI>();

        //currentUsername = GetUsername();
        //StartCoroutine(GetUserInfo());     
        StartCoroutine(GetLectureInfo());
    }

  
    public IEnumerator GetUserInfo()
    {
        UnityWebRequest userInforequest;
        using (userInforequest = UnityWebRequest.Get("https://k5c202.p.ssafy.io/od/unitys/profile/"+ currentUsername + "/"))
        {
            yield return userInforequest.SendWebRequest();
           
            JsonData fromJson = JsonUtility.FromJson<JsonData>(userInforequest.downloadHandler.text);
            username.text = fromJson.username;
            birth_day.text = fromJson.birth_day;
            phone_number.text = fromJson.phone_number;

        }

    }

    public IEnumerator GetLectureInfo()
    {
        UnityWebRequest lectureInforequest;
        using (lectureInforequest = UnityWebRequest.Get("https://k5c202.p.ssafy.io/od/unitys/lecture/" + "oxoxo" + "/"))
        {
            yield return lectureInforequest.SendWebRequest();
            var response = lectureInforequest.downloadHandler.text;
            Debug.Log(response);
        
            

            //lecture_tutor.text = fromJson[0].name;
            //lecture_password.text = fromJson[0].password;


        }

    }
}