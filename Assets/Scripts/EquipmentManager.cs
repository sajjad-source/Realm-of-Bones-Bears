using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

/*
 * https://pavcreations.com/equipment-system-for-an-rpg-unity-game/
 */
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
    public GameObject axeSlot;
    public GameObject keySlot;

    public GameObject fish;
    public GameObject enemy;

    private void Awake()
    {
        instance = this;

        equipmentSlotObjects[EquipmentSlot.Head] = headSlot;
        equipmentSlotObjects[EquipmentSlot.Chest] = chestSlot;
        equipmentSlotObjects[EquipmentSlot.Legs] = legsSlot;
        equipmentSlotObjects[EquipmentSlot.Cape] = capeSlot;
        equipmentSlotObjects[EquipmentSlot.Weapon] = axeSlot;
        equipmentSlotObjects[EquipmentSlot.Key] = keySlot;

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

        currentEquipment[slotIdx] = newItem;

        if (newItem.equipSlot == EquipmentSlot.Food)
        {
            enemy.GetComponentInChildren<Animator>().SetBool("Eat", true);
            enemy.GetComponentInChildren<Bear>().attackRange = 0f;
            enemy.GetComponentInChildren<Bear>().lookRadius = 0f;
            fish.SetActive(true);
            Debug.Log("Using Food");
          
        }
        else if (equipmentSlotObjects.TryGetValue(newItem.equipSlot, out GameObject slotObject))
        {
            if (slotObject != null)
            {
                slotObject.SetActive(true);
            }
        }
    }

    public void Unequip(int slotIndex)
    {
        currentEquipment[slotIndex] = null;
        EquipmentSlot slot = (EquipmentSlot)slotIndex;

        if (equipmentSlotObjects.TryGetValue(slot, out GameObject slotObject))
        {
            if (slotObject != null)
            {
                slotObject.SetActive(false);
            }
        }
    }
}
