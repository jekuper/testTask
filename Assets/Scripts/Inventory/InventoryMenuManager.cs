using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] InventorySystem inventory;

    public ItemsSorting type {
        get {
            return _type;
        }
        set {
            _type = value;
            inventory.LoadInventoryGrid(_type, _characteristic);
        }
    }
    public CharsSorting characteristic {
        get {
            return _characteristic;
        }
        set {
            _characteristic = value;
            inventory.LoadInventoryGrid(_type, _characteristic);
        }
    }

    private ItemsSorting _type = ItemsSorting.None;
    private CharsSorting _characteristic = CharsSorting.None;

    public void Open() {
        menu.SetActive(true);
        inventory.LoadInventoryGrid(_type, _characteristic);
    }
    public void Close() {
        menu.SetActive(false);
    }
}
