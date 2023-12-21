using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    public SerializedDictionary<ItemType, List<Sprite>> itemIcons;
    public SerializedDictionary<Characteristics, Sprite> charIcons;

    [SerializeField] GameObject worldItemPrefab;
    [SerializeField] Transform holder;
    [SerializeField] InventorySystem inventory;

    private void Start() {
        int cnt = Random.Range(0, 60);
        for (int i = 0; i < cnt; i++) {
            SpawnRandomItem();
        }
    }

    private void SpawnRandomItem() {
        Characteristics characteristic = GetRandomEnumValue<Characteristics>();
        ItemType type = GetRandomEnumValue<ItemType>();

        ItemData data = (ItemData)ScriptableObject.CreateInstance(nameof(ItemData));

        data.type = type;
        data.characteristic = characteristic;

        data.characteristicCount = Random.Range(1, 150);

        data.charIcon = charIcons[characteristic];
        data.icon = itemIcons[type][Random.Range(0, itemIcons[type].Count)];



        GameObject uiInstance = Instantiate(worldItemPrefab, Vector3.zero, Quaternion.identity, holder);
        uiInstance.GetComponent<WorldItemManager>().Load(data, inventory);

        RectTransform uiRectTransform = uiInstance.GetComponent<RectTransform>();

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float minX = uiRectTransform.rect.width / 2;
        float maxX = screenWidth - uiRectTransform.rect.width / 2;

        float minY = uiRectTransform.rect.height / 2;
        float maxY = screenHeight - uiRectTransform.rect.height / 2;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        uiRectTransform.anchoredPosition = new Vector2(randomX, randomY);
    }

    T GetRandomEnumValue<T>() {
        System.Array enumValues = System.Enum.GetValues(typeof(T));
        return (T)enumValues.GetValue(Random.Range(0, enumValues.Length));
    }
}
