using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellManager : MonoBehaviour
{
    public InventoryCellData data {
        get {
            return _data;
        }
    }
    public bool isLoaded = false;

    private InventoryCellData _data;

    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI charCountText;

    [SerializeField] Image itemImage;
    [SerializeField] Image charImage;

    public void Load(InventoryCellData newData = null) {
        if (newData == null)
            newData = data;

        isLoaded = true;

        countText.gameObject.SetActive(true);
        charCountText.gameObject.SetActive(true);
        itemImage.gameObject.SetActive(true);
        charImage.gameObject.SetActive(true);

        countText.text = "x" + newData.count.ToString();

        if (newData.item.characteristicCount > 0)
            charCountText.text = "+" + newData.item.characteristicCount.ToString();
        else
            charCountText.text = "-" + newData.item.characteristicCount.ToString();

        itemImage.sprite = newData.item.icon;
        charImage.sprite = newData.item.charIcon;
    }
    public void Unload() {
        isLoaded = false;

        countText.gameObject.SetActive(false);
        itemImage.gameObject.SetActive(false);
        charImage.gameObject.SetActive(false);
        charCountText.gameObject.SetActive(false);

        _data = null;
    }
}
