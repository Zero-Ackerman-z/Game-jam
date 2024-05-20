using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void ExitMainScreen()
    {
        SceneManager.LoadScene("Pantalla Principal");
    }
    public void Continue()
    {
        uIManager.ReturnGame();
    }
    public void CollectibleGameOpen()
    {
        uIManager.ShowCollectiblePanel();
    }
    public void CollectibleGameClose()
    {
        uIManager.HideCollectiblePanel();
    }

    

}

