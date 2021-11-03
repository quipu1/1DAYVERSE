using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPick : MonoBehaviour
{
    string onScreen = "start";
    // Start is called before the first frame update
    void Start()
    {
      
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


    private void OnMouseDown()
    {
        
    }
}
