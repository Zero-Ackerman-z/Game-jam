using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ImageSequence : MonoBehaviour
{
    public GameObject Panel;
    public Image imagePrefab; 
    public Sprite[] Images; 
    public float Interval = 1f; 
    private int IndexPosition = 0;

    void Start()
    {
        if (Images.Length > 0)
        {
            StartCoroutine(ShowImages());
        }
        else
        {
            Debug.LogError("No se han asignado imágenes");
        }
    }

    IEnumerator ShowImages()
    {
        while (IndexPosition < Images.Length)
        {
            Image nuevaImagen = Instantiate(imagePrefab, Panel.transform);
            nuevaImagen.sprite = Images[IndexPosition];
            RectTransform rectTransform = nuevaImagen.GetComponent<RectTransform>();
            Vector2 posicion = GetPosition(IndexPosition, Panel.GetComponent<RectTransform>().rect);
            rectTransform.anchoredPosition = posicion;
            yield return new WaitForSeconds(Interval);

            IndexPosition++;
        }
        Panel.SetActive(false);
    }
    Vector2 GetPosition(int indice, Rect rect)
    {
        switch (indice)
        {
            case 0:
                return new Vector2(-rect.width / 2 + 90, rect.height / 2 - 90); // Top-left
            case 1:
                return new Vector2(0, rect.height / 2 - 90); // Top-center
            case 2:
                return new Vector2(rect.width / 2 - 90, rect.height / 2 - 90); // Top-right
            case 3:
                return new Vector2(-rect.width / 2 + 90, -rect.height / 2 + 80); // Bottom-left
            case 4:
                return new Vector2(0, -rect.height / 2 + 80); // Bottom-center
            case 5:
                return new Vector2(rect.width / 2 - 80, -rect.height / 2 + 80); // Bottom-right
            case 6:
                return new Vector2(-rect.width / 2 + 90, 0); // Left-center
            default:
                return Vector2.zero; 

        }
    }
}
