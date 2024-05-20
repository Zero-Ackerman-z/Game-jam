using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject PanelPause;
    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject PanelGamerOver;
    [SerializeField] private GameObject PanelItems;
    [SerializeField] private GameManager gameManager;

    public float Speed; 
    
    // Start is called before the first frame update
    void Start()
    {
        PanelPause.SetActive(false);
        ResultPanel.SetActive(false);
        PanelGamerOver.SetActive(false);
        PanelItems.SetActive(false);
        Vector3 InitialPosition = PanelPause.transform.position;
        InitialPosition.y += Screen.height; 
        PanelPause.transform.position = InitialPosition;
    }
    IEnumerator ShowPanel()
    {
        PanelPause.SetActive(true);
        Vector3 FinalPosition = new Vector3(PanelPause.transform.position.x, 80f, PanelPause.transform.position.z);
        while (PanelPause.transform.position.y > 80f)
        {
            PanelPause.transform.position = Vector3.MoveTowards(PanelPause.transform.position, FinalPosition, Speed * Time.deltaTime);
            yield return null;
        }
        gameManager.PauseGame();

    }
    IEnumerator HidePanel()
    {
        Vector3 posicionFinal = new Vector3(PanelPause.transform.position.x, Screen.height + 50, PanelPause.transform.position.z);

        while (PanelPause.transform.position.y < Screen.height + 50)
        {
            PanelPause.transform.position = Vector3.MoveTowards(PanelPause.transform.position, posicionFinal, Speed * Time.deltaTime);
            yield return null;
        }
        PanelPause.SetActive(false);
    }
    public void ShowPause()
    {
        StartCoroutine(ShowPanel());
    }
    public void ReturnGame()
    {
        StartCoroutine(HidePanel());
        gameManager.ResumeGame();
    }
    public void ResulPanel()
    {
        ResultPanel.SetActive(true);
    }
    public void ShowCollectiblePanel()
    {
        PanelItems.SetActive(true);
    }
    public void HideCollectiblePanel()
    {
        PanelItems.SetActive(false);
    }
    public void GameOverPanel()
    {
        PanelGamerOver.SetActive(true);
    }

}
