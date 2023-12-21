using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryCellData : IEquatable<InventoryCellData> {
    public ItemData item;

    public int count = 1;

    public InventoryCellData(ItemData _item, int itemCount = 1) {
        item = _item;
        count = itemCount;
    }

    public bool Equals(InventoryCellData other) {
        if (other == null)
            return false;

        return item.Equals(other.item);
    }
}
