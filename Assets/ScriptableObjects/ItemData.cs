using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Characteristics {
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
}
public enum ItemType {
    armor,
    arrow,
    boots,
    bow,
    gloves,
    helmet,
    meleeWeapon1H,
    meleeWeapon2H,
    shield,
}

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemData : ScriptableObject, IEquatable<ItemData> {

    public Characteristics characteristic = Characteristics.regen;
    public int characteristicCount = 1;

    public ItemType type = ItemType.armor;

    public Sprite icon = null;
    public Sprite charIcon = null;

    public bool Equals(ItemData other) {
        if (other == null)
            return false;
        return (
            characteristic == other.characteristic &&
            characteristicCount == other.characteristicCount &&
            type == other.type &&
            icon == other.icon &&
            charIcon == other.charIcon
        );
    }
}
