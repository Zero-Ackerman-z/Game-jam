using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogiFullScreen : MonoBehaviour
{

    [SerializeField] private Toggle toggle; 
    // Start is called before the first frame update
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }
    public void ActivateFullScreen(bool FullScreen)
    {
        Screen.fullScreen = FullScreen;
    }
}
