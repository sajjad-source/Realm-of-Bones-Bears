using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        //Add to inventory
        bool pickedUp = Inventory.instance.Add(item);

        if (pickedUp)
            Destroy(gameObject);
    }
}
