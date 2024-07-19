using CodeBase.Infrastructure.AssetManagement;
using CodeBase.UI.Element;
using CodeBase.UI.Service.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IWindowService _windowService;

        public GameFactory(IAssetProvider assets, IWindowService windowService)
        {
            _assets = assets;
            _windowService = windowService;
        }

        public GameObject CreateHero(GameObject at)
        {
            var hero = _assets.Instantiate(path: AssetPath.HeroPath, at: at.transform.position);

            return hero;
        }

        public GameObject CreateHud()
        {
            var hud = _assets.Instantiate(AssetPath.HudPath);
            
            foreach (OpenWindowButton windowButton in hud.GetComponentsInChildren<OpenWindowButton>())
                windowButton.Construct(_windowService);
            
            return hud;
        }
    }
}