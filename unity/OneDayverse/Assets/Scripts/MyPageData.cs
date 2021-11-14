using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using TMPro;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.UI;

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

    private Dictionary<int, Sprite> characterDic = new Dictionary<int, Sprite>();
    public Image profileImage;

    [SerializeField]
    private Sprite character1;
    [SerializeField]
    private Sprite character2;
    [SerializeField]
    private Sprite character3;
    [SerializeField]
    private Sprite character4;
    [SerializeField]
    private Sprite character5;



    [DllImport("__Internal")]
    private static extern string GetUsername();


    public class Profile
    {
        public string id;
        public string username;
        public string birth_day;
        public string phone_number;
        public int character;
        public string profile_image;
        public string teachable;
    }

    public class JsonData
    {
        public Profile profile;
        public Lectures lectures;
        public string character;
    }

    public class Lectures
    {
        public List<Lecture> lectureList;
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
        characterDic[1] = character1;
        characterDic[2] = character2;
        characterDic[3] = character3;
        characterDic[4] = character4;
        characterDic[5] = character5;

        username = GameObject.Find("name").GetComponent<TMPro.TextMeshProUGUI>();
        birth_day = GameObject.Find("birthday").GetComponent<TMPro.TextMeshProUGUI>();
        phone_number = GameObject.Find("phonenumber").GetComponent<TMPro.TextMeshProUGUI>();
        lecture_name = GameObject.Find("lecturename").GetComponent<TMPro.TextMeshProUGUI>();
        lecture_tutor = GameObject.Find("lecturetutor").GetComponent<TMPro.TextMeshProUGUI>();
        lecture_password = GameObject.Find("lecturepassword").GetComponent<TMPro.TextMeshProUGUI>();

        currentUsername = GetUsername();
        StartCoroutine(GetUserInfo());     
        //StartCoroutine(GetLectureInfo());
    }

  
    public IEnumerator GetUserInfo()
    {
        UnityWebRequest userInforequest;
        using (userInforequest = UnityWebRequest.Get("https://k5c202.p.ssafy.io/od/unitys/profile/"+ currentUsername + "/"))
        {
            yield return userInforequest.SendWebRequest();

            Profile profileJson = JsonUtility.FromJson<Profile>(userInforequest.downloadHandler.text);
            username.text = profileJson.username;
            birth_day.text = profileJson.birth_day;
            phone_number.text = profileJson.phone_number;

            profileImage = GameObject.Find("CharacterImage").GetComponent<Image>();
            profileImage.sprite = characterDic[profileJson.character];
        }

    }

    public IEnumerator GetLectureInfo()
    {
        UnityWebRequest lectureInforequest;
        using (lectureInforequest = UnityWebRequest.Get("https://k5c202.p.ssafy.io/od/accounts/profile/" + "oxoxo" + "/"))
        {
            yield return lectureInforequest.SendWebRequest();
            var response = lectureInforequest.downloadHandler.text;
            JsonData userInfo = JsonUtility.FromJson<JsonData>(response);
            
            Debug.Log(userInfo);                

            //lecture_tutor.text = fromJson[0].name;
            //lecture_password.text = fromJson[0].password;


        }

    }
}