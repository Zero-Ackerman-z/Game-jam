using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    [SerializeField] private UIManagerMainScreen mainScreen;
    public void NewGame()
    {
        SceneManager.LoadScene("Pantalla de Carga");
    }
    public void ContinueGame()
    {

    }
    public void ShowOptions()
    {
        mainScreen.ShowOptionsMenu();
    }
    public void ExitOptions()
    {
        mainScreen.ExitOptionsMenu();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Creditos");

    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego.");
        Application.Quit();
    }
}
