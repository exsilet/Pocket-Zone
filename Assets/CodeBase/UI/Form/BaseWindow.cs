using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Form
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public Button CloseButton;

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            CloseButton.onClick.AddListener(ClosePanel);
        }

        private void ClosePanel()
        {
            if (gameObject.GetComponent<ViewInventory>() != null)
            {
                //gameObject.GetComponent<ViewInventory>().Inactive();
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }

        }
    }
}