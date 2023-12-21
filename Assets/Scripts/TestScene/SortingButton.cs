using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SortingButton : MonoBehaviour, IPointerClickHandler {
    [SerializeField] ItemsSorting type = ItemsSorting.None;
    [SerializeField] CharsSorting characteristic = CharsSorting.None;
    public void OnPointerClick(PointerEventData eventData) {
        if (type == ItemsSorting.None && characteristic != CharsSorting.None) {
            InventoryMenuManager.instance.characteristic = characteristic;
        }
        else if (type != ItemsSorting.None && characteristic == CharsSorting.None) {
            InventoryMenuManager.instance.type = type;
        }
        else {
            InventoryMenuManager.instance.type = type;
            InventoryMenuManager.instance.characteristic = characteristic;
        }
    }
}
