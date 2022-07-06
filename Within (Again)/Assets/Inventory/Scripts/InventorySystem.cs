using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData refrenceData)
    {
        if(m_itemDictionary.TryGetValue(refrenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData refrenceData)
    {
        if(m_itemDictionary.TryGetValue(refrenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(refrenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refrenceData, newItem);
        }
    }

    public void Remove(InventoryItemData refrenceData)
    {
        if(m_itemDictionary.TryGetValue(refrenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(refrenceData);
            }
        }
    }
}

public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set;}
    
    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}