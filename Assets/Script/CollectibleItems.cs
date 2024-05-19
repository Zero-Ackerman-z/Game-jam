using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItem", menuName = "Store/Item", order = 1)]
public class CollectibleItems : ScriptableObject
{
    public string ItemName;
    [TextArea(3, 10)]
    public string ItemDescription;
    public Sprite imagenItem;
}
