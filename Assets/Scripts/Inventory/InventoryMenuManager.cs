using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] InventorySystem inventory;

    public static InventoryMenuManager instance;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public ItemsSorting type {
        get {
            return _type;
        }
        set {
            _type = value;
            ReloadInventory();
        }
    }
    public CharsSorting characteristic {
        get {
            return _characteristic;
        }
        set {
            _characteristic = value;
            ReloadInventory();
        }
    }

    private ItemsSorting _type = ItemsSorting.None;
    private CharsSorting _characteristic = CharsSorting.None;

    public void Open() {
        menu.SetActive(true);
        ReloadInventory();
    }
    public void Close() {
        menu.SetActive(false);
    }

    public void AddItem(ItemData item) {
        inventory.AddItem(item);
        ReloadInventory();
    }
    public void RemoveItem(InventoryCellData item) {
        inventory.RemoveItem(item);
        ReloadInventory();
    }

    public void ReloadInventory() {
        inventory.LoadInventoryGrid(_type, _characteristic);
    }
}
