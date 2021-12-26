using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas tutorial;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.enabled = false;
    }

    public void TutorialButtonOnClick()
    {
        tutorial.enabled = true;   
    }

    public void OkButtonOnClick()
    {
        tutorial.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
