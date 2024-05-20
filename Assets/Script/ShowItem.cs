using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowItem : MonoBehaviour
{
    public List<CollectibleItems> Items; 

    public TextMeshProUGUI TitleItem;
    public TextMeshProUGUI Description;
    public Image ItemImage;

    private int currentIndex = 0;

    void Start()
    {
        if (Items != null && Items.Count > 0)
        {
            ShowCurrentItem();
        }
        else
        {
            Debug.LogError("No se han asignado");
        }
    }

    public void ShowCurrentItem()
    {
        TitleItem.text = Items[currentIndex].ItemName;
        Description.text = Items[currentIndex].ItemDescription;
        ItemImage.sprite = Items[currentIndex].imagenItem;
    }

    public void ShowNextItem()
    {
        if (Items != null && Items.Count > 0)
        {
            currentIndex = (currentIndex + 1) % Items.Count;
            ShowCurrentItem();
        }
    }

    public void ShowPreviousItem()
    {
        if (Items != null && Items.Count > 0)
        {
            currentIndex = (currentIndex - 1 + Items.Count) % Items.Count;
            ShowCurrentItem();
        }
    }
}
