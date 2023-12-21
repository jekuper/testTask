using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WorldItemManager : MonoBehaviour, IPointerClickHandler {
    public ItemData data;

    [SerializeField] InventorySystem inventory;

    public void Load(ItemData _data, InventorySystem _sys) {
        data = _data;
        inventory = _sys;
        GetComponent<Image>().sprite = data.icon;
    }

    public void OnPointerClick(PointerEventData eventData) {
        inventory.AddItem(data);
        Destroy(gameObject);
    }
}
