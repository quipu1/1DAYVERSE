using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CateEnterCategoryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "Category1")
                {
                    SceneManager.LoadScene("CateExercise");
                } else if (hit.transform.gameObject.name == "Category2")
                {
                    SceneManager.LoadScene("CateHobby");
                }
                else if (hit.transform.gameObject.name == "Category3")
                {
                    SceneManager.LoadScene("CateLanguage");
                }               

            }
        }
    }
}
