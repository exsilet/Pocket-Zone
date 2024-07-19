using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData.Items;
using CodeBase.UI.Form;
using UnityEngine;

namespace CodeBase.Hero.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private int _space;
        private List<ItemStaticData> _items = new List<ItemStaticData>();

        private ViewInventory _viewInventory;
        
        public void Construct(ViewInventory viewInventory, int countSlotLength)
        {
            _viewInventory = viewInventory;
            _space = countSlotLength;
        }
        
        public bool Add(ItemStaticData item)
        {
            if (!item.isDefaultItem)
            {
                if (_items.Count >= _space)
                {
                    Debug.Log("Not enough room.");
                    return false;
                }

                _items.Add(item);
                _viewInventory.UpdateUI(_items);
            }

            return true;
        }
        
        public void Remove (ItemStaticData item)
        {
            _items.Remove(item);
        }
    }
}