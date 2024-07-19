using CodeBase.Hero.Inventory;
using CodeBase.Infrastructure.StaticData.Items;
using CodeBase.UI.Form;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Button _button;

        private ItemStaticData _item;
        private ViewObject _viewObject;
        private Inventory _inventory;

        public void Construct(Inventory inventory, ViewObject viewObject)
        {
            _inventory = inventory;
            _viewObject = viewObject;
        }

        public void UseItem()
        {
            if (_item != null)
            {
                _item.Use(_viewObject, _item);
            }
        }

        public void AddItem(ItemStaticData newItem)
        {
            _item = newItem;

            _icon.enabled = true;
            _button.gameObject.SetActive(true);
            _icon.sprite = _item.UIIcon;
            _countText.text = _item.Count.ToString();

            _countText.gameObject.SetActive(_item.Count > 1);
        }

        public void OnRemoveButton()
        {
            ClearSlot();
            _inventory.Remove(_item);
        }

        public void ClearSlot()
        {
            _item = null;

            _icon.enabled = false;
            _button.gameObject.SetActive(false);
            _countText.gameObject.SetActive(false);
            _icon.sprite = null;
            _countText.text = null;
        }
    }
}