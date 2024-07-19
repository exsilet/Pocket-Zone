using System;
using System.Collections.Generic;
using CodeBase.Hero.Inventory;
using CodeBase.Infrastructure.StaticData.Items;
using CodeBase.UI.Element;
using UnityEngine;

namespace CodeBase.UI.Form
{
    public class ViewInventory : BaseWindow
    {
        [SerializeField] private Transform _itemsParent;

        private Inventory _inventory;
        private List<InventorySlot> _slots = new(); 

        public void Construct(Inventory inventory)
        {
            foreach (InventorySlot slot in _itemsParent.GetComponentsInChildren<InventorySlot>())
            {
                _slots.Add(slot);
            }
            
            _inventory = inventory;
        }

        public void UpdateUI(List<ItemStaticData> items)
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                if (i < items.Count)
                {
                    _slots[i].AddItem(items[i]);
                    Debug.Log("add item");
                }
                else
                {
                    break;
                }
            }
        }
    }
}