using CodeBase.Infrastructure.AssetManagement;
using CodeBase.UI.Form;
using UnityEngine;

namespace CodeBase.UI.Service.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private Transform _uiRoot;
        private ViewInventory _viewInventory;
        private ViewObject _view;

        public UIFactory(IAssetProvider assets) => _assets = assets;
        public ViewInventory ViewInventory => _viewInventory; 
        public ViewObject View => _view;

        public GameObject CreateUIRoot()
        {
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
            _viewInventory = GetInventory();
            _view = GetViewObjects();

            return _uiRoot.gameObject;
        }

        private ViewInventory GetInventory()
        {
            ViewInventory viewInventory = _uiRoot.gameObject.GetComponentInChildren<ViewInventory>();
            viewInventory.gameObject.SetActive(false);
            return viewInventory;
        }
        
        private ViewObject GetViewObjects()
        {
            ViewObject view = _uiRoot.gameObject.GetComponentInChildren<ViewObject>();
            view.gameObject.SetActive(false);
            return view;
        }
    }
}