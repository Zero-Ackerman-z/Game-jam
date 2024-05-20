using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private float minWaitTime = 1.5f;
    [SerializeField] private float maxWaitTime = 3.5f;

    private bool isFirstLoad = true;

    private void Start()
    {
        StartCoroutine(LoadSceneWithSpinner());

    }

    private IEnumerator LoadSceneWithSpinner()
    {

        while (true)
        {
            Debug.Log("Iniciando pantalla de carga...");

            float waitTime = isFirstLoad ? 0f : Random.Range(minWaitTime, maxWaitTime);
            isFirstLoad = false;

            Debug.Log("Carga iniciada. Esperando " + waitTime + " segundos...");
            yield return new WaitForSeconds(waitTime);

            Debug.Log("Tiempo de espera completado. Cargando escena...");
            SceneManager.LoadScene("Game");
            AudioManager.Instance.PauseMusic();
            AudioManager.Instance.PlayMusicByIndex(1);
            yield return new WaitForSeconds(3f); 
        }

    }
    
}


