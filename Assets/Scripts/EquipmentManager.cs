using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    private Dictionary<EquipmentSlot, GameObject> equipmentSlotObjects = new Dictionary<EquipmentSlot, GameObject>();
    public GameObject headSlot;
    public GameObject chestSlot;
    public GameObject legsSlot;
    public GameObject capeSlot;

    private void Awake()
    {
        instance = this;

        equipmentSlotObjects[EquipmentSlot.Head] = headSlot;
        equipmentSlotObjects[EquipmentSlot.Chest] = chestSlot;
        equipmentSlotObjects[EquipmentSlot.Legs] = legsSlot;
        equipmentSlotObjects[EquipmentSlot.Cape] = capeSlot;


    }

    Equipment[] currentEquipment;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIdx = (int)newItem.equipSlot;

        Equipment oldItem = null;
        if (currentEquipment[slotIdx] != null)
        {
            oldItem = currentEquipment[slotIdx];
            Inventory.instance.Add(oldItem);
        }

        if (onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIdx] = newItem;

        if (equipmentSlotObjects.TryGetValue(newItem.equipSlot, out GameObject slotObject))
        {
            if (slotObject != null)
            {
                slotObject.SetActive(true);
            }
        }
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add(oldItem);

            currentEquipment[slotIndex] = null;
            EquipmentSlot slot = (EquipmentSlot)slotIndex;

            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }

            if (equipmentSlotObjects.TryGetValue(slot, out GameObject slotObject))
            {
                if (slotObject != null)
                {
                    slotObject.SetActive(false);
                }
            }
        }
    }
}
