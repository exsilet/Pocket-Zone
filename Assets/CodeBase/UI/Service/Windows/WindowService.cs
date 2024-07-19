﻿using CodeBase.UI.Service.Factory;
using UnityEngine;

namespace CodeBase.UI.Service.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(WindowId windowID)
        {
            switch (windowID)
            {
                case WindowId.Unknown:
                    break;
                case WindowId.Inventory:
                    EnableWindow(_uiFactory.ViewInventory.gameObject);
                    break;
                case WindowId.ViewObject:
                    EnableWindow(_uiFactory.View.gameObject);
                    break;
                    
            }
        }

        private void EnableWindow(GameObject window)
        {
            window.SetActive(true);
        }
    }
}