using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PanelOptions;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
