using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemsSorting {
    armor,
    meleeWeapons,
    rangeWeapons,
    None,
}

public enum CharsSorting {
    regen,
    health,
    slowness,
    bounty,
    wodoo,
    coldness,
    electrification,
    poisoness,
    fire,
    wings,
    sleepiness,

    None,
}

public class InventorySystem : MonoBehaviour {
    public List<InventoryCellData> inventory = new List<InventoryCellData>();

    [SerializeField] Transform scrollViewContent;
    [SerializeField] GameObject cellPrefab;
    [SerializeField] HorizontalGridManager grid;

    private List<GameObject> cells = new List<GameObject>();

    private int firstInactive = 0;

    public static InventorySystem instance;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void LoadInventoryGrid(ItemsSorting itemsSorting = ItemsSorting.None, CharsSorting charSorting = CharsSorting.None) {
        int requiredCellCount = grid.FullCellCount();

        foreach (var cell in cells) {
            cell.GetComponent<CellManager>().Unload();
        }

        int i = 0;
        foreach (InventoryCellData cellData in inventory) {
            if (!CheckItemType(cellData, itemsSorting) || !CheckCharType(cellData, charSorting)) {
                continue;
            }

            GameObject cell;
            if (i < cells.Count) {
                cell = cells[i];
                cell.SetActive(true);
            }
            else {
                cell = CreateEmpty();
            }
            i++;

            LoadCell(cell, cellData);
        }

        firstInactive = i;
        while(i < cells.Count) {
            cells[i].SetActive(false);
            i++;
        }

        for (i = firstInactive; i < requiredCellCount; i++) {
            CreateEmpty();
        }

        while (firstInactive % grid.constraint != 0) {
            CreateEmpty();
        }
    }

    public void AddItem(ItemData item) {
        InventoryCellData data = new InventoryCellData(item);

        bool found = false;
        foreach (InventoryCellData objData in inventory) {
            if (objData.Equals(data)) {
                objData.count++;
                found = true;
                break;
            }
        }

        if (!found)
            inventory.Add(data);
    }
    public void RemoveItem(InventoryCellData item) {
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].Equals(item)) {
                inventory.RemoveAt(i);
                break;
            }
        }
    }
    private void LoadCell(GameObject cell, InventoryCellData cellData) {
        if (cell.TryGetComponent<CellManager>(out CellManager manager)) {
            manager.Load(cellData);
        }
        else {
            Debug.LogError("Cell missing CellManager component");
        }
    }

    private GameObject CreateEmpty() {
        GameObject cell;
        if (firstInactive >= cells.Count) {
            cell = Instantiate(cellPrefab, scrollViewContent);
            cells.Add(cell);
            firstInactive++;
        }
        else {
            cells[firstInactive].SetActive(true);
            cell = cells[firstInactive];

            while (firstInactive < cells.Count && cells[firstInactive].activeSelf)
                firstInactive++;
        }
        return cell;

    }

    private bool CheckItemType(InventoryCellData item, ItemsSorting itemsSorting) {
        if (itemsSorting == ItemsSorting.None)
            return true;

        switch (item.item.type) {
            case ItemType.armor:
            case ItemType.boots:
            case ItemType.gloves:
            case ItemType.helmet:
                return itemsSorting == ItemsSorting.armor;
            case ItemType.arrow:
            case ItemType.bow:
                return itemsSorting == ItemsSorting.rangeWeapons;
            case ItemType.meleeWeapon1H:
            case ItemType.meleeWeapon2H:
            case ItemType.shield:
                return itemsSorting == ItemsSorting.meleeWeapons;
            default:
                break;
        }

        return false;
    }
    private bool CheckCharType(InventoryCellData item, CharsSorting charsSorting) {
        if (charsSorting == CharsSorting.None)
            return true;

        return charsSorting.ToString() == item.item.characteristic.ToString();
    }
}
