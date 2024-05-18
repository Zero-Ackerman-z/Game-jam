using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Pantalla de Carga");
    }
    public void ContinueGame()
    {

    }
    public void ShowOptions()
    {
        UIManager.Instance.ShowOptionsMenu();
    }
    public void ExitOptions()
    {
        UIManager.Instance.ExitOptionsMenu();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Creditos");

    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego.");
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }
}

