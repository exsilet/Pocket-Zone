using CodeBase.Infrastructure.StaticData.Items;
using CodeBase.UI.Element;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Form
{
    public class ViewObject : BaseWindow
    {
        [SerializeField] private TMP_Text _textTitle;
        [SerializeField] private TMP_Text _textHeadline;
        [SerializeField] private Image _imageIcon;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private ViewObject _panel;
        [SerializeField] private GameObject _itemView;

        private ItemStaticData _data;
        private InventorySlot _inventorySlot;

        public void OpenPanel(ItemStaticData item)
        {
            _panel.gameObject.SetActive(true);
            _itemView.SetActive(true);
            Show(item);
        }

        public void ClosePanel()
        {
            _panel.gameObject.SetActive(false);
        }

        public void RemoveItem()
        {
            _inventorySlot.OnRemoveButton();
        }

        private void Show(ItemStaticData data)
        {
            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                _textTitle.text = data.NameRus;
                _textHeadline.text = data.NameRus;
                _descriptionText.text = data.DescriptionRus;
            }
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                _textTitle.text = data.NameEng;
                _textHeadline.text = data.NameEng;
                _descriptionText.text = data.DescriptionEng;
            }

            _imageIcon.sprite = data.UIIcon;
        }
    }
}