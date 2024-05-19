using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMainScreen : MonoBehaviour
{
    public GameObject PanelOptions;
    // Start is called before the first frame update
    void Start()
    {
        PanelOptions.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowOptionsMenu()
    {
        PanelOptions.SetActive(true);
    }

    public void ExitOptionsMenu()
    {
        PanelOptions.SetActive(false);
    }
    


}
