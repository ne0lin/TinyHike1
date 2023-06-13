using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass 
{
    private ItemClass item;
    private int quantity;

    public SlotClass (ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem() { return item; }
    public int GetQuantity() { return quantity; }
}
