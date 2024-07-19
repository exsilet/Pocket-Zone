using CodeBase.Hero.Inventory;
using CodeBase.UI.Form;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "StaticData/Item")]
    public class ItemStaticData : ScriptableObject
    {
        public string NameRus;
        public string NameEng;
        public int Count;
        public int MaxCount;
        public string DescriptionRus;
        public string DescriptionEng;
        public bool isDefaultItem = false;
        
        public Sprite UIIcon;
        public GameObject Prefab;
        public ItemTypeID ItemTypeID;

        public bool Stack()
        {
            if (MaxCount > 1)
                return true;

            return false;
        }
        
        // public void RemoveFromInventory()
        // {
        //     Inventory.Remove(this);
        // }
        
        public virtual void Use(ViewObject viewObject, ItemStaticData itemStaticData)
        {
            viewObject.OpenPanel(itemStaticData);

            Debug.Log("Using " + name);
        }
    }
}