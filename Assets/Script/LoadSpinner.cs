using System.Collections;
using UnityEngine;

public class LoadSpinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if (transform.eulerAngles.z >= 360f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }
        transform.rotation = Quaternion.identity; 

    }


}
