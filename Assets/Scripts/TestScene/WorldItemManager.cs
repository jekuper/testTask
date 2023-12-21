using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WorldItemManager : MonoBehaviour, IPointerClickHandler {
    public ItemData data;

    public void Load(ItemData _data) {
        data = _data;
        GetComponent<Image>().sprite = data.icon;
    }

    public void OnPointerClick(PointerEventData eventData) {
        InventoryMenuManager.instance.AddItem(data);
        Destroy(gameObject);
    }
}
