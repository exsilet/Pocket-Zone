using CodeBase.Hero.Inventory;
using CodeBase.Infrastructure.StaticData.Items;
using UnityEngine;

namespace CodeBase.Items
{
    public class ItemPickUp : MonoBehaviour
    {
        [SerializeField] private ItemStaticData _item;

        private ItemTypeID _typeID;
        private int _count;

        private void Start()
        {
            _typeID = _item.ItemTypeID;
            _count = _item.Count;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Inventory bag))
            {
                switch (_typeID)
                {
                    case ItemTypeID.Fruits:
                        PickUp(bag);
                        break;
                    case ItemTypeID.Thing:
                        PickUp(bag);
                        break;
                    case ItemTypeID.SpareParts:
                        PickUp(bag);
                        break;
                    case ItemTypeID.Weapon:
                        PickUp(bag);
                        break;
                    case ItemTypeID.Cartridges:
                        PickUp(bag);
                        break;
                }
            }
        }

        private void PickUp(Inventory inventory)
        {
            bool wasPickedUp = inventory.Add(_item);

            if (wasPickedUp)
                Destroy(gameObject);
        }
    }
}