using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImage : MonoBehaviour
{
    public GameObject imageObj;
    private Image myCharacter;
    
    // Start is called before the first frame update
    void Start()
    {
        myCharacter = imageObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
