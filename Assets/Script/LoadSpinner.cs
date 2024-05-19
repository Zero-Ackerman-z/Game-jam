using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSpinner : MonoBehaviour
{
    [SerializeField] private float RotationSpeed; 
    private float TimeWaitMinimum = 1.5f; 
    private float TimeWaitMaximum = 3.5f; 

    private float TimeElapsed = 0f;
    [SerializeField]private string SceneName; 

    void Update()
    {
        transform.Rotate(0f, 0f, RotationSpeed * Time.deltaTime);
        if (transform.eulerAngles.z >= 360f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0f);
        }
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= TimeWaitMinimum
)
        {
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(Random.Range(TimeWaitMinimum, TimeWaitMaximum));
        SwitchToSceneNext();
    }
    void SwitchToSceneNext()
    {
        SceneManager.LoadScene(SceneName);
    }
}
