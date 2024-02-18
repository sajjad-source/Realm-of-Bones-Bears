using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem;

    public virtual void Use()
    {
        // Use item

        Debug.Log("Using" + itemName);
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
