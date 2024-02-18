using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/
 * https://www.youtube.com/watch?v=AoD_F1fSFFg&ab_channel=SoloGameDev
 * 
 */
public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public List<Item> items = new List<Item>();
    public int space = 12;
    
    private void Awake()
    {
        instance = this;
    }

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory is full");
                return false;
            }

            items.Add(item);

            if (onItemChanged != null)
                onItemChanged.Invoke();
        }
        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChanged != null)
            onItemChanged.Invoke();
    }
}
